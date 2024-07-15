using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using MPS.BusinessLogic.MeterController;
using MPS.Customer_Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MPS.Utility;

namespace MPS
{
    public partial class Customerfrm : Form
    {
        #region variable
        IMeter meterservice;
        ICustomer iCustomerServices;
        private ToolTip tooltip = new ToolTip();

        public String UserID { get; set; }
        public Meter meterHistory { get; set; }
        public String customerID { get; set; }
        public Boolean isEdit { get; set; }
        public Boolean isAddList { get; set; }
        string meterId;
        string quarterCustomerID;        
        public string currentMeter { get; set; }

        CustomerController customerController = new CustomerController();
        #endregion

        public Customerfrm()
        {
            InitializeComponent();
            meterservice = new MeterController();
            iCustomerServices = new CustomerController();
        }

        #region Form Load
        private void RegisterCustomer_Load(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();

            bindQuarter();
            //BindTransformerCode();

            bindBillCode();
            bindBookCode();
            txtPageNo.Enabled = false;
            txtLineNo.Enabled = false;
            txtBranchFullCode.Text = SettingController.BranchCode.ToString() + "-" + SettingController.Division.ToString() + "-" + SettingController.TownShip;
            if (isEdit)
            {
                //txtQuarterCode.Text = Convert.ToString(cboQuarterName.SelectedValue);
                btnSave.Text = "Update";
                Customer customer = (from c in mbmsEntities.Customers where c.CustomerID == customerID select c).FirstOrDefault();
                meterId = customer.MeterID;
                cboQuarterName.Text = customer.Quarter.QuarterNameInEng;
                cboTransformerCode.Text = customer.Meter.MeterBox.Pole.Transformer.TransformerName;
                txtAddressEng.Text = customer.CustomerAddressInEng;
                txtAddressMM.Text = customer.CustomerAddressInMM;
                txtCustomerCode.Text = customer.CustomerCode;
                txtCustomerNameEng.Text = customer.CustomerNameInEng;
                txtCustomerNameMM.Text = customer.CustomerNameInMM;
                txtLineNo.Text = Convert.ToString(customer.LineNo);
                txtPageNo.Text = Convert.ToString(customer.PageNo);
                txtPhone.Text = customer.PhoneNo;
                txtPost.Text = customer.Post;
                txtNRC.Text = customer.NRC;
                cboBillCodeNo.Text = Convert.ToString(customer.BillCode7Layer.BillCode7LayerNo);
                cboBookCode.Text = Convert.ToString(customer.Ledger.BookCode);
                txtMeterSerialNo.Text = customer.Meter.MeterNo;
                txtSMDSerial.Text = customer.SMDNo;
            }
            else
                InitialState();
        }
        #endregion

