using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MPS.Utility;

namespace MPS.Setting_Setup
{
    public partial class StreetLightFeesUI : Form
    {

        #region Variables
        private ToolTip tooltip = new ToolTip();

        public string UserID { get; set; }
        public string streetLightFeesId { get; set; }
        private ToolTip tp = new ToolTip();
        #endregion
        public StreetLightFeesUI()
        {
            InitializeComponent();
        }

        #region Bind Combo
        public void bindQuarter()
        {

            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true && x.Township.TownshipNameInEng.Trim() == cboTownshipName.Text.Trim()).OrderBy(x => x.QuarterNameInEng).ToList());
            cboQuarterName.DataSource = quarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
        }
        public void BindTownship()
        {

            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Township> townshipList = new List<Township>();
            Township township = new Township();
            township.TownshipID = Convert.ToString(1);
            township.TownshipNameInEng = "Select";
            townshipList.Add(township);
            townshipList.AddRange(mbmsEntities.Townships.Where(x => x.Active == true).OrderBy(x => x.TownshipNameInEng).ToList());
            cboTownshipName.DataSource = townshipList;
            cboTownshipName.DisplayMember = "TownshipNameInEng";
            cboTownshipName.ValueMember = "TownshipID";
        }
        #endregion

        #region Form Load
        private void StreetLightFeesUI_Load(object sender, EventArgs e)
        {
            bindQuarter();
            BindTownship();
            cboTownshipName.Text = SettingController.TownShip;
            bindStreetLightFeesGridView();
        }
        #endregion

        #region Method
        private void bindStreetLightFeesGridView()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            gvStreetLightFees.AutoGenerateColumns = false;
            gvStreetLightFees.DataSource = mbmsEntities.StreetLightFees.Where(x => x.Active == true).OrderByDescending(y => y.CreatedDate).ToList();
        }

        private bool checkValidation()
        {
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            if (cboQuarterName.SelectedIndex <= 0)
            {
                MessageBox.Show("Select Quarter data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(txtstreetlightfeeamt.Text))
            {
                tp.SetToolTip(txtstreetlightfeeamt, "Error");
                tp.Show("Please Fill Up Street Light Fees Amount", txtstreetlightfeeamt);
                txtstreetlightfeeamt.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Button Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValidation())
            {
                MBMSEntities mbmsEntities = new MBMSEntities();
                string QuarterId = cboQuarterName.SelectedValue.ToString();
                bool isdataExists = mbmsEntities.StreetLightFees.Any(x => x.Active == true && x.QuarterID == QuarterId);
                if (isdataExists)
                {
                    MessageBox.Show("Same Quarter data already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (btnSave.Text.Equals("Update"))
                {
                    StreetLightFee streetlightfeeentity = mbmsEntities.StreetLightFees.Where(x => x.Active == true && x.StreetLightFeesID == streetLightFeesId).SingleOrDefault();
                    streetlightfeeentity.QuarterID = QuarterId;
                    streetlightfeeentity.Amount = Convert.ToDecimal(txtstreetlightfeeamt.Text);
                    streetlightfeeentity.Active = true;
                    streetlightfeeentity.UpdatedDate = DateTime.Now;
                    streetlightfeeentity.UpdatedUserID = UserID;
                    mbmsEntities.StreetLightFees.AddOrUpdate(streetlightfeeentity);
                    mbmsEntities.SaveChanges();
                    MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Text = "Save";
                }
                else
                {
                    StreetLightFee streetlightfeeentity = new StreetLightFee();
                    streetlightfeeentity.StreetLightFeesID = Guid.NewGuid().ToString();
                    streetlightfeeentity.QuarterID = QuarterId;
                    streetlightfeeentity.Amount = Convert.ToDecimal(txtstreetlightfeeamt.Text);
                    streetlightfeeentity.Active = true;
                    streetlightfeeentity.CreatedDate = DateTime.Now;
                    streetlightfeeentity.CreatedUserID = UserID;
                    mbmsEntities.StreetLightFees.Add(streetlightfeeentity);
                    mbmsEntities.SaveChanges();
                    MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                bindStreetLightFeesGridView();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            cboQuarterName.SelectedIndex = cboTownshipName.SelectedIndex = 0;
            txtstreetlightfeeamt.Text = string.Empty;
            bindStreetLightFeesGridView();
        }

        #endregion

        #region Data Bind by DataGrid
        private void gvStreetLightFees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in gvStreetLightFees.Rows)
            {
                StreetLightFee streetLightFeesEntity = (StreetLightFee)row.DataBoundItem;
                row.Cells[0].Value = streetLightFeesEntity.StreetLightFeesID;
                row.Cells[1].Value = streetLightFeesEntity.Quarter.QuarterNameInEng;
                row.Cells[2].Value = streetLightFeesEntity.Quarter.Township.TownshipNameInEng;
                row.Cells[3].Value = streetLightFeesEntity.Amount;
            }
        }
        #endregion

        #region Datagrid Cell Click
        private void gvStreetLightFees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    //Delete
                    DialogResult result = MessageBox.Show(this, "Are you sure  to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = gvStreetLightFees.Rows[e.RowIndex];
                        StreetLightFee griddata = (StreetLightFee)row.DataBoundItem;//get the selected row's data 
                        StreetLightFee streetLightFee = mbmsEntities.StreetLightFees.Where(x => x.Active == true && x.StreetLightFeesID == griddata.StreetLightFeesID).SingleOrDefault();
                        streetLightFee.Active = false;
                        streetLightFee.UpdatedDate = DateTime.Now;
                        streetLightFee.UpdatedUserID = this.UserID;
                        mbmsEntities.SaveChanges();
                        MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bindStreetLightFeesGridView();
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    //Edit
                    DataGridViewRow row = gvStreetLightFees.Rows[e.RowIndex];
                    StreetLightFee streetLightFee = (StreetLightFee)row.DataBoundItem;//get the selected row's data 
                    streetLightFeesId = streetLightFee.StreetLightFeesID;
                    cboQuarterName.Text = streetLightFee.Quarter.QuarterNameInEng;
                    cboTownshipName.Text = streetLightFee.Quarter.Township.TownshipNameInEng;
                    txtstreetlightfeeamt.Text = streetLightFee.Amount.ToString();
                    btnSave.Text = "Update";
                }
            }
        }
        #endregion

        #region Key Press
        private void txtstreetlightfeeamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void cboTownshipName_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindQuarter();
        }
    }
}
