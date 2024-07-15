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
using System.Text.RegularExpressions;

namespace MPS
{
    public partial class Rolefrm : Form
    {
        #region Variable
        string RoleID;
        public string UserID { get; set; }

        private ToolTip tooltip = new ToolTip();
      

        RoleController roleController = new RoleController();

        public Boolean isEdit { get; set; }
        #endregion
        public Rolefrm()
        {
            InitializeComponent();
        }

        #region Method
        public bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";
            //Validation
            if (txtRoleName.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtRoleName, "Require");
                tooltip.Show("Please fill up Role name!", txtRoleName);
                txtRoleName.Focus();
                hasError = false;
            }
            else if (cboRoleLevel.SelectedIndex == -1)
            {
                tooltip.SetToolTip(cboRoleLevel, "Require");
                tooltip.Show("Please choose Role Level !", cboRoleLevel);
                cboRoleLevel.Focus();
                hasError = false;
            }
            return hasError;
        }

        private void Save()
        {
            
            try
            {
                MBMSEntities mbsEntities = new MBMSEntities();
                int roleNameCount = 0;
                roleNameCount = (from r in mbsEntities.Roles where r.RoleName == txtRoleName.Text && r.Active == true select r).ToList().Count;
                if (roleNameCount > 0)
                {
                    tooltip.SetToolTip(txtRoleName, "Error");
                    tooltip.Show("Role Name is already exist!", txtRoleName);
                    return;
                }
                Role role = new Role();
                role.RoleID = Guid.NewGuid().ToString();
                role.RoleName = txtRoleName.Text;
                role.RoleLevel = cboRoleLevel.Text;
                role.Active = true;
                role.CreatedUserID = UserID;
                role.CreatedDate = DateTime.Now;
                roleController.Save(role);
                MessageBox.Show("Successfully registered Role! Please Check it in 'Role List'.", "Save Success");
                InitialState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void UpdateRole()
        {
            try
            {
                MBMSEntities mbsEntities = new MBMSEntities();
                int editRoleCount = 0;
                Role updateRole = (from r in mbsEntities.Roles where r.RoleID == RoleID select r).FirstOrDefault();
                if (txtRoleName.Text != updateRole.RoleName)
                {
                    editRoleCount = (from r in mbsEntities.Roles where r.RoleName == txtRoleName.Text && r.Active == true select r).ToList().Count;
                }

                if (editRoleCount > 0)
                {
                    tooltip.SetToolTip(txtRoleName, "Error");
                    tooltip.Show("Role Name is already exist!", txtRoleName);
                    return;
                }
                updateRole.RoleName = txtRoleName.Text;
                updateRole.RoleLevel = cboRoleLevel.Text;
                updateRole.UpdatedUserID = UserID;
                updateRole.UpdatedDate = DateTime.Now;
                roleController.UpdateByRoleID(updateRole);
                MessageBox.Show("Successfully updated Role!", "Update");
                InitialState();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void FormRefresh()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            dgvRole.AutoGenerateColumns = false;
            dgvRole.DataSource = (from r in mbsEntities.Roles where r.Active == true orderby r.RoleName descending select r).ToList();
        }

        private  void InitialState()
        {
            txtRoleName.Text = string.Empty;
            cboRoleLevel.SelectedIndex = 0;
            txtRoleName.Focus();
            isEdit = false;
            btnSave.Text = "Save";
        }
        
        #endregion

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckingRoleManagementFeature("RoleAdd"))
            {
                MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (checkValidation())
            {
                if (isEdit)
                {
                    UpdateRole();
                    FormRefresh();
                }
                else
                {
                    Save();
                    FormRefresh();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();
        }


        #endregion

        #region Form Load
        private void Rolefrm_Load(object sender, EventArgs e)
        {
            cboRoleLevel.Items.Add("Admin");
            cboRoleLevel.Items.Add("Manager");
            cboRoleLevel.Items.Add("Operator");
            cboRoleLevel.SelectedIndex = 0;
            FormRefresh();
            InitialState();
        }
        #endregion
      
        #region Data Permision for Role Mgt
        private bool CheckingRoleManagementFeature(string ProgramName)
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            bool IsAllowed = false;
            string roleID = mbsEntities.Users.Where(x => x.Active == true && x.UserID == UserID).SingleOrDefault().RoleID;
            List<RoleManagement> rolemgtList = mbsEntities.RoleManagements.Where(x => x.Active == true && x.RoleID == roleID).ToList();
            foreach (RoleManagement item in rolemgtList)
            {
                //bill payment Menu Permission CustomerView
                if (item.RoleFeatureName.Equals(ProgramName) && item.IsAllowed) IsAllowed = item.IsAllowed;
            }
            return IsAllowed;
        }
        #endregion

        #region DataBind to DataGrid
        private void dgvRole_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRole.Rows)
            {
                Role role = (Role)row.DataBoundItem;
                row.Cells[0].Value = role.RoleID;
                row.Cells[1].Value = role.RoleName;
                row.Cells[2].Value = role.RoleLevel;
            }
        }
        #endregion

        #region Datagrid Cell Click
        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    MBMSEntities mbsEntities = new MBMSEntities();
                    //DeleteForRole
                    if (!CheckingRoleManagementFeature("RoleEditOrDelete"))
                    {
                        MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvRole.Rows[e.RowIndex];
                        RoleID = Convert.ToString(row.Cells[0].Value);
                        Role roleObj = (Role)row.DataBoundItem;
                        roleObj = (from r in mbsEntities.Roles where r.RoleID == roleObj.RoleID select r).FirstOrDefault();
                        var userCount = (from u in roleObj.Users where u.Active == true select u).Count();
                        if (userCount > 0)
                        {
                            MessageBox.Show("This Role cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvRole.DataSource = "";
                        Role role = (from r in mbsEntities.Roles where r.RoleID == RoleID select r).FirstOrDefault();
                        role.Active = false;
                        role.DeletedUserID = UserID;
                        role.DeletedDate = DateTime.Now;
                        roleController.DeletedByRoleID(role);
                        dgvRole.DataSource = (from em in mbsEntities.Roles where em.Active == true orderby em.RoleID descending select em).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitialState();
                        FormRefresh();

                    }

                }
                else if (e.ColumnIndex == 3)
                {
                    //EditRole
                    if (!CheckingRoleManagementFeature("RoleEditOrDelete"))
                    {
                        MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataGridViewRow row = dgvRole.Rows[e.RowIndex];
                    RoleID = Convert.ToString(row.Cells[0].Value);
                    txtRoleName.Text = Convert.ToString(row.Cells[1].Value);
                    cboRoleLevel.Text = Convert.ToString(row.Cells[2].Value);
                    isEdit = true;
                    btnSave.Text = "Update";
                }
            }
        }
        #endregion

        #region Mouse Move 
        private void Rolefrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtRoleName);
            tooltip.Hide(cboRoleLevel);
        }
        #endregion

        #region KeyPress
        private void txtRoleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        #endregion

        private void txtRoleName_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                case Keys.Down:
                case Keys.Enter:
                    cboRoleLevel.Focus();
                    break;

                default:
                    txtRoleName.Focus();
                    break;

            }
        }

        private void cboRoleLevel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Up:
                    txtRoleName.Focus();
                    break;

                default:
                    cboRoleLevel.Focus();
                    break;

            }
        }
    }
}

