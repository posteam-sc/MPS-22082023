using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
using MPS.Master_Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS
{
    public partial class frmBillDay : Form
    {
        #region Variable
        public string billDayID { get; set; }
        public string UserID { get; set; }
        public bool isAddList { get; set; }

        private ToolTip tooltip = new ToolTip();
        //public List<BillDayDetail> billDayDetail { get; set; }
        BillDayController billDayController = new BillDayController();
        public Boolean isEdit { get; set; }
        CheckBox headerCheckBox = new CheckBox();
        #endregion

        public frmBillDay()
        {
            InitializeComponent();
        }

        private void frmBillDay_Load(object sender, EventArgs e)
        {
            dgvCustomerList.AutoGenerateColumns = false;

            BindQuarter();
            BindTransformer();
            InitialState();

            SetCheckbox();
            headerCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            //SetCheckBoxGirdHeader();
        }

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
        #endregion

        #region Validation
        private bool CheckValidation()
        {
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";
            if (string.IsNullOrWhiteSpace(txtGroupCode.Text.Trim()))
            {
                tooltip.SetToolTip(txtGroupCode, "Require");
                tooltip.Show("Please fill up Group Code No!", txtGroupCode);
                txtGroupCode.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDueDate.Text.Trim()))
            {
                tooltip.SetToolTip(txtDueDate, "Require");
                tooltip.Show("Please fill up Due Date!", txtDueDate);
                txtDueDate.Focus();
                return false;
            }

            else if (dgvCustomerList.Rows.Count == 0)
            {
                MessageBox.Show("Search Customer or Check Customer for Bill Day", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
           

            return true;
        }

        #endregion

        #region Method
        private void Save()

        {
            try
            {

                MBMSEntities mbsEntities = new MBMSEntities();
                BillDay billday = new BillDay();
                var groupCode = mbsEntities.BillDays.Where(b => b.BillDayGroupCode.Trim() == txtGroupCode.Text).FirstOrDefault();
                //string gc = groupCode.BillDayGroupCode.Trim();
                if (groupCode != null)
                {
                    billday.BillDayGroupCode = txtGroupCode.Text;
                    billday.DueDate = Convert.ToInt32(txtDueDate.Text);
                    billday.UpdatedUserID = UserID;
                    billday.UpdatedDate = DateTime.Now;
                    billday.Active = true;
                    foreach (DataGridViewRow row in dgvCustomerList.Rows) 
                    {
                        if ((Convert.ToBoolean(row.Cells[0].Value) == true))
                        {
                            string customerID = Convert.ToString(row.Cells[1].Value);
                            Customer customer = new Customer();
                            customer = mbsEntities.Customers.Where(x => x.CustomerID == customerID).FirstOrDefault();
                            customer.BillDayGroupCode = txtGroupCode.Text;
                        }
                    }
                    MessageBox.Show("Save Sucess", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mbsEntities.SaveChanges();
                    InitialState();
                }
                else
                {
                    billday.BillDayGroupCode = txtGroupCode.Text;
                    billday.DueDate = Convert.ToInt32(txtDueDate.Text);
                    billday.CreatedUserID = UserID;
                    billday.CreatedDate = DateTime.Now;
                    billday.Active = true;
                    billDayController.Save(billday);
                    //Set the CheckBox selection.
                    foreach (DataGridViewRow row in dgvCustomerList.Rows)
                    {
                        if ((Convert.ToBoolean(row.Cells[0].Value) == true))
                        {
                            string customerID = Convert.ToString(row.Cells[1].Value);
                            Customer customer = new Customer();
                            customer = mbsEntities.Customers.Where(x => x.CustomerID == customerID).FirstOrDefault();
                            customer.BillDayGroupCode = txtGroupCode.Text;
                        }
                    }
                    MessageBox.Show("Save Sucess", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mbsEntities.SaveChanges();
                    InitialState();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void InitialState()
        {
            cboQuarterName.SelectedIndex = 0;
            txtGroupCode.Clear();
            txtDueDate.Clear();
            cboTransformerName.SelectedIndex = 0;
            dgvCustomerList.DataSource = null;
            txtGroupCode.Focus();
            isEdit = false;
        }

        private void Updates()
        {
            //MBMSEntities mbsEntities = new MBMSEntities();
            //BillDay billday = new BillDay();
            //billday.BillDayGroupCode = txtGroupCode.Text;
            //billday.BillDayID = Guid.NewGuid().ToString();
            //billday.ExpireDate = dtexpireDate.Value;
            //billday.UpdatedUserID = UserID;
            //billday.UpdatedDate = DateTime.Now;
            //billday.Active = true;
            //billDayController.Update(billday);
            //foreach (DataGridViewRow row in dgvBillDayList.Rows)
            //{
            //    BillDayDetail billDayDetail = new BillDayDetail();
            //    billDayDetail.BillDayDetailID = Guid.NewGuid().ToString();
            //    billDayDetail.QuarterID = row.Cells[1].Value.ToString();
            //    billDayDetail.BillDayID = billday.BillDayID;
            //    billDayDetail.CreatedUserID = UserID;
            //    billDayDetail.CreatedDate = DateTime.Now;
            //    billDayDetail.Active = true;
            //    mbsEntities.BillDayDetails.Add(billDayDetail);
            //}
            //mbsEntities.SaveChanges();
            //Clear();
        }

        private void BindData()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            var groupCode = mbsEntities.BillDays.Where(b => b.BillDayGroupCode.Trim() == txtGroupCode.Text).FirstOrDefault();
            if (groupCode != null)
            {
                txtDueDate.Text = groupCode.DueDate.ToString().Trim();
                txtGroupCode.Text = groupCode.BillDayGroupCode.ToString().Trim();
            }
        }

        private void Search()
        {
            MBMSEntities mbsEntites = new MBMSEntities();
            var customer = mbsEntites.Customers.Where(c => c.Active == true && c.BillDayGroupCode == null).ToList();
            if (cboQuarterName.SelectedIndex > 0 && cboTransformerName.SelectedIndex == 0)
            {
                dgvCustomerList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else if (cboQuarterName.SelectedIndex > 0 && cboTransformerName.SelectedIndex > 0)
            {
                dgvCustomerList.DataSource = customer.Where(u => u.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                u.Transformer.TransformerName.IndexOf(cboTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else if (cboQuarterName.SelectedIndex == 0 && cboTransformerName.SelectedIndex > 0)
            {
                dgvCustomerList.DataSource = customer.Where(u => u.Transformer.TransformerName.IndexOf(cboTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                dgvCustomerList.DataSource = customer;
            }
        }

        #endregion

        #region Button Click 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                Save();

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();
        }

        #endregion

        #region Mouse Move
        private void frmBillDay_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtGroupCode);
            tooltip.Hide(txtDueDate);
            tooltip.Hide(cboQuarterName);
        }

        #endregion


        #region DataBind for Grid View 
        private void dgvCustomerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCustomerList.Rows)
            {
                Customer customer = (Customer)row.DataBoundItem;
                row.Cells[1].Value = customer.CustomerID;
                row.Cells[2].Value = customer.CustomerCode;
                row.Cells[3].Value = customer.CustomerNameInEng;
                row.Cells[4].Value = customer.CustomerAddressInEng;
                row.Cells[5].Value = customer.PhoneNo;
                row.Cells[6].Value = customer.Meter.MeterNo;
                row.Cells[7].Value = customer.BillCode7Layer.BillCode7LayerNo;

            }
        }
        #endregion

        #region Cell Click
        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Reference the GridView Row.
                DataGridViewRow row = dgvCustomerList.Rows[e.RowIndex];

                //Set the CheckBox selection.
                row.Cells["checkgrid"].Value = !Convert.ToBoolean(row.Cells["checkgrid"].EditedFormattedValue);
            }
        }
        #endregion

        #region Key Press
        private void txtDueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        #endregion

        #region Preview Key Down
        private void txtGroupCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                BindData();
        }

        #endregion

        #region Combo Selected Index Change
        private void cboQuarterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTransformer();
        }
        #endregion

        #region Leave Event
        private void txtGroupCode_Leave(object sender, EventArgs e)
        {
            BindData();
        }
        #endregion

        #region GridView Header Checkbox

        private void SetCheckbox()
        {
            Point headerCellLocation = this.dgvCustomerList.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheckBox.Location = new Point(headerCellLocation.X + 18, headerCellLocation.Y + 13);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            dgvCustomerList.Controls.Add(headerCheckBox);
        }

        private void HeaderCheckBoxChecked(CheckBox hCheckbox)
        {
            foreach (DataGridViewRow row in dgvCustomerList.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells["checkgrid"]).Value = hCheckbox.Checked;
            }
            dgvCustomerList.RefreshEdit();
           
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxChecked((CheckBox)sender);
        }
        #endregion

        private void frmBillDay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGroupCode.Text))
            {
                if (isEdit == true)
                {
                    DialogResult result = MessageBox.Show("Need to Update Record", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        var billDayList = new frmBillDayList();
                        billDayList.UserID = UserID;
                        billDayList.FormRefresh();
                    }
                }

            }
        }
    }
}
