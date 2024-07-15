using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Customer_Setup
{
    public partial class CustomerListfrm : Form
    {
        #region Variables
        CustomerController customerController = new CustomerController();
        
        string customerID;
        public string UserID { get; set; }
        #endregion

        public CustomerListfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void CustomerListfrm_Load(object sender, EventArgs e)
        {
            bindQuarter();
            bindTransformer();
            FormRefresh();
            InitialState();
        }
        #endregion

        #region Methods
        public void FormRefresh()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            dgvCustomerList.AutoGenerateColumns = false;
            dgvCustomerList.DataSource = (from c in mbsEntities.Customers where c.Active == true orderby c.CustomerCode select c).ToList();
        }

        public void bindQuarter()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<Quarter> QuarterList = new List<Quarter>();
            Quarter Quarter = new Quarter();
            Quarter.QuarterID = Convert.ToString(0);
            Quarter.QuarterNameInEng = "Select";
            QuarterList.Add(Quarter);
            QuarterList.AddRange(mbsEntities.Quarters.Where(x => x.Active == true).ToList());
            cboQuarterName.DataSource = QuarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
        }

        public void bindTransformer()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Transformer> transformerList = new List<Transformer>();
            Transformer Transformer = new Transformer();
            Transformer.TransformerID = Convert.ToString(0);
            Transformer.TransformerName = "Select";
            transformerList.Add(Transformer);
            transformerList.AddRange(mbmsEntities.Transformers.Where(x => x.Quarter.QuarterNameInEng == cboQuarterName.Text && x.Active == true).ToList());
            cboTransformerName.DataSource = transformerList;
            cboTransformerName.DisplayMember = "TransformerName";
            cboTransformerName.ValueMember = "TransformerID";
        }

        public void LoadData()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<Customer> customerList = new List<Customer>();

            if (cboQuarterName.SelectedIndex != 0 && cboTransformerName.SelectedIndex != 0)
            {
                customerList = (from c in mbsEntities.Customers
                                join q in mbsEntities.Quarters on c.QuarterID equals q.QuarterID
                                join t in mbsEntities.Transformers on c.TransformerID equals t.TransformerID
                                where q.QuarterNameInEng == cboQuarterName.Text
                                && t.TransformerName == cboTransformerName.Text && c.Active ==true
                                select c).OrderBy(x=>x.CustomerCode).ToList();
            }
            else if (cboQuarterName.SelectedIndex != 0 && cboTransformerName.SelectedIndex == 0)
            {
                customerList = (from c in mbsEntities.Customers
                                join q in mbsEntities.Quarters on c.QuarterID equals q.QuarterID
                                where q.QuarterNameInEng == cboQuarterName.Text && c.Active==true
                                select c).OrderBy(x=>x.CustomerCode).ToList();
            }
            else
            {
                customerList = (from c in mbsEntities.Customers where c.Active==true
                                select c).OrderBy(x=>x.CustomerCode).ToList();
            }

            if (!String.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                if (rdoCustomerCode.Checked==true)
                {
                    dgvCustomerList.DataSource = customerList.Where(c => c.CustomerCode.IndexOf(txtCustomer.Text, StringComparison.OrdinalIgnoreCase) != -1 && c.Active==true).OrderBy(x=>x.CustomerCode).ToList();
                }
                else
                {
                    dgvCustomerList.DataSource = customerList.Where(c => c.CustomerNameInEng.IndexOf(txtCustomer.Text, StringComparison.OrdinalIgnoreCase) != -1 && c.Active ==true).OrderBy(x=>x.CustomerCode).ToList();
                }
            }
            else
            {
                dgvCustomerList.DataSource = customerList.ToList();
            }
        }
        private void InitialState()
        {
            //if (!CheckingRoleManagementFeature("CustomerView"))
            //{
            //    MessageBox.Show("Access Denied For this Function","Permission",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //    this.Close();
            //}else
            
                txtCustomer.Text = string.Empty;
                txtCustomer.Text = string.Empty;
                cboQuarterName.SelectedIndex = 0;
                cboTransformerName.SelectedIndex = 0;
                rdoCustomerCode.Checked = true;
            
           
        }
        private bool CheckingRoleManagementFeature(string ProgramName)
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            bool IsAllowed = false;
            string roleID = mbsEntities.Users.Where(x => x.Active == true && x.UserID == UserID).SingleOrDefault().RoleID;
            List<RoleManagement> rolemgtList = mbsEntities.RoleManagements.Where(x => x.Active == true && x.RoleID == roleID).ToList();
            foreach (RoleManagement item in rolemgtList)
            {
                //bill payment Menu Permission CustomerView
                if (item.RoleFeatureName.Equals(ProgramName) && item.IsAllowed) IsAllowed = item.IsAllowed;
            }
            return IsAllowed;
        }
        #endregion

        #region Grid Bind
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
                row.Cells[6].Value = customer.Transformer.TransformerName;
                row.Cells[7].Value = customer.Quarter.QuarterNameInEng;
                row.Cells[8].Value = customer.Transformer.TransformerName;
                row.Cells[9].Value = customer.Meter.MeterNo;
                row.Cells[10].Value = customer.Ledger.BookCode;
                row.Cells[11].Value = customer.BillCode7Layer.BillCode7LayerNo;
                row.Cells[12].Value = customer.SMDNo;
            }
        }
        #endregion

        #region Click Event
        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 15)
                {
                    //DeleteForCustomer
                    if (!CheckingRoleManagementFeature("CustomerEditOrDelete"))
                    {
                        MessageBox.Show("Access Denied for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvCustomerList.Rows[e.RowIndex];
                        customerID = Convert.ToString(row.Cells[0].Value);

                        dgvCustomerList.DataSource = "";
                        Customer customer = (from c in mbsEntities.Customers where c.CustomerID == customerID select c).FirstOrDefault();
                        customer.Active = false;
                        customer.DeletedUserID = UserID;
                        customer.DeletedDate = DateTime.Now;
                        customerController.DeleteCustomer(customer);
                        dgvCustomerList.DataSource = (from c in mbsEntities.Customers where c.Active == true orderby c.CustomerCode descending select c).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRefresh();
                    }

                }
                else if (e.ColumnIndex == 13)
                {
                    //if (!CheckingRoleManagementFeature("CustomerView"))
                    //{
                    //    MessageBox.Show("Access Denied for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    DetailCustomerfrm detailCustomerForm = new DetailCustomerfrm();
                    detailCustomerForm.customerID = Convert.ToString(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                    detailCustomerForm.ShowDialog();

                }
                else if (e.ColumnIndex == 14)
                {
                    //EditCustomer
                    if (!CheckingRoleManagementFeature("CustomerEditOrDelete"))
                    {
                        MessageBox.Show("Access Denied for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Customerfrm customerForm = new Customerfrm();
                    customerForm.isEdit = true;
                    customerForm.Text = "Edit Customer";
                    customerForm.customerID = Convert.ToString(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                    customerForm.UserID = UserID;
                    var result = customerForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        FormRefresh();
                    }
                }
            }
        }


        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitialState();
            FormRefresh();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            if (!CheckingRoleManagementFeature("CustomerAdd"))
            {
                MessageBox.Show("Access Denied for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Customerfrm customerForm = new Customerfrm();
            customerForm.UserID = UserID;
            customerForm.isAddList = true;
            var result = customerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadData();
            }
        }
        #endregion

        #region Key Down
        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }
        #endregion

        #region CheckedChanged
        private void rdoCustomerCode_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomer.Text = "Customer Code";
        }

        private void rdoCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomer.Text = "Customer Name";
        }
        #endregion

        private void cboQuarterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindTransformer();
        }
    }
}
