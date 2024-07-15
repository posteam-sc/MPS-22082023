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
    public partial class BillCode7LayerList : Form
    {
        #region Variables
        BillCode7LayerController billCode7LayerController = new BillCode7LayerController();
        private List<BillCode7Layer> billCode7LayerList = new List<BillCode7Layer>();
        string billCode7LayerID;
        public string UserID { get; set; }
        #endregion
        public BillCode7LayerList()
        {
            InitializeComponent();
        }

        #region Data Bind by Data Grid
        private void dgvBillCode7LayerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            MBMSEntities mbsEntities = new MBMSEntities();

            foreach (DataGridViewRow row in dgvBillCode7LayerList.Rows)
            {
                BillCode7Layer billCode7Layer = (BillCode7Layer)row.DataBoundItem;
                row.Cells[0].Value = billCode7Layer.BillCode7LayerID;
                row.Cells[1].Value = billCode7Layer.BillCode7LayerNo;
                row.Cells[2].Value = billCode7Layer.BillCodeLayerType;
                row.Cells[3].Value = billCode7Layer.CreatedDate;
                row.Cells[4].Value = mbsEntities.Users.Where(x => x.UserID == billCode7Layer.CreatedUserID).SingleOrDefault().UserName;
                //row.Cells[5].Value = billCode7Layer.AmountPerUnit;
            }
        }
        #endregion

        #region Method
        public void FormRefresh()
        {
            MBMSEntities mbsEntities = new MBMSEntities();

            dgvBillCode7LayerList.AutoGenerateColumns = false;
            dgvBillCode7LayerList.DataSource = (from b in mbsEntities.BillCode7Layer where b.Active == true orderby b.BillCode7LayerNo descending select b).ToList();
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

        #region Form Load
        private void BillCode7LayerList_Load(object sender, EventArgs e)
        {
            FormRefresh();
        }
        #endregion

        #region Cell Click
        private void dgvBillCode7LayerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    //DeleteForBillCode7Layer
                    if (!CheckingRoleManagementFeature("BillCodeLayerEditOrDelete"))
                    {
                        MessageBox.Show("Access Deined for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        MBMSEntities mbsEntities = new MBMSEntities();

                        DataGridViewRow row = dgvBillCode7LayerList.Rows[e.RowIndex];
                        billCode7LayerID = Convert.ToString(row.Cells[0].Value);
                        BillCode7Layer billCodeObj = (BillCode7Layer)row.DataBoundItem;
                        billCodeObj = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerID == billCodeObj.BillCode7LayerID select b).FirstOrDefault();
                        var customerCount = (from c in billCodeObj.Customers where c.Active == true select c).Count();
                        if (customerCount > 0)
                        {
                            MessageBox.Show("This Bill Code is used in Customer !", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        dgvBillCode7LayerList.DataSource = "";
                        BillCode7Layer billCode7Layer = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerID == billCode7LayerID select b).FirstOrDefault();
                        billCode7Layer.Active = false;
                        billCode7Layer.DeletedUserID = UserID;
                        billCode7Layer.DeletedDate = DateTime.Now;
                        billCode7LayerController.DeleteBillCode7Layer(billCode7Layer);
                        dgvBillCode7LayerList.DataSource = (from b in mbsEntities.BillCode7Layer where b.Active == true orderby b.BillCode7LayerNo descending select b).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRefresh();
                    }

                }
                else if (e.ColumnIndex == 5)
                {
                    MBMSEntities mbsEntities = new MBMSEntities();

                    //EditBillCode7Layer
                    if (!CheckingRoleManagementFeature("BillCodeLayerEditOrDelete"))
                    {
                        MessageBox.Show("Access Deined for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string _billCode7LayerID;
                    BillCode7Layerfrm billcode7LayerForm = new BillCode7Layerfrm();
                    billcode7LayerForm.isEdit = true;
                    billcode7LayerForm.Text = "Edit BillCode";
                    _billCode7LayerID = Convert.ToString(dgvBillCode7LayerList.Rows[e.RowIndex].Cells[0].Value);
                    billcode7LayerForm.billCode7LayerID = _billCode7LayerID;
                    billcode7LayerForm.billCode7LayerDetailList = mbsEntities.BillCode7LayerDetail.Where(x => x.BillCode7LayerID == _billCode7LayerID && x.BillCode7Layer.Active == true && x.Active == true).OrderBy(y => y.LowerLimit).ToList();
                    billcode7LayerForm.UserID = UserID;
                    billcode7LayerForm.ShowDialog();


                }
            }
        }
        #endregion

        #region Button Click
        private void btnAddNewBillCode_Click(object sender, EventArgs e)
        {
            if (!CheckingRoleManagementFeature("BillCodeLayerAdd"))
            {
                MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BillCode7Layerfrm billcode7LayerForm = new BillCode7Layerfrm();
            billcode7LayerForm.UserID = UserID;
            billcode7LayerForm.isAddList = true;
            var result = billcode7LayerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                FormRefresh();
            }

        }
        #endregion

    }
}
