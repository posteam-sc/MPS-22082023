using MBMS.DAL;
using MPS.BusinessLogic.MeterController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Meter_Setup
{
    public partial class MeterFrm : Form
    {
        #region Variables
        private ToolTip tooltip = new ToolTip();

        public string UserID { get; set; }
        public string meterID { get; set; }

        public Boolean isAdd { get; set; }
        public bool isEdit { get; set; }
        MeterController meterController = new MeterController();
        #endregion
        public MeterFrm()
        {
            InitializeComponent();
        }

        #region FormLoad
        private void MeterFrm_Load(object sender, EventArgs e)
        {

            bindMeterBoxCode();
            bindMeterTypeCode();
            if (isEdit)
            {
                BindMeter();

            }
            else
            {
                InitialState();
            }

        }
        #endregion

        #region Bind Combo
        private void bindMeterBoxCode()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<MeterBox> meterboxList = new List<MeterBox>();
            MeterBox meterbox = new MeterBox();
            meterbox.MeterBoxID = Convert.ToString(0);
            meterbox.MeterBoxCode = "Select";
            meterboxList.Add(meterbox);
            meterboxList.AddRange(mbmsEntities.MeterBoxes.Where(x => x.Active == true).OrderBy(x => x.MeterBoxCode).ToList());
            cboMeterBoxCode.DataSource = meterboxList;
            cboMeterBoxCode.DisplayMember = "MeterBoxCode";
            cboMeterBoxCode.ValueMember = "MeterBoxID";
        }
        private void BindMeter()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            btnSave.Text = "Update";
            Meter meter = (from m in mbmsEntities.Meters where m.MeterID == meterID select m).FirstOrDefault();
            txtMeterNo.Text = meter.MeterNo;
            txtMeterModel.Text = meter.Model;
            dtpInstallDate.Value = Convert.ToDateTime(meter.InstalledDate);
            txtLosses.Text = Convert.ToString(meter.Losses);
            txtMultiplier.Text = Convert.ToString(meter.Multiplier);
            txtHp.Text = Convert.ToString(meter.HP);
            txtVoltage.Text = Convert.ToString(meter.Voltage);
            txtAMP.Text = meter.AMP;
            txtStandard.Text = Convert.ToString(meter.Standard);
            txtPhrase.Text = meter.Phrase;
            txtWire.Text = meter.Wire;
            txtAvailableYear.Text = Convert.ToString(meter.AvailableYear);
            txtClass.Text = meter.Class;
            txtConstant.Text = meter.Constant;
            txtBasicCurrent.Text = meter.BasicCurrent;
            if (meter.Status == true)
            {
                rdoEnable.Checked = true;
            }
            else
            {
                rdoDisable.Checked = true;
            }
            txtiMax.Text = Convert.ToString(meter.iMax);
            txtKVA.Text = Convert.ToString(meter.KVA);
            txtManufacture.Text = meter.ManufactureBy;
            txtFrequency.Text = Convert.ToString(meter.Frequency);
            cboMeterBoxCode.Text = meter.MeterBox.MeterBoxCode;
            cboMeterSequence.Text = meter.MeterBoxSequence;
            cboMeterTypeCode.Text = meter.MeterType.MeterTypeCode;
        }


        private void bindMeterTypeCode()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<MeterType> meterTypeList = new List<MeterType>();
            MeterType meterType = new MeterType();
            meterType.MeterTypeID = Convert.ToString(0);
            meterType.MeterTypeCode = "Select";
            meterTypeList.Add(meterType);
            meterTypeList.AddRange(mbmsEntities.MeterTypes.Where(x => x.Active == true).OrderBy(x => x.MeterTypeCode).ToList());
            cboMeterTypeCode.DataSource = meterTypeList;
            cboMeterTypeCode.DisplayMember = "MeterTypeCode";
            cboMeterTypeCode.ValueMember = "MeterTypeID";
        }
        #endregion

        #region Method
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
        private bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";
            if (string.IsNullOrWhiteSpace(txtMeterNo.Text))
            {
                tooltip.SetToolTip(txtMeterNo, "Require");
                tooltip.Show("Please fill up Meter No !", txtMeterNo);
                txtMeterNo.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtMeterModel.Text))
            {
                tooltip.SetToolTip(txtMeterModel, "Require");
                tooltip.Show("Please fill up Meter Model!", txtMeterModel);
                txtMeterModel.Focus();
                hasError = false;
            }
            else if (dtpInstallDate.Value.ToString() == "")
            {
                tooltip.SetToolTip(dtpInstallDate, "Require");
                tooltip.Show("Please Select Install Date!", dtpInstallDate);
                dtpInstallDate.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhrase.Text))
            {
                tooltip.SetToolTip(txtPhrase, "Require");
                tooltip.Show("Please fill up Phrase!", txtPhrase);
                txtPhrase.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtWire.Text))
            {
                tooltip.SetToolTip(txtWire, "Require");
                tooltip.Show("Please fill up Wire!", txtWire);
                txtWire.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtBasicCurrent.Text))
            {
                tooltip.SetToolTip(txtBasicCurrent, "Require");
                tooltip.Show("Please fill up Basic Current!", txtBasicCurrent);
                txtBasicCurrent.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtiMax.Text))
            {
                tooltip.SetToolTip(txtiMax, "Require");
                tooltip.Show("Please fill up Max Current!", txtiMax);
                txtiMax.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtVoltage.Text))
            {
                tooltip.SetToolTip(txtVoltage, "Require");
                tooltip.Show("Please fill up Voltage!", txtVoltage);
                txtVoltage.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtManufacture.Text))
            {
                tooltip.SetToolTip(txtManufacture, "Require");
                tooltip.Show("Please fill up Manufacture By!", txtManufacture);
                txtManufacture.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtAvailableYear.Text))
            {
                tooltip.SetToolTip(txtAvailableYear, "Require");
                tooltip.Show("Please fill up Available Year!", txtAvailableYear);
                txtAvailableYear.Focus();
                hasError = false;
            }
            else if (cboMeterBoxCode.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboMeterBoxCode, "Require");
                tooltip.Show("Please choose Meter Box Code!", cboMeterBoxCode);
                cboMeterBoxCode.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(cboMeterSequence.Text))
            {
                tooltip.SetToolTip(cboMeterSequence, "Require");
                tooltip.Show("Please choose up Meter Box Sequence!", cboMeterSequence);
                cboMeterSequence.Focus();
                hasError = false;
            }
            else if (cboMeterTypeCode.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboMeterTypeCode, "Require");
                tooltip.Show("Please choose Meter Type Code!", cboMeterTypeCode);
                cboMeterTypeCode.Focus();
                hasError = false;
            }

            else if (string.IsNullOrWhiteSpace(txtLosses.Text))
            {
                tooltip.SetToolTip(txtLosses, "Require");
                tooltip.Show("Please fill up Losses!", txtLosses);
                txtLosses.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtMultiplier.Text))
            {
                tooltip.SetToolTip(txtMultiplier, "Require");
                tooltip.Show("Please fill up Multiplier!", txtMultiplier);
                txtMultiplier.Focus();
                hasError = false;
            }
            return hasError;
        }

        private void UpdateMeter()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();
                int editMeterCount = 0; int editmeterBoxNoCount = 0;
                Meter updateMeter = (from m in mbmsEntities.Meters where m.MeterID == meterID select m).FirstOrDefault();

                if (cboMeterSequence.Text != updateMeter.MeterBoxSequence)
                {
                    string meterboxId = cboMeterBoxCode.SelectedValue.ToString();
                    editmeterBoxNoCount = (from m in mbmsEntities.Meters where m.MeterBoxSequence == cboMeterSequence.Text && m.MeterBoxID == meterboxId && m.Active == true select m).ToList().Count;
                }
                if (editmeterBoxNoCount > 0)
                {
                    tooltip.SetToolTip(cboMeterSequence, "Error");
                    tooltip.Show("MeterBox Sequence No is already used!", cboMeterSequence);
                    return;
                }
                if (txtMeterNo.Text != updateMeter.MeterNo)
                {
                    editMeterCount = (from m in mbmsEntities.Meters where m.MeterNo == txtMeterNo.Text && m.Active == true select m).ToList().Count;
                }

                if (editMeterCount > 0)
                {
                    tooltip.SetToolTip(txtMeterNo, "Error");
                    tooltip.Show("Meter No is already exist!", txtMeterNo);
                    return;
                }
                updateMeter.MeterNo = txtMeterNo.Text;
                updateMeter.Model = txtMeterModel.Text;
                updateMeter.InstalledDate = dtpInstallDate.Value.Date;
                updateMeter.Losses = Convert.ToInt32(String.IsNullOrWhiteSpace(txtLosses.Text)? "1":txtLosses.Text);
                updateMeter.Multiplier = Convert.ToInt32(String.IsNullOrWhiteSpace(txtMultiplier.Text) ? "1":txtMultiplier.Text);
                updateMeter.HP = Convert.ToInt32(String.IsNullOrWhiteSpace(txtHp.Text) ? "0":txtHp.Text);
                updateMeter.Voltage = Convert.ToInt32(String.IsNullOrWhiteSpace(txtVoltage.Text) ? "0" :txtVoltage.Text);
                updateMeter.AMP = txtAMP.Text;
                updateMeter.Standard = Convert.ToInt32(String.IsNullOrWhiteSpace(txtStandard.Text) ? "0":txtStandard.Text);
                updateMeter.Status = rdoEnable.Checked;
                updateMeter.Phrase = txtPhrase.Text;
                updateMeter.Wire = txtWire.Text;
                updateMeter.BasicCurrent = txtBasicCurrent.Text;
                updateMeter.Constant = txtConstant.Text;
                updateMeter.AvailableYear = Convert.ToInt32(txtAvailableYear.Text);
                updateMeter.Class = txtClass.Text;
                updateMeter.iMax = Convert.ToInt32(String.IsNullOrWhiteSpace(txtiMax.Text) ? "0":txtiMax.Text );
                updateMeter.KVA = Convert.ToInt32(String.IsNullOrWhiteSpace(txtKVA.Text) ? "0" :txtKVA.Text);
                updateMeter.ManufactureBy = txtManufacture.Text;
                updateMeter.Frequency = Convert.ToInt32(String.IsNullOrWhiteSpace(txtFrequency.Text)?"0":txtFrequency.Text);
                updateMeter.MeterBoxID = cboMeterBoxCode.SelectedValue.ToString();
                updateMeter.MeterBoxSequence = cboMeterSequence.Text;
                updateMeter.MeterTypeID = cboMeterTypeCode.SelectedValue.ToString();
                updateMeter.UpdatedUserID = UserID;
                updateMeter.UpdatedDate = DateTime.Now;
                meterController.UpdateMeter(updateMeter);
                MessageBox.Show("Successfully updated Meter!", "Update");
                InitialState();
                //MeterListfrm newForm = (MeterListfrm)System.Windows.Forms.Application.OpenForms["MeterListfrm"];
                //newForm.UserID = UserID;
                //newForm.Show();
                this.Close();
                this.DialogResult = DialogResult.OK;
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
                Meter meter = new Meter();
                int meterNoCount = 0; int meterBoxNoCount = 0;
                string meterboxId = cboMeterBoxCode.SelectedValue.ToString();
                meterBoxNoCount = (from m in mbmsEntities.Meters where m.MeterBoxSequence == cboMeterSequence.Text && m.MeterBoxID == meterboxId && m.Active == true select m).ToList().Count;

                if (meterBoxNoCount > 0)
                {
                    tooltip.SetToolTip(cboMeterSequence, "Error");
                    tooltip.Show("MeterBox Sequence No is already used!", cboMeterSequence);
                    return;
                }
                meterNoCount = (from m in mbmsEntities.Meters where m.MeterNo == txtMeterNo.Text && m.Active == true select m).ToList().Count;

                if (meterNoCount > 0)
                {
                    tooltip.SetToolTip(txtMeterNo, "Error");
                    tooltip.Show("Meter No is already exist!", txtMeterNo);
                    return;
                }
                meter.MeterID = Guid.NewGuid().ToString();
                meter.MeterNo = txtMeterNo.Text;
                meter.Model = txtMeterModel.Text;
                meter.InstalledDate = dtpInstallDate.Value.Date;
                meter.Losses = Convert.ToInt32(txtLosses.Text);
                meter.Multiplier = Convert.ToInt32(txtMultiplier.Text);
                meter.HP = Convert.ToInt32(String.IsNullOrWhiteSpace(txtHp.Text) ? "0" : txtHp.Text);
                meter.Voltage = Convert.ToInt32(txtVoltage.Text);
                meter.AMP =(String.IsNullOrWhiteSpace( txtAMP.Text) ? "0" : txtAMP.Text);
                meter.Standard = Convert.ToInt32(String.IsNullOrWhiteSpace(txtStandard.Text) ? "0" : txtStandard.Text);
                meter.Status = rdoEnable.Checked;
                meter.Phrase = txtPhrase.Text;
                meter.Wire = txtWire.Text;
                meter.BasicCurrent = txtBasicCurrent.Text;
                meter.Constant =String.IsNullOrWhiteSpace(txtConstant.Text) ? "0" : txtConstant.Text;
                meter.AvailableYear = Convert.ToInt32(txtAvailableYear.Text);
                meter.Class =String.IsNullOrWhiteSpace( txtClass.Text) ? "0" : txtClass.Text;
                meter.iMax = Convert.ToInt32(txtiMax.Text);
                meter.KVA = Convert.ToInt32(String.IsNullOrWhiteSpace(txtKVA.Text) ? "0" : txtKVA.Text);
                meter.ManufactureBy = txtManufacture.Text;
                meter.Frequency = Convert.ToInt32(String.IsNullOrWhiteSpace(txtFrequency.Text) ? "0" : txtFrequency.Text);
                meter.MeterBoxID = cboMeterBoxCode.SelectedValue.ToString();
                meter.MeterBoxSequence = cboMeterSequence.Text;
                meter.MeterTypeID = cboMeterTypeCode.SelectedValue.ToString();
                meter.Active = true;
                meter.CreatedUserID = UserID;
                meter.CreatedDate = DateTime.Now;
                meterController.Save(meter);
                MessageBox.Show("Successfully registered Meter! Please check it in 'Meter List'.", "Save Success");
                InitialState();
                if (isAdd)
                {
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void InitialState()
        {
            if (!CheckingRoleManagementFeature("MeterAdd"))
                btnSave.Enabled = false;

            txtAMP.Text = string.Empty;
            txtFrequency.Text = string.Empty;
            txtHp.Text = string.Empty;
            txtiMax.Text = string.Empty;
            txtKVA.Text = string.Empty;
            txtLosses.Text = "1";
            txtManufacture.Text = string.Empty;
            cboMeterSequence.Enabled = false;
            cboMeterSequence.Text = null;
            txtMeterModel.Text = string.Empty;
            txtMeterNo.Text = string.Empty;
            txtMultiplier.Text = "1";
            txtStandard.Text = string.Empty;
            txtVoltage.Text = string.Empty;
            dtpInstallDate.Value = DateTime.Now;
            cboMeterBoxCode.SelectedIndex = 0;
            cboMeterTypeCode.SelectedIndex = 0;
            rdoEnable.Checked = true;
            txtAvailableYear.Text = string.Empty;
            txtBasicCurrent.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtConstant.Text = string.Empty;
            txtWire.Text = string.Empty;
            txtPhrase.Text = string.Empty;
            btnSave.Text = "Save";
            txtMeterNo.Focus();
            isEdit = false;

        }

        #endregion

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (checkValidation())
            {
                if (isEdit)
                {
                    UpdateMeter();
                }
                else
                {
                    Save();
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();
        }

        #endregion

        #region Combo Selected Changed

        private void cboMeterBoxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            mbmsEntities = new MBMSEntities();
            if (cboMeterBoxCode.SelectedIndex > 0)
            {
                cboMeterSequence.Items.Clear();
                string meterBoxID = Convert.ToString(cboMeterBoxCode.SelectedValue);
                var meterBoxData = (from m in mbmsEntities.MeterBoxes where m.MeterBoxID == meterBoxID select m).FirstOrDefault();
                if (meterBoxData.MeterBoxName == "Single Box" || meterBoxData.MeterBoxName == "Three Phase Box")
                {
                    cboMeterSequence.Enabled = true;
                    cboMeterSequence.Items.Add(meterBoxData.Box + "1");
                }
                else if (meterBoxData.MeterBoxName == "Single Phase 4 Unit Box")
                {
                    cboMeterSequence.Enabled = true;
                    cboMeterSequence.Items.Add(meterBoxData.Box + "1");
                    cboMeterSequence.Items.Add(meterBoxData.Box + "2");
                    cboMeterSequence.Items.Add(meterBoxData.Box + "3");
                    cboMeterSequence.Items.Add(meterBoxData.Box + "4");
                }
            }
            else
            {
                cboMeterSequence.Enabled = false;
            }
        }

        #endregion

        #region Mouse Mouse
        private void MeterFrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtMeterNo);
            tooltip.Hide(txtMeterModel);
            tooltip.Hide(dtpInstallDate);
            tooltip.Hide(txtPhrase);
            tooltip.Hide(txtWire);
            tooltip.Hide(txtBasicCurrent);
            tooltip.Hide(txtiMax);
            tooltip.Hide(txtVoltage);
            tooltip.Hide(txtManufacture);
            tooltip.Hide(txtAvailableYear);
            tooltip.Hide(cboMeterBoxCode);
            tooltip.Hide(cboMeterSequence);
            tooltip.Hide(cboMeterTypeCode);
            tooltip.Hide(txtLosses);
            tooltip.Hide(txtMultiplier);
        }

        #endregion

        #region Key Press

        private void txtAvailableYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtLosses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtMultiplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtHp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtStandard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtiMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtKVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }
        private void txtPhrase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Please input numbers.");
                e.Handled = true;
            }
        }

        private void txtWire_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtBasicCurrent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        #endregion

        #region Form Closing
        private void MeterFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMeterNo.Text))
            {
                DialogResult result = MessageBox.Show("Need to Update Record", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    e.Cancel = true;
                }
                else
                {
                    var meterListForm = new MeterListfrm();
                    meterListForm.UserID = UserID;
                    meterListForm.SearchMeter();
                }
            }
        }



        #endregion

        #region Key Down

        private void txtMeterNo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtMeterModel.Focus();
                    break;
                case Keys.Right:
                    txtLosses.Focus();
                    break;
                default:
                    txtMeterNo.Focus();
                    break;
            }
        }

        private void txtMeterModel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    dtpInstallDate.Focus();
                    break;
                case Keys.Up:
                    txtMeterNo.Focus();
                    break;

                case Keys.Right:
                    txtMultiplier.Focus();
                    break;
                default:
                    txtMeterModel.Focus();
                    break;
            }
        }

        private void dtpInstallDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtPhrase.Focus();
                    break;
                case Keys.Up:
                    txtMeterModel.Focus();
                    break;

                case Keys.Right:
                    txtHp.Focus();
                    break;
                default:
                    dtpInstallDate.Focus();
                    break;
            }
        }

        private void txtPhrase_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                case Keys.Right:
                    txtWire.Focus();
                    break;
                case Keys.Up:
                    dtpInstallDate.Focus();
                    break;
                default:
                    txtPhrase.Focus();
                    break;
            }
        }

        private void txtWire_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtBasicCurrent.Focus();
                    break;
                case Keys.Left:
                    txtPhrase.Focus();
                    break;
                case Keys.Right:
                    txtAMP.Focus();
                    break;
                default:
                    txtWire.Focus();
                    break;
            }
        }

        private void txtBasicCurrent_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                case Keys.Right:
                    txtiMax.Focus();
                    break;
                case Keys.Up:
                    txtPhrase.Focus();
                    break;
                default:
                    txtBasicCurrent.Focus();
                    break;
            }
        }

        private void txtiMax_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtVoltage.Focus();
                    break;
                case Keys.Up:
                    txtWire.Focus();
                    break;
                case Keys.Right:
                    txtStandard.Focus();
                    break;
                case Keys.Left:
                    txtBasicCurrent.Focus();
                    break;
                default:
                    txtiMax.Focus();
                    break;
            }
        }

        private void txtVoltage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtManufacture.Focus();
                    break;
                case Keys.Up:
                    txtiMax.Focus();
                    break;
                case Keys.Right:
                    txtKVA.Focus();
                    break;
                default:
                    txtVoltage.Focus();
                    break;
            }
        }

        private void txtManufacture_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    rdoEnable.Focus();
                    break;
                case Keys.Up:
                    txtVoltage.Focus();
                    break;
                case Keys.Right:
                    txtFrequency.Focus();
                    break;
                default:
                    txtManufacture.Focus();
                    break;
            }
        }

        private void rdoEnable_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Down:
                    txtAvailableYear.Focus();
                    break;
                case Keys.Up:
                    txtManufacture.Focus();
                    break;
                case Keys.Right:
                    rdoDisable.Focus();
                    break;
                default:
                    rdoEnable.Focus();
                    break;
            }
        }

        private void rdoDisable_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Down:
                    txtAvailableYear.Focus();
                    break;
                case Keys.Up:
                    txtManufacture.Focus();
                    break;
                case Keys.Right:
                    txtClass.Focus();
                    break;
                case Keys.Left:
                    rdoEnable.Focus();
                    break;
                default:
                    rdoDisable.Focus();
                    break;
            }
        }

        private void txtAvailableYear_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    cboMeterBoxCode.Focus();
                    break;
                case Keys.Up:
                    rdoEnable.Focus();
                    break;
                case Keys.Right:
                    txtConstant.Focus();
                    break;
                default:
                    txtAvailableYear.Focus();
                    break;
            }
        }

        private void cboMeterBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    cboMeterSequence.Focus();
                    break;


                default:
                    cboMeterBoxCode.Focus();
                    break;
            }
        }

        private void cboMeterSequence_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    cboMeterTypeCode.Focus();
                    break;


                default:
                    cboMeterSequence.Focus();
                    break;
            }
        }

        private void cboMeterTypeCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtLosses.Focus();
                    break;

                default:
                    cboMeterTypeCode.Focus();
                    break;
            }
        }

        private void txtLosses_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtMultiplier.Focus();
                    break;
                case Keys.Up:
                    cboMeterTypeCode.Focus();
                    break;
                case Keys.Left:
                    txtMeterNo.Focus();
                    break;
                default:
                    txtLosses.Focus();
                    break;
            }
        }

        private void txtMultiplier_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtHp.Focus();
                    break;
                case Keys.Up:
                    txtLosses.Focus();
                    break;
                case Keys.Left:
                    txtMeterModel.Focus();
                    break;
                default:
                    txtMultiplier.Focus();
                    break;
            }
        }

        private void txtHp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtAMP.Focus();
                    break;
                case Keys.Up:
                    txtMultiplier.Focus();
                    break;
                case Keys.Left:
                    dtpInstallDate.Focus();
                    break;
                default:
                    txtHp.Focus();
                    break;
            }
        }

        private void txtAMP_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtStandard.Focus();
                    break;
                case Keys.Up:
                    txtHp.Focus();
                    break;
                case Keys.Left:
                    txtWire.Focus();
                    break;
                default:
                    txtAMP.Focus();
                    break;
            }
        }

        private void txtStandard_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtKVA.Focus();
                    break;
                case Keys.Up:
                    txtAMP.Focus();
                    break;
                case Keys.Left:
                    txtiMax.Focus();
                    break;
                default:
                    txtStandard.Focus();
                    break;
            }
        }

        private void txtKVA_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtFrequency.Focus();
                    break;
                case Keys.Up:
                    txtStandard.Focus();
                    break;
                case Keys.Left:
                    txtVoltage.Focus();
                    break;
                default:
                    txtKVA.Focus();
                    break;
            }
        }

        private void txtFrequency_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtClass.Focus();
                    break;
                case Keys.Up:
                    txtKVA.Focus();
                    break;
                case Keys.Left:
                    txtManufacture.Focus();
                    break;
                default:
                    txtFrequency.Focus();
                    break;
            }
        }

        private void txtClass_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    txtConstant.Focus();
                    break;
                case Keys.Up:
                    txtFrequency.Focus();
                    break;
                case Keys.Left:
                    rdoDisable.Focus();
                    break;
                default:
                    txtClass.Focus();
                    break;
            }
        }

        private void txtConstant_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    txtClass.Focus();
                    break;
                case Keys.Left:
                    txtAvailableYear.Focus();
                    break;
                case Keys.Enter:
                case Keys.Down:
                    btnSave.Focus();
                    break;
                default:
                    txtConstant.Focus();
                    break;
            }
        }
        #endregion
    }
}
