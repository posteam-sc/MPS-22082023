using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS
{
    public partial class Quarterfrm : Form
    {
        #region Variable
        private ToolTip tooltip = new ToolTip();
        public String UserID { get; set; }
        string quarterID;
        public Boolean isEdit { get; set; }
        QuarterController quarterController = new QuarterController();
        #endregion

        public Quarterfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void Quarterfrm_Load(object sender, EventArgs e)
        {
            
            bindTownship();
            bindSearchTownship();
            InitialState();
            FormRefresh();
            InitialState();
            //tooltip.AutoPopDelay = 1;
            //tooltip.InitialDelay = 1;
            //tooltip.ReshowDelay = 1;
        }
        #endregion

        #region Method
        private  bool checkValidation()
        {
            bool hasError = true;
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";

            if (string.IsNullOrWhiteSpace(txtQuarterCode.Text))
            {
                tooltip.SetToolTip(txtQuarterCode, "Require");
                tooltip.Show("Please fill up Quarter Code!", txtQuarterCode);
                txtQuarterCode.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtQuarterNameEng.Text))
            {
                tooltip.SetToolTip(txtQuarterNameEng, "Require");
                tooltip.Show("Please fill up Quarter Name (Eng)!", txtQuarterNameEng);
                txtQuarterNameEng.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtQuarterNameMM.Text))
            {
                tooltip.SetToolTip(txtQuarterNameMM, "Require");
                tooltip.Show("Please fill up Quarter Name (MM)!", txtQuarterNameMM);
                txtQuarterNameMM.Focus();
                hasError = false;
            }
            else if (cboTownshipName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboTownshipName, "Require");
                tooltip.Show("Please Choose Township Name!", cboTownshipName);
                cboTownshipName.Focus();
                hasError = false;
            }
            return hasError;
        }

        private void bindTownship()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Township> townshipList = new List<Township>();
            Township township = new Township();
            township.TownshipID = Convert.ToString(0);
            township.TownshipNameInEng = "Select";
            townshipList.Add(township);
            townshipList.AddRange(mbmsEntities.Townships.Where(x => x.Active == true).OrderBy(x => x.TownshipNameInEng).ToList());
            cboTownshipName.DataSource = townshipList;
            cboTownshipName.DisplayMember = "TownshipNameInEng";
            cboTownshipName.ValueMember = "TownshipID";
            cboSearchTownshipName.DataSource = townshipList;
            cboSearchTownshipName.DisplayMember = "TownshipNameInEng";
            cboSearchTownshipName.ValueMember = "TownshipID";
        }

        private void bindSearchTownship()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Township> townshipList = new List<Township>();
            Township township = new Township();
            township.TownshipID = Convert.ToString(0);
            township.TownshipNameInEng = "Select";
            townshipList.Add(township);
            townshipList.AddRange(mbmsEntities.Townships.Where(x => x.Active == true).OrderBy(x => x.TownshipNameInEng).ToList());
            cboSearchTownshipName.DataSource = townshipList;
            cboSearchTownshipName.DisplayMember = "TownshipNameInEng";
            cboSearchTownshipName.ValueMember = "TownshipID";
        }

        private void FormRefresh()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            dgvQuarterList.AutoGenerateColumns = false;
            dgvQuarterList.DataSource = (from q in mbmsEntities.Quarters where q.Active == true orderby q.QuarterCode descending select q).ToList();
        }

        private void InitialState()
        {
            if (!CheckingRoleManagementFeature("QuarterAdd"))
            {
                btnSave.Enabled = false;
            }
            txtQuarterCode.Clear();
            txtAddress.Clear();
            txtQuarterNameEng.Clear();
            txtQuarterNameMM.Clear();
            cboTownshipName.SelectedIndex = 0;
            cboSearchTownshipName.SelectedIndex = 0;
            txtQuarterCode.Focus();
            isEdit = false;
            btnSave.Text = "Save";
        }

        private void loadData()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            var quarterList = mbmsEntities.Quarters.Where(t => t.Active == true).ToList();
            if (rdoQuarterCode.Checked == true)
            {
                if (cboSearchTownshipName.SelectedIndex != 0)
                {
                    dgvQuarterList.DataSource = quarterList.Where(q => q.QuarterCode.IndexOf(txtSearchQuarter.Text, StringComparison.OrdinalIgnoreCase) != -1 && q.Township.TownshipNameInEng == cboSearchTownshipName.Text).ToList();
                }
                else
                {
                    dgvQuarterList.DataSource = quarterList.Where(q => q.QuarterCode.IndexOf(txtSearchQuarter.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
                }
            }
            else
            {
                if (cboSearchTownshipName.SelectedIndex != 0)
                {
                    dgvQuarterList.DataSource = quarterList.Where(q => q.QuarterNameInEng.IndexOf(txtSearchQuarter.Text, StringComparison.OrdinalIgnoreCase) != -1 && q.Township.TownshipNameInEng == cboSearchTownshipName.Text).ToList();
                }
                else
                {
                    dgvQuarterList.DataSource = quarterList.Where(q => q.QuarterNameInEng.IndexOf(txtSearchQuarter.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
                }
            }
        }

        private void UpdateQuarter()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();
                int editQuarterCodeCount = 0, editQuarterNameEngCount = 0, editQuarterNameMMCount = 0;

                Quarter updateQuarter = (from q in mbmsEntities.Quarters where q.QuarterID == quarterID select q).FirstOrDefault();
                if (txtQuarterCode.Text != updateQuarter.QuarterCode)
                {
                    editQuarterCodeCount = (from q in mbmsEntities.Quarters where q.QuarterCode == txtQuarterCode.Text && q.Active == true select q).ToList().Count;
                }
                if (editQuarterCodeCount > 0)
                {
                    tooltip.SetToolTip(txtQuarterCode, "Error");
                    tooltip.Show("Quarter Code is already exist!", txtQuarterCode);
                    return;
                }
                if (txtQuarterNameEng.Text != updateQuarter.QuarterNameInEng)
                {
                    editQuarterNameEngCount = (from q in mbmsEntities.Quarters where q.QuarterNameInEng == txtQuarterNameEng.Text && q.Active == true select q).ToList().Count;
                }

                if (editQuarterNameEngCount > 0)
                {
                    tooltip.SetToolTip(txtQuarterNameEng, "Error");
                    tooltip.Show("Quarter Name is already exist!", txtQuarterNameEng);
                    return;
                }
                if (txtQuarterNameMM.Text != updateQuarter.QuarterNameInMM)
                {
                    editQuarterNameMMCount = (from q in mbmsEntities.Quarters where q.QuarterNameInMM == txtQuarterNameMM.Text && q.Active == true select q).ToList().Count;
                }

                if (editQuarterNameMMCount > 0)
                {
                    tooltip.SetToolTip(txtQuarterNameMM, "Error");
                    tooltip.Show("Quarter Name is already exist!", txtQuarterNameMM);
                    return;
                }

                updateQuarter.QuarterCode = txtQuarterCode.Text;
                updateQuarter.QuarterNameInEng = txtQuarterNameEng.Text;
                updateQuarter.QuarterNameInMM = txtQuarterNameMM.Text;
                updateQuarter.Address = txtAddress.Text;
                updateQuarter.TownshipID = cboTownshipName.SelectedValue.ToString();
                updateQuarter.UpdatedUserID = UserID;
                updateQuarter.UpdatedDate = DateTime.Now;
                quarterController.UpdateByQuarter(updateQuarter);
                MessageBox.Show("Successfully updated Quarter! Please check it in 'Quarter List'.", "Update");
                isEdit = false;
                btnSave.Text = "Save";
                InitialState();
                FormRefresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void Save()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();
                Quarter quarter = new Quarter();
                int quarterCodeCount = 0, quarterNameEngCount = 0, quarterNameMMCount = 0;
                quarterCodeCount = (from q in mbmsEntities.Quarters where q.QuarterCode == txtQuarterCode.Text && q.Active == true select q).ToList().Count;
                quarterNameEngCount = (from q in mbmsEntities.Quarters where q.QuarterNameInEng == txtQuarterNameEng.Text && q.Active == true select q).ToList().Count;
                quarterNameMMCount = (from q in mbmsEntities.Quarters where q.QuarterNameInMM == txtQuarterNameMM.Text && q.Active == true select q).ToList().Count;
                if (quarterCodeCount > 0)
                {
                    tooltip.SetToolTip(txtQuarterCode, "Error");
                    tooltip.Show("Quarter Code is already exist!", txtQuarterCode);
                    return;
                }
                if (quarterNameEngCount > 0)
                {
                    tooltip.SetToolTip(txtQuarterNameEng, "Error");
                    tooltip.Show("Quarter Name is already exist!", txtQuarterNameEng);
                    return;
                }
                if (quarterNameMMCount > 0)
                {
                    tooltip.SetToolTip(txtQuarterNameMM, "Error");
                    tooltip.Show("Quarter Name is already exist!", txtQuarterNameMM);
                    return;
                }
                quarter.QuarterID = Guid.NewGuid().ToString();
                quarter.QuarterCode = txtQuarterCode.Text;
                quarter.QuarterNameInEng = txtQuarterNameEng.Text;
                quarter.QuarterNameInMM = txtQuarterNameMM.Text;
                quarter.TownshipID = cboTownshipName.SelectedValue.ToString();
                quarter.Address = txtAddress.Text;
                quarter.Active = true;
                quarter.CreatedUserID = UserID;
                quarter.CreatedDate = DateTime.Now;
                quarterController.Save(quarter);
                MessageBox.Show("Successfully registered Quarter! Please check it in 'Quarter List'.", "Save Success");
                InitialState();
                FormRefresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

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

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            if (!CheckingRoleManagementFeature("QuarterAdd"))
            {
                MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (checkValidation())
            {
                if (isEdit)
                {
                    UpdateQuarter();
                }
                else
                {
                    Save();
                }
            }
        }

        private void dgvQuarterList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 7)
                {
                    //DeleteForQuarter
                    if (!CheckingRoleManagementFeature("QuarterEditOrDelete"))
                    {
                        MessageBox.Show("Access Deined for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvQuarterList.Rows[e.RowIndex];
                        quarterID = Convert.ToString(row.Cells[0].Value);
                        Quarter quarterObj = (Quarter)row.DataBoundItem;
                        quarterObj = (from q in mbmsEntities.Quarters where q.QuarterID == quarterObj.QuarterID select q).FirstOrDefault();
                        var transformerCount = (from t in quarterObj.Transformers where t.Active == true select t).Count();
                        var customerCount = (from t in quarterObj.Customers where t.Active == true select t).Count();
                        if (customerCount > 0)
                        {
                            MessageBox.Show("This Quarter cannot deleted! It is in used", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (transformerCount > 0)
                        {
                            MessageBox.Show("This Quarter cannot deleted! It is in used", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvQuarterList.DataSource = "";
                        Quarter quarter = (from q in mbmsEntities.Quarters where q.QuarterID == quarterID select q).FirstOrDefault();
                        quarter.Active = false;
                        quarter.DeletedUserID = UserID;
                        quarter.DeletedDate = DateTime.Now;
                        quarterController.DeleteByQuarter(quarter);
                        dgvQuarterList.DataSource = (from q in mbmsEntities.Quarters where q.Active == true orderby q.QuarterCode descending select q).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitialState();
                        FormRefresh();
                    }
                }
                else if (e.ColumnIndex == 6)
                {
                    //EditQuarter
                    if (!CheckingRoleManagementFeature("QuarterEditOrDelete"))
                    {
                        MessageBox.Show("Access Deined for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataGridViewRow row = dgvQuarterList.Rows[e.RowIndex];
                    quarterID = Convert.ToString(row.Cells[0].Value);
                    txtQuarterCode.Text = Convert.ToString(row.Cells[1].Value);
                    txtQuarterNameEng.Text = Convert.ToString(row.Cells[2].Value);
                    txtQuarterNameMM.Text = Convert.ToString(row.Cells[3].Value);
                    cboTownshipName.Text = Convert.ToString(row.Cells[4].Value);
                    txtAddress.Text = Convert.ToString(row.Cells[5].Value);
                    isEdit = true;
                    btnSave.Text = "Update";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboSearchTownshipName.SelectedIndex = 0;
            txtSearchQuarter.Clear();
            FormRefresh();
        }
        #endregion

        #region Grid Bind
        private void dgvQuarterList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvQuarterList.Rows)
            {
                Quarter quarter = (Quarter)row.DataBoundItem;
                row.Cells[0].Value = quarter.QuarterID;
                row.Cells[1].Value = quarter.QuarterCode;
                row.Cells[2].Value = quarter.QuarterNameInEng;
                row.Cells[3].Value = quarter.QuarterNameInMM;
                row.Cells[4].Value = quarter.Township.TownshipNameInEng;
                row.Cells[5].Value = quarter.Address;
            }
        }
        #endregion

        #region KeyDown
        private void txtQuarterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtQuarterNameEng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtQuarterNameMM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void cboTownshipName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }
        #endregion

        #region Mouse Move
        private void Quarterfrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtQuarterCode);
            tooltip.Hide(txtQuarterNameEng);
            tooltip.Hide(txtQuarterNameMM);
            tooltip.Hide(cboTownshipName);
        }
        #endregion

        #region rdoCheckChanged
        private void rdoQuarterCode_CheckedChanged(object sender, EventArgs e)
        {
            lblQuarter.Text = "Quarter Code";
        }

        private void rdoQuarterName_CheckedChanged(object sender, EventArgs e)
        {
            lblQuarter.Text = "Quarter Name";
        }
        #endregion

        #region Key Press

        private void txtQuarterNameEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
