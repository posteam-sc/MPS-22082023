using MBMS.DAL;
using Microsoft.Reporting.WinForms;
using MPS.BusinessLogic.AdvanceMoneyCustomerController;
using MPS.BusinessLogic.MeterBillCalculationController;
using MPS.BusinessLogic.PunishmentCustomerController;
using MPS.BusinessLogic.PunishmentRuleController;
using MPS.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace MPS.MeterBillPayment
{
    public partial class MeterBillPaymentByCash : Form
    {
        #region  Variables
        public string UserID { get; set; }

        public MeterBillInvoiceVM vm { get; set; }

        public string MeterBillId { get; set; }


        IMeterBillCalculateServices meterBillCalculateservices;

        IPunishmentRuleServices punishmentruleservices;

        IPunishmentCustomerServices punishmentCutomerServices;

        IAdvanceMoneyCustomerServices advanceMoneyCustomerServices;

        List<PunishmentRule> punishmentRuleList;

        public Boolean isPayment { get; set; }

        public string punishmentruleID { get; set; }
        #endregion

        public MeterBillPaymentByCash()
        {
            InitializeComponent();
            meterBillCalculateservices = new MeterBillCalculateController();
            punishmentruleservices = new PunishmentRuleController();
            advanceMoneyCustomerServices = new AdvanceMoneyCustomerController();
            punishmentCutomerServices = new PunishmentCustomerController();
            punishmentRuleList = new List<PunishmentRule>();
        }

        #region Form Load
        private void MeterBillPaymentByCash_Load(object sender, EventArgs e)
        {
            bindData();
        }
        #endregion

        #region Method
        private void bindData()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            txtCustomerName.Text = vm.CustomerName;
            txtQuarterName.Text = vm.QuarterName;
            txtTownshipName.Text = vm.TransformerName;
            txtBillCodeNo.Text = vm.MeterBillCode;
            txtTotalFees.Text = vm.TotalFees.ToString();
            punishmentRuleList = punishmentruleservices.getPunishmentList();
            int datediff = 0;
            if (punishmentRuleList.Count > 0)
            {
                datediff = (DateTime.Now.Date - vm.InvoiceDate.Date).Days / 30;
            }
            decimal totalPunishmentRuleAmount = 0;
            foreach (PunishmentRule rule in punishmentRuleList)
            {
                if (rule.ExceedMonth <= datediff)
                {
                    totalPunishmentRuleAmount += rule.Amount;
                    punishmentruleID = rule.PunishmentRuleID;
                }
            }

            txtpunishment.Text = totalPunishmentRuleAmount.ToString();

            var advanceMoney = mbmsEntities.MeterBills.Where(x => x.Active == true && x.MeterUnitCollect.Customer.CustomerCode == vm.CustomerCode && x.isPaid == true).OrderByDescending(x => x.LastBillPaidDate).Select(x => x.AdvanceMoney).FirstOrDefault();
            decimal advMoney = 0;
            if (advanceMoney != null)
            {
                advMoney = (decimal)advanceMoney;
            }
            txtAdvanceMoney.Text = advMoney.ToString();

            txtFinalTotalFees.Text = (Convert.ToDecimal(vm.TotalFees) + Convert.ToDecimal(txtpunishment.Text) - Convert.ToDecimal(txtAdvanceMoney.Text)).ToString();           
            
        }

        private void BindPunishmentCustomerEntity(PunishmentCustomer pc)
        {
            pc.PunishmentCustomerID = Guid.NewGuid().ToString();
            pc.Active = true;
            pc.CreatedDate = DateTime.Now;
            pc.CreatedUserID = UserID;
            pc.MeterBillID = vm.MeterBillID;
            pc.PunishmentRuleID = punishmentruleID;
            pc.PunishmentAmount = Convert.ToDecimal(txtpunishment.Text);
            pc.ForMonth = vm.InvoiceDate;
        }

        private void BindAdvanceMoneyCustomerEntity(AdvanceMoneyCustomer amc)
        {
            amc.AdvanceMoneyCustomerID = Guid.NewGuid().ToString();
            amc.MeterBillID = vm.MeterBillID;
            amc.ForMonth = DateTime.Now.Date;
            amc.AdvanceMonthAmount = Convert.ToDecimal(txtChangeAmt.Text);
            amc.Active = true;
            amc.CreatedDate = DateTime.Now;
            amc.CreatedUserID = UserID;

        }

        private void BindMeterBillEntity(MeterBill mb)
        {
            mb.MeterBillID = vm.MeterBillID;
            mb.MeterBillCode = vm.MeterBillCode;
            mb.InvoiceDate = vm.InvoiceDate;
            mb.LastBillPaidDate = vm.LastBillPaidDate;
            mb.ServicesFees = vm.ServicesFees;
            mb.MeterFees = vm.MeterFees;
            /*mb.TotalFees = Convert.ToDecimal(txtFinalTotalFees.Text);*/ //vm.TotalFees;
            mb.StreetLightFees = vm.StreetLightFees;
            mb.UsageUnit = vm.UsageUnit;
            mb.CurrentMonthUnit = vm.CurrentMonthUnit;
            mb.PreviousMonthUnit = vm.PreviousMonthUnit;

            if (rdoadvancemoney.Checked)
            {
                mb.AdvanceMoney = Convert.ToDecimal(txtChangeAmt.Text);
            }
            else
            {
                mb.AdvanceMoney = 0;
            }

            mb.isPaid = true;
            mb.Remark = vm.Remark;
            mb.BillPayDate = DateTime.Now.Date;
            mb.RecivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
            mb.HorsePowerFees = vm.HorsePowerFees;
            mb.AdditionalFees1 = vm.AdditionalFees1;
            mb.AdditionalFees2 = vm.AdditionalFees2;
            mb.AdditionalFees3 = vm.AdditionalFees3;
            mb.MeterUnitCollectID = vm.MeterUnitCollectID;
            mb.Active = true;
            mb.CreatedDate = vm.CreatedDate;
            mb.CreatedUserID = vm.CreatedUserID;
        }

        private bool CheckValidation()
        {
            if (String.IsNullOrWhiteSpace(txtpunishment.Text))
            {
                MessageBox.Show("Purnishment Money Not Be Blank!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpunishment.Focus();
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txtReceivedAmount.Text))
            {
                MessageBox.Show("Recieve Amount Not Be Blank!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReceivedAmount.Focus();
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txtChangeAmt.Text))
            {
                MessageBox.Show("Changes Amount Not Be Blank!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChangeAmt.Focus();
                return false;
            }
            else if (Convert.ToDecimal(txtReceivedAmount.Text) < Convert.ToDecimal(txtFinalTotalFees.Text))
            {
                MessageBox.Show("Recieve Amount is Less Than Final Total Fees", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (Convert.ToDecimal(txtFinalTotalFees.Text) < (Convert.ToDecimal(txtTotalFees.Text) - Convert.ToDecimal(txtAdvanceMoney.Text)))
            {
                MessageBox.Show("Final Total Fees is Less Than Total Fees", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        #endregion

        #region Button Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            if (CheckValidation())
            {
                //MeterBill mb = new MeterBill();
                //BindMeterBillEntity(mb);
                try
                {
                    var meterBillPayment = mbmsEntities.MeterBills.Where(x => x.MeterBillID == MeterBillId).FirstOrDefault();
                    meterBillPayment.isPaid = true;
                    meterBillPayment.BillPayDate = DateTime.Now.Date;
                    meterBillPayment.RecivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
                    if (rdoadvancemoney.Checked)
                    {
                        meterBillPayment.AdvanceMoney = Convert.ToDecimal(txtChangeAmt.Text);
                    }
                    else
                    {
                        meterBillPayment.AdvanceMoney = 0;
                    }
                    mbmsEntities.SaveChanges();

                    if (rdoadvancemoney.Checked)
                    {
                        AdvanceMoneyCustomer amc = new AdvanceMoneyCustomer();
                        BindAdvanceMoneyCustomerEntity(amc);
                        if (advanceMoneyCustomerServices.SaveAdvanceMoney(amc))
                        {
                        }
                    }//end of Advance Money save
                    if (Convert.ToDecimal(txtpunishment.Text) > 0)
                    {
                        PunishmentCustomer pc = new PunishmentCustomer();
                        BindPunishmentCustomerEntity(pc);
                        if (punishmentCutomerServices.Save(pc))
                        {
                        }//end of Punishment Customer function save
                    }
                    MessageBox.Show("Payment is Complete Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (isPayment)
                    {
                        this.DialogResult = DialogResult.OK;
                        ReportViewer rv = new ReportViewer();
                        string appFolder = Path.GetDirectoryName(Application.ExecutablePath);
                        string reportPath = Path.Combine(appFolder, @"Print\MeterBillPrint.rdlc");
                        rv.LocalReport.ReportPath = reportPath;

                        ReportParameter BillPayDate = new ReportParameter("BillPayDate", Convert.ToString(DateTime.Now));
                        rv.LocalReport.SetParameters(BillPayDate);
                        ReportParameter RecieveAmount = new ReportParameter("RecieveAmount", meterBillPayment.TotalFees.ToString());
                        rv.LocalReport.SetParameters(RecieveAmount);
                        Utility.Get_Print(rv);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }




            }//end of meter bill payment paid 
        }

        #endregion

        #region Key Down
        private void txtReceivedAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChangeAmt.Text = (Convert.ToDecimal(txtReceivedAmount.Text) - Convert.ToDecimal(txtFinalTotalFees.Text)).ToString();
            }
        }
        #endregion

        #region Key press
        private void OnlyAllowforNumericKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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

        #region Leave
        private void txtReceivedAmount_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtReceivedAmount.Text))
            {
                txtChangeAmt.Text = (Convert.ToDecimal(txtReceivedAmount.Text) - Convert.ToDecimal(txtFinalTotalFees.Text)).ToString();

            }
        }
        #endregion

        #region Text Change

        private void txtpunishment_TextChanged(object sender, EventArgs e)
        {
            decimal totalfees = Convert.ToDecimal(!String.IsNullOrWhiteSpace(txtTotalFees.Text) ? txtTotalFees.Text : "0");
            decimal advanceMoney = Convert.ToDecimal(!String.IsNullOrWhiteSpace(txtAdvanceMoney.Text) ? txtAdvanceMoney.Text : "0");
            decimal punishment = Convert.ToDecimal(!String.IsNullOrWhiteSpace(txtpunishment.Text) ? txtpunishment.Text : "0");
            txtFinalTotalFees.Text = ((totalfees + punishment) - advanceMoney).ToString("#,0.00");
        }

        private void txtAdvanceMoney_TextChanged(object sender, EventArgs e)
        {
            decimal totalfees = Convert.ToDecimal(!String.IsNullOrWhiteSpace(txtTotalFees.Text) ? txtTotalFees.Text : "0");
            decimal advanceMoney = Convert.ToDecimal(!String.IsNullOrWhiteSpace(txtAdvanceMoney.Text) ? txtAdvanceMoney.Text : "0");
            decimal punishment = Convert.ToDecimal(!String.IsNullOrWhiteSpace(txtpunishment.Text) ? txtpunishment.Text : "0");
            txtFinalTotalFees.Text = ((totalfees + punishment) - advanceMoney).ToString("#,0.00");
        }

        private void txtReceivedAmount_TextChanged(object sender, EventArgs e)
        {
            decimal totalfees = Convert.ToDecimal(!String.IsNullOrWhiteSpace(txtFinalTotalFees.Text) ? txtFinalTotalFees.Text : "0");
            decimal recieveAmount = Convert.ToDecimal(!String.IsNullOrWhiteSpace(txtReceivedAmount.Text) ? txtReceivedAmount.Text : "0");
            txtChangeAmt.Text = (recieveAmount - totalfees).ToString("#,0.00");
        }
        #endregion
    }
}
