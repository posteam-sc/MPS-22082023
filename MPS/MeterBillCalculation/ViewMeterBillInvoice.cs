using MBMS.DAL;
using MPS.BusinessLogic.MeterBillCalculationController;
using MPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using static MPS.Utility;

namespace MPS.MeterBillCalculation
{
    public partial class ViewMeterBillInvoice : Form
    {
        #region Variables
        public bool isPassedByCalculateForm { get; set; }
        public string UserID { get; set; }
        MBMSEntities mbmsEntities = new MBMSEntities();
        IMeterBillCalculateServices meterbillcalculateservice;
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string QuarterID { get; set; }
        public string TransformerID { get; set; }
        IMeterBillCalculateServices meterBillCalculateServices;
        #endregion
        public ViewMeterBillInvoice()
        {
            InitializeComponent();
            meterBillCalculateServices = new MeterBillCalculateController();
            meterbillcalculateservice = new MeterBillCalculateController();
        }
        static int RowIndex=0;
        #region Form Load
        private void ViewMeterBillInvoice_Load(object sender, EventArgs e)
        {
            gvmeterbillinvoice.AutoGenerateColumns = false;
            if (isPassedByCalculateForm)
            {
                dtpFromDate.Value = fromDate;
                dtptoDate.Value = toDate;
                cboQuarter.SelectedValue = QuarterID;
                cbotransformer.SelectedValue = TransformerID;
                bindQuarterData();
                bindTransformerData();
                gvmeterbillinvoice.DataSource = meterBillCalculateServices.GetmeterBillInvoices(fromDate, toDate, TransformerID, QuarterID, string.Empty, string.Empty);
            }
            else
            {
                BidnigData();
                this.bindQuarterData();
                this.bindTransformerData();
            }

            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "MM/dd/yyyy";
            dtptoDate.Format = DateTimePickerFormat.Custom;
            dtptoDate.CustomFormat = "MM/dd/yyyy";
        }
        #endregion

        #region Datagrid Cell Click
        private void gvmeterbillinvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Edit function
                if (e.ColumnIndex == 20)
                {

                    if (!CheckingRoleManagementFeature())
                    {
                        MessageBox.Show("Access Deined for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataGridViewRow row = gvmeterbillinvoice.Rows[e.RowIndex];
                    MeterBillInvoiceVM meterBillInvoice = (MeterBillInvoiceVM)row.DataBoundItem;//get the selected row's data                    
                    UpdateMeterbillInvoiceRecrod meterbillinvoiceUI = new UpdateMeterbillInvoiceRecrod();
                    meterbillinvoiceUI.vm = meterBillInvoice;
                    meterbillinvoiceUI.isEdit = true;
                    var result = meterbillinvoiceUI.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        btnSearch_Click(this, new EventArgs());
                    }
                }//end of edit function              
                //print function 
                if (e.ColumnIndex == 21)//do the print Link action
                {
                    DialogResult result = MessageBox.Show("Are you sure  want to print?", "printing",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        RowIndex = e.RowIndex;
                        #endregion
                        PrintDocument pd = new PrintDocument();

                        pd.PrintPage += new PrintPageEventHandler(PrintMeterReceipt);
                        int copy = Convert.ToInt32(SettingController.DefaultNoOfCopies);
                        pd.PrinterSettings.PrinterName = GetDefaultPrinter();
                        for (int i = 0; i < copy; i++)
                        {
                            pd.Print();
                        }
                    }
                }
            }
        }
        public void PrintMeterReceipt(object sender, PrintPageEventArgs ev)
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();
                DataGridViewRow row = gvmeterbillinvoice.Rows[RowIndex];//get the selected row's data and then 
                                                                          //MeterBillInvoiceVM meterBillInvoice = (MeterBillInvoiceVM)row.DataBoundItem;//get the selected row's data 
                var meterBillID = Convert.ToString(gvmeterbillinvoice.Rows[RowIndex].Cells[0].Value);
                var meterBillInvoice = (from mb in mbmsEntities.MeterBills
                                        join mbc in mbmsEntities.MeterUnitCollects on mb.MeterUnitCollectID equals mbc.MeterUnitCollectID
                                        join custo in mbmsEntities.Customers on mbc.CustomerID equals custo.CustomerID
                                        join billcode in mbmsEntities.BillCode7Layer on custo.BillCode7LayerID equals billcode.BillCode7LayerID
                                        join meterno in mbmsEntities.Meters on custo.MeterID equals meterno.MeterID
                                        where mb.MeterBillID == meterBillID
                                        select mb).FirstOrDefault();
                var meterUnitFees = mbmsEntities.BillCode7LayerDetail.Where(x => x.BillCode7LayerID == meterBillInvoice.MeterUnitCollect.Customer.BillCode7LayerID && x.Active == true).Select(x => x.AmountPerUnit).FirstOrDefault();

                var meterBillNo = mbmsEntities.MeterBills.Where(x => x.LastBillPaidDate.Month == DateTime.Now.Month && x.isPaid == false).OrderByDescending(x => x.MeterBillNo).Select(x => x.MeterBillNo).FirstOrDefault();
                if (meterBillNo == null)
                {
                    meterBillInvoice.MeterBillNo = 0000001;
                }
                else if (meterBillInvoice.MeterBillNo == null)
                {
                    meterBillInvoice.MeterBillNo = meterBillNo + 1;
                }

