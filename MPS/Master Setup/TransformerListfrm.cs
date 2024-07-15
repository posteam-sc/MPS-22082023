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
    public partial class TransformerListfrm : Form
    {
        #region Variables        
        TransformerController transformerController = new TransformerController();
        string TransformerID;
        public string UserID { get; set; }

        #endregion

        public TransformerListfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void TransformerListfrm_Load(object sender, EventArgs e)
        {
            bindQuarter();
            FormRefresh();
            FormRefreshRemoveTransformer();
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
        #endregion

        #region Method 
        public void FormRefresh()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            dgvTransformerList.AutoGenerateColumns = false;
            dgvTransformerList.DataSource = (from tf in mbsEntities.Transformers where tf.Active == true orderby tf.TransformerName descending select tf).ToList();
        }

        public void FormRefreshRemoveTransformer()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            dgvRemoveTransformerList.AutoGenerateColumns = false;
            dgvRemoveTransformerList.DataSource = (from tf in mbsEntities.TransformerHistories where tf.Active == true orderby tf.OldTransformerName descending select tf).ToList();
        }

        public void loadData()
        {
            MBMSEntities mbsEntites = new MBMSEntities();
            var transformer = mbsEntites.Transformers.Where(t => t.Active == true).ToList();
            if (rdoTrasformerName.Checked == true)
            {
                if (!string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex == 0)
                    dgvTransformerList.DataSource = transformer.Where(t => t.TransformerName.IndexOf(txtTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                else if (!string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex > 0)
                    dgvTransformerList.DataSource = transformer.Where(t => t.TransformerName.IndexOf(txtTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1
                    && t.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                else if (string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex > 0)
                    dgvTransformerList.DataSource = transformer.Where(t => t.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex == 0)
                    dgvTransformerList.DataSource = transformer.Where(t => t.Model.IndexOf(txtTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
                else if (!string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex > 0)
                    dgvTransformerList.DataSource = transformer.Where(t => t.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1
                   && t.Model.IndexOf(txtTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
                else if (string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex > 0)
                    dgvTransformerList.DataSource = transformer.Where(t => t.Quarter.QuarterNameInEng.IndexOf(cboQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            }

        }

        public void RemoveLoadData()
        {
            MBMSEntities mbsEntites = new MBMSEntities();
            var transformerHistory = mbsEntites.TransformerHistories.Where(t => t.Active == true).ToList();
            if (rdoTrasformerName.Checked == true)
            {
                if (!string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex == 0)
                    dgvTransformerList.DataSource = transformerHistory.Where(t => t.TransformerName.IndexOf(txtTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                else if (!string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex > 0)
                    dgvTransformerList.DataSource = transformerHistory.Where(t => t.TransformerName.IndexOf(txtTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1
                    && t.QuarterID.IndexOf(cboQuarterName.SelectedValue.ToString(), StringComparison.OrdinalIgnoreCase) != -1).ToList();

                else if (string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex > 0)
                    dgvTransformerList.DataSource = transformerHistory.Where(t => t.QuarterID.IndexOf(cboQuarterName.SelectedValue.ToString(), StringComparison.OrdinalIgnoreCase) != -1).ToList();

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex == 0)
                    dgvTransformerList.DataSource = transformerHistory.Where(t => t.Model.IndexOf(txtTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
                else if (!string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex > 0)
                    dgvTransformerList.DataSource = transformerHistory.Where(t => t.QuarterID.IndexOf(cboQuarterName.SelectedValue.ToString(), StringComparison.OrdinalIgnoreCase) != -1
                   && t.Model.IndexOf(txtTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
                else if (string.IsNullOrWhiteSpace(txtTransformerName.Text) && cboQuarterName.SelectedIndex > 0)
                    dgvTransformerList.DataSource = transformerHistory.Where(t => t.QuarterID.IndexOf(cboQuarterName.SelectedValue.ToString(), StringComparison.OrdinalIgnoreCase) != -1).ToList();

            }

        }
        #endregion

        #region Button Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tabPage1.Text == "Active Trasnformer")
            {
                loadData();
            }
            else
            {
                RemoveLoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            txtTransformerName.Clear();
            cboQuarterName.SelectedIndex = 0;
            FormRefresh();
            FormRefreshRemoveTransformer();
        }

        private void btnAddNewTrans_Click(object sender, EventArgs e)
        {
            Transformerfrm transForm = new Transformerfrm();
            transForm.UserID = UserID;
            transForm.isAddList = true;
            var result = transForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                FormRefresh();
            }

        }
        #endregion

        #region Data Bind By DataGrid
        private void dgvTransformerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransformerList.Rows)
            {
                Transformer transformer = (Transformer)row.DataBoundItem;
                row.Cells[0].Value = transformer.TransformerID;
                row.Cells[1].Value = transformer.TransformerName;
                row.Cells[2].Value = transformer.Model;
                row.Cells[3].Value = transformer.Maker;
                row.Cells[4].Value = transformer.CountryOfOrgin;
                if (transformer.Status == true)
                    row.Cells[5].Value = "Enable";
                else
                    row.Cells[5].Value = "Disable";

                row.Cells[6].Value = transformer.Quarter.QuarterNameInEng;
                row.Cells[7].Value = transformer.Standard;
            }
        }

        private void dgvRemoveTransformerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRemoveTransformerList.Rows)
            {
                TransformerHistory transformerhistory = (TransformerHistory)row.DataBoundItem;
                row.Cells[0].Value = transformerhistory.TransformerID;
                row.Cells[1].Value = transformerhistory.OldTransformerName;
                row.Cells[2].Value = transformerhistory.TransformerName;
                row.Cells[3].Value = transformerhistory.Model;
                row.Cells[4].Value = transformerhistory.Maker;
                row.Cells[5].Value = transformerhistory.CountryOfOrgin;
                row.Cells[6].Value = transformerhistory.Status;
                row.Cells[7].Value = transformerhistory.Standard;
            }
        }
        #endregion

        #region Data Grid Cell Click
        private void dgvTransformerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 10)
                {
                    //DeleteForTransformer
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        MBMSEntities mbsEntities = new MBMSEntities();
                        DataGridViewRow row = dgvTransformerList.Rows[e.RowIndex];
                        Transformer transObi = (Transformer)row.DataBoundItem;
                        transObi = (from t in mbsEntities.Transformers where t.TransformerID == transObi.TransformerID select t).FirstOrDefault();
                        var poleCount = (from t in transObi.Poles where t.Active == true select t).Count();
                        var ledgerCount = (from l in transObi.Ledgers where l.Active == true select l).Count();
                        if (poleCount > 0)
                        {
                            MessageBox.Show("This Transformer cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (ledgerCount > 0)
                        {
                            MessageBox.Show("This Transformer cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        TransformerID = Convert.ToString(row.Cells[0].Value);

                        dgvTransformerList.DataSource = "";
                        Transformer transformer = (from tf in mbsEntities.Transformers where tf.TransformerID == TransformerID select tf).FirstOrDefault();
                        transformer.Active = false;
                        transformer.DeletedUserID = UserID;
                        transformer.DeletedDate = DateTime.Now;
                        transformerController.DeleteTransformer(transformer);
                        dgvTransformerList.DataSource = (from tf in mbsEntities.Transformers where tf.Active == true orderby tf.TransformerName descending select tf).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRefresh();
                    }
                }
                else if (e.ColumnIndex == 9)
                {
                    TransformerDetailfrm transformerDetailForm = new TransformerDetailfrm();
                    transformerDetailForm.transformerID = Convert.ToString(dgvTransformerList.Rows[e.RowIndex].Cells[0].Value);
                    transformerDetailForm.ShowDialog();
                }
                else if (e.ColumnIndex == 8)
                {
                    //EditTransformer
                    Transformerfrm transForm = new Transformerfrm();
                    transForm.isEdit = true;
                    transForm.Text = "Edit Transformer";
                    transForm.TransformerID = Convert.ToString(dgvTransformerList.Rows[e.RowIndex].Cells[0].Value);
                    transForm.UserID = UserID;
                    transForm.isAddList = true;
                    var resullt=  transForm.ShowDialog();
                    if (resullt == DialogResult.OK)
                    {
                        FormRefresh();
                    }
                }
            }
        }

        private void dgvRemoveTransformerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 9)
                {
                    //DeleteForTransformer
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        MBMSEntities mbsEntities = new MBMSEntities();
                        DataGridViewRow row = dgvRemoveTransformerList.Rows[e.RowIndex];
                        TransformerID = Convert.ToString(row.Cells[0].Value);
                        dgvRemoveTransformerList.DataSource = "";
                        TransformerHistory removeTransformer = (from tf in mbsEntities.TransformerHistories where tf.TransformerID == TransformerID select tf).FirstOrDefault();
                        removeTransformer.Active = false;
                        removeTransformer.DeletedUserID = UserID;
                        removeTransformer.DeletedDate = DateTime.Now;
                        mbsEntities.SaveChanges();
                        dgvRemoveTransformerList.DataSource = (from tf in mbsEntities.TransformerHistories where tf.Active == true orderby tf.TransformerName descending select tf).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRefresh();
                    }
                }
            }
        }
        #endregion

        #region Key Down
        private void txtTransformerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void txtTransformerModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void cboQuarterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }
        #endregion

        #region Check Changed
        private void rdoTrasformerName_CheckedChanged(object sender, EventArgs e)
        {
            lblTransformer.Text = "Transformer Code:";
        }

        private void rdoTransformerModel_CheckedChanged(object sender, EventArgs e)
        {
            lblTransformer.Text = "Transformer Model";
        }
        #endregion
    }
}
