using MBMS.DAL;
using MPS.BusinessLogic.MeterController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Meter_Setup
{
    public partial class MeterRemoveUI : Form
    {
        #region Variables
        IMeter meterservice;
        public Meter meter { get; set; }

        #endregion
        public MeterRemoveUI()
        {
            InitializeComponent();
            meterservice = new MeterController();
        }

        #region Form Load
        private void MeterRemoveUI_Load(object sender, EventArgs e)
        {
            LoadMeterInfo();
            gbNormal.Enabled = false;
            txtRemoveOtherRemark.Enabled = false;
        }
        #endregion

        #region Method
        private void LoadMeterInfo()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            lblmeterNo.Text = meter.MeterNo;
            Customer customer = mbmsEntities.Customers.Where(x => x.MeterID == meter.MeterID).SingleOrDefault();
            lblcustomername.Text = customer.CustomerNameInEng;
            lblinstallationdate.Text = meter.InstalledDate.Value.ToShortDateString();
        }
        #endregion

        #region Button Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnremove_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure to remove it?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Customer customer = mbmsEntities.Customers.Where(x => x.MeterID == meter.MeterID).SingleOrDefault();

                    Customerfrm customerForm = new Customerfrm();
                    customerForm.isEdit = true;
                    customerForm.Text = "Edit Customer";
                    customerForm.meterHistory = meter;
                    customerForm.customerID = customer.CustomerID;
                    customerForm.UserID = meter.CreatedUserID;
                    var result = customerForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        MeterHistory meterhistory = new MeterHistory();

                        meterhistory.MeterHistoryID = Guid.NewGuid().ToString();
                        meterhistory.OldMeterID = meter.MeterID;
                        if(customerForm.currentMeter != null)
                        {
                            meterhistory.MeterID = customerForm.currentMeter;
                        }                      

                        meterhistory.CustomerID = customer.CustomerID;

                        if (rdoDamage.Checked == true)
                        {
                            meterhistory.RemoveType = true;
                            if (rdoCommunication.Checked == true)
                                meterhistory.DamageType = "Comm";
                            else if (rdoBattery.Checked == true)
                                meterhistory.DamageType = "Battery";
                            else if (rdoLCDError.Checked == true)
                                meterhistory.DamageType = "LCD";
                            else if (rdoLED.Checked == true)
                                meterhistory.DamageType = "LED";
                            else if (rdoPower.Checked == true)
                                meterhistory.DamageType = "Power";
                            else if (rdoWatt.Checked == true)
                                meterhistory.DamageType = "Watt";

                            else if (rdoOther.Checked == true)
                            {
                                txtRemoveOtherRemark.Enabled = true;
                                meterhistory.DamageType = "Other";
                                meterhistory.Remark = txtRemoveOtherRemark.Text;
                            }
                        }
                        else
                        {
                            meterhistory.RemoveType = false;
                            meterhistory.DamageType = "Normal";
                            meterhistory.Remark = txtRemark.Text;
                        }
                        meterhistory.RemovedDate = dtpremoveddate.Value;
                        meterhistory.Active = true;
                        meterhistory.CreatedDate = DateTime.Now;
                        meterhistory.CreatedUserID = meter.CreatedUserID;
                        meterservice.RemoveMeter(meterhistory);

                        MBMSEntities disableMeterEntities = new MBMSEntities();
                        var disableMeter = disableMeterEntities.Meters.Where(x => x.MeterID == meter.MeterID).FirstOrDefault();
                        disableMeter.Status = false;
                        disableMeterEntities.SaveChanges();

                        MessageBox.Show("Successfully removed Meter record'.", "Remove Success");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Occur");
                }
            }
        }
        #endregion



        #region Check Change
        private void rdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            gbNormal.Enabled = true;
            gbDamage.Enabled = false;
        }

        private void rdoDamage_CheckedChanged(object sender, EventArgs e)
        {
            gbDamage.Enabled = true;
            gbNormal.Enabled = false;
        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            txtRemoveOtherRemark.Enabled = true;
        }

        private void rdoCommunication_CheckedChanged(object sender, EventArgs e)
        {
            txtRemoveOtherRemark.Enabled = false;
        }

        private void rdoLCDError_CheckedChanged(object sender, EventArgs e)
        {
            txtRemoveOtherRemark.Enabled = false;
        }

        private void rdoPower_CheckedChanged(object sender, EventArgs e)
        {
            txtRemoveOtherRemark.Enabled = false;
        }

        private void rdoWatt_CheckedChanged(object sender, EventArgs e)
        {
            txtRemoveOtherRemark.Enabled = false;
        }

        private void rdoLED_CheckedChanged(object sender, EventArgs e)
        {
            txtRemoveOtherRemark.Enabled = false;
        }

        private void rdoBattery_CheckedChanged(object sender, EventArgs e)
        {
            txtRemoveOtherRemark.Enabled = false;
        }
        #endregion
    }
}
