using MBMS.DAL;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MPS.Utility;

namespace MPS.Setting_Setup
{

    public partial class Settingfrm : Form
    {
        #region Variables


        private ToolTip tp = new ToolTip();
        public string UserID { get; set; }
        #endregion

        public Settingfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void Settingfrm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        #endregion 

        #region Method
        private void BindData()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            CompanyProfile companyProfile = new CompanyProfile();
            companyProfile = mbmsEntities.CompanyProfiles.Where(X => X.Active == true).SingleOrDefault();
            lblCompanyName.Text = SettingController.defaultCompanyProfile.CompanyName;
            lblAddress.Text = companyProfile.AddressEng;
            lblEmail.Text = companyProfile.CompanyEmail;
            lblPhoneNumber.Text = companyProfile.PhoneNumber;
            lblWebsite.Text = companyProfile.CompanyWebsite;
            

            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(printerName);
            }
            if (DefaultPrinter.A4Printer != null)
            {
                cboPrinter.Text = DefaultPrinter.A4Printer;
            }
            txtNoCopy.Text = SettingController.DefaultNoOfCopies.ToString();
            txtStreetLightFees.Text = SettingController.StreetLightFees.ToString();

            txtDateFormat.Text = SettingController.DateFormat;
            bindTownship();
            cboTownship.Text = SettingController.TownShip;
            txtDivision.Text = SettingController.Division.ToString();
            txtBranchCode.Text = SettingController.BranchCode.ToString();
            txtFullCode.Text = SettingController.BranchCode + "-" + SettingController.Division + "-" + SettingController.TownShip;
            
        }
        #endregion

        #region Bind Combo
        public void bindTownship()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Township> townshipList = new List<Township>();
            Township township = new Township();
            township.TownshipID = Convert.ToString(0);
            township.TownshipCode = "Select";
            townshipList.Add(township);
            townshipList.AddRange(mbmsEntities.Townships.Where(x => x.Active == true).OrderBy(x => x.TownshipCode).ToList());
            cboTownship.DataSource = townshipList;
            cboTownship.DisplayMember = "TownshipCode";
            cboTownship.ValueMember = "TownshipID";
        }
        #endregion

        #region Button Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            Boolean hasError = false;
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            if (txtNoCopy.Text.Trim() == string.Empty || Convert.ToInt32(txtNoCopy.Text) == 0)
            {
                tp.SetToolTip(txtNoCopy, "Error");
                tp.Show("Please number of Copy!", txtNoCopy);
                hasError = true;
            }
            else if (txtBranchCode.Text.Trim() == string.Empty || Convert.ToInt32(txtBranchCode.Text) == 0)
            {
                tp.SetToolTip(txtBranchCode, "Error");
                tp.Show("Please Fill Branch Code!", txtBranchCode);
                hasError = true;
            }
            if (txtDivision.Text.Trim() == string.Empty || Convert.ToInt32(txtDivision.Text) == 0)
            {
                tp.SetToolTip(txtDivision, "Error");
                tp.Show("Please Fill Division!", txtDivision);
                hasError = true;
            }
            if (!hasError)
            {
                DefaultPrinter.A4Printer = cboPrinter.Text;
                SettingController.CompanyName = lblCompanyName.Text;
                SettingController.CompanyEmail = lblEmail.Text;
                SettingController.PhoneNo = lblPhoneNumber.Text;
                SettingController.CompanyWebsite = lblWebsite.Text;
                SettingController.CompanyAddress = lblAddress.Text;
                SettingController.DefaultNoOfCopies = Convert.ToInt32(txtNoCopy.Text);
                SettingController.TownShip = cboTownship.Text;
                SettingController.DateFormat = txtDateFormat.Text;
                SettingController.StreetLightFees = Convert.ToInt32(txtStreetLightFees.Text);
                SettingController.BranchCode = txtBranchCode.Text;
                SettingController.Division = txtDivision.Text;
                mbmsEntities.SaveChanges();
                MessageBox.Show("Successfully save Setting!");
                Settingfrm settingForm = new Settingfrm();
                settingForm.Refresh();
            }
        }

        private void btnDefineCustom_Click(object sender, EventArgs e)
        {
            StreetLightFeesUI slfui = new StreetLightFeesUI();
            slfui.UserID = this.UserID;
            slfui.Show();
        }
        #endregion      

        #region Key Press

        private void txtBranchCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDivision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