                //Select Advance Money from PreviousMonth
                var advanceMoney = mbmsEntities.MeterBills.Where(x => x.Active == true && x.MeterUnitCollect.CustomerID == meterBillInvoice.MeterUnitCollect.CustomerID && x.isPaid == true).OrderByDescending(x => x.LastBillPaidDate).Select(x => x.AdvanceMoney).FirstOrDefault();
                decimal advMoney = 0;
                if (advanceMoney != null)
                {
                    advMoney = (decimal)advanceMoney;
                }
                mbmsEntities.SaveChanges();



                if (meterBillInvoice.MeterUnitCollect.Customer.BillCode7Layer.BillCodeLayerType == "Flat Type")
                {

                    float fSize = 6;


                    //if (!string.IsNullOrEmpty(AppSetting.ReceiptSize) && AppSetting.ReceiptSize == "58") fSize = 6;

                    //Create a font
                    System.Drawing.Font smallFont = new System.Drawing.Font("Arial", fSize);
                    System.Drawing.Font engFont = new System.Drawing.Font("Arial", 8);
                    System.Drawing.Font bFont = new System.Drawing.Font("Arial", fSize + 1);
                    System.Drawing.Font mmFont = new System.Drawing.Font("Myanmar3", fSize + 2, System.Drawing.FontStyle.Bold);
                    System.Drawing.Font bigFont = new System.Drawing.Font("Arial", fSize + 1, System.Drawing.FontStyle.Bold);
                    System.Drawing.Font biggerFont = new System.Drawing.Font("Arial", fSize + 6, System.Drawing.FontStyle.Regular);

                    System.Drawing.Font barCodeFont = new System.Drawing.Font("Free 3 of 9", 15, System.Drawing.FontStyle.Bold);
                   // Font threeOfNine = new System.Drawing.Font("IDAutomationHC39M", 15, FontStyle.Bold); //new Font("Free 3 of 9", 31, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);


                    //Get the font's height            
                    float fontheight = bFont.GetHeight(ev.Graphics);
                    //Draw four strings

                    ev.Graphics.DrawString(meterBillInvoice.MeterUnitCollect.Customer.Quarter.QuarterNameInMM, mmFont, System.Drawing.Brushes.Black, 25, 20); 

                    ev.Graphics.DrawString(meterBillInvoice.MeterUnitCollect.Customer.CustomerNameInMM, mmFont, System.Drawing.Brushes.Black, 25, 50); 
                    ev.Graphics.DrawString(meterBillInvoice.MeterUnitCollect.Customer.CustomerAddressInMM, mmFont, System.Drawing.Brushes.Black, 25, 80); 
                    ev.Graphics.DrawString(Utility.SettingController.CompanyName, bigFont, System.Drawing.Brushes.Black, 195, 20);
                    ev.Graphics.DrawString(meterBillInvoice.LastBillPaidDate.ToString("dd/MM/yyyy"), engFont, System.Drawing.Brushes.Black, 230, 81);

                    ev.Graphics.DrawString(meterBillInvoice.MeterBillNo.ToString().PadLeft(8, '0'), engFont, System.Drawing.Brushes.Black, 120, 137);
                    ev.Graphics.DrawString(meterBillInvoice.InvoiceDate.ToString("dd/MM/yyyy")+" ~ "+ meterBillInvoice.InvoiceDate.AddMonths(1).ToString("dd/MM/yyyy"), bFont, System.Drawing.Brushes.Black, 120, 160);
                    ev.Graphics.DrawString(meterBillInvoice.MeterUnitCollect.Meter.MeterNo+"         "+ meterBillInvoice.MeterUnitCollect.BillCode+ "                    " + meterBillInvoice.PreviousMonthUnit.ToString()+ "                  " + meterBillInvoice.CurrentMonthUnit.ToString() + "               " + meterBillInvoice.UsageUnit.ToString(), bFont, System.Drawing.Brushes.Black, 22, 218);
                    ev.Graphics.DrawString((Convert.ToString(meterUnitFees) + " " + "x" + " " + Convert.ToString(meterBillInvoice.UsageUnit) + " " + "=" + " " + Convert.ToString(meterBillInvoice.MeterFees)), bFont, System.Drawing.Brushes.Black, 150, 250);
                    ev.Graphics.DrawString("-------------------------------------------", bFont, System.Drawing.Brushes.Black, 120, 265);
                    ev.Graphics.DrawString("Total        " + (Convert.ToString(meterBillInvoice.UsageUnit) + " " + "=" + " " + Convert.ToString(meterBillInvoice.MeterFees)), bFont, System.Drawing.Brushes.Black, 122, 285);
                    Bitmap bitmap = new Bitmap(meterBillInvoice.MeterBillCode.Length, 50);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        Font ofont = new System.Drawing.Font("3 of 9 Barcode", 20);
                        PointF point = new PointF(355, 30);
                        SolidBrush black = new SolidBrush(Color.Black);
                        SolidBrush White = new SolidBrush(Color.White);
                        ev.Graphics.FillRectangle(White, 355, 30, 50, bitmap.Height);
                        ev.Graphics.DrawString("*" + meterBillInvoice.MeterBillCode + "*", ofont, black, point);

                        PointF point2 = new PointF(580, 450);
                        ev.Graphics.FillRectangle(White, 580, 450, 50, bitmap.Height);
                        ev.Graphics.DrawString("*" + meterBillInvoice.MeterBillCode + "*", ofont, black, point2);
                    }
                   
