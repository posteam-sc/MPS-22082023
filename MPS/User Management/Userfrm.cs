using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
using MPS.User_Management;
using System.Text.RegularExpressions;

namespace MPS
{
    public partial class Userfrm : Form
    {
        #region Variable
        private ToolTip tooltip = new ToolTip();        

        public Boolean isEdit { get; set; }

        public Boolean isAdd { get; set; }

        public String edituserID { get; set; }

        public String UserID { get; set; }

        public Role LoginUserRole { get; set; }

        UserController userController = new UserController();
        #endregion
        public Userfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void Userfrm_Load(object sender, EventArgs e)
        {
            bindUserRole();
            if (isEdit)
            {
                BindEditUser();
            }
            else
            {
                InitialState();
               
            }
           

        }
        #endregion

        #region Method
        private void bindUserRole()
        {
            MBMSEntities mbmsEntityies = new MBMSEntities();
            List<Role> roleList = new List<Role>();
            Role role = new Role();
            role.RoleID = Convert.ToString(0);
            role.RoleName = "Select";
            roleList.Add(role);
            roleList.AddRange(mbmsEntityies.Roles.Where(x => x.Active == true).ToList());
            cboUserRole.DataSource = roleList;
            cboUserRole.DisplayMember = "RoleName";
            cboUserRole.ValueMember = "RoleID";
        }

        private bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Rerquire";

            if (txtUserName.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtUserName, "Require");
                tooltip.Show("Please fill up User name!", txtUserName);
                txtUserName.Focus();
                hasError = false;
            }
            else if (txtFullName.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtFullName, "Require");
                tooltip.Show("Please fill up Full Name", txtFullName);
                txtFullName.Focus();
                hasError = false;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtPassword, "Require");
                tooltip.Show("Please fill up Password", txtPassword);
                txtPassword.Focus();
                hasError = false;
            }

            else if (txtConfirmPassword.Text.Trim() == string.Empty || txtConfirmPassword.Text != txtPassword.Text)
            {
                tooltip.SetToolTip(txtConfirmPassword, "Error");
                tooltip.Show("Do not match password or fill up password", txtConfirmPassword);
                txtConfirmPassword.Focus();
                hasError = false;
            }
            else if (cboUserRole.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboUserRole, "Error");
                tooltip.Show("Please choose User role", cboUserRole);
                cboUserRole.Focus();
                hasError = false;
            }
            return hasError;
        }

        private void Save()
        {
            try
            {
                MBMSEntities mbmsEntityies = new MBMSEntities();
                bool usercheck = mbmsEntityies.Users.Any(x => x.Active == true && x.UserName == txtUserName.Text);
                if (usercheck)
                {
                    MessageBox.Show("User already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                User user = new User();
                user.UserID = Guid.NewGuid().ToString();
                user.UserName = txtUserName.Text;
                user.Password = Utility.EncryptString(txtPassword.Text, "scadmin@123");
                user.RoleID = cboUserRole.SelectedValue.ToString();
                user.FullName = txtFullName.Text;
                user.Active = true;
                user.CreatedUserID = UserID;
                user.CreatedDate = DateTime.Now;
                userController.Save(user);
                MessageBox.Show("Successfully registered user! Please check it in 'User list' ", "Save Success");
                if (isAdd)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                InitialState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void UpdateUser()
        {
            try
            {
                MBMSEntities mbmsEntityies = new MBMSEntities();
                User updateUser = (from u in mbmsEntityies.Users where u.UserID == edituserID select u).FirstOrDefault();
                updateUser.UserName = txtUserName.Text;
                updateUser.RoleID = cboUserRole.SelectedValue.ToString();
                updateUser.FullName = txtFullName.Text;
                updateUser.Password = Utility.EncryptString(txtPassword.Text, "scadmin@123");
                updateUser.UpdatedUserID = UserID;
                updateUser.UpdatedDate = DateTime.Now;
                userController.UpdateUserID(updateUser);
                MessageBox.Show("Successfully updated User!", "Update");
                InitialState();                
                this.Close();
                if (isAdd)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BindEditUser()
        {
            MBMSEntities mbmsEntityies = new MBMSEntities();
            User user = (from u in mbmsEntityies.Users where u.UserID == edituserID select u).FirstOrDefault<User>();
            txtUserName.Text = user.UserName;
            cboUserRole.Text = user.Role.RoleName;
            txtFullName.Text = user.FullName;
            txtPassword.Text = Utility.DecryptString(user.Password, "scadmin@123");
            txtConfirmPassword.Text = Utility.DecryptString(user.Password, "scadmin@123");
            btnSave.Text = "Update";
        }

        public void InitialState()
        {
            txtUserName.Text = string.Empty;            
            txtConfirmPassword.Text = string.Empty;
            txtPassword.Text = string.Empty;           
            txtFullName.Text = string.Empty;
            cboUserRole.SelectedIndex = 0;
            btnSave.Text = "Save";
            txtUserName.Focus();
            isEdit = false;
        }
        #endregion

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (checkValidation())
            {
                if (isEdit)
                {
                    UpdateUser();                  
                    
                    
                }
                else
                {
                    Save();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();
        }
        #endregion

        #region Mouse Move
        private void Userfrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtUserName);
            tooltip.Hide(txtFullName);
            tooltip.Hide(txtPassword);
            tooltip.Hide(txtConfirmPassword);
            tooltip.Hide(cboUserRole);
        }
        #endregion

        #region Form Closing
        private void Userfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                DialogResult result = MessageBox.Show("Need to Update Record", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    e.Cancel = true;
                }
                else
                {
                    var userlistform = new UserListfrm();
                    userlistform.UserID = UserID;
                    userlistform.FormRefresh();
                }
            }
           
        }
        #endregion

        #region Key Press
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Key Down
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                case Keys.Down:
                case Keys.Enter:
                    txtFullName.Focus();
                    break;
                default:
                    txtUserName.Focus();
                    break;                  

            }
        }
        
        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
           
            switch (e.KeyCode)
            {
                case Keys.Tab:
                case Keys.Down:
                case Keys.Enter:
                    txtPassword.Focus();
                    break;
                case Keys.Up:
                    txtUserName.Focus();
                    break;  
                default:
                    txtFullName.Focus();
                    break;

            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                case Keys.Down:
                case Keys.Enter:
                    txtConfirmPassword.Focus();
                    break;
                case Keys.Up:
                   txtFullName.Focus();
                    break;                
                  
                default:
                    txtPassword.Focus();
                    break;

            }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                case Keys.Down:
                case Keys.Enter:
                    cboUserRole.Focus();
                    break;
                case Keys.Up:
                   txtPassword.Focus();
                    break;              
                   
                default:
                    txtConfirmPassword.Focus();
                    break;

            }
        }

        private void cboUserRole_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {               
                case Keys.Up:
                    txtConfirmPassword.Focus();
                    break; 
                default:
                    cboUserRole.Focus();
                    break;

            }
        }
        #endregion
    }
}
