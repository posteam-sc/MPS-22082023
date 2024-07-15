using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS
{
    public partial class frmLogin : Form
    {
        MBMSEntities mbsEntities = new MBMSEntities();
        ToolTip tooltip = new ToolTip();
        int attempt = 1;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void InitialState()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";
           
            //Validation
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                tooltip.SetToolTip(txtUserName, "Error");
                tooltip.Show("Please fill up User name!", txtUserName);
                txtUserName.Focus();
                hasError = true;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                tooltip.SetToolTip(txtPassword, "Error");
                tooltip.Show("Please fill up Password!", txtPassword);
                txtPassword.Focus();
                hasError = true;
            }
            if (!hasError)
            {
                User user = new User();
                user = (from u in mbsEntities.Users where u.UserName == txtUserName.Text && u.Active == true select u).FirstOrDefault<User>();
               
               
                if (user != null)
                {
                    string correctPassWord = Utility.DecryptString(user.Password, "scadmin@123");
                    if (correctPassWord.Equals(txtPassword.Text))
                    {
                        string UserID = user.UserID;
                        string UserName = user.UserName;
                        string position = user.Role.RoleName;
                        this.Hide();
                        MainMDI mainForm = new MainMDI();
                        Role r = mbsEntities.Roles.Where(x => x.Active == true && x.RoleID == user.RoleID).SingleOrDefault();
                        mainForm.role = r;
                        mainForm.UserID = UserID;
                        mainForm.UserName = UserName;
                        mainForm.position = position;
                        LogData logData = new LogData();
                        logData.UserName = UserName;
                        logData.Position = user.Role.RoleName;
                        logData.Status = "Login";
                        logData.Datetime = DateTime.Now;
                        mbsEntities.LogDatas.Add(logData);
                        mbsEntities.SaveChanges();
                        var result = mainForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            this.Show();
                            InitialState();
                        }
                        else if (result == DialogResult.Yes)
                        {
                            Application.Exit();
                        }
                    }

                    else
                    {
                        MessageBox.Show(this, "Incorrect Username or Password! Please try again" + "" + "Attempt Out 3 of" + attempt, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        attempt++;
                    }
                    if (attempt == 4)
                    {
                        MessageBox.Show("login Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Incorrect Username or Password! Please try again"+ ""+"Attempt Out 3 of" +attempt , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    attempt++;
                }
                if (attempt == 4)
                {
                    MessageBox.Show("login Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtUserName);
            tooltip.Hide(txtPassword);
        }
    }
}
