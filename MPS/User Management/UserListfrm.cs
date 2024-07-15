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
namespace MPS.User_Management
{
    public partial class UserListfrm : Form
    {
        #region Variables
        public string UserID { get; set; }

        string deleteUserID;        

        private List<User> userList = new List<User>();

        UserController userController = new UserController();

        #endregion
        public UserListfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void UserListfrm_Load(object sender, EventArgs e)
        {
            FormRefresh();
            bindUserRole();
        }
        #endregion

        #region Bind Combo
        public void bindUserRole()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<Role> roleList = new List<Role>();
            Role role = new Role();
            role.RoleID = Convert.ToString(0);
            role.RoleName = "Select";
            roleList.Add(role);
            roleList.AddRange(mbsEntities.Roles.Where(x => x.Active == true).ToList());
            cboRoleName.DataSource = roleList;
            cboRoleName.DisplayMember = "RoleName";
            cboRoleName.ValueMember = "RoleID";
        }
        #endregion

        #region Method 
        public void FormRefresh()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            dgvUserList.AutoGenerateColumns = false;
            User u = mbsEntities.Users.Where(x => x.UserID == this.UserID).SingleOrDefault();
            Role role = mbsEntities.Roles.Where(x => x.RoleID == u.RoleID).SingleOrDefault();
            if (role.RoleLevel.Equals("Admin"))
            {
                userList = mbsEntities.Users.Where(x => x.Active == true).OrderByDescending(y => y.CreatedDate).ToList();
            }
            else if (role.RoleLevel.Equals("Manager"))
            {
                userList = mbsEntities.Users.Where(x => x.Active == true && !x.Role.RoleLevel.Equals("Admin")).OrderByDescending(y => y.CreatedDate).ToList();
            }
            else if (role.RoleLevel.Equals("Operator"))
            {
                userList = mbsEntities.Users.Where(x => x.Active == true && x.Role.RoleLevel.Equals("Operator")).OrderByDescending(y => y.CreatedDate).ToList();
            }
            dgvUserList.DataSource = userList;
        }

        public void loadData()
        {
            MBMSEntities mbsEntites = new MBMSEntities();
            var user = mbsEntites.Users.Where(u => u.Active == true).ToList();
            if (txtUserName.Text != null && cboRoleName.SelectedIndex == 0)
            {
                dgvUserList.DataSource = user.Where(u => u.UserName.IndexOf(txtUserName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else if (cboRoleName.SelectedIndex != 0 && string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                dgvUserList.DataSource = user.Where(u => u.Role.RoleName.IndexOf(cboRoleName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                dgvUserList.DataSource = user.Where(u => u.Role.RoleName.IndexOf(cboRoleName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                 u.UserName.IndexOf(txtUserName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
        }

        public void foundDataBind()
        {
            dgvUserList.DataSource = "";
            if (userList.Count < 1)
            {
                MessageBox.Show("No data Found", "Cannot find");
                dgvUserList.DataSource = "";
                return;
            }
            else
            {
                dgvUserList.DataSource = userList;
            }
        }
        #endregion

        #region DataBind Datagrid
        private void dgvUserList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvUserList.Rows)
            {
                User user = (User)row.DataBoundItem;
                row.Cells[0].Value = user.UserID;
                row.Cells[1].Value = user.UserName;
                row.Cells[2].Value = user.Role.RoleName;
            }
        }
        #endregion

        #region Cell Click
        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    MBMSEntities mbsEntities = new MBMSEntities();
                    //DeleteForUser
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvUserList.Rows[e.RowIndex];
                        deleteUserID = Convert.ToString(row.Cells[0].Value);
                        dgvUserList.DataSource = "";
                        User user = (from u in mbsEntities.Users where u.UserID == deleteUserID select u).FirstOrDefault();
                        user.Active = false;
                        user.DeletedUserID = UserID;
                        user.DeletedDate = DateTime.Now;
                        userController.DeleteUserID(user);
                        dgvUserList.DataSource = (from u in mbsEntities.Users where u.Active == true orderby u.UserID descending select u).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRefresh();
                    }

                }
                else if (e.ColumnIndex == 4)
                {
                    //EditUser
                    Userfrm userForm = new Userfrm();
                    userForm.isEdit = true;
                    userForm.Text = "Edit User";
                    userForm.edituserID = Convert.ToString(dgvUserList.Rows[e.RowIndex].Cells[0].Value);
                    userForm.UserID = UserID;                    
                    userForm.isAdd = true;               
                    var result = userForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        FormRefresh();
                    }
                }
            }
        }
        #endregion

        #region Button Click Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            cboRoleName.SelectedIndex = 0;
            FormRefresh();
        }
        #endregion
    }
}
