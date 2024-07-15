using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Importing
{
    public partial class CustomerImportingUI : Form
    {
        #region Variables
        ICustomer iCustomerServices;
        DataTable dt = new DataTable();
        public string UserID { get; set; }
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private bool check;
        #endregion

        public CustomerImportingUI()
        {
            InitializeComponent();
            iCustomerServices = new CustomerController();
        }

        #region Form Load
        private void CustomerImportingUI_Load(object sender, EventArgs e)
        {
            check = false;
            CheckSaveButton();
        }
        #endregion

        #region Method
        private void CheckSaveButton()
        {
            btnSave.Enabled = (check == false ? false : true);
        }
        #endregion

        #region Select
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ofdSelect.ShowDialog();
        }

        private void ofdSelect_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = ofdSelect.FileName;
            string extension = Path.GetExtension(filePath);
            string conString = "";
            string sheetName = "";
            switch (extension)
            {
                case ".xls":
                    conString = string.Format(Excel03ConString, filePath, "YES");
                    break;
                case ".xlsx":
                    conString = string.Format(Excel07ConString, filePath, "YES");
                    break;
                default:
                    MessageBox.Show("Invalid file", "Informtion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dt.Rows[0]["Table_Name"].ToString();
                    con.Close();
                }
            }
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    OleDbDataAdapter oda = new OleDbDataAdapter();
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    oda.SelectCommand = cmd;
                    oda.Fill(dt);
                    con.Close();
                    gvCustomer.DataSource = dt;
                }
            }
        }
        #endregion

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            MBMSEntities mBMSEntities = new MBMSEntities();
            if (gvCustomer.Rows.Count > 0)
            {
                DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ok == DialogResult.Yes)
                {
                    List<Customer> customerList = new List<Customer>();
                    for (int i = 0; i < gvCustomer.Rows.Count - 1; i++)
                    {
                        Customer customer = new Customer();
                        customer.CustomerID = Guid.NewGuid().ToString();
                        customer.CustomerCode = gvCustomer.Rows[i].Cells["CustomerCode"].Value.ToString();
                        customer.CustomerNameInEng = gvCustomer.Rows[i].Cells["CustomerNameInEng"].Value.ToString();
                        customer.CustomerNameInMM = gvCustomer.Rows[i].Cells["CustomerNameInMM"].Value.ToString();
                        customer.CustomerAddressInEng = gvCustomer.Rows[i].Cells["Address(English)"].Value.ToString();
                        customer.CustomerAddressInMM = gvCustomer.Rows[i].Cells["Address(Myanmar)"].Value.ToString();
                        customer.NRC = gvCustomer.Rows[i].Cells["NRC"].Value.ToString();
                        Ledger ledger = iCustomerServices.GetLedgerByLedgerCode(Convert.ToInt32(gvCustomer.Rows[i].Cells["LedgerCode"].Value.ToString()));
                        customer.LedgerID = ledger.LedgerID;
                        customer.PageNo = Convert.ToInt16(gvCustomer.Rows[i].Cells["PageNo"].Value.ToString());
                        customer.LineNo = Convert.ToInt16(gvCustomer.Rows[i].Cells["LineNo"].Value.ToString());
                        Quarter quarter = iCustomerServices.GetQuarterByQarterCode(gvCustomer.Rows[i].Cells["QuarterCode"].Value.ToString());
                        customer.QuarterID = quarter.QuarterID;
                        //remind BillDayGroupCode
                        string tCode = gvCustomer.Rows[i].Cells["TransformerCode"].Value.ToString();
                        Transformer transformer = mBMSEntities.Transformers.Where(t => t.TransformerName == tCode).FirstOrDefault();
                        customer.TransformerID = transformer.TransformerID;
                        Meter meter = iCustomerServices.GetMeterByQarterNo(gvCustomer.Rows[i].Cells["MeterNo"].Value.ToString());
                        customer.MeterID = meter.MeterID;
                        customer.Post = gvCustomer.Rows[i].Cells["PostalCode"].Value.ToString();
                        customer.PhoneNo = gvCustomer.Rows[i].Cells["PhoneNo"].Value.ToString();
                        BillCode7Layer billCode7Layer = iCustomerServices.GetBillCode7LayerByBillCodeNo(Convert.ToInt32(gvCustomer.Rows[i].Cells["BillCodeNo"].Value.ToString()));
                        customer.BillCode7LayerID = billCode7Layer.BillCode7LayerID;
                        customer.Active = true;
                        customer.CreatedUserID = UserID;
                        customer.CreatedDate = DateTime.Now;
                        customer.SMDNo = gvCustomer.Rows[i].Cells["SMDNo"].Value.ToString();
                        customerList.Add(customer);


                        //Customer customerEntity = new Customer();
                        //customerEntity.CustomerCode = gvCustomer.Rows[i].Cells["CustomerCode"].Value.ToString();
                        //customerEntity.CustomerID = Guid.NewGuid().ToString();
                        //customerEntity.SMDNo = gvCustomer.Rows[i].Cells["SMDNo"].Value.ToString();
                        //customerEntity.CustomerNameInEng = gvCustomer.Rows[i].Cells["CustomerNameInEng"].Value.ToString();
                        //customerEntity.CustomerNameInMM = gvCustomer.Rows[i].Cells["CustomerNameInMM"].Value.ToString();
                        //customerEntity.NRC = gvCustomer.Rows[i].Cells["NRC"].Value.ToString();
                        //customerEntity.PhoneNo = gvCustomer.Rows[i].Cells["PhoneNo"].Value.ToString();
                        //customerEntity.Post = gvCustomer.Rows[i].Cells["PostalCode"].Value.ToString();

                        //Quarter q = iCustomerServices.GetQuarterByQarterCode(gvCustomer.Rows[i].Cells["QuarterCode"].Value.ToString());
                        //customerEntity.QuarterID = q.QuarterID;
                        //customerEntity.Quarter = q;

                        //string transformerCode = gvCustomer.Rows[i].Cells["TransformerCode"].Value.ToString();
                        //Transformer tran = mBMSEntities.Transformers.Where(t => t.TransformerName == transformerCode).FirstOrDefault();
                        //customerEntity.TransformerID = tran.TransformerID;

                        //customerEntity.CustomerAddressInEng = gvCustomer.Rows[i].Cells["Address(English)"].Value.ToString();
                        //customerEntity.CustomerAddressInMM = gvCustomer.Rows[i].Cells["Address(Myanmar)"].Value.ToString();

                        //Meter m = iCustomerServices.GetMeterByQarterNo(gvCustomer.Rows[i].Cells["MeterNo"].Value.ToString());
                        //customerEntity.MeterID = m.MeterID;
                        //customerEntity.Meter = m;

                        //Ledger l = iCustomerServices.GetLedgerByLedgerCode(Convert.ToInt32(gvCustomer.Rows[i].Cells["LedgerCode"].Value.ToString()));
                        //customerEntity.Ledger = l;
                        //customerEntity.LedgerID = l.LedgerID;
                        //customerEntity.PageNo = Convert.ToInt16(gvCustomer.Rows[i].Cells["PageNo"].Value.ToString());
                        //customerEntity.LineNo = Convert.ToInt16(gvCustomer.Rows[i].Cells["LineNo"].Value.ToString());

                        //BillCode7Layer b = iCustomerServices.GetBillCode7LayerByBillCodeNo(Convert.ToInt32(gvCustomer.Rows[i].Cells["BillCodeNo"].Value.ToString()));
                        //customerEntity.BillCode7LayerID = b.BillCode7LayerID;
                        //customerEntity.BillCode7Layer = b;
                        //customerEntity.Active = true;
                        //customerEntity.CreatedDate = DateTime.Now;
                        //customerEntity.CreatedUserID = UserID;

                        //customerList.Add(customerEntity);
                        
                    }

                    if (customerList.Count > 0)
                    {
                        try
                        {
                            iCustomerServices.SaveRange(customerList);
                            MessageBox.Show("Importing Customer data is successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gvCustomer.DataSource = null;
                            gvCustomer.Rows.Clear();
                            gvCustomer.Refresh();
                            check = false;
                            CheckSaveButton();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error occur :(", "information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        #endregion

        #region Check
        private void btnCheck_Click(object sender, EventArgs e)
        {
            MBMSEntities mBMSEntities = new MBMSEntities();
            if (gvCustomer.Rows.Count > 0)
            {
                check = true;
                for (int i = 0; i < gvCustomer.Rows.Count - 1; i++)
                {
                    bool checkcolor = false;
                    bool customerCode = false;
                    bool SMDNo = false;
                    bool TransformerCode = false;
                    bool QuarterCode = false;
                    bool MeterNo = false;
                    bool LedgerCode = false;
                    bool billCodeNo = false;

                    bool isdataexit = iCustomerServices.GetCustomerCustomerCode(gvCustomer.Rows[i].Cells["CustomerCode"].Value.ToString());
                    if (isdataexit)
                    {
                        gvCustomer.Rows[i].Cells["CustomerCode"].Style.BackColor = Color.Red;
                        check = false;
                        checkcolor = true;
                    }
                    else
                    {
                        customerCode = true;
                    }

                    bool IsSMDSerialNoExist = iCustomerServices.GetCustomerBySMDNo(gvCustomer.Rows[i].Cells["SMDNo"].Value.ToString());
                    if (IsSMDSerialNoExist)
                    {
                        gvCustomer.Rows[i].Cells["SMDNo"].Style.BackColor = Color.Red;
                        check = false;
                        checkcolor = true;
                    }
                    else
                    {
                        SMDNo = true;
                    }

                    Quarter q = iCustomerServices.GetQuarterByQarterCode(gvCustomer.Rows[i].Cells["QuarterCode"].Value.ToString());
                    if (q == null)
                    {
                        gvCustomer.Rows[i].Cells["QuarterCode"].Style.BackColor = Color.Red;
                        check = false;
                        checkcolor = true;
                    }
                    else
                    {
                        QuarterCode = true;
                    }

                    //Township t = iCustomerServices.GetTownshipByTownshipCode(gvCustomer.Rows[i].Cells["TownshipCode"].Value.ToString());
                    string transformerCode = gvCustomer.Rows[i].Cells["TransformerCode"].Value.ToString();
                    Transformer tran = mBMSEntities.Transformers.Where(t => t.TransformerName == transformerCode).FirstOrDefault();
                    if (tran == null)
                    {
                        gvCustomer.Rows[i].Cells["TransformerCode"].Style.BackColor = Color.Red;
                        check = false;
                        checkcolor = true;
                    }
                    else
                    {
                        TransformerCode = true;
                    }
                    
                    Meter m = iCustomerServices.GetMeterByQarterNo(gvCustomer.Rows[i].Cells["MeterNo"].Value.ToString());
                    if (m == null)
                    {
                        gvCustomer.Rows[i].Cells["MeterNo"].Style.BackColor = Color.Red;
                        check = false;
                        checkcolor = true;
                    }
                    else
                    {
                        MeterNo = true;
                    }

                    //bool IsMeterIDExitsin = iCustomerServices.GetCustomerByMeterID(m.MeterNo);
                    var IsMeterIDExitsin = from c in mBMSEntities.Customers
                            join me in mBMSEntities.Meters on c.MeterID equals me.MeterID
                            where me.MeterNo == m.MeterNo
                            select c;
                    //var IsMeterIDExitsin = mBMSEntities.Customers.Where(c => c.Meter.MeterNo == m.MeterNo).FirstOrDefault();
                    if (IsMeterIDExitsin == null)
                    {
                        gvCustomer.Rows[i].Cells["MeterNo"].Style.BackColor = Color.Red;
                        check = false;
                        checkcolor = true;
                    }
                    else
                    {
                        MeterNo = true;
                    }

                    Ledger l = iCustomerServices.GetLedgerByLedgerCode(Convert.ToInt32(gvCustomer.Rows[i].Cells["LedgerCode"].Value.ToString()));
                    if (l == null)
                    {
                        gvCustomer.Rows[i].Cells["LedgerCode"].Style.BackColor = Color.Red;
                        check = false;
                        checkcolor = true;
                    }
                    else
                    {
                        LedgerCode = true;
                    }

                    BillCode7Layer b = iCustomerServices.GetBillCode7LayerByBillCodeNo(Convert.ToInt32(gvCustomer.Rows[i].Cells["BillCodeNo"].Value.ToString()));
                    if (b == null)
                    {
                        gvCustomer.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        gvCustomer.Rows[i].Cells["BillCodeNo"].Style.BackColor = Color.Red;
                        check = false;
                        checkcolor = true;
                    }
                    else
                    {
                        billCodeNo = true;
                    }


                    gvCustomer.Rows[i].DefaultCellStyle.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                    if (customerCode == true)
                    {
                        gvCustomer.Rows[i].Cells["CustomerCode"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                    }
                    if (SMDNo == true)
                    {
                        gvCustomer.Rows[i].Cells["SMDNo"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                    }
                    if (TransformerCode == true)
                    {
                        gvCustomer.Rows[i].Cells["TransformerCode"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                    }
                    if (QuarterCode == true)
                    {
                        gvCustomer.Rows[i].Cells["QuarterCode"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                    }
                    if (MeterNo == true)
                    {
                        gvCustomer.Rows[i].Cells["MeterNo"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                    }
                    if (LedgerCode == true)
                    {
                        gvCustomer.Rows[i].Cells["LedgerCode"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                    }
                    if (billCodeNo == true)
                    {
                        gvCustomer.Rows[i].Cells["BillCodeNo"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                    }
                }
            }
            CheckSaveButton();
        }
        #endregion
    }
}