        #region Method
        public void bindQuarter()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true).OrderBy(x => x.QuarterNameInEng).ToList());
            cboQuarterName.DataSource = quarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
        }

        public void bindBillCode()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<BillCode7Layer> billode7LayerList = new List<BillCode7Layer>();
            BillCode7Layer billCode = new BillCode7Layer();
            billCode.BillCode7LayerID = Convert.ToString(0);
            billCode.BillCode7LayerNo = 0;
            billode7LayerList.Add(billCode);
            billode7LayerList.AddRange(mbmsEntities.BillCode7Layer.Where(x => x.Active == true).OrderBy(x => x.BillCode7LayerNo).ToList());
            cboBillCodeNo.DataSource = billode7LayerList;
            cboBillCodeNo.DisplayMember = "BillCode7LayerNo";
            cboBillCodeNo.ValueMember = "BillCode7LayerID";
        }

        public void bindBookCode()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Ledger> ledgerList = new List<Ledger>();
            Ledger ledger = new Ledger();
            ledger.LedgerID = Convert.ToString(0);
            ledger.BookCode = 0;
            ledgerList.Add(ledger);
            ledgerList.AddRange(mbmsEntities.Ledgers.Where(x => x.Transformer.TransformerName == cboTransformerCode.Text && x.Active == true).OrderBy(x => x.BookCode).ToList());
            cboBookCode.DataSource = ledgerList;
            cboBookCode.DisplayMember = "BookCode";
            cboBookCode.ValueMember = "LedgerID";
        }

        private void BindTransformerCode()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Transformer> transformerList = new List<Transformer>();
            //cboTransformerCode.Items.Clear();
            transformerList.AddRange(mbmsEntities.Transformers.Where(x => x.Quarter.QuarterNameInEng == cboQuarterName.Text && x.Active == true).ToList());
            cboTransformerCode.DataSource = transformerList;
            cboTransformerCode.DisplayMember = "TransformerName";
            cboTransformerCode.ValueMember = "TransformerID";
        }

        public bool checkValidation()
        {
            bool hasError = true;
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";
            //  if (cboTownshipName.SelectedIndex == 0)
            //{
            //    tooltip.SetToolTip(cboTownshipName, "Error");
            //    tooltip.Show("Please choose Township Name!", cboTownshipName);
            //    cboTownshipName.Focus();
            //    hasError = false;
            //}
            if (cboQuarterName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboQuarterName, "Require");
                tooltip.Show("Please choose Quarter Name!", cboQuarterName);
                cboQuarterName.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtCustomerCode.Text))
            {
                tooltip.SetToolTip(txtCustomerCode, "Require");
                tooltip.Show("Please fill up Customer Code!", txtCustomerCode);
                txtCustomerCode.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtCustomerNameEng.Text))
            {
                tooltip.SetToolTip(txtCustomerNameEng, "Require");
                tooltip.Show("Please fill up Customer Name (English)!", txtCustomerNameEng);
                txtCustomerNameEng.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtCustomerNameMM.Text))
            {
                tooltip.SetToolTip(txtCustomerNameMM, "Require");
                tooltip.Show("Please fill up Customer Name (Myanmar)!", txtCustomerNameMM);
                txtCustomerNameMM.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtNRC.Text))
            {
                tooltip.SetToolTip(txtNRC, "Require");
                tooltip.Show("Please fill up NRC!", txtNRC);
                txtNRC.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                tooltip.SetToolTip(txtPhone, "Require");
                tooltip.Show("Please fill up Phone No!", txtPhone);
                txtPhone.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtAddressEng.Text))
            {
                tooltip.SetToolTip(txtAddressEng, "Require");
                tooltip.Show("Please fill up Address (English)!", txtAddressEng);
                txtAddressEng.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtAddressMM.Text))
            {
                tooltip.SetToolTip(txtAddressMM, "Require");
                tooltip.Show("Please fill up Address (Myanmar)!", txtAddressMM);
                txtAddressMM.Focus();
                hasError = false;
            }
            else if (String.IsNullOrWhiteSpace(txtMeterSerialNo.Text))
            {
                tooltip.SetToolTip(txtMeterSerialNo, "Require");
                tooltip.Show("Please choose Meter No!", txtMeterSerialNo);
                btnMeterSearch.Focus();
                hasError = false;
            }
            else if (cboBookCode.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboBookCode, "Require");
                tooltip.Show("Please choose Book Code!", cboBookCode);
                cboBookCode.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtPageNo.Text))
            {
                tooltip.SetToolTip(txtPageNo, "Require");
                tooltip.Show("Please fill up Page No!", txtPageNo);
                txtPageNo.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtLineNo.Text))
            {
                tooltip.SetToolTip(txtLineNo, "Require");
                tooltip.Show("Please fill up Line No!", txtLineNo);
                txtLineNo.Focus();
                hasError = false;
            }
            else if (cboBillCodeNo.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboBillCodeNo, "Require");
                tooltip.Show("Please choose Bill Code No!", cboBillCodeNo);
                cboBillCodeNo.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtSMDSerial.Text))
            {
                tooltip.SetToolTip(txtSMDSerial, "Require");
                tooltip.Show("Please fill up SMD Serial!", txtSMDSerial);
                txtSMDSerial.Focus();
                hasError = false;
            }
            return hasError;
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
        public void InitialState()
        {
            if (!CheckingRoleManagementFeature("CustomerAdd"))
            {
                btnSave.Enabled = false;
            }
            txtAddressEng.Clear();
            txtAddressMM.Clear();
            txtCustomerCode.Clear();
            txtCustomerNameEng.Clear();
            txtCustomerNameMM.Clear();
            txtLineNo.Clear();
            txtNRC.Clear();
            txtPageNo.Clear();
            txtPhone.Clear();
            txtPost.Clear();
            cboBillCodeNo.SelectedIndex = 0;
            cboBookCode.SelectedIndex = -1;
            txtMeterSerialNo.Clear();
            cboQuarterName.SelectedIndex = 0;
            txtSMDSerial.Clear();
            cboTransformerCode.DataSource = null;
            txtQuarterCode.Clear();
            txtCustomerCode.Focus();
            btnSave.Text = "Save";
            isEdit = false;
        }

        private void UpdateCustomer()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();
                int editBookCode = 0; int editPageNo = 0; int editLineNo = 0; int editLineCount = 0;
                int editMeterCount = 0;
                editBookCode = Convert.ToInt32(cboBookCode.Text);
                editLineNo = Convert.ToInt32(txtLineNo.Text);
                editPageNo = Convert.ToInt32(txtPageNo.Text);

                int editCustomerCodeCount = 0, editNRCCount = 0;
                Customer updateCustomer = (from c in mbmsEntities.Customers where c.CustomerID == customerID select c).FirstOrDefault();
                List<Customer> updateOldCustomer = (from c in mbmsEntities.Customers where c.PreviousID == customerID && c.Active == false select c).ToList();
                if (txtCustomerCode.Text != updateCustomer.CustomerCode)
                {
                    editCustomerCodeCount = (from c in mbmsEntities.Customers where c.CustomerCode == txtCustomerCode.Text && c.Active == true select c).ToList().Count;
                }
                if (txtMeterSerialNo.Text != updateCustomer.Meter.MeterNo)
                {
                    editMeterCount = (from c in mbmsEntities.Customers where c.Meter.MeterNo == txtMeterSerialNo.Text && c.Active == true select c).ToList().Count;
                }

                if (editMeterCount > 0)
                {
                    tooltip.SetToolTip(txtMeterSerialNo, "Error");
                    tooltip.Show("Meter Serial No is already used!", txtMeterSerialNo);
                    return;
                }
                if (cboQuarterName.Text != updateCustomer.Quarter.QuarterNameInEng)
                {
                    if (txtMeterSerialNo.Text == updateCustomer.Meter.MeterNo)
                    {
                        tooltip.SetToolTip(txtMeterSerialNo, "Error");
                        tooltip.Show("This Customer change Quarter.Need Meter No Change!", txtMeterSerialNo);
                        return;
                    }
                    else
                    {
                        //MBMSEntities mbmsEEntites = new MBMSEntities();
                        Customer quarterCustomer = new Customer();
                        quarterCustomer.CustomerID = Guid.NewGuid().ToString();
                        quarterCustomer.CustomerCode = txtCustomerCode.Text;
                        quarterCustomer.CustomerNameInEng = txtCustomerNameEng.Text;
                        quarterCustomer.CustomerNameInMM = txtCustomerNameMM.Text;
                        quarterCustomer.CustomerAddressInEng = txtAddressEng.Text;
                        quarterCustomer.CustomerAddressInMM = txtAddressMM.Text;
                        quarterCustomer.NRC = txtNRC.Text;
                        quarterCustomer.PhoneNo = txtPhone.Text;
                        quarterCustomer.Post = txtPost.Text;
                        if (Convert.ToInt32(txtLineNo.Text) <= 30)
                            quarterCustomer.LineNo = Convert.ToInt32(txtLineNo.Text);
                        else
                        {
                            tooltip.SetToolTip(txtLineNo, "Error");
                            tooltip.Show("Customer Line No is Greater than 30!", txtLineNo);
                            return;
                        }
                        if (Convert.ToInt32(txtPageNo.Text) <= 90)
                            quarterCustomer.PageNo = Convert.ToInt32(txtPageNo.Text);
                        else
                        {
                            tooltip.SetToolTip(txtPageNo, "Error");
                            tooltip.Show("Customer Line No is Greater than 90!", txtPageNo);
                            return;
                        }
                        
                        quarterCustomer.LedgerID = cboBookCode.SelectedValue.ToString();
                        quarterCustomer.QuarterID = cboQuarterName.SelectedValue.ToString();
                        //quarterCustomer.PreviousID = customerID;
                        quarterCustomer.TransformerID = cboTransformerCode.SelectedValue.ToString();
                        quarterCustomer.BillCode7LayerID = cboBillCodeNo.SelectedValue.ToString();
                        quarterCustomer.MeterID = meterId;
                        quarterCustomer.SMDNo = txtSMDSerial.Text;
                        quarterCustomer.Active = true;
                        quarterCustomer.CreatedUserID = UserID;
                        quarterCustomer.CreatedDate = DateTime.Now;
                        quarterCustomerID = quarterCustomer.CustomerID;
                        updateCustomer.PreviousID = quarterCustomerID;
                        updateCustomer.Active = false;
                        if (updateOldCustomer != null)
                        {
                            for (int i = 0; i < updateOldCustomer.Count; i++)
                            {
                                updateOldCustomer[i].PreviousID = quarterCustomerID;
                            }
                        }
                        mbmsEntities.Customers.Add(quarterCustomer);
                        mbmsEntities.SaveChanges();
                        MessageBox.Show("Successfully Updated Customer!", "Update");
                        InitialState();
                        return;
                    }
                }
                if (txtNRC.Text != updateCustomer.NRC)
                {
                    editNRCCount = (from c in mbmsEntities.Customers where c.NRC == txtNRC.Text && c.Active == true select c).ToList().Count;
                }
                if (editLineNo != updateCustomer.LineNo)
                {
                    editLineCount = (from c in mbmsEntities.Customers where (c.Ledger.BookCode == editBookCode && c.LineNo == editLineNo && c.PageNo == editPageNo) && c.Active == true select c).ToList().Count;
                }

                if (editCustomerCodeCount > 0)
                {
                    tooltip.SetToolTip(txtCustomerCode, "Error");
                    tooltip.Show("Customer Code is already exist!", txtCustomerCode);
                    return;
                }
                if (editNRCCount > 0)
                {
                    tooltip.SetToolTip(txtNRC, "Error");
                    tooltip.Show("NRC is already exist!", txtNRC);
                    return;
                }
                if (editLineCount > 0)
                {
                    tooltip.SetToolTip(txtLineNo, "Error");
                    tooltip.Show("Line No is already used!", txtLineNo);
                    return;
                }

                string oldMeterNo = updateCustomer.Meter.MeterNo;
                updateCustomer.CustomerCode = txtCustomerCode.Text;
                updateCustomer.CustomerNameInEng = txtCustomerNameEng.Text;
                updateCustomer.CustomerNameInMM = txtCustomerNameMM.Text;
                updateCustomer.CustomerAddressInEng = txtAddressEng.Text;
                updateCustomer.CustomerAddressInMM = txtAddressMM.Text;
                updateCustomer.NRC = txtNRC.Text;
                updateCustomer.PhoneNo = txtPhone.Text;
                updateCustomer.Post = txtPost.Text;
                if (Convert.ToInt32(txtLineNo.Text) <= 30)
                    updateCustomer.LineNo = Convert.ToInt32(txtLineNo.Text);
                else
                {
                    tooltip.SetToolTip(txtLineNo, "Error");
                    tooltip.Show("Customer Line No is Greater than 30!", txtLineNo);
                    return;
                }
                if (Convert.ToInt32(txtPageNo.Text) <= 90)
                    updateCustomer.PageNo = Convert.ToInt32(txtPageNo.Text);
                else
                {
                    tooltip.SetToolTip(txtPageNo, "Error");
                    tooltip.Show("Customer Line No is Greater than 90!", txtPageNo);
                    return;
                }
                updateCustomer.LedgerID = cboBookCode.SelectedValue.ToString();
                updateCustomer.QuarterID = cboQuarterName.SelectedValue.ToString();
                updateCustomer.PreviousID = quarterCustomerID;
                updateCustomer.TransformerID = cboTransformerCode.SelectedValue.ToString();
                updateCustomer.BillCode7LayerID = cboBillCodeNo.SelectedValue.ToString();
                updateCustomer.MeterID = meterId;
                updateCustomer.SMDNo = txtSMDSerial.Text;
                updateCustomer.UpdatedUserID = UserID;
                updateCustomer.UpdatedDate = DateTime.Now;
                customerController.UpdateCustomer(updateCustomer);
                //updating the meter history information
                if (!txtMeterSerialNo.Text.Equals(oldMeterNo) && meterHistory != null)
                {
                    currentMeter = updateCustomer.MeterID;
                    
                }
                MessageBox.Show("Successfully Updated Customer!", "Update");
                InitialState();
                //CustomerListfrm customerListForm = new CustomerListfrm();
                //customerListForm.UserID = UserID;
                //customerListForm.Show();
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();
                int customerCodeCount = 0, nrcCount = 0;
                customerCodeCount = (from c in mbmsEntities.Customers where c.CustomerCode == txtCustomerCode.Text && c.Active == true select c).ToList().Count;
                nrcCount = (from c in mbmsEntities.Customers where c.NRC == txtNRC.Text && c.Active == true select c).ToList().Count;
                int bookCode = 0; int pageNo = 0; int lineNo = 0; int lineCount = 0;
                bookCode = Convert.ToInt32(cboBookCode.Text);
                lineNo = Convert.ToInt32(txtLineNo.Text);
                pageNo = Convert.ToInt32(txtPageNo.Text);

                lineCount = (from c in mbmsEntities.Customers where (c.Ledger.BookCode == bookCode && c.PageNo == pageNo && c.LineNo == lineNo) && c.Active == true select c).ToList().Count;


                if (customerCodeCount > 0)
                {
                    tooltip.SetToolTip(txtCustomerCode, "Error");
                    tooltip.Show("Customer Code is already exist!", txtCustomerCode);
                    return;
                }
                if (nrcCount > 0)
                {
                    tooltip.SetToolTip(txtNRC, "Error");
                    tooltip.Show("Customer NRC is already exist!", txtNRC);
                    return;
                }
                if (lineCount > 0)
                {
                    tooltip.SetToolTip(txtLineNo, "Error");
                    tooltip.Show("Line No is already used!", txtLineNo);
                    return;
                }
                bool IsMeterIDExists = iCustomerServices.GetCustomerByMeterID(meterId);
                if (IsMeterIDExists)
                {
                    MessageBox.Show("Customer's Meter No already exists in the system for>" + txtCustomerCode.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool IsSMDSerialExist = mbmsEntities.Customers.Any(x => x.SMDNo == txtSMDSerial.Text);
                if (IsSMDSerialExist)
                {
                    tooltip.SetToolTip(txtSMDSerial, "Error");
                    tooltip.Show("Customer SMD Serial No is already exist!", txtSMDSerial);
                    return;
                }
                Customer customer = new Customer();
                customer.CustomerID = Guid.NewGuid().ToString();
                customer.CustomerCode = txtCustomerCode.Text;
                customer.CustomerNameInEng = txtCustomerNameEng.Text;
                customer.CustomerNameInMM = txtCustomerNameMM.Text;
                customer.CustomerAddressInEng = txtAddressEng.Text;
                customer.CustomerAddressInMM = txtAddressMM.Text;
                customer.NRC = txtNRC.Text;
                customer.PhoneNo = txtPhone.Text;
                customer.Post = txtPost.Text;
                if (Convert.ToInt32(txtLineNo.Text) <= 30)
                    customer.LineNo = Convert.ToInt32(txtLineNo.Text);
                else
                {
                    tooltip.SetToolTip(txtLineNo, "Error");
                    tooltip.Show("Customer Line No is Greater than 30!", txtLineNo);
                    return;
                }
                if (Convert.ToInt32(txtPageNo.Text) <=90)
                customer.PageNo = Convert.ToInt32(txtPageNo.Text);
                else
                {
                    tooltip.SetToolTip(txtPageNo, "Error");
                    tooltip.Show("Customer Line No is Greater than 90!", txtPageNo);
                    return;
                }

                customer.LedgerID = cboBookCode.SelectedValue.ToString();
                customer.QuarterID = cboQuarterName.SelectedValue.ToString();
                customer.TransformerID = cboTransformerCode.SelectedValue.ToString();
                customer.BillCode7LayerID = cboBillCodeNo.SelectedValue.ToString();
                customer.MeterID = meterId;
                customer.SMDNo = txtSMDSerial.Text;
                customer.Active = true;
                customer.CreatedUserID = UserID;
                customer.CreatedDate = DateTime.Now;
                customerController.Save(customer);
                MessageBox.Show("Successfully registered Customer! Please check it in 'Customer List", "Save Success");
                InitialState();
                if (isAddList)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValidation())
            {
                if (isEdit)
                {
                    UpdateCustomer();
                }
                else
                {
                    Save();
                }
            }
        }

        private void btnMeterSearch_Click(object sender, EventArgs e)
        {
            frmMeterSearch meterSearch = new frmMeterSearch();
            if (!string.IsNullOrEmpty(cboTransformerCode.Text))
            {
                meterSearch.transformer = cboTransformerCode.Text;
                var result = meterSearch.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtMeterSerialNo.Text = meterSearch.meterNo;
                    meterId = meterSearch.meterId;
                }
            }
            else
            {
                MessageBox.Show("Select Transformer Code First", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTransformerCode.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();
        }
        #endregion

        #region IndexChanged Event
        private void cboBookCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPageNo.Enabled = true;
            txtLineNo.Enabled = true;
        }

        private void cboQuarterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            BindTransformerCode();
            if (cboQuarterName.SelectedIndex > 0)
            {
                string quarterID = Convert.ToString(cboQuarterName.SelectedValue);
                var quarterData = (from q in mbmsEntities.Quarters where q.QuarterID == quarterID select q).FirstOrDefault();
                txtQuarterCode.Text = quarterData.QuarterCode;
            }
        }

        private void cboTransformerCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindBookCode();
        }
        #endregion

        #region Key Down
        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtCustomerNameEng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtCustomerNameMM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtNRC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void cboTownshipName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void cboBillCodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }
        #endregion

        #region Mouse Move
        private void Customerfrm_MouseMove(object sender, MouseEventArgs e)
        {
            //tooltip.Hide(cboTownshipName);
            tooltip.Hide(cboQuarterName);
            tooltip.Hide(txtCustomerCode);
            tooltip.Hide(txtCustomerNameEng);
            tooltip.Hide(txtCustomerNameMM);
            tooltip.Hide(txtNRC);
            tooltip.Hide(txtPhone);
            tooltip.Hide(txtAddressEng);
            tooltip.Hide(txtAddressMM);
            tooltip.Hide(txtMeterSerialNo);
            tooltip.Hide(txtPhone);
            tooltip.Hide(txtLineNo);
            tooltip.Hide(cboBillCodeNo);
            tooltip.Hide(cboBookCode);
        }
        #endregion

        #region Key Press

        private void txtCustomerCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtCustomerNameEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtSMDSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtPost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtPageNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtLineNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }


        #endregion

       
    }
}
