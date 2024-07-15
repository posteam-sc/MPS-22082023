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
    public partial class Transformerfrm : Form
    {
        #region Variables
        public string TransformerID { get; set; }
        public string UserID { get; set; }
       
        private ToolTip tooltip = new ToolTip();

        TransformerController transformerController = new TransformerController();
        public Boolean isEdit { get; set; }

        public Boolean isAddList { get; set; }
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
            quarterList.AddRange(mbsEntities.Quarters.Where(x => x.Active == true).OrderBy(x => x.QuarterNameInEng).ToList());
            cboQuarterName.DataSource = quarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
        }
        #endregion
        public Transformerfrm()
        {
            InitializeComponent();
        }

        #region Method
        private bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";
            //Validation
            if (string.IsNullOrWhiteSpace(txtTransformerName.Text))
            {
                tooltip.SetToolTip(txtTransformerName, "Require");
                tooltip.Show("Please fill up Transformer name!", txtTransformerName);
                txtTransformerName.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtTransformerModel.Text))
            {
                tooltip.SetToolTip(txtTransformerModel, "Require");
                tooltip.Show("Please fill up Transformer model!", txtTransformerModel);
                txtTransformerModel.Focus();

                hasError = false;
            }
            else if (cboQuarterName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboQuarterName, "Require");
                tooltip.Show("Please choose Quarter name!", cboQuarterName);
                cboQuarterName.Focus();
                hasError = false;
            }
            return hasError;
        }
        private void InitialState()
        {
            txtTransformerName.Text = string.Empty;
            txtTransformerModel.Text = string.Empty;
            txtmaker.Text = string.Empty;
            txtCountryOrgin.Text = string.Empty;
            txtImpedanceVoltage.Text = string.Empty;
            cboQuarterName.SelectedIndex = 0;
            txtEfficiency.Text = string.Empty;
            txtFullLoadLoss.Text = string.Empty;
            txtNoLoadLoss.Text = string.Empty;
            txtRatedPower.Text = string.Empty;
            txtTypeOfCooling.Text = string.Empty;
            txtVectorGroup.Text = string.Empty;
            txtVoltageRatio.Text = string.Empty;
            rdoEnable.Checked = true;
            txtStandard.Text = string.Empty;
            txtTappingRange.Text = string.Empty;
            btnSave.Text = "Save";
            isEdit = false;
            txtTransformerName.Focus();

        }

        private void UpdateTransformer()
        {
            try
            {
                MBMSEntities mbsEntities = new MBMSEntities();
                int TransformerName = 0;
                TransformerName = (from tn in mbsEntities.Transformers where tn.TransformerName.Trim() == txtTransformerName.Text.Trim() && tn.Quarter.QuarterNameInEng==cboQuarterName.Text && tn.TransformerID != TransformerID && tn.Active == true select tn).ToList().Count;
                if (TransformerName == 0)
                {
                    string oldTransformerName;
                    Transformer updateTransformer = (from tf in mbsEntities.Transformers where tf.TransformerID == TransformerID select tf).FirstOrDefault();
                    oldTransformerName = updateTransformer.TransformerName;

                    updateTransformer.TransformerName = txtTransformerName.Text;
                    updateTransformer.Model = txtTransformerModel.Text;
                    updateTransformer.CountryOfOrgin = txtCountryOrgin.Text;
                    updateTransformer.FullLoadLoss = Convert.ToInt32(txtFullLoadLoss.Text);
                    updateTransformer.ImpendanceVoltage = Convert.ToInt32(txtImpedanceVoltage.Text);
                    updateTransformer.EfficiencyLoad = Convert.ToInt32(txtEfficiency.Text);
                    updateTransformer.TappingRange = txtTappingRange.Text;
                    updateTransformer.TypeofCooling = txtTypeOfCooling.Text;
                    updateTransformer.VectorGroup = txtVectorGroup.Text;
                    updateTransformer.VoltageRatio = Convert.ToInt32(txtVoltageRatio.Text);
                    updateTransformer.Standard = txtStandard.Text;
                    updateTransformer.NoloadLoss = Convert.ToInt32(txtNoLoadLoss.Text);
                    updateTransformer.RatedOutputPower = Convert.ToInt32(txtRatedPower.Text);
                    updateTransformer.Maker = txtmaker.Text;

                    if (rdoEnable.Checked == true)
                    {
                        updateTransformer.Status = true;
                    }
                    else
                    {
                        updateTransformer.Status = false;
                    }


                    updateTransformer.QuarterID = cboQuarterName.SelectedValue.ToString();
                    updateTransformer.UpdatedUserID = UserID;
                    updateTransformer.UpdateDate = DateTime.Now;
                    transformerController.UpdateTransformer(updateTransformer);
                    if (oldTransformerName != txtTransformerName.Text)
                    {
                        TransformerHistory transformerHistory = new TransformerHistory();
                        transformerHistory.TransformerID = Guid.NewGuid().ToString();
                        transformerHistory.OldTransformerName = oldTransformerName;
                        transformerHistory.TransformerName = updateTransformer.TransformerName;
                        transformerHistory.Model = updateTransformer.Model;
                        transformerHistory.CountryOfOrgin = updateTransformer.CountryOfOrgin;
                        transformerHistory.FullLoadLoss = updateTransformer.FullLoadLoss;
                        transformerHistory.ImpendanceVoltage = updateTransformer.ImpendanceVoltage;
                        transformerHistory.EfficiencyLoad = updateTransformer.EfficiencyLoad;
                        transformerHistory.TappingRange = updateTransformer.TappingRange;
                        transformerHistory.TypeofCooling = updateTransformer.TypeofCooling;
                        transformerHistory.VectorGroup = updateTransformer.VectorGroup;
                        transformerHistory.VoltageRatio = updateTransformer.VoltageRatio;
                        transformerHistory.Standard = updateTransformer.Standard;
                        transformerHistory.NoloadLoss = updateTransformer.NoloadLoss;
                        transformerHistory.RatedOutputPower = updateTransformer.RatedOutputPower;
                        transformerHistory.Maker = updateTransformer.Maker;
                        transformerHistory.GPSX = 0;
                        transformerHistory.GPSY = 0;
                        if (updateTransformer.Status == true)
                            transformerHistory.Status = true;
                        else
                            transformerHistory.Status = false;
                        transformerHistory.CreatedUserID = updateTransformer.UpdatedUserID;
                        transformerHistory.CreatedDate = DateTime.Now;
                        transformerHistory.QuarterID = updateTransformer.QuarterID;
                        transformerHistory.Active = true;
                        mbsEntities.TransformerHistories.Add(transformerHistory);
                        mbsEntities.SaveChanges();
                    }

                    MessageBox.Show("Successfully updated Transformer!", "Update");
                    InitialState();
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else if (TransformerName > 0)
                {
                    tooltip.SetToolTip(txtTransformerName, "Error");
                    tooltip.Show("This Transformer Code is already exist!", txtTransformerName);
                }
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
                MBMSEntities mbsEntities = new MBMSEntities();
                int TransformerName = 0;
                TransformerName = (from tn in mbsEntities.Transformers where tn.TransformerName.Trim() == txtTransformerName.Text.Trim() && tn.Quarter.QuarterNameInEng==cboQuarterName.Text && tn.Active == true select tn).ToList().Count;
                 if (TransformerName == 0)
                {
                    Transformer transformer = new Transformer();
                    transformer.TransformerID = Guid.NewGuid().ToString();
                    transformer.TransformerName = txtTransformerName.Text;
                    transformer.Model = txtTransformerModel.Text;
                    transformer.CountryOfOrgin = txtCountryOrgin.Text;
                    transformer.FullLoadLoss = Convert.ToInt32(txtFullLoadLoss.Text == "" ? "0" : txtFullLoadLoss.Text);
                    transformer.ImpendanceVoltage = Convert.ToInt32(txtImpedanceVoltage.Text == "" ? "0" : txtImpedanceVoltage.Text);
                    transformer.EfficiencyLoad = Convert.ToInt32(txtEfficiency.Text == "" ? "0" : txtEfficiency.Text);
                    transformer.TappingRange = txtTappingRange.Text == "" ? "0" : txtTappingRange.Text;
                    transformer.TypeofCooling = txtTypeOfCooling.Text == "" ? "0" : txtTypeOfCooling.Text;
                    transformer.VectorGroup = txtVectorGroup.Text;
                    transformer.VoltageRatio = Convert.ToInt32(txtVoltageRatio.Text == "" ? "0" : txtVoltageRatio.Text);
                    transformer.Standard = txtStandard.Text == "" ? "0" : txtStandard.Text;
                    transformer.NoloadLoss = Convert.ToInt32(txtNoLoadLoss.Text == "" ? "0" : txtNoLoadLoss.Text);
                    transformer.RatedOutputPower = Convert.ToInt32(txtRatedPower.Text == "" ? "0" : txtRatedPower.Text);
                    transformer.Maker = txtmaker.Text;
                    if (rdoEnable.Checked == true)
                    {
                        transformer.Status = true;
                    }
                    else
                    {
                        transformer.Status = false;
                    }
                    transformer.QuarterID = cboQuarterName.SelectedValue.ToString();
                    transformer.Active = true;
                    transformer.CreatedUserID = UserID;
                    transformer.CreatedDate = DateTime.Now;
                    transformerController.Save(transformer);
                    MessageBox.Show("Successfully registered Trasformer! Please check it in 'Transformer List'.", "Save Success");
                    InitialState();
                    if (isAddList)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else if (TransformerName > 0)
                {
                    tooltip.SetToolTip(txtTransformerName, "Error");
                    tooltip.Show("This Transformer Code is already exist!", txtTransformerName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BindEditTransformer()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            btnSave.Text = "Update";
            Transformer transformer = (from tf in mbsEntities.Transformers where tf.TransformerID == TransformerID select tf).FirstOrDefault();
            txtTransformerName.Text = transformer.TransformerName;
            txtTransformerModel.Text = transformer.Model;
            txtmaker.Text = transformer.Maker;
            txtCountryOrgin.Text = transformer.CountryOfOrgin;
            txtTappingRange.Text = transformer.TappingRange;
            txtStandard.Text = transformer.Standard;
            txtRatedPower.Text = Convert.ToString(transformer.RatedOutputPower);
            txtImpedanceVoltage.Text = Convert.ToString(transformer.ImpendanceVoltage);
            txtEfficiency.Text = Convert.ToString(transformer.EfficiencyLoad);
            txtTypeOfCooling.Text = transformer.TypeofCooling;
            txtVectorGroup.Text = transformer.VectorGroup;
            txtVoltageRatio.Text = Convert.ToString(transformer.VoltageRatio);
            txtNoLoadLoss.Text = Convert.ToString(transformer.NoloadLoss);
            txtFullLoadLoss.Text = Convert.ToString(transformer.FullLoadLoss);

            if (transformer.Status == true)
            {
                rdoEnable.Checked = true;
            }
            else
            {
                rdoDisable.Checked = true;
            }
            cboQuarterName.Text = transformer.Quarter.QuarterNameInEng;
        }

        #endregion

        #region Form Load
        private void Transformerfrm_Load(object sender, EventArgs e)
        {

            bindQuarter();
            if (isEdit)
            {
                BindEditTransformer();
            }
            else
                InitialState();
        }
        #endregion

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (checkValidation())
            {
                if (isEdit)
                {
                    UpdateTransformer();

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

        #region Mouse Move
        private void Transformerfrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtTransformerName);
            tooltip.Hide(txtTransformerName);
            tooltip.Hide(cboQuarterName);

        }
        #endregion

        #region Key Press

        private void txtRatedPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtVoltageRatio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtEfficiency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtImpedanceVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtNoLoadLoss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }

        private void txtFullLoadLoss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please input numbers.");
            }
        }
        #endregion

        #region Form Closing
        private void Transformerfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTransformerName.Text))
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
                        var transformerList = new TransformerListfrm();
                        transformerList.UserID = UserID;
                        transformerList.FormRefresh();
                    }
                }

            }
        }
        #endregion
    }
}