                    ev.Graphics.DrawString(Utility.SettingController.PhoneNo, engFont, System.Drawing.Brushes.Black, 300, 420);
                    //ev.Graphics.DrawString("*" + meterBillInvoice.MeterBillCode + "*", threeOfNine, System.Drawing.Brushes.Black, 400, 30);
                    ev.Graphics.DrawString(Utility.SettingController.BranchCode+"-" + meterBillInvoice.MeterUnitCollect.Customer.CustomerCode, smallFont, System.Drawing.Brushes.Black, 445, 50);
                    //ev.Graphics.DrawString("*" + meterBillInvoice.MeterBillCode + "*", threeOfNine, System.Drawing.Brushes.Black, 600, 500);
                    ev.Graphics.DrawString(Utility.SettingController.BranchCode+"-" + meterBillInvoice.MeterUnitCollect.Customer.CustomerCode, smallFont, System.Drawing.Brushes.Black, 668, 470);

                    ev.Graphics.DrawString((Convert.ToString(meterBillInvoice.MeterUnitCollect.Customer.Ledger.BookCode) + @"/" + Convert.ToString(meterBillInvoice.MeterUnitCollect.Customer.PageNo) + @"/" + Convert.ToString(meterBillInvoice.MeterUnitCollect.Customer.LineNo)), engFont, System.Drawing.Brushes.Black, 450, 67);
                    ev.Graphics.DrawString(meterBillInvoice.ServicesFees.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 450, 90);
                    ev.Graphics.DrawString(meterBillInvoice.MeterFees.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 450, 116);
                    ev.Graphics.DrawString(meterBillInvoice.StreetLightFees.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 450, 139);
                    ev.Graphics.DrawString(meterBillInvoice.TotalFees.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 450, 160);
                    ev.Graphics.DrawString(meterBillInvoice.CreditAmount.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 450, 192);
                    
                    ev.Graphics.DrawString(meterBillInvoice.TotalFees.ToString()+" Ks", biggerFont, System.Drawing.Brushes.Black, 420, 299);

