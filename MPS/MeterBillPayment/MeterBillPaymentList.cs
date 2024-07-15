using MBMS.DAL;
using MPS.BusinessLogic.MeterBillCalculationController;
using MPS.MeterBillCalculation;
using MPS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.MeterBillPayment
{
    public partial class MeterBillPaymentList : Form
    {
        #region Variables
        MBMSEntities mBMSEntities = new MBMSEntities();

        public String UserID { get; set; }

        IMeterBillCalculateServices meterbillcalculateservice;

        List<MeterBillInvoiceVM> data = null;
        #endregion
        public MeterBillPaymentList()
        {
            InitializeComponent();
            meterbillcalculateservice = new MeterBillCalculateController();
        }

        #region Form Load
        private void MeterBillPaymentUI_Load(object sender, EventArgs e)
        {
            BindTransformer();
            bindQuarterData();
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "MM/dd/yyyy";
            dtptoDate.Format = DateTimePickerFormat.Custom;
            dtptoDate.CustomFormat = "MM/dd/yyyy";
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

        private void BindTransformer()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Transformer> transformerList = new List<Transformer>();
            Transformer transformer = new Transformer();
            transformer.TransformerID = Convert.ToString(0);
            transformer.TransformerName = "Select";
            transformerList.Add(transformer);
            transformerList.AddRange(mbmsEntities.Transformers.Where(x => x.Quarter.QuarterNameInEng == cboQuarter.Text && x.Active == true).ToList());
            cboTransformerName.DataSource = transformerList;
            cboTransformerName.DisplayMember = "TransformerName";
            cboTransformerName.ValueMember = "TransformerID";
        }
        #endregion

        #region Button Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            data = new List<MeterBillInvoiceVM>();
            this.gvmeterbillinvoice.DataSource = null;
            this.gvmeterbillinvoice.AutoGenerateColumns = false;
            string Customerid = string.Empty;
            string quarterid = string.Empty;
            string townshipid = string.Empty;
            string meterBillCode = string.Empty;
            if (cboQuarter.Text != "Select One") quarterid = cboQuarter.SelectedValue.ToString();
            if (cboTransformerName.Text != "Select One") townshipid = cboTransformerName.SelectedValue.ToString();
            if (rdoCustomerName.Checked)
            {
                if (!string.IsNullOrEmpty(txtBillCodeNo.Text))
                {
                    Customer c = mBMSEntities.Customers.Where(x => x.Active == true && x.CustomerNameInEng.Equals(txtBillCodeNo.Text)).SingleOrDefault();
                    if (c == null)
                    {
                        MessageBox.Show("There is no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else Customerid = c.CustomerID;
                }
            }

            else if (rdoCustomerCode.Checked)
            {
                if (!string.IsNullOrEmpty(txtBillCodeNo.Text))
                {
                    Customer c = mBMSEntities.Customers.Where(x => x.Active == true && x.CustomerCode == txtBillCodeNo.Text).SingleOrDefault();
                    if (c == null)
                    {
                        MessageBox.Show("There is no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else Customerid = c.CustomerID;
                }
            }
            else if (rdoMeterBillCode.Checked)
            {
                meterBillCode = txtBillCodeNo.Text;
            }

            data = meterbillcalculateservice.GetmeterBillInvoices(dtpFromDate.Value,
                    dtptoDate.Value,
                   townshipid,
                  quarterid,
                    Customerid,
                    meterBillCode);
            if (data.Count == 0)
            {
                MessageBox.Show("There is no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.gvmeterbillinvoice.DataSource = data;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();
        }

        #endregion

        #region Data Grid Cell Click

        private void gvmeterbillinvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Payment function
                if (e.ColumnIndex == 21)
                {
                    if (!CheckingRoleManagementFeature("BillPaymentEditOrDelete"))
                    {
                        MessageBox.Show("Access Denied For this Function","Permission",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }
                    DataGridViewRow row = gvmeterbillinvoice.Rows[e.RowIndex];
                    MeterBillInvoiceVM meterBillInvoice = (MeterBillInvoiceVM)row.DataBoundItem;//get the selected row's data 
                    var previousPaidCheck = mBMSEntities.MeterBills.Where(x => x.Active == true && x.MeterUnitCollect.Customer.CustomerCode == meterBillInvoice.CustomerCode && x.isPaid==false).OrderBy(x => x.InvoiceDate).Select(x=>x.InvoiceDate).FirstOrDefault();
                    if(previousPaidCheck !=null && previousPaidCheck.Month!= meterBillInvoice.InvoiceDate.Month)
                    {
                        MessageBox.Show("This Customer Not Paid Previous Month", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }else
                    {
                        MeterBillPaymentByCash paymentbycash = new MeterBillPaymentByCash();
                        paymentbycash.UserID = this.UserID;
                        paymentbycash.vm = meterBillInvoice;
                        paymentbycash.MeterBillId = meterBillInvoice.MeterBillID;
                        paymentbycash.isPayment = true;
                        var result = paymentbycash.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            btnSearch_Click(this, new EventArgs());
                        }
                    }
                    
                }//end of edit function
            }
        }
        #endregion

        #region Method
        private void InitialState()
        {
            if (!CheckingRoleManagementFeature(""))
            {

            }
            dtpFromDate.Value = dtptoDate.Value = DateTime.Now;
            cboTransformerName.Text = cboQuarter.Text = "Select One";
            txtBillCodeNo.Clear();
            gvmeterbillinvoice.DataSource = null;
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
        #endregion

        #region Key Down
        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }

        private void txtBillCodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }
        #endregion

        #region Check Change And Index Change
        private void cboQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            BindTransformer();
            if (cboQuarter.SelectedIndex == 0)
            {
                cboTransformerName.Text = "Select One";
            }
        }

        private void rdoMeterBillCode_CheckedChanged(object sender, EventArgs e)
        {
            lblMeterPayment.Text = "Meter Bill Code:";
        }

        private void rdoCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            lblMeterPayment.Text = "Customer Name:";
        }

        private void rdoCustomerCode_CheckedChanged(object sender, EventArgs e)
        {
            lblMeterPayment.Text = "Customer Code:";
        }
        #endregion
    }
}
