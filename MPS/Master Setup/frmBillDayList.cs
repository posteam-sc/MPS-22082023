using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Master_Setup
{
    public partial class frmBillDayList : Form
    {
        #region Variables
        MBMSEntities mbsEntities = new MBMSEntities();
        BillDayController billDayController = new BillDayController();
        private List<BillDay> billDay = new List<BillDay>();

        public string UserID { get; set; }
        #endregion

        public frmBillDayList()
        {
            InitializeComponent();
        }

        private void frmBillDayList_Load(object sender, EventArgs e)
        {
            FormRefresh();
            BindQuarter();
            BindTransformer();
            BindGroupCode();
        }

        #region DataBinding for DatagridView

        private void dgvBillDayList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvBillDayList.Rows)
            {
                Customer customer = (Customer)row.DataBoundItem;
                row.Cells[0].Value = customer.CustomerID;
                row.Cells[1].Value = customer.CustomerCode;
                row.Cells[2].Value = customer.CustomerNameInEng;
                row.Cells[3].Value = customer.CustomerAddressInEng;
                row.Cells[4].Value = customer.PhoneNo;
                row.Cells[5].Value = customer.Meter.MeterNo;
                row.Cells[6].Value = customer.BillCode7Layer.BillCode7LayerNo;
                row.Cells[7].Value = customer.BillDayGroupCode;

            }
        }

        #endregion

        #region Bind Combo
        private void BindQuarter()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbsEntities.Quarters.Where(x => x.Active == true).OrderBy(x => x.QuarterNameInEng).ToList());
            cboQuarterName.DataSource = quarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
        }

        private void BindTransformer()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<Transformer> transformerList = new List<Transformer>();
            Transformer transformer = new Transformer();
            transformer.TransformerID = Convert.ToString(0);
            transformer.TransformerName = "Select";
            transformerList.Add(transformer);
            transformerList.AddRange(mbsEntities.Transformers.Where(x => x.Active == true && x.Quarter.QuarterNameInEng == cboQuarterName.Text).OrderBy(x => x.TransformerName).ToList());
            cboTransformerName.DataSource = transformerList;
            cboTransformerName.DisplayMember = "TransformerName";
            cboTransformerName.ValueMember = "TransformerID";
        }

        private void BindGroupCode()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<BillDay> billDayList = new List<BillDay>();
            BillDay billDay = new BillDay();
            billDay.BillDayGroupCode = Convert.ToString(0);
            billDay.BillDayGroupCode = "Select";
            billDayList.Add(billDay);
            billDayList.AddRange(mbsEntities.BillDays.Where(x => x.Active == true && x.BillDayGroupCode.Trim() ==x.BillDayGroupCode.Trim()).OrderBy(x => x.BillDayGroupCode).ToList());
            cboGroupCode.DataSource = billDayList;
            cboGroupCode.DisplayMember = "BillDayGroupCode".TrimEnd();
            cboGroupCode.ValueMember = "BillDayGroupCode".TrimEnd();
        }
        #endregion

        #region Method 

        public void FormRefresh()
        {
            dgvBillDayList.AutoGenerateColumns = false;
            dgvBillDayList.DataSource = (from b in mbsEntities.Customers where b.Active == true && b.BillDayGroupCode != null orderby b.CustomerNameInEng descending select b).ToList();
        }

        private void Clear()
        {
            cboGroupCode.SelectedIndex=0;
            cboQuarterName.SelectedIndex = 0;
            cboTransformerName.SelectedIndex = 0;                
        }

        private void Search()
        {

            MBMSEntities mbsEntites = new MBMSEntities();
            var customer = mbsEntites.Customers.Where(c => c.Active == true && c.BillDayGroupCode!=null).ToList();
            if (cboGroupCode.SelectedIndex  > 0 && cboQuarterName.SelectedIndex == 0 && cboTransformerName.SelectedIndex==0)
            {
                dgvBillDayList.DataSource = customer.Where(u => u.BillDayGroupCode.Trim() == cboGroupCode.Text.Trim()).ToList();
            }
            else if (cboGroupCode.SelectedIndex > 0 && cboQuarterName.SelectedIndex > 0 && cboTransformerName.SelectedIndex == 0)
            {
                dgvBillDayList.DataSource = customer.Where(u => u.BillDayGroupCode.Trim() == cboGroupCode.Text.Trim() &&
                u.Quarter.QuarterNameInEng.Trim() == cboQuarterName.Text.Trim() ).ToList();
            }
            else if (cboGroupCode.SelectedIndex > 0 && cboQuarterName.SelectedIndex == 0 && cboTransformerName.SelectedIndex > 0)
            {
                dgvBillDayList.DataSource = customer.Where(u => u.BillDayGroupCode.Trim() ==cboGroupCode.Text.Trim() &&
                u.Meter.MeterBox.Pole.Transformer.TransformerName.Trim() == cboTransformerName.Text.Trim()).ToList();
            }
            else if(cboGroupCode.SelectedIndex > 0 && cboQuarterName.SelectedIndex > 0 && cboTransformerName.SelectedIndex > 0)
            {
                dgvBillDayList.DataSource = customer.Where(u => u.BillDayGroupCode.Trim() == cboGroupCode.Text.Trim() &&
                u.Meter.MeterBox.Pole.Transformer.TransformerName.Trim() == cboTransformerName.Text.Trim() &&
                u.Quarter.QuarterNameInEng.Trim() == cboQuarterName.Text.Trim()).ToList();
            }
            else if (cboGroupCode.SelectedIndex == 0 && cboQuarterName.SelectedIndex > 0 && cboTransformerName.SelectedIndex == 0)
            {
                dgvBillDayList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else if (cboGroupCode.SelectedIndex == 0 && cboQuarterName.SelectedIndex > 0 && cboTransformerName.SelectedIndex > 0)
            {
                dgvBillDayList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                u.Meter.MeterBox.Pole.Transformer.TransformerName.IndexOf(cboTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else if (cboGroupCode.SelectedIndex == 0 && cboQuarterName.SelectedIndex == 0 && cboTransformerName.SelectedIndex > 0)
            {
                dgvBillDayList.DataSource = customer.Where(u => u.Meter.MeterBox.Pole.Transformer.TransformerName.IndexOf(cboTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }

        }
        #endregion

        #region Cell Click
        private void dgvBillDayList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 8)
                {
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvBillDayList.Rows[e.RowIndex];
                        string customerID = Convert.ToString(row.Cells[0].Value); 
                        //BillDay billday = (BillDay)row.DataBoundItem;
                        dgvBillDayList.DataSource = "";
                        Customer customer = (from c in mbsEntities.Customers where c.CustomerID == customerID select c).FirstOrDefault();
                        customer.BillDayGroupCode = null;
                        mbsEntities.SaveChanges();
                        dgvBillDayList.DataSource = (from b in mbsEntities.Customers where b.Active == true && b.BillDayGroupCode != null orderby b.CustomerNameInEng descending select b).ToList();
                        MessageBox.Show(this, "successfully deleted!", "delete complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRefresh();
                    }
                }
            }
        }
        #endregion

        #region Key Press
        private void txtBillDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
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

        #region Button Event

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormRefresh();
            Clear();

        }

        private void btnAddNewBillDay_Click(object sender, EventArgs e)
        {
            frmBillDay billdayForm = new frmBillDay();
            billdayForm.UserID = UserID;
            billdayForm.isAddList = true;
            var result = billdayForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                FormRefresh();
            }
        }

        #endregion

        #region Combo Selected Index Change
        private void cboQuarterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTransformer();
        }
        #endregion
    }
}
