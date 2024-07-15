using MBMS.DAL;
using MPS.BusinessLogic.MeterBillCalculationController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.MeterBillCalculation
{
    public partial class MeterBillCalculate : Form

    {

        #region vairable & initialize Componemt
        public string UserID { get; set; }
        public int meterMultiplier { get; set; }
        IMeterBillCalculateServices meterbillcalculateservice;


        #endregion

        public MeterBillCalculate()
        {
            InitializeComponent();
            meterbillcalculateservice = new MeterBillCalculateController();
        }
        private bool CheckRequireField()
        {
            MBMSEntities mbmsEntites = new MBMSEntities();
            DateTime fromDate = dtpfromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            if (cboQuarter.Text.Equals("Select One"))
            {
                MessageBox.Show("Select quarter to calculate meter bill", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            var checkPreviousToDate = mbmsEntites.MeterUnitCollects.Where(x => x.ToDate.Month != dtpToDate.Value.Month && x.ToDate < dtpToDate.Value.Date && x.Active == true && x.TransformerID == cbotransformer.SelectedValue).OrderByDescending(x => x.ToDate).Select(x => x.ToDate).FirstOrDefault();

            if (checkPreviousToDate != default(DateTime))
            {
                var checkTodateInMeterBill = mbmsEntites.MeterBills.Where(x => x.Active == true && x.isPaid == false && x.MeterUnitCollect.TransformerID == cbotransformer.SelectedValue).OrderByDescending(x => x.InvoiceDate).Select(x => x.InvoiceDate).FirstOrDefault();
                if (checkTodateInMeterBill == default(DateTime) && checkPreviousToDate.Month != checkTodateInMeterBill.Month)
                {
                    MessageBox.Show("Previous Month Should Be Calculate First", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (meterbillcalculateservice.checkIsPaidStatusBeforeCalculate(dtpfromDate.Value, dtpToDate.Value, cbotransformer.SelectedValue.ToString()))
            {
                MessageBox.Show("Sorry :(  payment had paid can't re-process again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //if (meterbillcalculateservice.checkAdvanceMoneyCustomerListBeforeCalculate(dtpfromDate.Value, dtpToDate.Value))
            //{
            //    MessageBox.Show("Sorry :(  check Advance Money Customer List Before Calculate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //if (meterbillcalculateservice.checkPunishmentCustomerListBeforeCalculate(dtpfromDate.Value, dtpToDate.Value))
            //{
            //    MessageBox.Show("Sorry :(  check Punishment Customer List Before Calculate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            List<ManualMeterUnitCollect> checkManualUnit = mbmsEntites.ManualMeterUnitCollects.Where(x => x.Transformer.TransformerName == cbotransformer.Text && (x.FromDate >= fromDate && x.ToDate <= toDate) && x.Active == true).ToList();
            if (checkManualUnit.Count != 0)
            {
                MessageBox.Show("Please, Add Meter Unit In Manual Meter Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            List<MeterBill> checkMeterBill = mbmsEntites.MeterBills.Where(x => x.InvoiceDate >= fromDate && x.InvoiceDate <= toDate && x.Active == true && x.MeterUnitCollect.Transformer.TransformerName == cbotransformer.Text).ToList();
            if (checkMeterBill.Count != 0)
            {
                MessageBox.Show("This Month Meter Unit Had Calculated, Can't Calculate Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            return true;
        }

        #region Click Event
        private void btnbillprocess_Click(object sender, EventArgs e)
        {
            if (CheckRequireField())
            {
                MBMSEntities mbmsEnties = new MBMSEntities();

                List<MBMS.DAL.MeterUnitCollect> dataList = getMeterUnitCollect(dtpfromDate.Value, dtpToDate.Value, this.cbotransformer.SelectedValue.ToString(), cboQuarter.SelectedValue.ToString());

                if (dataList.Count == 0)
                {
                    MessageBox.Show("There is no meter unit collection record!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    List<Customer> checkBillCode = new List<Customer>();
                    checkBillCode = (from cus in mbmsEnties.Customers
                                     join muc in mbmsEnties.MeterUnitCollects on cus.CustomerID equals muc.CustomerID
                                     where cus.BillDayGroupCode == null && cus.Active == true && cus.Transformer.TransformerName == cbotransformer.Text
                                     select cus).ToList();
                    if (checkBillCode.Count != 0)
                    {
                        MessageBox.Show("Firstly, Please Add Bill Code Due Date For Customer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (IsBillCalculateSuccess(dataList, dtpfromDate.Value, dtpToDate.Value))
                {
                    MessageBox.Show("Meter bill process is complete successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnViewInvoices_Click(object sender, EventArgs e)
        {
            ViewMeterBillInvoice viewMeterBillInvoice = new ViewMeterBillInvoice();
            viewMeterBillInvoice.UserID = UserID;
            viewMeterBillInvoice.fromDate = dtpfromDate.Value.Date;
            viewMeterBillInvoice.toDate = dtpToDate.Value.Date;
            viewMeterBillInvoice.TransformerID = cbotransformer.SelectedValue.ToString();
            viewMeterBillInvoice.QuarterID = cboQuarter.SelectedValue.ToString();
            viewMeterBillInvoice.isPassedByCalculateForm = true;
            viewMeterBillInvoice.Show();
        }
        #endregion

        #region Method
        private bool IsBillCalculateSuccess(List<MBMS.DAL.MeterUnitCollect> dataList, DateTime fromDate, DateTime toDate)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<MeterBill> meterbillList = new List<MeterBill>();
            try
            {
                foreach (MBMS.DAL.MeterUnitCollect item in dataList)
                {
                    MeterBill mb = new MeterBill();
                    int dueDate = mbmsEntities.BillDays.Where(x => x.Active == true && x.BillDayGroupCode == item.Customer.BillDayGroupCode).Select(x => x.DueDate).FirstOrDefault();

                    mb.MeterBillID = Guid.NewGuid().ToString();
                    mb.MeterBillCode = item.Customer.Meter.MeterNo;
                    mb.InvoiceDate = item.FromDate;
                    mb.LastBillPaidDate = DateTime.Now.AddDays(dueDate);
                    mb.ServicesFees = 0;
                    //getting multiplier value from customer's meter  value
                    meterMultiplier = (int)item.Customer.Meter.Multiplier;

                    StreetLightFee streetLightFeeEntity = mbmsEntities.StreetLightFees.Where(x => x.Active == true && x.QuarterID == item.Customer.QuarterID).FirstOrDefault();
                    if (streetLightFeeEntity == null)
                    {
                        mb.StreetLightFees = Utility.SettingController.StreetLightFees;
                    }
                    else
                    {
                        mb.StreetLightFees = streetLightFeeEntity.Amount;
                    }
                    mb.HorsePowerFees = 0;
                    //multiply totol meter unit with multiplier value
                    mb.CurrentMonthUnit = (item.TotalMeterUnit * meterMultiplier);
                    var previousUnit = mbmsEntities.MeterUnitCollects.Where(m => m.CustomerID == item.CustomerID && m.MeterID == item.MeterID && m.ToDate != item.ToDate && m.ToDate < item.ToDate).OrderByDescending(m => m.ToDate).Select(m => m.TotalMeterUnit).FirstOrDefault();
                    if (previousUnit != null)
                    {
                        mb.PreviousMonthUnit = previousUnit;
                    }
                    else
                    {
                        mb.PreviousMonthUnit = 0;
                    }

                    mb.UsageUnit = (item.TotalMeterUnit - mb.PreviousMonthUnit);
                    mb.MeterFees = getMeterFeesAmountwith7LayerCode(item, mb.UsageUnit);
                    //calculate advance money 
                    //   mb.AdvanceMoney = 0;
                    mb.TotalFees = Convert.ToDecimal((mb.ServicesFees + mb.MeterFees + mb.StreetLightFees + mb.HorsePowerFees));

                    mb.CreditAmount = 0;
                    mb.BillPayDate = null;
                    mb.isPaid = false;
                    mb.Remark = "bill data for " + item.FromDate.ToString("MMMM");
                    mb.MeterUnitCollectID = item.MeterUnitCollectID;
                    mb.Active = true;
                    mb.CreatedDate = DateTime.Now;
                    mb.CreatedUserID = UserID;
                    meterbillList.Add(mb);
                }//end of foreach loop after adding Meter Bill List 
                meterbillcalculateservice.MeterBillCalculate(meterbillList, fromDate, toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occur" + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        //bill calculate with 7 Layer detail with Box Type(Flat or Block Type)
        private decimal getMeterFeesAmountwith7LayerCode(MBMS.DAL.MeterUnitCollect meterUnitCollect, decimal usageUnit)
        {
            decimal result = 0;
            decimal sumUnits = 0;
            BillCode7Layer billCode7Layer = meterbillcalculateservice.GetBillCode7LayerByBillCode(Convert.ToInt64(meterUnitCollect.Customer.BillCode7Layer.BillCode7LayerNo));
            List<BillCode7LayerDetail> billCode7LayerDetailList = meterbillcalculateservice.GetBillCode7LayerDetailByBillCode7LayerID(billCode7Layer.BillCode7LayerID).OrderBy(y => y.LowerLimit).ToList();
            foreach (BillCode7LayerDetail item in billCode7LayerDetailList)
            {
                if (billCode7Layer.BillCodeLayerType.Equals("Block Type"))
                {
                    //before calculate the value,multiply totol meter unit with multiplier value
                    if ((usageUnit * meterMultiplier) > (sumUnits + item.RateUnit))
                    {
                        result += (decimal)(item.RateUnit * item.AmountPerUnit);
                        sumUnits += (decimal)item.RateUnit;
                    }
                    else
                    {
                        decimal diffUnits = usageUnit - sumUnits;
                        result += (decimal)diffUnits * item.AmountPerUnit;
                        if ((diffUnits + sumUnits) == usageUnit)
                        {
                            return result;
                        }
                    }//end of else 
                }//end of Block Type condition
                else
                {
                    result = usageUnit * item.AmountPerUnit;
                }
            }//end of foreach loop
            return result;
        }//end of method

        private List<MBMS.DAL.MeterUnitCollect> getMeterUnitCollect(DateTime fromdate, DateTime todate, string TransformerID, string QuaeterID)
        {
            List<MBMS.DAL.MeterUnitCollect> data = meterbillcalculateservice.MeterUnitCollect(fromdate, todate, TransformerID, QuaeterID);
            return data;
        }

        private void InitialState()
        {
            if (!CheckingRoleManagementFeature("BillProcessAdd"))
            {
                btnbillprocess.Enabled = false;
            }
            if (!CheckingRoleManagementFeature("BillProcessView"))
                btnViewInvoices.Enabled = false;
        }


        #endregion

        #region Page Load
        private void MeterBillCalculate_Load(object sender, EventArgs e)
        {
            dtpfromDate.Format = DateTimePickerFormat.Custom;
            dtpfromDate.CustomFormat = "MM/dd/yyyy";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "MM/dd/yyyy";
            InitialState();
            bindQuarterData();
            bindTransformerData();           
        }

        private void bindQuarterData()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true).OrderBy(x => x.QuarterNameInEng).ToList());
            cboQuarter.DataSource = quarterList;
            cboQuarter.DisplayMember = "QuarterNameInEng";
            cboQuarter.ValueMember = "QuarterID";
        }

        private void bindTransformerData()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Transformer> transformerList = new List<Transformer>();
            Transformer transformer = new Transformer();
            transformer.TransformerID = Convert.ToString(0);
            transformer.TransformerName = "Select";
            transformerList.Add(transformer);
            transformerList.AddRange(mbmsEntities.Transformers.Where(x => x.Quarter.QuarterNameInEng == cboQuarter.Text && x.Active == true).ToList());
            cbotransformer.DataSource = transformerList;
            cbotransformer.DisplayMember = "TransformerName";
            cbotransformer.ValueMember = "TransformerID";
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

        #region cboQuarter SelectedIndex Change Event
        private void cboQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindTransformerData();            

        }
        #endregion

    }
}
