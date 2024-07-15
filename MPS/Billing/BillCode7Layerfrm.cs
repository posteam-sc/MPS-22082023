using MBMS.DAL;
using MPS.BusinessLogic.BillingController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Billing
{
    public partial class BillCode7Layerfrm : Form
    {

        #region Variables
        public string billCode7LayerID { get; set; }
        public string UserID { get; set; }
        private ToolTip tooltip = new ToolTip();
        BillCode7Layer billCode7Layer = new BillCode7Layer();
        public Boolean isAddList { get; set; }
        public List<BillCode7LayerDetail> billCode7LayerDetailList { get; set; }
        BillCode7LayerController billCode7LayerController = new BillCode7LayerController();
        public Boolean isEdit { get; set; }
        #endregion

        public BillCode7Layerfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void BillCode7Layerfrm_Load(object sender, EventArgs e)
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            gv7layer.AutoGenerateColumns = false;
            cboBillCodeType.Items.Add("Flat Type");
            cboBillCodeType.Items.Add("Block Type");
            cboBillCodeType.SelectedIndex = 0;
            if (isEdit)
            {
                BillCode7Layer billCode7Layer = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerID == billCode7LayerID select b).FirstOrDefault();
                txtBillCodeNo.Text = Convert.ToString(billCode7Layer.BillCode7LayerNo);
                cboBillCodeType.Text = billCode7Layer.BillCodeLayerType;
                btnSave.Text = "Update";
                //btnAdd.Text = "Update";
                //adding data to the list            
                foreach (var item in billCode7LayerDetailList)
                {
                    string[] row = new string[] { item.LowerLimit.ToString(), item.UpperLimit.ToString(), item.RateUnit.ToString(), item.AmountPerUnit.ToString() };
                    gv7layer.Rows.Add(row);
                }
            }
        }
        #endregion

        #region Method
        public bool checkValidation()
        {
            Boolean hasError = true;
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";
            //Validation
            if (string.IsNullOrWhiteSpace(txtBillCodeNo.Text))
            {
                tooltip.SetToolTip(txtBillCodeNo, "Require");
                tooltip.Show("Please fill up Bill Code No in numeric value(s)!", txtBillCodeNo);
                txtBillCodeNo.Focus();
                hasError = false;
            }
            if (!string.IsNullOrWhiteSpace(txtLowerLimit.Text) || !string.IsNullOrWhiteSpace(txtUpperLimit.Text) || !string.IsNullOrEmpty(txtRateUnit.Text) || !string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("can't save. plz add the layers data to the table list", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hasError = false;
            }
            return hasError;
        }

        private void UpdateBillCodeLayer()
        {
            try
            {
                MBMSEntities mbsEntities = new MBMSEntities();

                int editBillCodeNoCount = 0;
                long editbillCodeNo = Convert.ToInt64(txtBillCodeNo.Text);
                BillCode7Layer updateBillCode7Layer = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerID == billCode7LayerID select b).FirstOrDefault();
                if (txtBillCodeNo.Text != Convert.ToString(updateBillCode7Layer.BillCode7LayerNo))
                {
                    editBillCodeNoCount = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerNo == editbillCodeNo && b.Active == true select b).ToList().Count;
                }

                if (editBillCodeNoCount > 0)
                {
                    tooltip.SetToolTip(txtBillCodeNo, "Error");
                    tooltip.Show("Bill Code No is already exist!", txtBillCodeNo);
                    return;
                }

                updateBillCode7Layer.BillCode7LayerNo = Convert.ToInt64(txtBillCodeNo.Text);
                updateBillCode7Layer.BillCodeLayerType = cboBillCodeType.Text;
                updateBillCode7Layer.UpdatedUserID = UserID;
                updateBillCode7Layer.UpdatedDate = DateTime.Now;
                billCode7LayerController.UpdateBillCode7Layer(updateBillCode7Layer);
                mbsEntities.BillCode7LayerDetail_DeleteByBillCode7LayerID(billCode7LayerID);
                foreach (DataGridViewRow row in gv7layer.Rows)
                {
                    BillCode7LayerDetail billCode7LayerDetail = new BillCode7LayerDetail();
                    billCode7LayerDetail.BillCode7LayerDetailID = Guid.NewGuid().ToString();
                    billCode7LayerDetail.BillCode7LayerID = billCode7LayerID;
                    billCode7LayerDetail.LowerLimit = Convert.ToDecimal(row.Cells[0].Value);
                    billCode7LayerDetail.UpperLimit = Convert.ToDecimal(row.Cells[1].Value);
                    billCode7LayerDetail.RateUnit = Convert.ToDecimal(row.Cells[2].Value);
                    billCode7LayerDetail.AmountPerUnit = Convert.ToDecimal(row.Cells[3].Value);
                    billCode7LayerDetail.Active = true;
                    billCode7LayerDetail.CreatedDate = DateTime.Now;
                    billCode7LayerDetail.CreatedUserID = UserID;
                    mbsEntities.BillCode7LayerDetail.Add(billCode7LayerDetail);
                }
                mbsEntities.SaveChanges();
                MessageBox.Show("Successfully Updated Bill Code Layer!", "Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
                InitialState();
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void Save()
        {
            try
            {
                MBMSEntities mbsEntities = new MBMSEntities();

                if (gv7layer.Rows.Count == 0)
                {
                    MessageBox.Show("please define  layers information firstly!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int billCodeNoCount = 0;
                long billCodeNo = Convert.ToInt64(txtBillCodeNo.Text);
                billCodeNoCount = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerNo == billCodeNo && b.Active == true select b).ToList().Count;
                if (billCodeNoCount > 0)
                {
                    tooltip.SetToolTip(txtBillCodeNo, "Error");
                    tooltip.Show("Bill Code No is already exist!", txtBillCodeNo);
                    MessageBox.Show("Bill Code No is already exist!", "Error");
                    return;
                }
                billCode7Layer.BillCode7LayerID = Guid.NewGuid().ToString();
                billCode7Layer.BillCode7LayerNo = Convert.ToInt64(txtBillCodeNo.Text);
                billCode7Layer.BillCodeLayerType = cboBillCodeType.Text;
                billCode7Layer.Active = true;
                billCode7Layer.CreatedUserID = UserID;
                billCode7Layer.CreatedDate = DateTime.Now;
                billCode7LayerController.Save(billCode7Layer);
                foreach (DataGridViewRow row in gv7layer.Rows)
                {
                    BillCode7LayerDetail billCode7LayerDetail = new BillCode7LayerDetail();
                    billCode7LayerDetail.BillCode7LayerDetailID = Guid.NewGuid().ToString();
                    billCode7LayerDetail.BillCode7LayerID = billCode7Layer.BillCode7LayerID;
                    billCode7LayerDetail.LowerLimit = Convert.ToDecimal(row.Cells[0].Value);
                    billCode7LayerDetail.UpperLimit = Convert.ToDecimal(row.Cells[1].Value);
                    billCode7LayerDetail.RateUnit = Convert.ToDecimal(row.Cells[2].Value);
                    billCode7LayerDetail.AmountPerUnit = Convert.ToDecimal(row.Cells[3].Value);
                    billCode7LayerDetail.Active = true;
                    billCode7LayerDetail.CreatedDate = DateTime.Now;
                    billCode7LayerDetail.CreatedUserID = UserID;
                    mbsEntities.BillCode7LayerDetail.Add(billCode7LayerDetail);
                }
                mbsEntities.SaveChanges();
                MessageBox.Show("Successfully registered Bill Code Layer!", "Save Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                InitialState();
                if (isAddList)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                //BillCode7LayerList billcode7LayerListForm = new BillCode7LayerList();
                //billcode7LayerListForm.UserID = this.UserID;
                //billcode7LayerListForm.Show();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InitialState()
        {
            if (!CheckingRoleManagementFeature("BillCodeLayerAdd"))
            {
                btnAdd.Enabled = false;
                btnSave.Enabled = false;
            }
            txtAmount.Text = string.Empty;
            txtBillCodeNo.Text = string.Empty;
            txtLowerLimit.Text = string.Empty;
            txtUpperLimit.Text = string.Empty;
            cboBillCodeType.SelectedIndex = 0;
            gv7layer.DataSource=null;
            gv7layer.Rows.Clear();
            isEdit = false;
            txtBillCodeNo.Focus();
        }

        private bool checkBillCode7LayerDetailRecord()
        {
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";
            if (txtBillCodeNo.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtBillCodeNo, "Error");
                tooltip.Show("Please fill up Bill Code No !", txtBillCodeNo);
                return false;
            }
            else if (txtLowerLimit.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtLowerLimit, "Error");
                tooltip.Show("Please fill up Lower Limit !", txtLowerLimit);
                return false;
            }
            else if (txtUpperLimit.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtUpperLimit, "Error");
                tooltip.Show("Please fill up Upper Limit !", txtUpperLimit);
                return false;
            }
            else if (Convert.ToDecimal(txtLowerLimit.Text) > Convert.ToDecimal(txtUpperLimit.Text))
            {
                tooltip.SetToolTip(txtRateUnit, "Error");
                tooltip.Show("Lower limit should not greater than upper limit !", txtRateUnit);
                return false;
            }

            else if (txtRateUnit.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtRateUnit, "Error");
                tooltip.Show("Please define Rate Unit by filling up lower limit and upper limit !", txtRateUnit);
                return false;
            }
            else if (txtAmount.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtAmount, "Error");
                tooltip.Show("Please fill up Amount Per Unit!", txtAmount);
                return false;
            }
            foreach (DataGridViewRow row in gv7layer.Rows)
            {
                decimal lowerlimit = Convert.ToDecimal(row.Cells[0].Value);
                decimal upperlimit = Convert.ToDecimal(row.Cells[1].Value);
                if (Convert.ToDecimal(txtLowerLimit.Text) == lowerlimit || Convert.ToDecimal(txtUpperLimit.Text) == upperlimit)
                {
                    MessageBox.Show("Lower  or  Upper Limit are already defined", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (Convert.ToDecimal(txtLowerLimit.Text) <= upperlimit && Convert.ToDecimal(txtLowerLimit.Text) >= lowerlimit)
                {
                    MessageBox.Show("Lower Limit data are already defined.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (Convert.ToDecimal(txtLowerLimit.Text) >= upperlimit && Convert.ToDecimal(txtLowerLimit.Text) <= upperlimit)
                {
                    MessageBox.Show("Lower Limit data are already defined.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (Convert.ToDecimal(txtUpperLimit.Text) >= upperlimit && Convert.ToDecimal(txtUpperLimit.Text) <= upperlimit)
                {
                    MessageBox.Show("Upper Limit data are already defined.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValidation())
            {
                if (isEdit)
                {
                    UpdateBillCodeLayer();
                }
                else
                {
                    Save();

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] row = new string[] { txtLowerLimit.Text, txtUpperLimit.Text, txtRateUnit.Text, txtAmount.Text };
            if (checkBillCode7LayerDetailRecord())
            {
                gv7layer.Rows.Add(row);
                txtAmount.Text = txtLowerLimit.Text = txtUpperLimit.Text = txtRateUnit.Text = string.Empty;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtAmount.Text = txtBillCodeNo.Text = txtLowerLimit.Text = txtUpperLimit.Text = txtRateUnit.Text = string.Empty;
            cboBillCodeType.SelectedIndex = 0;
        }
        #endregion

        #region Key Press
        private void txtBillCodeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }

        }

        private void txtLowerLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtUpperLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        #endregion

        #region Data Grid Cell Click
        private void gv7layer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Delete function
                if (e.ColumnIndex == 5)
                {
                    DataGridViewRow row = gv7layer.Rows[e.RowIndex];
                    DialogResult comfirmYes = MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == comfirmYes)
                    {
                        gv7layer.Rows.RemoveAt(row.Index);
                    }
                }//end of delete function
            }
            //Edit function
            if (e.ColumnIndex == 4)
            {
                DataGridViewRow row = gv7layer.Rows[e.RowIndex];
                DialogResult comfirmYes = MessageBox.Show("Are you sure to edit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == comfirmYes)
                {
                    gv7layer.Rows.RemoveAt(row.Index);
                    txtLowerLimit.Text = Convert.ToString(row.Cells[0].Value);
                    txtUpperLimit.Text = Convert.ToString(row.Cells[1].Value);
                    txtRateUnit.Text = Convert.ToString(row.Cells[2].Value);
                    txtAmount.Text = Convert.ToString(row.Cells[3].Value);
                    btnAdd.Text = "Update";
                }
            }//end of Edit function
        }//end of cell click    

        #endregion

        #region Key Down
        private void txtUpperLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDecimal(txtLowerLimit.Text) > Convert.ToDecimal(txtUpperLimit.Text))
                {
                    MessageBox.Show("Lower Limit is greater than upper limit.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else txtRateUnit.Text = Convert.ToString(Convert.ToDecimal(txtUpperLimit.Text) - (Convert.ToDecimal(txtLowerLimit.Text) - 1));
            }
        }
        #endregion

        #region Mouse Move
        private void BillCode7Layerfrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtBillCodeNo);
            tooltip.Hide(cboBillCodeType);
            tooltip.Hide(txtLowerLimit);
            tooltip.Hide(txtUpperLimit);
            tooltip.Hide(txtRateUnit);
        }
        #endregion

        #region TAb Index Change
        private void txtUpperLimit_TabIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtLowerLimit.Text) > Convert.ToDecimal(txtUpperLimit.Text))
            {
                MessageBox.Show("Lower Limit is greater than upper limit.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else txtRateUnit.Text = Convert.ToString(Convert.ToDecimal(txtUpperLimit.Text) - (Convert.ToDecimal(txtLowerLimit.Text) - 1));
        }
        #endregion

        private void BillCode7Layerfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBillCodeNo.Text))
            {
                DialogResult result = MessageBox.Show("Need to Update Record", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    e.Cancel = true;
                }
                else
                {
                    var billCodeListForm = new BillCode7LayerList();
                    billCodeListForm.UserID = UserID;
                    billCodeListForm.FormRefresh();
                }
            }

        }
    }
}
