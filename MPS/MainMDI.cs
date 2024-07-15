
using MBMS.DAL;
using MPS.Billing;
using MPS.CompanyProfileSetup;
using MPS.Customer_Setup;
using MPS.Importing;
using MPS.Ledger_Setup;
using MPS.Master_Setup;
using MPS.Meter_Setup;
using MPS.MeterBillCalculation;
using MPS.MeterBillPayment;
using MPS.MeterUnitCollect;
using MPS.MeterUnitCollection;
using MPS.PC2HHUDB;
using MPS.PunishmentCustomerList;
using MPS.Reports;
using MPS.Setting_Setup;
using MPS.User_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MPS
{
    public partial class MainMDI : Form
    {
        #region Variable
        public string UserID { get; set; }
        public Role role { get; set; }
        public string UserName { get; set; }
        public string position { get; set; }
        private string closeCondition;
        #endregion

        public MainMDI()
        {
            InitializeComponent();
        }

        #region Form Load
        private void MainMDI_Load(object sender, EventArgs e)
        {
            tpUserName.Text = UserName;
            MenuPermission(role.RoleLevel);
        }
        #endregion

        #region Method
        private bool logout()
        {
            DialogResult isExit = MessageBox.Show("Are you sure to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isExit == DialogResult.Yes)
            {
                Savelog();
                closeCondition = "logout";
                this.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Savelog()
        {
            MBMSEntities mbsEntites = new MBMSEntities();
            LogData logdata = new LogData();
            logdata.UserName = tpUserName.Text;
            logdata.Datetime = DateTime.Now;
            logdata.Position = position;
            logdata.Status = "Logout";
            mbsEntites.LogDatas.Add(logdata);
            mbsEntites.SaveChanges();
        }
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
        public void MenuPermission(string roleName)
        {
            if (!CheckingRoleManagementFeature("CustomerView"))
                customerListToolStripMenuItem1.Visible = false;
            if (!CheckingRoleManagementFeature("MeterView"))
                meterListToolStripMenuItem.Visible = false;
            if (!CheckingRoleManagementFeature("BillCodeLayerView"))
                billCodeListToolStripMenuItem.Visible = false;
            if (!CheckingRoleManagementFeature("BillPaymentView"))
                meterBillPaymentToolStripMenuItem.Visible = false;
            if (!CheckingRoleManagementFeature("BillUnitCollectView"))
                meterBillCollectToolStripMenuItem.Visible = false;
                

            //checking the role,if operator role then hide the role menu,add user menu,bill code 7 layer menu,add customer menu,add meter menu,punishment menu
            if (roleName.Equals("Operator"))
            {
               
                //Remove sub Menu  items 
                userManagementToolStripMenuItem.Visible = false;
                userManagementToolStripMenuItem.DropDownItems.RemoveAt(3);//mgt role 
                userManagementToolStripMenuItem.DropDownItems.RemoveAt(0);//add user
                //billingToolStripMenuItem.DropDownItems.RemoveAt(0);//add bill code 7 layer 
               //customerToolStripMenuItem.DropDownItems.RemoveAt(0);//add customer 
              //meterToolStripMenuItem2.DropDownItems.RemoveAt(0);//add meter 
             //masterSetupToolStripMenuItem.DropDownItems.RemoveAt(7);  //punishment rule setup
               masterSetupToolStripMenuItem.DropDownItems.RemoveAt(10);
            }
        }
        #endregion

        #region Click Event
        private void hHUToPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PolePC2HHUDB poleui2hhudb = new PolePC2HHUDB();
            poleui2hhudb.UserID = UserID;
            poleui2hhudb.ShowDialog();
        }

        private void roleManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rolefrm roleForm = new Rolefrm();
            roleForm.UserID = UserID;
            roleForm.ShowDialog();
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserListfrm userListForm = new UserListfrm();
            userListForm.UserID = UserID;
            userListForm.ShowDialog();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Userfrm userForm = new Userfrm();
            userForm.UserID = UserID;
            userForm.ShowDialog();
        }

        private void townshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Townshipfrm townshipForm = new Townshipfrm();
            townshipForm.UserID = UserID;
            townshipForm.ShowDialog();
        }

        private void QuarterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quarterfrm quarterForm = new Quarterfrm();
            quarterForm.UserID = UserID;
            quarterForm.ShowDialog();
        }

        private void transformerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transformerfrm transformerForm = new Transformerfrm();
            transformerForm.UserID = UserID;
            transformerForm.ShowDialog();
        }

        private void transformeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransformerListfrm transListForm = new TransformerListfrm();
            transListForm.UserID = UserID;
            transListForm.ShowDialog();
        }

        private void poleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polefrm poleForm = new Polefrm();
            poleForm.UserID = UserID;
            poleForm.ShowDialog();
        }

        private void meterTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterTypefrm meterTypeForm = new MeterTypefrm();
            meterTypeForm.UserID = UserID;
            meterTypeForm.ShowDialog();
        }

        private void punishementRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PunishmentRulefrm punishementRuleForm = new PunishmentRulefrm();
            punishementRuleForm.UserID = UserID;
            punishementRuleForm.ShowDialog();

        }

        private void meterBillCollectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterUnitCollectionsfrm _MeterUnitCollectionsfrm = new MeterUnitCollectionsfrm();
            _MeterUnitCollectionsfrm.UserID = UserID;
            _MeterUnitCollectionsfrm.ShowDialog();
        }

        private void companyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyProfilefrm companyProfileForm = new CompanyProfilefrm();
            companyProfileForm.UserID = UserID;
            companyProfileForm.ShowDialog();
        }

        private void configurationSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settingfrm settingform = new Settingfrm();
            settingform.UserID = UserID;
            settingform.ShowDialog();
        }

        private void importExportCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerImportingUI importCustomerDataForm = new CustomerImportingUI();
            importCustomerDataForm.UserID = UserID;
            importCustomerDataForm.ShowDialog();
        }

        private void meterBillCalculationProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterBillCalculate mbc = new MeterBillCalculate();
            mbc.UserID = UserID;
            mbc.ShowDialog();
        }

        private void meterBillPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterBillPaymentList mbp = new MeterBillPaymentList();
            mbp.UserID = UserID;
            mbp.ShowDialog();

        }

        private void advanceMoneyCustomerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdvanceMoneyCustomerUI().ShowDialog();
        }

        private void punishmentCustomerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PunishmentCustomerListUI().ShowDialog();
        }

        private void pCToHHUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Quaeter2HHUDBUI().ShowDialog();
        }

        private void meterDataToHHUDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MeterList2HHUDB().ShowDialog();
        }

        private void customerDataToHHUDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerList2HHUDB cdbui = new CustomerList2HHUDB();
            cdbui.UserID = UserID;
            cdbui.ShowDialog();
        }

        private void roleManagementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RoleManagementUI rolemgtui = new RoleManagementUI();
            rolemgtui.UserID = UserID;
            rolemgtui.ShowDialog();
        }

        private void meterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MeterImportingUI meterImporting = new MeterImportingUI();
            meterImporting.UserID = UserID;
            meterImporting.ShowDialog();
        }

        private void versionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VersionInfo().ShowDialog();
        }

        private void addBillDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBillDay formBillday = new frmBillDay();
            formBillday.UserID = UserID;
            formBillday.ShowDialog();
        }

        private void billDayListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBillDayList formBillDayList = new frmBillDayList();
            formBillDayList.UserID = UserID;
            formBillDayList.ShowDialog();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customerfrm customerForm = new Customerfrm();
            customerForm.UserID = UserID;
            customerForm.ShowDialog();
        }

        private void customerListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerListfrm customerListForm = new CustomerListfrm();
            customerListForm.UserID = UserID;
            customerListForm.ShowDialog();
        }

        private void addBillCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillCode7Layerfrm billcode7LayerForm = new BillCode7Layerfrm();
            billcode7LayerForm.UserID = UserID;
            billcode7LayerForm.ShowDialog();
        }

        private void billCodeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillCode7LayerList billCode7LayerForm = new BillCode7LayerList();
            billCode7LayerForm.UserID = UserID;
            billCode7LayerForm.ShowDialog();
        }

        private void manualMeterUnitCollectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManualMeterUnitCollect formManualMeterUnitCollect = new frmManualMeterUnitCollect();
            formManualMeterUnitCollect.userID = UserID;
            formManualMeterUnitCollect.ShowDialog();

        }

        private void addMeterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterFrm meterForm = new MeterFrm();
            meterForm.UserID = UserID;
            meterForm.ShowDialog();
        }

        private void meterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterListfrm meterListForm = new MeterListfrm();
            meterListForm.UserID = UserID;
            meterListForm.ShowDialog();
        }

        private void addLedgerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Accountfrm ledgerForm = new Accountfrm();
            ledgerForm.UserID = UserID;
            ledgerForm.ShowDialog();
        }

        private void searchLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LedgerSearchFrm ledgerSearchForm = new LedgerSearchFrm();
            ledgerSearchForm.ShowDialog();
        }

        private void meterBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterBoxfrm meterBoxForm = new MeterBoxfrm();
            meterBoxForm.UserID = UserID;
            meterBoxForm.ShowDialog();
        }

        private void monthlyMeterBillReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBillingReport billingReportForm = new frmBillingReport();
            billingReportForm.ShowDialog();
        }

        private void MainMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeCondition == "exit")
            {
                this.DialogResult = DialogResult.Yes;
            }
            else if (closeCondition == "logout")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (logout())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Exist the system?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == result)
            {
                closeCondition = "exit";
                this.Close();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logout();
        }
        #endregion


    }
}
