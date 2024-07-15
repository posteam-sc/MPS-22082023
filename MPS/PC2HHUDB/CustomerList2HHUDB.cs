using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using MPS.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MPS.Customer_Setup
{
    public partial class CustomerList2HHUDB : Form
    {
        #region Variables

        CustomerController customerController = new CustomerController();
        private List<Customer> customerList = new List<Customer>();
        public string UserID { get; set; }
        #endregion
        public CustomerList2HHUDB()
        {
            InitializeComponent();
            getDbFileList();
        }

        #region Method
        private void getDbFileList()
        {
            this.cbofileName.Items.Add("Select One");
            this.cbofileName.SelectedIndex = 0;
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings["dbFileListPath"]);
                FileInfo[] Files = dirInfo.GetFiles("*.db"); //Getting db files
                foreach (FileInfo file in Files)
                {
                    this.cbofileName.Items.Add(file.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void BuildSQLiteConnection()
        {
            string sqlitedbPath = System.Configuration.ConfigurationManager.AppSettings["DatabaseFile"] + cbofileName.SelectedItem;
            if (String.IsNullOrEmpty(Storage.ConnectionString))
            {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", sqlitedbPath));
            }
        }

        public void FormRefresh()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            dgvCustomerList.AutoGenerateColumns = false;
            customerList = (from c in mbsEntities.Customers where c.Active == true orderby c.CustomerCode descending select c).ToList();

            dgvCustomerList.DataSource = (from c in mbsEntities.Customers where c.Active == true orderby c.CustomerCode descending select c).ToList();
        }

        public void LoadData()
        {
            MBMSEntities mbsEntites = new MBMSEntities();
            var customer = mbsEntites.Customers.Where(u => u.Active == true).ToList();
            if (rdoCustomerCode.Checked == true)
            {
                if (!string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex == 0 && cboTransformer.SelectedIndex == -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.CustomerCode.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                    customerList = customer.Where(u => u.CustomerCode.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                }

                else if (!string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex > 0 && cboTransformer.SelectedIndex ==-1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.CustomerCode.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                    u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                    customerList = customer.Where(u => u.CustomerCode.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                      u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                }

                else if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex > 0 && cboTransformer.SelectedIndex == -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                    customerList = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                }
                else if (!string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex > 0 && cboTransformer.SelectedIndex > -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                    && u.CustomerCode.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1
                    && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                    customerList = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                      && u.CustomerCode.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1
                      && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                }
                else if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex > 0 && cboTransformer.SelectedIndex > -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                     && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                    customerList = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                       && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                }
                else if (!string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex == 0 && cboTransformer.SelectedIndex > -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.CustomerCode.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                     && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                    customerList = customer.Where(u => u.CustomerCode.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                      && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                }
                else if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex == 0 && cboTransformer.SelectedIndex > -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.Active == true && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
                    customerList = customer.Where(u => u.Active == true && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList(); ;
                }
                else if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex == 0 && cboTransformer.SelectedIndex ==-1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.Active == true).ToList();
                    customerList = customer.Where(u => u.Active == true).ToList();
                }

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex == 0 && cboTransformer.SelectedIndex ==-1)
                {

                    dgvCustomerList.DataSource = customer.Where(u => u.CustomerNameInEng.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                    customerList = customer.Where(u => u.CustomerNameInEng.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                }

                else if (!string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex > 0 && cboTransformer.SelectedIndex == -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.CustomerNameInEng.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                    u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                    customerList = customer.Where(u => u.CustomerNameInEng.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                      u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                }

                else if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex > 0 && cboTransformer.SelectedIndex == -1)
                {

                    dgvCustomerList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                    customerList = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                }
                else if (!string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex > 0 && cboTransformer.SelectedIndex > -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                    && u.CustomerNameInEng.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1
                    && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                    customerList = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                      && u.CustomerNameInEng.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1
                      && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                }
                else if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex > 0 && cboTransformer.SelectedIndex > -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                     && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                    customerList = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                       && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                }
                else if (!string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex == 0 && cboTransformer.SelectedIndex > -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.CustomerNameInEng.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                     && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                    customerList = customer.Where(u => u.CustomerNameInEng.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true
                       && u.Transformer.TransformerName.IndexOf(cboTransformer.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                }
                else if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) && cboQuarterName.SelectedIndex == 0 && cboTransformer.SelectedIndex == -1)
                {
                    dgvCustomerList.DataSource = customer.Where(u => u.Active == true).ToList();
                    customerList = customer.Where(u => u.Active == true).ToList();
                }
            }

        }

        public void foundDataBind()
        {
            dgvCustomerList.DataSource = "";

            if (customerList.Count < 1)
            {
                MessageBox.Show("No data Found", "Cannot find");
                dgvCustomerList.DataSource = "";
                return;
            }
            else
            {
                dgvCustomerList.DataSource = customerList;
            }
        }
        #endregion

        #region Data Bind By Data Grid
        private void dgvCustomerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCustomerList.Rows)
            {
                Customer customer = (Customer)row.DataBoundItem;
                row.Cells[0].Value = customer.CustomerID;
                row.Cells[1].Value = customer.CustomerCode;
                row.Cells[2].Value = customer.CustomerNameInEng;
                row.Cells[3].Value = customer.CustomerNameInMM;
                row.Cells[4].Value = customer.NRC;
                row.Cells[5].Value = customer.PhoneNo;
                row.Cells[6].Value = customer.Quarter.Township.TownshipNameInEng;
                row.Cells[7].Value = customer.Quarter.QuarterNameInEng;
                row.Cells[8].Value = customer.Meter.MeterNo;
                row.Cells[9].Value = customer.Ledger.BookCode;
                row.Cells[10].Value = customer.BillCode7Layer.BillCode7LayerNo;
            }
        }
        #endregion

        #region Form Load
        private void CustomerListfrm_Load(object sender, EventArgs e)
        {
            FormRefresh();
            bindQuarter();
        }
        #endregion

        #region Bind Combo
        public void bindQuarter()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbsEntities.Quarters.Where(x => x.Active == true).ToList());
            cboQuarterName.DataSource = quarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
        }
        private void BindTransformerCode()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Transformer> transformerList = new List<Transformer>();
            //cboTransformerCode.Items.Clear();
            transformerList.AddRange(mbmsEntities.Transformers.Where(x => x.Quarter.QuarterNameInEng == cboQuarterName.Text && x.Active == true).ToList());
            cboTransformer.DataSource = transformerList;
            cboTransformer.DisplayMember = "TransformerName";
            cboTransformer.ValueMember = "TransformerID";
        }
        #endregion

        #region Datagrid Cell Click
        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 11)
                {
                    DetailCustomerfrm detailCustomerForm = new DetailCustomerfrm();
                    detailCustomerForm.customerID = Convert.ToString(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                    detailCustomerForm.ShowDialog();
                }
            }
        }
        #endregion

        #region Button Click Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCustomerCode.Text = string.Empty;
            cbofileName.SelectedIndex = cboQuarterName.SelectedIndex = 0;
            rdoCustomerCode.Checked = true;
            FormRefresh();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            Customerfrm customerForm = new Customerfrm();
            customerForm.Show();
        }

        private void btnSave2HHUDB_Click(object sender, EventArgs e)
        {

            if (this.customerList.Count == 0)
            {
                MessageBox.Show("There is no Customers data to save HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbofileName.SelectedItem.Equals("Select One"))
            {
                MessageBox.Show("Select HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.Yes)
            {
                MBMSEntities mbsEntities = new MBMSEntities();
                BuildSQLiteConnection();
                ConsumerMasterServices sqlitecustomerservices = new ConsumerMasterServices();
                List<ConsumerMaster> sqlConsumerMasterList = new List<ConsumerMaster>();
                string sqlCommand = string.Format("SELECT * FROM ConsumerMaster");
                var data = sqlitecustomerservices.GetAll(sqlCommand);
                foreach (var v in data)
                {
                    foreach (Customer c in customerList)
                    {
                        if (c.CustomerCode == v.csm_id)
                        {
                            customerList.Remove(c);
                            break;
                            //MessageBox.Show("(" + c.CustomerCode + ") Customer code already exists in HHU db file.", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return;
                        }
                    }
                }

                if (customerList.Count != 0)
                {
                    foreach (Customer c in customerList)
                    {
                        ConsumerMaster consumer = new ConsumerMaster();
                        consumer.csm_id = c.CustomerCode;
                        consumer.csm_name = c.CustomerNameInEng;
                        consumer.csm_village_code = c.Quarter.QuarterCode;
                        consumer.csm_village_name = c.Quarter.QuarterNameInEng;
                        consumer.csm_meter_id = c.Meter.MeterNo;
                        consumer.csm_address_name = c.CustomerAddressInEng;
                        Pole p = mbsEntities.Poles.Where(x => x.Transformer.QuarterID == c.QuarterID).FirstOrDefault();
                        if (p == null)
                        {
                            MessageBox.Show("set Pole data for>" + c.CustomerCode, "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        consumer.csm_gps_h = p.GPSX.ToString();
                        consumer.csm_gps_l = p.GPSY.ToString();
                        sqlConsumerMasterList.Add(consumer);
                    }
                    try
                    {
                        sqlitecustomerservices.AddRange(sqlConsumerMasterList);
                        LoadData();
                        MessageBox.Show("Customers data to HHU db file is successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occur when saving Customers to HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Customers data is already exist in HHU db.", "Inforamation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }

            }
        }
        #endregion

        #region Key Down
        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }
        #endregion

        #region Check Changed

        private void rdoCustomerCode_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomer.Text = "Customer Code";
        }

        private void rdoCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomer.Text = "Customer Name";
        }
        #endregion

        #region Selected Index Change
        private void cboQuarterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTransformerCode();
        }
        #endregion
    }
}
