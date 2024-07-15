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

namespace MPS
{
    public partial class MeterTypefrm : Form
    {
        #region Variable
        private ToolTip tooltip = new ToolTip();
        public String UserID { get; set; }
        string meterTypeID;
        public Boolean isEdit { get; set; }
        MeterTypeController meterTypeController = new MeterTypeController();
        #endregion

        public MeterTypefrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void MeterTypefrm_Load(object sender, EventArgs e)
        {
            InitialState();
            FormRefresh();
        }
        #endregion

        #region Method
        private  void InitialState()
        {
            txtMeterTypeCode.Text = string.Empty;
            txtMeterTypeDes.Text = string.Empty;
            btnSave.Text = "Save";
            isEdit = false;
            txtMeterTypeCode.Focus();
        }

        private void FormRefresh()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();

            dgvMeterTypeList.AutoGenerateColumns = false;
            dgvMeterTypeList.DataSource = (from mt in mbmsEntities.MeterTypes where mt.Active == true orderby mt.MeterTypeCode descending select mt).ToList();
        }

        private bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";

            if (string.IsNullOrWhiteSpace(txtMeterTypeCode.Text))
            {
                tooltip.SetToolTip(txtMeterTypeCode, "Require");
                tooltip.Show("Please fill up Meter Type Code!", txtMeterTypeCode);
                txtMeterTypeCode.Focus();
                hasError = false;
            }
            else if(string.IsNullOrWhiteSpace(txtMeterTypeDes.Text))
            {
                tooltip.SetToolTip(txtMeterTypeDes, "Require");
                tooltip.Show("Please fill up Meter Type Description!", txtMeterTypeDes);
                txtMeterTypeDes.Focus();
                hasError = false;
            }
            return hasError;
        }

        private void UpdateMeterType()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();

                int editMeterTypeCode = 0;
                MeterType updateMeterType = (from mt in mbmsEntities.MeterTypes where mt.MeterTypeID == meterTypeID select mt).FirstOrDefault();
                if (txtMeterTypeCode.Text != updateMeterType.MeterTypeCode)
                {
                    editMeterTypeCode = (from mt in mbmsEntities.MeterTypes where mt.MeterTypeCode == txtMeterTypeCode.Text select mt).ToList().Count;
                }
                if (editMeterTypeCode > 0)
                {
                    tooltip.SetToolTip(txtMeterTypeCode, "Error");
                    tooltip.Show("Meter Type Code is already exist!", txtMeterTypeCode);
                    return;
                }
                updateMeterType.MeterTypeCode = txtMeterTypeCode.Text;
                updateMeterType.MeterTypeDescription = txtMeterTypeDes.Text;
                updateMeterType.UpdatedUserID = UserID;
                updateMeterType.UpdatedDate = DateTime.Now;
                meterTypeController.UpdateMeterType(updateMeterType);
                MessageBox.Show("Successfully updated Meter Type!", "Update");
                isEdit = false;
                btnSave.Text = "Save";
                InitialState();
                FormRefresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Save()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();

                MeterType meterType = new MeterType();
                int meterTypeCount = 0;
                meterTypeCount = (from m in mbmsEntities.MeterTypes where m.MeterTypeCode == txtMeterTypeCode.Text && m.Active == true select m).ToList().Count;

                if (meterTypeCount > 0)
                {
                    tooltip.SetToolTip(txtMeterTypeCode, "Error");
                    tooltip.Show("MeterType Code is already exist!", txtMeterTypeCode);
                    return;
                }
                meterType.MeterTypeID = Guid.NewGuid().ToString();
                meterType.MeterTypeCode = txtMeterTypeCode.Text;
                meterType.MeterTypeDescription = txtMeterTypeDes.Text;
                meterType.Active = true;
                meterType.CreatedUserID = UserID;
                meterType.CreatedDate = DateTime.Now;
                meterTypeController.Save(meterType);
                MessageBox.Show("Successfully registered Meter Type! Please check it in 'Meter Type List'.", "Save Success");
                InitialState();
                FormRefresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                    UpdateMeterType();
                }
                else
                {
                    Save();
                }
            }
        }

        private void dgvMeterTypeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();

                    //DeleteForMeterType
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvMeterTypeList.Rows[e.RowIndex];
                        meterTypeID = Convert.ToString(row.Cells[0].Value);
                        MeterType meterTypeObj = (MeterType)row.DataBoundItem;
                        meterTypeObj = (from mt in mbmsEntities.MeterTypes where mt.MeterTypeID == meterTypeObj.MeterTypeID select mt).FirstOrDefault();
                        var meterCount = (from m in meterTypeObj.Meters where m.Active == true select m).Count();
                        if (meterCount > 0)
                        {
                            MessageBox.Show("This Meter Type cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvMeterTypeList.DataSource = "";
                        MeterType meterType = (from mt in mbmsEntities.MeterTypes where mt.MeterTypeID == meterTypeID select mt).FirstOrDefault();
                        meterType.Active = false;
                        meterType.DeletedUserID = UserID;
                        meterType.DeletedDate = DateTime.Now;
                        meterTypeController.DeleteMeterType(meterType);
                        dgvMeterTypeList.DataSource = (from mt in mbmsEntities.MeterTypes where mt.Active == true orderby mt.MeterTypeCode descending select mt).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitialState();
                        FormRefresh();
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    //EditMeterType
                    DataGridViewRow row = dgvMeterTypeList.Rows[e.RowIndex];
                    meterTypeID = Convert.ToString(row.Cells[0].Value);
                    txtMeterTypeCode.Text = Convert.ToString(row.Cells[1].Value);
                    txtMeterTypeDes.Text = Convert.ToString(row.Cells[2].Value);
                    isEdit = true;
                    btnSave.Text = "Update";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();
        }
        #endregion

        #region Grid Bind
        private void dgvMeterTypeList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMeterTypeList.Rows)
            {
                MeterType meterType = (MeterType)row.DataBoundItem;
                row.Cells[0].Value = meterType.MeterTypeID;
                row.Cells[1].Value = meterType.MeterTypeCode;
                row.Cells[2].Value = meterType.MeterTypeDescription;
            }
        }
        #endregion

        #region KeyDown
        private void txtMeterTypeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtMeterTypeDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }
        #endregion

        #region MouseMove
        private void MeterTypefrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtMeterTypeCode);
            tooltip.Hide(txtMeterTypeDes);
        }
        #endregion
    }
}
