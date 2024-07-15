using MBMS.DAL;
using Microsoft.Reporting.WinForms;
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
using static MPS.Utility;

namespace MPS.Reports
{
    public partial class frmBillingReport : Form
    {


        public frmBillingReport()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmBillingReport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "MM/dd/yyyy";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "MM/dd/yyyy";
            this.rvBillReport.RefreshReport();
            bindBookCode();
            bindLineNo();
            bindPageNo();
            InitialState();

        }
        #endregion

        #region Method        


        private void bindBookCode()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Ledger> ledgerList = new List<Ledger>();
            Ledger ledger = new Ledger();
            ledger.LedgerID = Convert.ToString(0);
            ledger.BookCode = 0;
            ledgerList.Add(ledger);
            ledgerList.AddRange(mbmsEntities.Ledgers.Where(x => x.Active == true).OrderBy(x => x.BookCode).ToList());
            cboBookCode.DataSource = ledgerList;
            cboBookCode.DisplayMember = "BookCode";
            cboBookCode.ValueMember = "LedgerID";
        }

        private void bindPageNo()
        {
            cboPageNo.Items.Add("1"); cboPageNo.Items.Add("2"); cboPageNo.Items.Add("3");
            cboPageNo.Items.Add("4"); cboPageNo.Items.Add("5"); cboPageNo.Items.Add("6");
            cboPageNo.Items.Add("7"); cboPageNo.Items.Add("8"); cboPageNo.Items.Add("9");
            cboPageNo.Items.Add("10"); cboPageNo.Items.Add("11"); cboPageNo.Items.Add("12");
            cboPageNo.Items.Add("13"); cboPageNo.Items.Add("14"); cboPageNo.Items.Add("15");
            cboPageNo.Items.Add("16"); cboPageNo.Items.Add("17"); cboPageNo.Items.Add("18");
            cboPageNo.Items.Add("19"); cboPageNo.Items.Add("20"); cboPageNo.Items.Add("21");
            cboPageNo.Items.Add("22"); cboPageNo.Items.Add("23"); cboPageNo.Items.Add("24");
            cboPageNo.Items.Add("25"); cboPageNo.Items.Add("26"); cboPageNo.Items.Add("27");
            cboPageNo.Items.Add("28"); cboPageNo.Items.Add("29"); cboPageNo.Items.Add("30");
            cboPageNo.Items.Add("31"); cboPageNo.Items.Add("32"); cboPageNo.Items.Add("33");
            cboPageNo.Items.Add("34"); cboPageNo.Items.Add("35"); cboPageNo.Items.Add("36");
            cboPageNo.Items.Add("37"); cboPageNo.Items.Add("38"); cboPageNo.Items.Add("39");
            cboPageNo.Items.Add("40"); cboPageNo.Items.Add("41"); cboPageNo.Items.Add("42");
            cboPageNo.Items.Add("43"); cboPageNo.Items.Add("44"); cboPageNo.Items.Add("45");
            cboPageNo.Items.Add("46"); cboPageNo.Items.Add("47"); cboPageNo.Items.Add("48");
            cboPageNo.Items.Add("49"); cboPageNo.Items.Add("50"); cboPageNo.Items.Add("51");
            cboPageNo.Items.Add("52"); cboPageNo.Items.Add("53"); cboPageNo.Items.Add("54");
            cboPageNo.Items.Add("55"); cboPageNo.Items.Add("56"); cboPageNo.Items.Add("57");
            cboPageNo.Items.Add("58"); cboPageNo.Items.Add("59"); cboPageNo.Items.Add("60");
            cboPageNo.Items.Add("61"); cboPageNo.Items.Add("62"); cboPageNo.Items.Add("63");
            cboPageNo.Items.Add("64"); cboPageNo.Items.Add("65"); cboPageNo.Items.Add("66");
            cboPageNo.Items.Add("67"); cboPageNo.Items.Add("68"); cboPageNo.Items.Add("69");
            cboPageNo.Items.Add("70"); cboPageNo.Items.Add("71"); cboPageNo.Items.Add("72");
            cboPageNo.Items.Add("73"); cboPageNo.Items.Add("74"); cboPageNo.Items.Add("75");
            cboPageNo.Items.Add("76"); cboPageNo.Items.Add("77"); cboPageNo.Items.Add("78");
            cboPageNo.Items.Add("79"); cboPageNo.Items.Add("80"); cboPageNo.Items.Add("81");
            cboPageNo.Items.Add("82"); cboPageNo.Items.Add("83"); cboPageNo.Items.Add("84");
            cboPageNo.Items.Add("85"); cboPageNo.Items.Add("86"); cboPageNo.Items.Add("87");
            cboPageNo.Items.Add("88"); cboPageNo.Items.Add("89"); cboPageNo.Items.Add("90");

        }

        private void bindLineNo()
        {
            cboLineNo.Items.Add("1"); cboLineNo.Items.Add("2"); cboLineNo.Items.Add("3");
            cboLineNo.Items.Add("4"); cboLineNo.Items.Add("5"); cboLineNo.Items.Add("6");
            cboLineNo.Items.Add("7"); cboLineNo.Items.Add("8"); cboLineNo.Items.Add("9");
            cboLineNo.Items.Add("10"); cboLineNo.Items.Add("11"); cboLineNo.Items.Add("12");
            cboLineNo.Items.Add("13"); cboLineNo.Items.Add("14"); cboLineNo.Items.Add("15");
            cboLineNo.Items.Add("16"); cboLineNo.Items.Add("17"); cboLineNo.Items.Add("18");
            cboLineNo.Items.Add("19"); cboLineNo.Items.Add("20"); cboLineNo.Items.Add("21");
            cboLineNo.Items.Add("22"); cboLineNo.Items.Add("23"); cboLineNo.Items.Add("24");
            cboLineNo.Items.Add("25"); cboLineNo.Items.Add("26"); cboLineNo.Items.Add("27");
            cboLineNo.Items.Add("28"); cboLineNo.Items.Add("29"); cboLineNo.Items.Add("30");
        }

        #region Current List With Arrerar

        private void LoadCurrentWithArrearReport()
        {
            var mbmsEntities = new MBMSEntities();
            var isPaidTrue = (from mb in mbmsEntities.MeterBills
                        join muc in mbmsEntities.MeterUnitCollects on mb.MeterUnitCollectID equals muc.MeterUnitCollectID
                        join custo in mbmsEntities.Customers on muc.CustomerID equals custo.CustomerID
                        join bc in mbmsEntities.BillCode7Layer on custo.BillCode7LayerID equals bc.BillCode7LayerID
                        join le in mbmsEntities.Ledgers on custo.LedgerID equals le.LedgerID
                        where mb.InvoiceDate >= dtpFromDate.Value.Date
&& mb.InvoiceDate <= dtpToDate.Value.Date&& mb.isPaid==true && mb.Active == true 
                        select new
                        {

                            LedgerNo = le.BookCode,
                            PageNo = custo.PageNo,
                            LineNo = custo.LineNo,
                            BillCodeNo = bc.BillCode7LayerNo,
                            CustomerCode = custo.CustomerCode,
                            CustomerName = custo.CustomerNameInEng,
                            MeterFees = mb.MeterFees,
                            StreetLightFees=mb.StreetLightFees,
                            CreditAmt = mb.CreditAmount,
                            AdditionalFees = mb.AdditionalFees1,
                            TotalFees = mb.TotalFees
                        }).ToList();

            var isPaidFalse = (from mb in mbmsEntities.MeterBills
                              join muc in mbmsEntities.MeterUnitCollects on mb.MeterUnitCollectID equals muc.MeterUnitCollectID
                              join custo in mbmsEntities.Customers on muc.CustomerID equals custo.CustomerID
                              join bc in mbmsEntities.BillCode7Layer on custo.BillCode7LayerID equals bc.BillCode7LayerID
                              join le in mbmsEntities.Ledgers on custo.LedgerID equals le.LedgerID
                              where mb.InvoiceDate >= dtpFromDate.Value.Date
      && mb.InvoiceDate <= dtpToDate.Value.Date && mb.isPaid == false && mb.Active == true
                              select new
                              {
                                  LedgerNo = le.BookCode,
                                  PageNo = custo.PageNo,
                                  LineNo = custo.LineNo,
                                  BillCodeNo = bc.BillCode7LayerNo,
                                  CustomerCode = custo.CustomerCode,
                                  CustomerName = custo.CustomerNameInEng,
                                  MeterFees = mb.MeterFees,
                                  StreetLightFees = mb.StreetLightFees,
                                  CreditAmt = mb.CreditAmount,
                                  AdditionalFees = mb.AdditionalFees1,
                                  TotalFees = mb.TotalFees
                              }).ToList();

            if (isPaidTrue.Count > 0 || isPaidFalse.Count >0)
            {
                List<CurrentListWithArrear> meterBillList = new List<CurrentListWithArrear>();
                foreach (var item in isPaidTrue)
                {                    
                    var meterBill = new CurrentListWithArrear();
                    meterBill.LedgerNo = item.LedgerNo + "/" + item.PageNo + "/" + item.LineNo;
                    meterBill.BillCodeNo = item.BillCodeNo.ToString();
                    meterBill.CustomerCode = item.CustomerCode;
                    meterBill.CustomerName = item.CustomerName;
                    meterBill.MeterFees = item.MeterFees;
                    meterBill.StreetLightFees =Convert.ToDecimal(item.StreetLightFees);
                    meterBill.CreditAmt = Convert.ToDecimal(item.CreditAmt);
                    meterBill.AdditionalFees = Convert.ToDecimal(item.AdditionalFees);
                    meterBill.TotalFees = Convert.ToDecimal(item.TotalFees);
                    meterBill.PageNo = item.PageNo;
                    meterBill.LineNo = item.LineNo;
                    meterBillList.Add(meterBill);
                }

                foreach (var item in isPaidFalse)
                {
                    var meterBill = new CurrentListWithArrear();
                    meterBill.LedgerNo = item.LedgerNo + "/" + item.PageNo + "/" + item.LineNo;
                    meterBill.BillCodeNo = item.BillCodeNo.ToString();
                    meterBill.CustomerCode = item.CustomerCode;
                    meterBill.CustomerName = item.CustomerName;
                    meterBill.MeterFees = item.MeterFees;
                    meterBill.StreetLightFees = Convert.ToDecimal(item.StreetLightFees);
                    meterBill.CreditAmt = Convert.ToDecimal(item.TotalFees);
                    meterBill.AdditionalFees = Convert.ToDecimal(item.AdditionalFees);
                    meterBill.TotalFees = Convert.ToDecimal(item.CreditAmt);
                    meterBill.PageNo = item.PageNo;
                    meterBill.LineNo = item.LineNo;
                    meterBillList.Add(meterBill);
                }
                rvBillReport.Visible = true;
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "CurrentListWithArrear";
                rds.Value = meterBillList;

                //string reportPath = Application.StartupPath + "Reports Rdlc\\CurrentWithArrear.rdlc";
                string reportPath = Application.StartupPath + @"\Reports\CurrentWithArrear.rdlc";
                rvBillReport.LocalReport.ReportPath = reportPath;
                rvBillReport.LocalReport.DataSources.Clear();
                rvBillReport.LocalReport.DataSources.Add(rds);
                ReportParameter FromDate = new ReportParameter("FromDate", dtpFromDate.Value.Date.ToString());
                rvBillReport.LocalReport.SetParameters(FromDate);
                ReportParameter ToDate = new ReportParameter("ToDate", dtpToDate.Value.Date.ToString());
                rvBillReport.LocalReport.SetParameters(ToDate);
                ReportParameter PrintDate = new ReportParameter("PrintDate", DateTime.Now.ToString());
                rvBillReport.LocalReport.SetParameters(PrintDate);
                ReportParameter TownshipName = new ReportParameter("TownshipName", mbmsEntities.Townships.Where(x => x.TownshipCode == SettingController.TownShip && x.Active == true).Select(x => x.TownshipNameInMM).FirstOrDefault().ToString());
                rvBillReport.LocalReport.SetParameters(TownshipName);
                ReportParameter CompanyProfile = new ReportParameter("CompanyProfile", SettingController.CompanyName);
                rvBillReport.LocalReport.SetParameters(CompanyProfile);               
                rvBillReport.RefreshReport();

            }
            else
            {
                MessageBox.Show("There is No Data");
                rvBillReport.LocalReport.DataSources.Clear();
                rvBillReport.RefreshReport();
            }
        }

        #endregion

        #region Current List 

        private void LoadCurrentWithReport()
        {
            var mbmsEntities = new MBMSEntities();
            var data = (from mb in mbmsEntities.MeterBills
                        join muc in mbmsEntities.MeterUnitCollects on mb.MeterUnitCollectID equals muc.MeterUnitCollectID
                        join custo in mbmsEntities.Customers on muc.CustomerID equals custo.CustomerID
                        join bc in mbmsEntities.BillCode7Layer on custo.BillCode7LayerID equals bc.BillCode7LayerID
                        join le in mbmsEntities.Ledgers on custo.LedgerID equals le.LedgerID
                        where (mb.BillPayDate >= dtpFromDate.Value.Date
&& mb.BillPayDate <= dtpToDate.Value.Date) && mb.Active == true && mb.isPaid == true
                        select new
                        {
                           
                            LedgerNo = le.BookCode,
                            PageNo = custo.PageNo,
                            LineNo = custo.LineNo,
                            BillCodeNo = bc.BillCode7LayerNo,
                            CustomerCode = custo.CustomerCode,
                            CustomerName = custo.CustomerNameInEng,
                            MeterFees = mb.MeterFees,
                            AdditionalFees = mb.AdditionalFees1,
                            StreetlightFees=mb.StreetLightFees,
                            TotalFees = mb.TotalFees
                        }).ToList();

            if (data.Count > 0)
            {
                List<CurrentList> meterBillList = new List<CurrentList>();
                foreach (var item in data)
                {
                    var meterBill = new CurrentList();                  
                    meterBill.LedgerNo = item.LedgerNo + "/" + item.PageNo + "/" + item.LineNo;
                    meterBill.BillCodeNo = item.BillCodeNo.ToString();
                    meterBill.CustomerCode = item.CustomerCode;
                    meterBill.CustomerName = item.CustomerName;
                    meterBill.MeterFees = item.MeterFees;
                    meterBill.AdditionalFees = Convert.ToDecimal(item.AdditionalFees);
                    meterBill.TotalFees = Convert.ToDecimal(item.TotalFees);
                    meterBill.StreetLightFees = Convert.ToDecimal(item.StreetlightFees);                   
                    meterBillList.Add(meterBill);
                }
                rvBillReport.Visible = true;
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "CurrentList";
                rds.Value = meterBillList;

                //string reportPath = Application.StartupPath + "\\Reports Rdlc\\CurrentList.rdlc";
                string reportPath = Application.StartupPath + @"\Reports\CurrentList.rdlc";
                rvBillReport.LocalReport.ReportPath = reportPath;
                rvBillReport.LocalReport.DataSources.Clear();
                rvBillReport.LocalReport.DataSources.Add(rds);
                ReportParameter FromDate = new ReportParameter("FromDate", dtpFromDate.Value.Date.ToString());
                rvBillReport.LocalReport.SetParameters(FromDate);
                ReportParameter ToDate = new ReportParameter("ToDate", dtpToDate.Value.Date.ToString());
                rvBillReport.LocalReport.SetParameters(ToDate);
                ReportParameter PrintDate = new ReportParameter("PrintDate", DateTime.Now.ToString());
                rvBillReport.LocalReport.SetParameters(PrintDate);
                ReportParameter TownshipName = new ReportParameter("TownshipName", mbmsEntities.Townships.Where(x => x.TownshipCode == SettingController.TownShip && x.Active == true).Select(x => x.TownshipNameInMM).FirstOrDefault().ToString());
                rvBillReport.LocalReport.SetParameters(TownshipName);
                ReportParameter CompanyProfile = new ReportParameter("CompanyProfile", SettingController.CompanyName);
                rvBillReport.LocalReport.SetParameters(CompanyProfile);
                rvBillReport.RefreshReport();

            }
            else
            {
                MessageBox.Show("There is No Data");
                rvBillReport.LocalReport.DataSources.Clear();
                rvBillReport.RefreshReport();
            }
        }

        #endregion

        #region Advanced List
        private void LoadAdvancedReport()
        {
            var mbmsEntities = new MBMSEntities();
            var data = (from mb in mbmsEntities.MeterBills
                        join adv in mbmsEntities.AdvanceMoneyCustomers on mb.MeterBillID equals adv.MeterBillID
                        join muc in mbmsEntities.MeterUnitCollects on mb.MeterUnitCollectID equals muc.MeterUnitCollectID
                        join custo in mbmsEntities.Customers on muc.CustomerID equals custo.CustomerID
                        join bc in mbmsEntities.BillCode7Layer on custo.BillCode7LayerID equals bc.BillCode7LayerID
                        join le in mbmsEntities.Ledgers on custo.LedgerID equals le.LedgerID

                        where adv.ForMonth >= dtpFromDate.Value.Date
&& adv.ForMonth <= dtpToDate.Value.Date && adv.Active == true
                        select new
                        {
                            ForMonth = adv.ForMonth,
                            LedgerNo = le.BookCode,
                            BillCodeNo = bc.BillCode7LayerNo,
                            CustomerCode = custo.CustomerCode,
                            PageNo = custo.PageNo,
                            LineNo = custo.LineNo,
                            CustomerName = custo.CustomerNameInEng,
                            AdvancedMonthAmount = adv.AdvanceMonthAmount
                        }).ToList();

            if (data.Count > 0)
            {
                List<AdvancedMoney> advancedCustomerList = new List<AdvancedMoney>();
                foreach (var item in data)
                {
                    var advancedCustomer = new AdvancedMoney();
                    advancedCustomer.ForMonth = Convert.ToDateTime(item.ForMonth);
                    advancedCustomer.LedgerNo = item.LedgerNo + "/" + item.PageNo + "/" + item.LineNo;
                    advancedCustomer.BillCodeNo = item.BillCodeNo.ToString();
                    advancedCustomer.CustomerCode = item.CustomerCode;
                    advancedCustomer.CustomerName = item.CustomerName;
                    advancedCustomer.AdvancedMonthAmount = item.AdvancedMonthAmount;
                    advancedCustomerList.Add(advancedCustomer);
                }
                rvBillReport.Visible = true;
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "AdvancedList";
                rds.Value = advancedCustomerList;
                //string reportPath = Application.StartupPath + "\\Reports Rdlc\\AdvancedMoneyCustomerList.rdlc";
                string reportPath = Application.StartupPath + @"\Reports\AdvancedMoneyCustomerList.rdlc";
                rvBillReport.LocalReport.ReportPath = reportPath;
                rvBillReport.LocalReport.DataSources.Clear();
                rvBillReport.LocalReport.DataSources.Add(rds);
                ReportParameter FromDate = new ReportParameter("FromDate", dtpFromDate.Value.Date.ToString());
                rvBillReport.LocalReport.SetParameters(FromDate);
                ReportParameter ToDate = new ReportParameter("ToDate", dtpToDate.Value.Date.ToString());
                rvBillReport.LocalReport.SetParameters(ToDate);
                ReportParameter PrintDate = new ReportParameter("PrintDate", DateTime.Now.ToString());
                rvBillReport.LocalReport.SetParameters(PrintDate);
                ReportParameter TownshipName = new ReportParameter("TownshipName", mbmsEntities.Townships.Where(x => x.TownshipCode == SettingController.TownShip && x.Active == true).Select(x => x.TownshipNameInMM).FirstOrDefault().ToString());
                rvBillReport.LocalReport.SetParameters(TownshipName);
                ReportParameter CompanyProfile = new ReportParameter("CompanyProfile", SettingController.CompanyName);
                rvBillReport.LocalReport.SetParameters(CompanyProfile);
                rvBillReport.RefreshReport();

            }
            else
            {
                MessageBox.Show("There is No Data");
                rvBillReport.LocalReport.DataSources.Clear();
                rvBillReport.RefreshReport();
            }
        }

        #endregion

        #region Arrear List

        private void LoadArrearListReport()
        {
            var mbmsEntities = new MBMSEntities();
            var data = (from mb in mbmsEntities.MeterBills
                        join muc in mbmsEntities.MeterUnitCollects on mb.MeterUnitCollectID equals muc.MeterUnitCollectID
                        join custo in mbmsEntities.Customers on muc.CustomerID equals custo.CustomerID
                        join bc in mbmsEntities.BillCode7Layer on custo.BillCode7LayerID equals bc.BillCode7LayerID
                        join le in mbmsEntities.Ledgers on custo.LedgerID equals le.LedgerID

                        where mb.InvoiceDate >= dtpFromDate.Value.Date
&& mb.InvoiceDate <= dtpToDate.Value.Date && mb.Active == true && mb.isPaid == false
                        select new
                        {
                            LastPaidDate = mb.LastBillPaidDate,
                            LedgerNo = le.BookCode,
                            BillCodeNo = bc.BillCode7LayerNo,
                            CustomerCode = custo.CustomerCode,
                            PageNo = custo.PageNo,
                            LineNo = custo.LineNo,
                            CustomerName = custo.CustomerNameInEng,
                            CreditAmt = mb.TotalFees,
                        }).ToList();

            if (data.Count > 0)
            {
                List<ArrearCustomerList> meterBillList = new List<ArrearCustomerList>();
                foreach (var item in data)
                {
                    var meterBill = new ArrearCustomerList();
                    meterBill.LastBillPaidDate = item.LastPaidDate;
                    meterBill.LedgerNo = item.LedgerNo + "/" + item.PageNo + "/" + item.LineNo;
                    meterBill.BillCodeNo = item.BillCodeNo.ToString();
                    meterBill.CustomerCode = item.CustomerCode;
                    meterBill.CustomerName = item.CustomerName;
                    meterBill.CreditAmt = Convert.ToDecimal(item.CreditAmt);
                    meterBillList.Add(meterBill);
                }
                rvBillReport.Visible = true;
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "ArrearList";
                rds.Value = meterBillList;

                //string reportPath = Application.StartupPath + "Reports Rdlc\\CurrentWithArrear.rdlc";
                string reportPath = Application.StartupPath + @"\Reports\ArrearList.rdlc";
                rvBillReport.LocalReport.ReportPath = reportPath;
                rvBillReport.LocalReport.DataSources.Clear();
                rvBillReport.LocalReport.DataSources.Add(rds);
                ReportParameter FromDate = new ReportParameter("FromDate", dtpFromDate.Value.Date.ToString());
                rvBillReport.LocalReport.SetParameters(FromDate);
                ReportParameter ToDate = new ReportParameter("ToDate", dtpToDate.Value.Date.ToString());
                rvBillReport.LocalReport.SetParameters(ToDate);
                ReportParameter PrintDate = new ReportParameter("PrintDate", DateTime.Now.ToString());
                rvBillReport.LocalReport.SetParameters(PrintDate);
                ReportParameter TownshipName = new ReportParameter("TownshipName", mbmsEntities.Townships.Where(x => x.TownshipCode == SettingController.TownShip && x.Active == true).Select(x => x.TownshipNameInMM).FirstOrDefault().ToString());
                rvBillReport.LocalReport.SetParameters(TownshipName);
                ReportParameter CompanyProfile = new ReportParameter("CompanyProfile", SettingController.CompanyName);
                rvBillReport.LocalReport.SetParameters(CompanyProfile);
                rvBillReport.RefreshReport();

            }
            else
            {
                MessageBox.Show("There is No Data");
                rvBillReport.LocalReport.DataSources.Clear();
                rvBillReport.RefreshReport();
            }
        }

        #endregion

        #region Bill Code Summary
        private void LoadBillCodeSummary()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            ObjectResult<BillCodeSummaryPro_Result> resultList;
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            resultList = mbsEntities.BillCodeSummaryPro(fromDate, toDate);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "BillCodeList";
            rds.Value = resultList;

            //string reportPath = Application.StartupPath + "Reports Rdlc\\CurrentWithArrear.rdlc";
            string reportPath = Application.StartupPath + @"\Reports\BillCodeSummary.rdlc";
            rvBillReport.LocalReport.ReportPath = reportPath;
            rvBillReport.LocalReport.DataSources.Clear();
            rvBillReport.LocalReport.DataSources.Add(rds);
            ReportParameter FromDate = new ReportParameter("FromDate", dtpFromDate.Value.Date.ToString());
            rvBillReport.LocalReport.SetParameters(FromDate);
            ReportParameter ToDate = new ReportParameter("ToDate", dtpToDate.Value.Date.ToString());
            rvBillReport.LocalReport.SetParameters(ToDate);
            ReportParameter PrintDate = new ReportParameter("PrintDate", DateTime.Now.ToString());
            rvBillReport.LocalReport.SetParameters(PrintDate);
            ReportParameter TownshipName = new ReportParameter("TownshipName", mbsEntities.Townships.Where(x => x.TownshipCode == SettingController.TownShip && x.Active == true).Select(x => x.TownshipNameInMM).FirstOrDefault().ToString());
            rvBillReport.LocalReport.SetParameters(TownshipName);
            ReportParameter CompanyName = new ReportParameter("CompanyName", SettingController.CompanyName);
            rvBillReport.LocalReport.SetParameters(CompanyName);
            rvBillReport.RefreshReport();

        }

        #endregion

        #region Ledger Summary
        private void LoadLedgerSummary()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            ObjectResult<LedgerSummaryList_Result> resultList;
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            int pageNo, lineNo, bookCode;
            pageNo = lineNo = bookCode = 0;
            if (cboBookCode.SelectedIndex > 0)
                bookCode = Convert.ToInt32(cboBookCode.Text);
            if (cboPageNo.SelectedIndex > -1)
                pageNo = Convert.ToInt32(cboPageNo.Text);
            if (cboLineNo.SelectedIndex > -1)
                lineNo = Convert.ToInt32(cboLineNo.Text);
            resultList = mbsEntities.LedgerSummaryList(fromDate, toDate, bookCode, lineNo, pageNo);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "LedgerList";
            rds.Value = resultList;

            //string reportPath = Application.StartupPath + "Reports Rdlc\\CurrentWithArrear.rdlc";
            string reportPath = Application.StartupPath + @"\Reports\LedgerSummary.rdlc";
            rvBillReport.LocalReport.ReportPath = reportPath;
            rvBillReport.LocalReport.DataSources.Clear();
            rvBillReport.LocalReport.DataSources.Add(rds);
            ReportParameter FromDate = new ReportParameter("FromDate", dtpFromDate.Value.Date.ToString());
            rvBillReport.LocalReport.SetParameters(FromDate);
            ReportParameter ToDate = new ReportParameter("ToDate", dtpToDate.Value.Date.ToString());
            rvBillReport.LocalReport.SetParameters(ToDate);
            ReportParameter TownshipName = new ReportParameter("TownshipName", mbsEntities.Townships.Where(x => x.TownshipCode == SettingController.TownShip && x.Active == true).Select(x => x.TownshipNameInMM).FirstOrDefault().ToString());
            rvBillReport.LocalReport.SetParameters(TownshipName);
            ReportParameter CompanyName = new ReportParameter("CompanyName", SettingController.CompanyName);
            rvBillReport.LocalReport.SetParameters(CompanyName);
            ReportParameter PrintDate = new ReportParameter("PrintDate", DateTime.Now.ToString());
            rvBillReport.LocalReport.SetParameters(PrintDate);
            rvBillReport.RefreshReport();

        }

        #endregion

        private void InitialState()
        {
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            cboBookCode.SelectedIndex = 0;
            cboLineNo.SelectedIndex = -1;
            cboPageNo.SelectedIndex = -1;

        }

        #endregion

        #region Button Event
        private void btnSearch(object sender, EventArgs e)
        {
            if (rdoCurrentWithArrear.Checked)
                LoadCurrentWithArrearReport();

            else if (rdoCurrentList.Checked)
                LoadCurrentWithReport();

            else if (rdoAdvance.Checked)
                LoadAdvancedReport();

            else if (rdoArrear.Checked)
                LoadArrearListReport();
            else if (rdoBillCode.Checked)
                LoadBillCodeSummary();
            else
                LoadLedgerSummary();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();
        }

        #endregion

        #region Radio Button Check Change
        private void rdoBillCode_CheckedChanged(object sender, EventArgs e)
        {
            cboBookCode.Enabled = false;
            cboLineNo.Enabled = false;
            cboPageNo.Enabled = false;

        }

        private void rdoLedger_CheckedChanged(object sender, EventArgs e)
        {
            cboBookCode.Enabled = true;
            cboLineNo.Enabled = true;
            cboPageNo.Enabled = true;
        }

        private void rdoAdvance_CheckedChanged(object sender, EventArgs e)
        {
            cboBookCode.Enabled = false;
            cboLineNo.Enabled = false;
            cboPageNo.Enabled = false;
        }

        private void rdoArrear_CheckedChanged(object sender, EventArgs e)
        {
            cboBookCode.Enabled = false;
            cboLineNo.Enabled = false;
            cboPageNo.Enabled = false;
        }

        private void rdoCurrentList_CheckedChanged(object sender, EventArgs e)
        {
            cboBookCode.Enabled = false;
            cboLineNo.Enabled = false;
            cboPageNo.Enabled = false;
        }

        private void rdoCurrentWithArrear_CheckedChanged(object sender, EventArgs e)
        {
            cboBookCode.Enabled = false;
            cboLineNo.Enabled = false;
            cboPageNo.Enabled = false;
        }
        #endregion
    }
}
