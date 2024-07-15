using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
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
    public partial class PunishmentRulefrm : Form
    {
        #region Variables
        private ToolTip tooltip = new ToolTip();

        public String UserID { get; set; }

        string punishmentRuleID;

        public Boolean isEdit { get; set; }

        PurnishmentRuleController punishmentRuleController = new PurnishmentRuleController();
        #endregion

        public PunishmentRulefrm()
        {
            InitializeComponent();
        }

        #region Data Permision for Role Mgt
        private bool CheckingRoleManagementFeature(string ProgramName)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();

            bool IsAllowed = false;
            string roleID = mbmsEntities.Users.Where(x => x.Active == true && x.UserID == UserID).SingleOrDefault().RoleID;
            List<RoleManagement> rolemgtList = mbmsEntities.RoleManagements.Where(x => x.Active == true && x.RoleID == roleID).ToList();
            foreach (RoleManagement item in rolemgtList)
            {
                //bill payment Menu Permission CustomerView
                if (item.RoleFeatureName.Equals(ProgramName) && item.IsAllowed) IsAllowed = item.IsAllowed;
            }
            return IsAllowed;
        }
        #endregion

        #region Method
        public bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";

            if (string.IsNullOrWhiteSpace(txtPunishmentCode.Text))
            {
                tooltip.SetToolTip(txtPunishmentCode, "Require");
                tooltip.Show("Please fill up Punishment Rule Code!", txtPunishmentCode);
                txtPunishmentCode.Focus();
                hasError = false;
            }

            else if (string.IsNullOrWhiteSpace(txtExceedMonth.Text))
            {
                tooltip.SetToolTip(txtExceedMonth, "Require");
                tooltip.Show("Please fill up To ExceedMonth!", txtExceedMonth);
                txtExceedMonth.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                tooltip.SetToolTip(txtAmount, "Require");
                tooltip.Show("Please fill up Amount!", txtAmount);
                txtAmount.Focus();
                hasError = false;
            }
            return hasError;
        }

        public void InitialState()
        {
            txtPunishmentCode.Text = string.Empty;
            txtExceedMonth.Text = string.Empty;
            txtExceedMonth.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtPunishmentCode.Focus();
            btnSave.Text = "Save";
            isEdit = false;
        }

        public void FormRefresh()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();

            this.btnSave.Text = "Save";
            dgvPunishmentRuleList.AutoGenerateColumns = false;
            dgvPunishmentRuleList.DataSource = (from p in mbmsEntities.PunishmentRules where p.Active == true orderby p.PunishmentCode descending select p).ToList();
        }

        private void UpdatePunishment()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();

                int editPunishmentCount = 0;
                PunishmentRule updatePunishmentRule = (from p in mbmsEntities.PunishmentRules where p.PunishmentRuleID == punishmentRuleID select p).FirstOrDefault();
                if (txtPunishmentCode.Text != updatePunishmentRule.PunishmentCode)
                {
                    editPunishmentCount = (from p in mbmsEntities.PunishmentRules where p.PunishmentCode == txtPunishmentCode.Text && p.Active == true select p).ToList().Count;
                }

                if (editPunishmentCount > 0)
                {
                    tooltip.SetToolTip(txtPunishmentCode, "Error");
                    tooltip.Show("Punishment Rule Code is already exist!", txtPunishmentCode);
                    return;
                }

                updatePunishmentRule.PunishmentCode = txtPunishmentCode.Text;
                updatePunishmentRule.ExceedMonth = Convert.ToInt32(txtExceedMonth.Text);
                updatePunishmentRule.Amount = Convert.ToDecimal(txtAmount.Text);
                updatePunishmentRule.UpdatedUserID = UserID;
                updatePunishmentRule.UpdatedDate = DateTime.Now;
                punishmentRuleController.UpdatePurnishmentRule(updatePunishmentRule);
                MessageBox.Show("Successfully updated Punishment Rule!", "Update");
                isEdit = false;
                btnSave.Text = "Save";
                InitialState();
                FormRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();

                PunishmentRule punishmentRule = new PunishmentRule();
                int punishmentRuleCount = 0;
                punishmentRuleCount = (from p in mbmsEntities.PunishmentRules where p.PunishmentCode == txtPunishmentCode.Text && p.Active == true select p).ToList().Count;

                if (punishmentRuleCount > 0)
                {
                    tooltip.SetToolTip(txtPunishmentCode, "Error");
                    tooltip.Show("Punishment Rule Code is already exist!", txtPunishmentCode);
                    return;
                }
                punishmentRule.PunishmentRuleID = Guid.NewGuid().ToString();
                punishmentRule.PunishmentCode = txtPunishmentCode.Text;
                punishmentRule.ExceedMonth = Convert.ToInt32(txtExceedMonth.Text);
                punishmentRule.Amount = Convert.ToDecimal(txtAmount.Text);
                punishmentRule.Active = true;
                punishmentRule.CreatedUserID = UserID;
                punishmentRule.CreatedDate = DateTime.Now;
                punishmentRuleController.Save(punishmentRule);
                MessageBox.Show("Successfully registered Punishment Rule! Please check it in 'Punishment Rule List'.", "Save Success");
                InitialState();
                FormRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Button Click

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (checkValidation())
            {
                if (isEdit)
                {
                    UpdatePunishment();
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

        #region Form Load
        private void PunishmentRulefrm_Load(object sender, EventArgs e)
        {
            InitialState();
            FormRefresh();
        }
        #endregion

        #region Data Grid Bind 
        private void dgvPunishmentRuleList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPunishmentRuleList.Rows)
            {
                PunishmentRule punishmentRule = (PunishmentRule)row.DataBoundItem;
                row.Cells[0].Value = punishmentRule.PunishmentRuleID;
                row.Cells[1].Value = punishmentRule.PunishmentCode;
                row.Cells[2].Value = punishmentRule.ExceedMonth;
                row.Cells[3].Value = punishmentRule.Amount;

            }
        }

        #endregion

        #region Datagrid Cell Click
        private void dgvPunishmentRuleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    //DeleteForPunishmentRule
                    if (!CheckingRoleManagementFeature("PunishmentEditOrDelete"))
                    {
                        MessageBox.Show("Access Denied for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        MBMSEntities mbmsEntities = new MBMSEntities();
                        DataGridViewRow row = dgvPunishmentRuleList.Rows[e.RowIndex];
                        punishmentRuleID = Convert.ToString(row.Cells[0].Value);
                        dgvPunishmentRuleList.DataSource = "";
                        PunishmentRule punishmentRule = (from p in mbmsEntities.PunishmentRules where p.PunishmentRuleID == punishmentRuleID select p).FirstOrDefault();
                        punishmentRule.Active = false;
                        punishmentRule.DeletedUserID = UserID;
                        punishmentRule.DeletedDate = DateTime.Now;
                        punishmentRuleController.DeletePrunishmentRule(punishmentRule);
                        dgvPunishmentRuleList.DataSource = (from p in mbmsEntities.PunishmentRules where p.Active == true orderby p.PunishmentCode descending select p).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitialState();
                        FormRefresh();
                    }

                }
                else if (e.ColumnIndex == 4)
                {
                    //EditPunishmentRule
                    if (!CheckingRoleManagementFeature("PunishmentEditOrDelete"))
                    {
                        MessageBox.Show("Access Denied for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataGridViewRow row = dgvPunishmentRuleList.Rows[e.RowIndex];
                    punishmentRuleID = Convert.ToString(row.Cells[0].Value);
                    txtPunishmentCode.Text = Convert.ToString(row.Cells[1].Value);
                    txtExceedMonth.Text = Convert.ToString(row.Cells[2].Value);
                    txtAmount.Text = Convert.ToString(row.Cells[3].Value);
                    isEdit = true;
                    this.btnSave.Text = "Update";
                }
            }
        }

        #endregion

        #region Key Down
        private void txtPunishmentCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtExceedMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }
        #endregion

        #region Mouse Move
        private void PunishmentRulefrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtPunishmentCode);
            tooltip.Hide(txtExceedMonth);
            tooltip.Hide(txtAmount);
        }
        #endregion

        #region Key Press
        private void txtExceedMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");

            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");

            }
        }
        #endregion
    }
}