                    ev.Graphics.DrawString(Utility.SettingController.CompanyName, bigFont, System.Drawing.Brushes.Black, 625, 38);
                    ev.Graphics.DrawString(meterBillInvoice.InvoiceDate.ToString("MMM-yyyy") , smallFont, System.Drawing.Brushes.Black, 673, 50);
                    ev.Graphics.DrawString(meterBillInvoice.MeterBillNo.ToString().PadLeft(8, '0'), engFont, System.Drawing.Brushes.Black, 690, 117);
                    ev.Graphics.DrawString((Convert.ToString(meterBillInvoice.MeterUnitCollect.Customer.Ledger.BookCode) + @"/" + Convert.ToString(meterBillInvoice.MeterUnitCollect.Customer.PageNo) + @"/" + Convert.ToString(meterBillInvoice.MeterUnitCollect.Customer.LineNo)), engFont, System.Drawing.Brushes.Black, 690, 147);
                    ev.Graphics.DrawString(meterBillInvoice.ServicesFees.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 690, 170);
                    ev.Graphics.DrawString(meterBillInvoice.MeterFees.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 690, 195);
                    ev.Graphics.DrawString(meterBillInvoice.StreetLightFees.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 690, 219);
                    ev.Graphics.DrawString(meterBillInvoice.TotalFees.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 690, 240);
                    ev.Graphics.DrawString(meterBillInvoice.CreditAmount.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 690, 273);
                    if (advanceMoney != null)
                    {
                        ev.Graphics.DrawString(advanceMoney.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 450, 228);

                        ev.Graphics.DrawString(advanceMoney.ToString() + " Ks", engFont, System.Drawing.Brushes.Black, 690, 309);

                    }
                    else
                    {
                        ev.Graphics.DrawString(advanceMoney.ToString(), engFont, System.Drawing.Brushes.Black, 450, 228);

                        ev.Graphics.DrawString(advanceMoney.ToString(), engFont, System.Drawing.Brushes.Black, 690, 309);
                    }
                    ev.Graphics.DrawString(meterBillInvoice.TotalFees.ToString() + " Ks", biggerFont, System.Drawing.Brushes.Black, 660, 380);


                    
                }

                //#region Block Type
                //else
                //{

                //    var meterUnitCalculate = mbmsEntities.BillCode7LayerDetail.Where(x => x.BillCode7LayerID == meterBillInvoice.MeterUnitCollect.Customer.BillCode7LayerID && x.Active == true).OrderBy(x => x.LowerLimit).ToList();



                //    ReportViewer rv = new ReportViewer();

                //    string appFolder = Path.GetDirectoryName(Application.ExecutablePath);
                //    string reportPath = Path.Combine(appFolder, @"Print\MeterBillCalculateBlockType.rdlc");
                //    rv.LocalReport.ReportPath = reportPath;

                //    ReportParameter BillMonth = new ReportParameter("BillMonth", meterBillInvoice.InvoiceDate.ToShortDateString());
                //    rv.LocalReport.SetParameters(BillMonth);

                //    ReportParameter MeterBillCode = new ReportParameter("MeterBillCode", meterBillInvoice.MeterBillNo.ToString().PadLeft(8, '0'));
                //    rv.LocalReport.SetParameters(MeterBillCode);

                //    ReportParameter InvoiceDate = new ReportParameter("InvoiceDate", Convert.ToString(meterBillInvoice.InvoiceDate.ToShortDateString()));
                //    rv.LocalReport.SetParameters(InvoiceDate);
                //    ReportParameter LastMeterDate = new ReportParameter("LastMeterDate", Convert.ToString(meterBillInvoice.InvoiceDate.AddMonths(1).ToShortDateString()));
                //    rv.LocalReport.SetParameters(LastMeterDate);
                //    ReportParameter LastBillPaidDate = new ReportParameter("LastBillPaidDate", meterBillInvoice.LastBillPaidDate.ToShortDateString());
                //    rv.LocalReport.SetParameters(LastBillPaidDate);
                //    ReportParameter ServiceFees = new ReportParameter("ServiceFees", meterBillInvoice.ServicesFees.ToString());
                //    rv.LocalReport.SetParameters(ServiceFees);
                //    ReportParameter MeterFees = new ReportParameter("MeterFees", meterBillInvoice.MeterFees.ToString());
                //    rv.LocalReport.SetParameters(MeterFees);
                //    ReportParameter StreetLightFees = new ReportParameter("StreetLightFees", meterBillInvoice.StreetLightFees.ToString());
                //    rv.LocalReport.SetParameters(StreetLightFees);
                //    ReportParameter TotalFees = new ReportParameter("TotalFees", meterBillInvoice.TotalFees.ToString());
                //    rv.LocalReport.SetParameters(TotalFees);


                //    ReportParameter AdvanceMoney = new ReportParameter("AdvanceMoney", advanceMoney.ToString());
                //    rv.LocalReport.SetParameters(AdvanceMoney);


                //    ReportParameter ActualFees = new ReportParameter("ActualFees", (meterBillInvoice.TotalFees).ToString());
                //    rv.LocalReport.SetParameters(ActualFees);

                //    decimal creditAmount;
                //    if (meterBillInvoice.CreditAmount == null)
                //    {
                //        creditAmount = 0.00M;
                //        ReportParameter CreditAmt = new ReportParameter("CreditAmt", creditAmount.ToString());
                //        rv.LocalReport.SetParameters(CreditAmt);
                //    }
                //    else
                //    {
                //        ReportParameter CreditAmt = new ReportParameter("CreditAmt", meterBillInvoice.CreditAmount.ToString());
                //        rv.LocalReport.SetParameters(CreditAmt);
                //    }

                //    ReportParameter CustomerName = new ReportParameter("CustomerName", meterBillInvoice.MeterUnitCollect.Customer.CustomerNameInMM);
                //    rv.LocalReport.SetParameters(CustomerName);
                //    ReportParameter CustomerAddress = new ReportParameter("CustomerAddress", meterBillInvoice.MeterUnitCollect.Customer.CustomerAddressInMM);
                //    rv.LocalReport.SetParameters(CustomerAddress);
                //    ReportParameter MeterNo = new ReportParameter("MeterNo", meterBillInvoice.MeterUnitCollect.Meter.MeterNo);
                //    rv.LocalReport.SetParameters(MeterNo);
                //    ReportParameter BillCodeNo = new ReportParameter("BillCodeNo", meterBillInvoice.MeterUnitCollect.BillCode);
                //    rv.LocalReport.SetParameters(BillCodeNo);
                //    ReportParameter PreviousUsageUnit = new ReportParameter("PreviousUsageUnit", meterBillInvoice.PreviousMonthUnit.ToString());
                //    rv.LocalReport.SetParameters(PreviousUsageUnit);
                //    ReportParameter CurrentUnit = new ReportParameter("CurrentUnit", meterBillInvoice.CurrentMonthUnit.ToString());
                //    rv.LocalReport.SetParameters(CurrentUnit);
                //    ReportParameter UsageUnit = new ReportParameter("UsageUnit", meterBillInvoice.UsageUnit.ToString());
                //    rv.LocalReport.SetParameters(UsageUnit);
                //    ReportParameter QuarterName = new ReportParameter("QuarterName", meterBillInvoice.MeterUnitCollect.Customer.Quarter.QuarterNameInMM);
                //    rv.LocalReport.SetParameters(QuarterName);
                //    ReportParameter LedgerCode = new ReportParameter("LedgerCode", meterBillInvoice.MeterUnitCollect.Customer.Ledger.BookCode + @"/" + meterBillInvoice.MeterUnitCollect.Customer.PageNo + @"/" + meterBillInvoice.MeterUnitCollect.Customer.LineNo);
                //    rv.LocalReport.SetParameters(LedgerCode);
                //    ReportParameter Barcode = new ReportParameter("Barcode", meterBillInvoice.MeterBillCode);
                //    rv.LocalReport.SetParameters(Barcode);

                //    ReportParameter BarCodeName = new ReportParameter("BarCodeName", Utility.SettingController.BranchCode + "-" + meterBillInvoice.MeterUnitCollect.Customer.CustomerCode);
                //    rv.LocalReport.SetParameters(BarCodeName);

                //    ReportParameter CompanyName = new ReportParameter("CompanyName", Utility.SettingController.CompanyName);
                //    rv.LocalReport.SetParameters(CompanyName);
                //    ReportParameter PhoneNumber = new ReportParameter("PhoneNumber", Utility.SettingController.PhoneNo);
                //    rv.LocalReport.SetParameters(PhoneNumber);

                //    #region Meter Unit  and Amountper Unit Parameter
                //    //Meter Unit and Amount per Unit from billcode 7 layer Detail

                //    ReportParameter Unit1 = new ReportParameter("Unit1", ((int)meterUnitCalculate[0].LowerLimit + "-" + (int)meterUnitCalculate[0].UpperLimit + " " + "Unit").ToString());
                //    rv.LocalReport.SetParameters(Unit1);

                //    ReportParameter AmountPerUnit1 = new ReportParameter("AmountPerUnit1", ((int)meterUnitCalculate[0].AmountPerUnit).ToString());
                //    rv.LocalReport.SetParameters(AmountPerUnit1);

                //    ReportParameter Unit2 = new ReportParameter("Unit2", ((int)meterUnitCalculate[1].LowerLimit + "-" + (int)meterUnitCalculate[1].UpperLimit + " " + "Unit").ToString());
                //    rv.LocalReport.SetParameters(Unit2);

                //    ReportParameter AmountPerUnit2 = new ReportParameter("AmountPerUnit2", ((int)meterUnitCalculate[1].AmountPerUnit).ToString());
                //    rv.LocalReport.SetParameters(AmountPerUnit2);

                //    ReportParameter Unit3 = new ReportParameter("Unit3", ((int)meterUnitCalculate[2].LowerLimit + "-" + (int)meterUnitCalculate[2].UpperLimit + " " + "Unit").ToString());
                //    rv.LocalReport.SetParameters(Unit3);

                //    ReportParameter AmountPerUnit3 = new ReportParameter("AmountPerUnit3", ((int)meterUnitCalculate[2].AmountPerUnit).ToString());
                //    rv.LocalReport.SetParameters(AmountPerUnit3);

                //    ReportParameter Unit4 = new ReportParameter("Unit4", ((int)meterUnitCalculate[3].LowerLimit + "-" + (int)meterUnitCalculate[3].UpperLimit + " " + "Unit").ToString());
                //    rv.LocalReport.SetParameters(Unit4);

                //    ReportParameter AmountPerUnit4 = new ReportParameter("AmountPerUnit4", ((int)meterUnitCalculate[3].AmountPerUnit).ToString());
                //    rv.LocalReport.SetParameters(AmountPerUnit4);

                //    ReportParameter Unit5 = new ReportParameter("Unit5", ((int)meterUnitCalculate[4].LowerLimit + "-" + (int)meterUnitCalculate[4].UpperLimit + " " + "Unit").ToString());
                //    rv.LocalReport.SetParameters(Unit5);

                //    ReportParameter AmountPerUnit5 = new ReportParameter("AmountPerUnit5", ((int)meterUnitCalculate[4].AmountPerUnit).ToString());
                //    rv.LocalReport.SetParameters(AmountPerUnit5);

                //    ReportParameter Unit6 = new ReportParameter("Unit6", ((int)meterUnitCalculate[5].LowerLimit + "-" + (int)meterUnitCalculate[5].UpperLimit + " " + "Unit").ToString());
                //    rv.LocalReport.SetParameters(Unit6);

                //    ReportParameter AmountPerUnit6 = new ReportParameter("AmountPerUnit6", ((int)meterUnitCalculate[5].AmountPerUnit).ToString());
                //    rv.LocalReport.SetParameters(AmountPerUnit6);

                //    ReportParameter Unit7 = new ReportParameter("Unit7", ((int)meterUnitCalculate[6].LowerLimit + " " + "Upper" + "Unit").ToString());
                //    rv.LocalReport.SetParameters(Unit7);

                //    ReportParameter AmountPerUnit7 = new ReportParameter("AmountPerUnit7", ((int)meterUnitCalculate[6].AmountPerUnit).ToString());
                //    rv.LocalReport.SetParameters(AmountPerUnit7);
                //    #endregion

                //    #region Calculate MeterBill And Insert Parameter
                //    decimal calculateUnit = 0;
                //    decimal calculateAmount = 0;
                //    decimal meterUnit = meterBillInvoice.UsageUnit;
                //    if (meterUnit >= meterUnitCalculate[0].LowerLimit && meterUnit <= meterUnitCalculate[0].UpperLimit)
                //    {
                //        ReportParameter CalculateUnit1 = new ReportParameter("CalculateUnit1", (meterUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit1);

                //        ReportParameter CalculateAmount1 = new ReportParameter("CalculateAmount1", (meterUnit * meterUnitCalculate[0].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount1);

                //        ReportParameter CalculateUnit2 = new ReportParameter("CalculateUnit2", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit2);

                //        ReportParameter CalculateAmount2 = new ReportParameter("CalculateAmount2", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount2);

                //        ReportParameter CalculateUnit3 = new ReportParameter("CalculateUnit3", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit3);

                //        ReportParameter CalculateAmount3 = new ReportParameter("CalculateAmount3", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount3);

                //        ReportParameter CalculateUnit4 = new ReportParameter("CalculateUnit4", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit4);

                //        ReportParameter CalculateAmount4 = new ReportParameter("CalculateAmount4", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount4);

                //        ReportParameter CalculateUnit5 = new ReportParameter("CalculateUnit5", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit5);

                //        ReportParameter CalculateAmount5 = new ReportParameter("CalculateAmount5", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount5);

                //        ReportParameter CalculateUnit6 = new ReportParameter("CalculateUnit6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit6);

                //        ReportParameter CalculateAmount6 = new ReportParameter("CalculateAmount6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount6);

                //        ReportParameter CalculateUnit7 = new ReportParameter("CalculateUnit7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit7);

                //        ReportParameter CalculateAmount7 = new ReportParameter("CalculateAmount7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount7);
                //    }
                //    else if (meterUnit >= meterUnitCalculate[1].LowerLimit && meterUnit <= meterUnitCalculate[1].UpperLimit)
                //    {
                //        ReportParameter CalculateUnit1 = new ReportParameter("CalculateUnit1", (meterUnitCalculate[0].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit1);

                //        ReportParameter CalculateAmount1 = new ReportParameter("CalculateAmount1", (meterUnitCalculate[0].RateUnit * meterUnitCalculate[0].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount1);

                //        ReportParameter CalculateUnit2 = new ReportParameter("CalculateUnit2", (meterUnit - meterUnitCalculate[0].UpperLimit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit2);

                //        ReportParameter CalculateAmount2 = new ReportParameter("CalculateAmount2", ((meterUnitCalculate[0].UpperLimit - meterUnit) * meterUnitCalculate[1].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount2);

                //        ReportParameter CalculateUnit3 = new ReportParameter("CalculateUnit3", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit3);

                //        ReportParameter CalculateAmount3 = new ReportParameter("CalculateAmount3", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount3);

                //        ReportParameter CalculateUnit4 = new ReportParameter("CalculateUnit4", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit4);

                //        ReportParameter CalculateAmount4 = new ReportParameter("CalculateAmount4", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount4);

                //        ReportParameter CalculateUnit5 = new ReportParameter("CalculateUnit5", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit5);

                //        ReportParameter CalculateAmount5 = new ReportParameter("CalculateAmount5", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount5);

                //        ReportParameter CalculateUnit6 = new ReportParameter("CalculateUnit6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit6);

                //        ReportParameter CalculateAmount6 = new ReportParameter("CalculateAmount6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount6);

                //        ReportParameter CalculateUnit7 = new ReportParameter("CalculateUnit7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit7);

                //        ReportParameter CalculateAmount7 = new ReportParameter("CalculateAmount7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount7);
                //    }
                //    else if (meterUnit >= meterUnitCalculate[2].LowerLimit && meterUnit <= meterUnitCalculate[2].UpperLimit)
                //    {
                //        ReportParameter CalculateUnit1 = new ReportParameter("CalculateUnit1", (meterUnitCalculate[0].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit1);

                //        ReportParameter CalculateAmount1 = new ReportParameter("CalculateAmount1", (meterUnitCalculate[0].RateUnit * meterUnitCalculate[0].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount1);

                //        ReportParameter CalculateUnit2 = new ReportParameter("CalculateUnit2", (meterUnitCalculate[1].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit2);

                //        ReportParameter CalculateAmount2 = new ReportParameter("CalculateAmount2", (meterUnitCalculate[1].RateUnit * meterUnitCalculate[1].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount2);

                //        ReportParameter CalculateUnit3 = new ReportParameter("CalculateUnit3", (meterUnit - (meterUnitCalculate[0].RateUnit + meterUnitCalculate[1].RateUnit)).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit3);

                //        ReportParameter CalculateAmount3 = new ReportParameter("CalculateAmount3", ((meterUnit - (meterUnitCalculate[0].RateUnit + meterUnitCalculate[1].RateUnit)) * meterUnitCalculate[2].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount3);

                //        ReportParameter CalculateUnit4 = new ReportParameter("CalculateUnit4", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit4);

                //        ReportParameter CalculateAmount4 = new ReportParameter("CalculateAmount4", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount4);

                //        ReportParameter CalculateUnit5 = new ReportParameter("CalculateUnit5", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit5);

                //        ReportParameter CalculateAmount5 = new ReportParameter("CalculateAmount5", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount5);

                //        ReportParameter CalculateUnit6 = new ReportParameter("CalculateUnit6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit6);

                //        ReportParameter CalculateAmount6 = new ReportParameter("CalculateAmount6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount6);

                //        ReportParameter CalculateUnit7 = new ReportParameter("CalculateUnit7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit7);

                //        ReportParameter CalculateAmount7 = new ReportParameter("CalculateAmount7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount7);
                //    }
                //    else if (meterUnit >= meterUnitCalculate[3].LowerLimit && meterUnit <= meterUnitCalculate[3].UpperLimit)
                //    {
                //        ReportParameter CalculateUnit1 = new ReportParameter("CalculateUnit1", (meterUnitCalculate[0].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit1);

                //        ReportParameter CalculateAmount1 = new ReportParameter("CalculateAmount1", (meterUnitCalculate[0].RateUnit * meterUnitCalculate[0].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount1);

                //        ReportParameter CalculateUnit2 = new ReportParameter("CalculateUnit2", (meterUnitCalculate[1].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit2);

                //        ReportParameter CalculateAmount2 = new ReportParameter("CalculateAmount2", (meterUnitCalculate[1].RateUnit * meterUnitCalculate[1].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount2);

                //        ReportParameter CalculateUnit3 = new ReportParameter("CalculateUnit3", (meterUnitCalculate[2].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit3);

                //        ReportParameter CalculateAmount3 = new ReportParameter("CalculateAmount3", (meterUnitCalculate[2].RateUnit * meterUnitCalculate[2].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount3);

                //        ReportParameter CalculateUnit4 = new ReportParameter("CalculateUnit4", (meterUnit - (meterUnitCalculate[0].RateUnit + meterUnitCalculate[1].RateUnit + meterUnitCalculate[2].RateUnit)).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit4);

                //        ReportParameter CalculateAmount4 = new ReportParameter("CalculateAmount4", ((meterUnit - (meterUnitCalculate[0].RateUnit + meterUnitCalculate[1].RateUnit + meterUnitCalculate[2].RateUnit)) * meterUnitCalculate[3].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount4);

                //        ReportParameter CalculateUnit5 = new ReportParameter("CalculateUnit5", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit5);

                //        ReportParameter CalculateAmount5 = new ReportParameter("CalculateAmount5", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount5);

                //        ReportParameter CalculateUnit6 = new ReportParameter("CalculateUnit6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit6);

                //        ReportParameter CalculateAmount6 = new ReportParameter("CalculateAmount6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount6);

                //        ReportParameter CalculateUnit7 = new ReportParameter("CalculateUnit7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit7);

                //        ReportParameter CalculateAmount7 = new ReportParameter("CalculateAmount7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount7);
                //    }
                //    else if (meterUnit >= meterUnitCalculate[4].LowerLimit && meterUnit <= meterUnitCalculate[4].UpperLimit)
                //    {
                //        ReportParameter CalculateUnit1 = new ReportParameter("CalculateUnit1", (meterUnitCalculate[0].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit1);

                //        ReportParameter CalculateAmount1 = new ReportParameter("CalculateAmount1", (meterUnitCalculate[0].RateUnit * meterUnitCalculate[0].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount1);

                //        ReportParameter CalculateUnit2 = new ReportParameter("CalculateUnit2", (meterUnitCalculate[1].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit2);

                //        ReportParameter CalculateAmount2 = new ReportParameter("CalculateAmount2", (meterUnitCalculate[1].RateUnit * meterUnitCalculate[1].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount2);

                //        ReportParameter CalculateUnit3 = new ReportParameter("CalculateUnit3", (meterUnitCalculate[2].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit3);

                //        ReportParameter CalculateAmount3 = new ReportParameter("CalculateAmount3", (meterUnitCalculate[2].RateUnit * meterUnitCalculate[2].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount3);

                //        ReportParameter CalculateUnit4 = new ReportParameter("CalculateUnit4", (meterUnitCalculate[3].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit4);

                //        ReportParameter CalculateAmount4 = new ReportParameter("CalculateAmount4", (meterUnitCalculate[3].RateUnit * meterUnitCalculate[3].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount4);

                //        ReportParameter CalculateUnit5 = new ReportParameter("CalculateUnit5", (meterUnit - (meterUnitCalculate[0].RateUnit + meterUnitCalculate[1].RateUnit + meterUnitCalculate[2].RateUnit + meterUnitCalculate[3].RateUnit)).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit5);

                //        ReportParameter CalculateAmount5 = new ReportParameter("CalculateAmount5", ((meterUnit - (meterUnitCalculate[0].RateUnit + meterUnitCalculate[1].RateUnit + meterUnitCalculate[2].RateUnit + meterUnitCalculate[3].RateUnit)) * meterUnitCalculate[4].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount5);

                //        ReportParameter CalculateUnit6 = new ReportParameter("CalculateUnit6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit6);

                //        ReportParameter CalculateAmount6 = new ReportParameter("CalculateAmount6", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount6);

                //        ReportParameter CalculateUnit7 = new ReportParameter("CalculateUnit7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit7);

                //        ReportParameter CalculateAmount7 = new ReportParameter("CalculateAmount7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount7);
                //    }
                //    else if (meterUnit >= meterUnitCalculate[5].LowerLimit && meterUnit <= meterUnitCalculate[5].UpperLimit)
                //    {
                //        ReportParameter CalculateUnit1 = new ReportParameter("CalculateUnit1", (meterUnitCalculate[0].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit1);

                //        ReportParameter CalculateAmount1 = new ReportParameter("CalculateAmount1", (meterUnitCalculate[0].RateUnit * meterUnitCalculate[0].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount1);

                //        ReportParameter CalculateUnit2 = new ReportParameter("CalculateUnit2", (meterUnitCalculate[1].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit2);

                //        ReportParameter CalculateAmount2 = new ReportParameter("CalculateAmount2", (meterUnitCalculate[1].RateUnit * meterUnitCalculate[1].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount2);

                //        ReportParameter CalculateUnit3 = new ReportParameter("CalculateUnit3", (meterUnitCalculate[2].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit3);

                //        ReportParameter CalculateAmount3 = new ReportParameter("CalculateAmount3", (meterUnitCalculate[2].RateUnit * meterUnitCalculate[2].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount3);

                //        ReportParameter CalculateUnit4 = new ReportParameter("CalculateUnit4", (meterUnitCalculate[3].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit4);

                //        ReportParameter CalculateAmount4 = new ReportParameter("CalculateAmount4", (meterUnitCalculate[3].RateUnit * meterUnitCalculate[3].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount4);

                //        ReportParameter CalculateUnit5 = new ReportParameter("CalculateUnit5", (meterUnitCalculate[4].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit5);

                //        ReportParameter CalculateAmount5 = new ReportParameter("CalculateAmount5", (meterUnitCalculate[4].RateUnit * meterUnitCalculate[4].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount5);

                //        ReportParameter CalculateUnit6 = new ReportParameter("CalculateUnit6", (meterUnit - (meterUnitCalculate[0].RateUnit + meterUnitCalculate[1].RateUnit + meterUnitCalculate[2].RateUnit + meterUnitCalculate[3].RateUnit + meterUnitCalculate[4].RateUnit)).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit6);

                //        ReportParameter CalculateAmount6 = new ReportParameter("CalculateAmount6", ((meterUnit - (meterUnitCalculate[0].RateUnit + meterUnitCalculate[1].RateUnit + meterUnitCalculate[2].RateUnit + meterUnitCalculate[3].RateUnit + meterUnitCalculate[4].RateUnit)) * meterUnitCalculate[5].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount6);

                //        ReportParameter CalculateUnit7 = new ReportParameter("CalculateUnit7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateUnit7);

                //        ReportParameter CalculateAmount7 = new ReportParameter("CalculateAmount7", "0.00");
                //        rv.LocalReport.SetParameters(CalculateAmount7);
                //    }
                //    else if (meterUnit >= meterUnitCalculate[6].LowerLimit && meterUnit <= meterUnitCalculate[6].UpperLimit)
                //    {
                //        ReportParameter CalculateUnit1 = new ReportParameter("CalculateUnit1", (meterUnitCalculate[0].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit1);

                //        ReportParameter CalculateAmount1 = new ReportParameter("CalculateAmount1", (meterUnitCalculate[0].RateUnit * meterUnitCalculate[0].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount1);

                //        ReportParameter CalculateUnit2 = new ReportParameter("CalculateUnit2", (meterUnitCalculate[1].RateUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit2);

                //        ReportParameter CalculateAmount2 = new ReportParameter("CalculateAmount2", (meterUnitCalculate[1].RateUnit * meterUnitCalculate[1].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount2);

                //        ReportParameter CalculateUnit3 = new ReportParameter("CalculateUnit3", (meterUnitCalculate[2].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit3);

                //        ReportParameter CalculateAmount3 = new ReportParameter("CalculateAmount3", (meterUnitCalculate[2].RateUnit * meterUnitCalculate[2].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount3);

                //        ReportParameter CalculateUnit4 = new ReportParameter("CalculateUnit4", (meterUnitCalculate[3].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit4);

                //        ReportParameter CalculateAmount4 = new ReportParameter("CalculateAmount4", (meterUnitCalculate[3].RateUnit * meterUnitCalculate[3].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount4);

                //        ReportParameter CalculateUnit5 = new ReportParameter("CalculateUnit5", (meterUnitCalculate[4].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit5);

                //        ReportParameter CalculateAmount5 = new ReportParameter("CalculateAmount5", (meterUnitCalculate[4].RateUnit * meterUnitCalculate[4].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount5);

                //        ReportParameter CalculateUnit6 = new ReportParameter("CalculateUnit6", (meterUnitCalculate[5].RateUnit).ToString().ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit6);

                //        ReportParameter CalculateAmount6 = new ReportParameter("CalculateAmount6", (meterUnitCalculate[5].RateUnit * meterUnitCalculate[5].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount6);

                //        decimal calcualte = (decimal)(meterUnit - (meterUnitCalculate[0].RateUnit + meterUnitCalculate[1].RateUnit + meterUnitCalculate[2].RateUnit + meterUnitCalculate[3].RateUnit + meterUnitCalculate[4].RateUnit + meterUnitCalculate[5].RateUnit));
                //        ReportParameter CalculateUnit7 = new ReportParameter("CalculateUnit7", calcualte.ToString());
                //        rv.LocalReport.SetParameters(CalculateUnit7);

                //        ReportParameter CalculateAmount7 = new ReportParameter("CalculateAmount7", (calcualte * meterUnitCalculate[6].AmountPerUnit).ToString());
                //        rv.LocalReport.SetParameters(CalculateAmount7);
                //    }
                //    #endregion

                //    Utility.Get_Print(rv);
                //}
                //#endregion

            }
            catch (Exception ex)
            {

            }
        }
       //#endregion

        #region Method
        private bool CheckingRoleManagementFeature()
        {
            bool IsAllowed = false;
            string roleID = mbmsEntities.Users.Where(x => x.Active == true && x.UserID == UserID).SingleOrDefault().RoleID;
            List<RoleManagement> rolemgtList = mbmsEntities.RoleManagements.Where(x => x.Active == true && x.RoleID == roleID).ToList();
            foreach (RoleManagement item in rolemgtList)
            {
                //bill payment Menu Permission 
                if (item.RoleFeatureName.Equals("BillProcessEditOrDelete") && item.IsAllowed) IsAllowed = item.IsAllowed;
            }
            return IsAllowed;
        }
        private void BidnigData()
        {
            this.bindQuarterData();
            this.bindTransformerData();
            dtpFromDate.Value = dtptoDate.Value = DateTime.Now;
            this.gvmeterbillinvoice.DataSource = null;
        }

        #endregion

        #region Button Click
        public void btnSearch_Click(object sender, EventArgs e)
        {
            string tid = string.Empty; string qid = string.Empty;
            if (cboQuarter.SelectedIndex > 0)
            {
                qid = cboQuarter.SelectedValue.ToString();
                tid = cbotransformer.SelectedValue.ToString();
            }
            //if (cbotransformer.SelectedIndex > 0)
            //{
            //    tid = cbotransformer.SelectedValue.ToString();
            //}
            List<MeterBillInvoiceVM> data = meterBillCalculateServices.GetmeterBillInvoices(dtpFromDate.Value, dtptoDate.Value, tid, qid, string.Empty, string.Empty);
            if (data.Count == 0)
            {
                MessageBox.Show("There is no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            gvmeterbillinvoice.DataSource = data;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BidnigData();
        }
        #endregion

        #region Bind Combo
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
            //cboTransformerCode.Items.Clear();
            transformerList.AddRange(mbmsEntities.Transformers.Where(x => x.Quarter.QuarterNameInEng == cboQuarter.Text && x.Active == true).ToList());
            cbotransformer.DataSource = transformerList;
            cbotransformer.DisplayMember = "TransformerName";
            cbotransformer.ValueMember = "TransformerID";
        }
        #endregion

        #region combo Index Changed

        private void cboQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboQuarter.SelectedIndex != -1)
            //{
            //    cbotransformer.DisplayMember = "TransformerName";
            //    cbotransformer.ValueMember = "TransformerID";
            //    List<Transformer> data = meterbillcalculateservice.GetTransformerByQuarterID(cboQuarter.SelectedValue.ToString());
            //    if (data.Count != 0)
            //        cbotransformer.DataSource = data;
            //    else
            //    {
            //        MessageBox.Show("There is no transformar data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.bindTransformerData();
            //    }
            //}
            bindTransformerData();

        }
        #endregion
    }
}
