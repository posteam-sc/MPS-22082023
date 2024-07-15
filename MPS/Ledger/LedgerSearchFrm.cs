using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Ledger_Setup
{
    public partial class LedgerSearchFrm : Form
    {
        public LedgerSearchFrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void LedgerSearchFrm_Load(object sender, EventArgs e)
        {
            bindBookCode();
            bindPageNo();
            bindLineNo();
            InitialState();
            FormRefresh();
            
        }
        #endregion

        #region Method
        public void bindBookCode()
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
        
        public void bindPageNo()
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

        public void bindLineNo()
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

        public void FormRefresh()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            dgvLedgerSearchList.AutoGenerateColumns = false;
            dgvLedgerSearchList.DataSource = (from c in mbmsEntities.Customers where c.Active == true orderby c.CustomerCode descending select c).ToList();
        }

        public void LoadData()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            int bookCode = 0; int pageNo = 0; int lineNo = 0;

            bookCode = Convert.ToInt32(cboBookCode.Text);
            pageNo = Convert.ToInt32(cboPageNo.Text == "" ? "0" : cboPageNo.Text);
            lineNo = Convert.ToInt32(cboLineNo.Text == "" ? "0" : cboLineNo.Text);
            if(bookCode!=0 && pageNo==0 && lineNo == 0)
            {
                var customerList = mbmsEntities.Customers.Where(c => c.Ledger.BookCode == bookCode && c.Active==true).ToList();
                dgvLedgerSearchList.DataSource = customerList;
            }else if(bookCode!=0 && pageNo!=0&& lineNo == 0)
            {
                var customerList = mbmsEntities.Customers.Where(c => c.Ledger.BookCode == bookCode &&c.PageNo==pageNo && c.Active==true).ToList();
                dgvLedgerSearchList.DataSource = customerList;
            }
            else if (bookCode != 0 && pageNo == 0 && lineNo != 0)
            {
                var customerList = mbmsEntities.Customers.Where(c => c.Ledger.BookCode == bookCode && c.LineNo == lineNo && c.Active==true).ToList();
                dgvLedgerSearchList.DataSource = customerList;
            }
            else if (bookCode != 0 && pageNo != 0 && lineNo != 0)
            {
                var customerList = mbmsEntities.Customers.Where(c => c.Ledger.BookCode == bookCode && c.LineNo == lineNo && c.PageNo==pageNo && c.Active==true).ToList();
                dgvLedgerSearchList.DataSource = customerList;
            }
            else if (bookCode == 0 && pageNo != 0 && lineNo == 0)
            {
                var customerList = mbmsEntities.Customers.Where(c => c.PageNo == pageNo && c.Active==true).ToList();
                dgvLedgerSearchList.DataSource = customerList;
            }
            else if (bookCode == 0 && pageNo != 0 && lineNo != 0)
            {
                var customerList = mbmsEntities.Customers.Where(c => c.PageNo == pageNo && c.LineNo==lineNo && c.Active==true).ToList();
                dgvLedgerSearchList.DataSource = customerList;
            }
            else if (bookCode == 0 && pageNo == 0 && lineNo != 0)
            {
                var customerList = mbmsEntities.Customers.Where(c =>c.LineNo == lineNo && c.Active==true).ToList();
                dgvLedgerSearchList.DataSource = customerList;
            }
            else if (bookCode != 0 && pageNo == 0 && lineNo != 0)
            {
                var customerList = mbmsEntities.Customers.Where(c => c.LineNo == lineNo && c.Ledger.BookCode==bookCode && c.Active==true).ToList();
                dgvLedgerSearchList.DataSource = customerList;
            }

        }

        private void InitialState()
        {
            cboBookCode.SelectedIndex = 0;
            cboLineNo.SelectedIndex = -1;
            cboPageNo.SelectedIndex = -1;
        }
        #endregion

        #region Data Bind
        private void dgvLedgerSearchList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvLedgerSearchList.Rows)
            {
                Customer customer = (Customer)row.DataBoundItem;
                row.Cells[0].Value = customer.CustomerID;
                row.Cells[1].Value = customer.CustomerNameInEng;
                row.Cells[2].Value = customer.Meter.MeterNo;
                row.Cells[3].Value = customer.Meter.MeterBox.Pole.PoleNo;
                row.Cells[4].Value = customer.Meter.MeterBox.MeterBoxCode;
                row.Cells[5].Value = customer.Meter.MeterBoxSequence;
                row.Cells[6].Value = customer.BillCode7Layer.BillCode7LayerNo;
                row.Cells[7].Value = customer.Meter.MeterBox.Pole.Transformer.TransformerName;
                row.Cells[8].Value = customer.Meter.MeterBox.Pole.Transformer.Quarter.QuarterNameInEng;
                row.Cells[9].Value = customer.Meter.MeterBox.Pole.Transformer.Quarter.Township.TownshipNameInEng;
                row.Cells[10].Value = customer.Ledger.BookCode;
                row.Cells[11].Value = customer.PageNo;
                row.Cells[12].Value = customer.LineNo;
            }
        }
        #endregion

        #region Click Event
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitialState();
            FormRefresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion
    }
}
