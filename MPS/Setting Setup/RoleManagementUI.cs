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

namespace MPS.Setting_Setup
{
    public partial class RoleManagementUI : Form
    {
        #region Variable
        MBMSEntities mbmsEntities = new MBMSEntities();
        RoleController roleController = new RoleController();
        public String UserID { get; set; }
        #endregion

        public RoleManagementUI()
        {
            InitializeComponent();
        }
        #region Form Load
        private void RoleManagementUI_Load(object sender, EventArgs e)
        {
            bindUserRole();
            CheckEnaDisable();

        }
        #endregion

        #region Bind Combo
        public void bindUserRole()
        {
            List<Role> roleList = new List<Role>();
            Role role = new Role();
            role.RoleID = Convert.ToString(0);
            role.RoleName = "Select";
            roleList.Add(role);
            roleList.AddRange(mbmsEntities.Roles.Where(x => x.Active == true).ToList());
            cboUserRole.DataSource = roleList;
            cboUserRole.DisplayMember = "RoleName";
            cboUserRole.ValueMember = "RoleID";
        }
        #endregion

        #region Method
        private bool Save()
        {
            try
            {
                string roleID = cboUserRole.SelectedValue.ToString();
                //delete all of role mgt before inserting .
                roleController.RoleManagementDeleteByRoleID(roleID);
                //Customer function 
                roleController.SaveRoleMgtByRoleID("Customer", "View", roleID, chkviewcustomerlist.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("Customer", "Add", roleID, chkaddcustomer.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("Customer", "Edit", roleID, chkeditdeletecustomer.Checked, UserID);
                //Bill Unit Collect 
                roleController.SaveRoleMgtByRoleID("BillUnitCollect", "View", roleID, chkViewBillUnit.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("BillUnitCollect", "Edit", roleID, chkcollectbillunit.Checked, UserID);
                //Bill Process
                roleController.SaveRoleMgtByRoleID("BillProcess", "Add", roleID, chkbillingprocess.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("BillProcess", "View", roleID, chkviewbillinginvoice.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("BillProcess", "Edit", roleID, chkeditbillingprocessdata.Checked, UserID);
                //Bill Code  Layer
                roleController.SaveRoleMgtByRoleID("BillCodeLayer", "Add", roleID, chkaddbillcodelayer.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("BillCodeLayer", "View", roleID, chkviewbillcodelayerlist.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("BillCodeLayer", "Edit", roleID, chkeditdeletebillcodelayer.Checked, UserID);
                //Meter
                roleController.SaveRoleMgtByRoleID("Meter", "Edit", roleID, chkeditdeletemeter.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("Meter", "Add", roleID, chkaddmeter.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("Meter", "View", roleID, chkviewmeterlist.Checked, UserID);
                //Bill Payment
                roleController.SaveRoleMgtByRoleID("BillPayment", "View", roleID, chkviewbillpayment.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("BillPayment", "Edit", roleID, chkeditdeletebillpayment.Checked, UserID);
                //ROle
                roleController.SaveRoleMgtByRoleID("Role", "Edit", roleID, chkeditdeleterole.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("Role", "Add", roleID, chkaddrole.Checked, UserID);
                //meter box
                roleController.SaveRoleMgtByRoleID("MeterBox", "Edit", roleID, chkeditdeletemeterbox.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("MeterBox", "Add", roleID, chkaddmeterbox.Checked, UserID);
                //village 
                roleController.SaveRoleMgtByRoleID("Quarter", "Edit", roleID, chkeditdeletevillage.Checked, UserID);
                roleController.SaveRoleMgtByRoleID("Quarter", "Add", roleID, chkaddvillage.Checked, UserID);
                //Punishment
                roleController.SaveRoleMgtByRoleID("Punishment", "Edit", roleID, chkEditDeletePunishmentRule.Checked, UserID);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Bind()
        {
            string roleID = cboUserRole.SelectedValue.ToString();
            resetCheckControl(false);
            List<RoleManagement> rolemgtList = mbmsEntities.RoleManagements.Where(x => x.Active == true && x.RoleID == roleID).ToList();
            foreach (RoleManagement item in rolemgtList)
            {
                //customer 
                if (item.RoleFeatureName.Equals("CustomerView")) chkviewcustomerlist.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("CustomerAdd")) chkaddcustomer.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("CustomerEditOrDelete")) chkeditdeletecustomer.Checked = item.IsAllowed;
                //bill pay ment 
                if (item.RoleFeatureName.Equals("BillPaymentView")) chkviewbillpayment.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("BillPaymentEditOrDelete")) chkeditdeletebillpayment.Checked = item.IsAllowed;

                //bill process
                if (item.RoleFeatureName.Equals("BillProcessAdd")) chkbillingprocess.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("BillProcessView")) chkviewbillinginvoice.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("BillProcessEditOrDelete")) chkeditbillingprocessdata.Checked = item.IsAllowed;

                //bill unit 
                if (item.RoleFeatureName.Equals("BillUnitCollectView")) chkViewBillUnit.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("BillUnitCollectEditOrDelete")) chkcollectbillunit.Checked = item.IsAllowed;

                //Meter 
                if (item.RoleFeatureName.Equals("MeterEditOrDelete")) chkeditdeletemeter.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("MeterAdd")) chkaddmeter.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("MeterView")) chkviewmeterlist.Checked = item.IsAllowed;
                //Role
                if (item.RoleFeatureName.Equals("RoleEditOrDelete")) chkeditdeleterole.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("RoleAdd")) chkaddrole.Checked = item.IsAllowed;

                //Meter Box
                if (item.RoleFeatureName.Equals("MeterBoxEditOrDelete")) chkeditdeletemeterbox.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("MeterBoxAdd")) chkaddmeterbox.Checked = item.IsAllowed;

                //village 
                if (item.RoleFeatureName.Equals("QuarterEditOrDelete")) chkeditdeletevillage.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("QuarterAdd")) chkaddvillage.Checked = item.IsAllowed;
                //Punishment
                if (item.RoleFeatureName.Equals("PunishmentEditOrDelete")) chkEditDeletePunishmentRule.Checked = item.IsAllowed;
                //bill code 7 Layer
                if (item.RoleFeatureName.Equals("BillCodeLayerEditOrDelete")) chkeditdeletebillcodelayer.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("BillCodeLayerAdd")) chkaddbillcodelayer.Checked = item.IsAllowed;
                if (item.RoleFeatureName.Equals("BillCodeLayerView")) chkviewbillcodelayerlist.Checked = item.IsAllowed;
            }
        }

        private void resetCheckControl(bool v)
        {
            chkviewcustomerlist.Checked = chkaddcustomer.Checked = chkeditdeletecustomer.Checked = v;
            chkviewbillpayment.Checked = chkeditdeletebillpayment.Checked = v;
            chkbillingprocess.Checked = chkviewbillinginvoice.Checked = chkeditbillingprocessdata.Checked = v;
            chkViewBillUnit.Checked = chkcollectbillunit.Checked = v;
            chkeditdeletemeter.Checked = chkaddmeter.Checked = chkviewmeterlist.Checked = v;
            chkeditdeleterole.Checked = chkaddrole.Checked = v;
            chkeditdeletemeterbox.Checked = chkaddmeterbox.Checked = v;
            chkeditdeletevillage.Checked = chkaddvillage.Checked = v;
            chkEditDeletePunishmentRule.Checked = chkeditdeletebillcodelayer.Checked = chkaddbillcodelayer.Checked = chkviewbillcodelayerlist.Checked = v;
        }

        private void CheckEnaDisable()
        {
            //Customer
            if (chkviewcustomerlist.Checked == true)
                chkeditdeletecustomer.Enabled = true;
            else
                chkeditdeletecustomer.Enabled = false;

            //Bill Code 7 Layer
            if (chkviewbillcodelayerlist.Checked)
                chkeditdeletebillcodelayer.Enabled = true;
            else
                chkeditdeletebillcodelayer.Enabled = false;

            //Meter 
            if (chkviewmeterlist.Checked)
                chkeditdeletemeter.Enabled = true;
            else
                chkeditdeletemeter.Enabled = false;

            //Bill Payment
            if (chkviewbillpayment.Checked)
                chkeditdeletebillpayment.Enabled = true;
            else
                chkeditdeletebillpayment.Enabled = false;

            //Role



        }
        #endregion

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboUserRole.SelectedIndex > 0)
                {
                    DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ok == DialogResult.Yes)
                    {
                        if (Save())
                        {
                            MessageBox.Show("Successfully saved ", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }//end of dialog yes
                }//end of index 0
                else
                {
                    MessageBox.Show("Please select role record to save data.", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetCheckControl(false);
            cboUserRole.SelectedIndex = 0;
        }

        #endregion

        #region Combo Index Changed
        private void cboUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();
        }
        #endregion

        #region Check Changed

        private void chkviewcustomerlist_CheckedChanged(object sender, EventArgs e)
        {
            if (chkviewcustomerlist.Checked)
            {
                chkeditdeletecustomer.Enabled = true;
            }
            else
            {
                chkeditdeletecustomer.Enabled = false;
                chkeditdeletecustomer.Checked = false;
            }
        }


        private void chkviewbillcodelayerlist_CheckedChanged(object sender, EventArgs e)
        {
            if (chkviewbillcodelayerlist.Checked)
                chkeditdeletebillcodelayer.Enabled = true;
            else
            {
                chkeditdeletebillcodelayer.Enabled = false;
                chkeditdeletebillcodelayer.Checked = false;
            }
        }

        private void chkviewmeterlist_CheckedChanged(object sender, EventArgs e)
        {
            if (chkviewmeterlist.Checked)
                chkeditdeletemeter.Enabled = true;
            else
            {
                chkeditdeletemeter.Enabled = false;
                chkeditdeletemeter.Checked = false;
            }
        }

        private void chkviewbillpayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkviewbillpayment.Checked)
                chkeditdeletebillpayment.Enabled = true;
            else
            {
                chkeditdeletebillpayment.Enabled = false;
                chkeditdeletebillpayment.Checked = false;

            }
        }



        #endregion
    }
}
