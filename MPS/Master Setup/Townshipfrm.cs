using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS
{
    public partial class Townshipfrm : Form
    {
        #region Variable
        private ToolTip tooltip = new ToolTip();
        public String UserID { get; set; }
        string TownshipID;
        public Boolean isEdit { get; set; }
        TownshipController townshipController = new TownshipController();
        #endregion

        public Townshipfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void Townshipfrm_Load(object sender, EventArgs e)
        {
            InitialState();
            FormRefresh();
        }
        #endregion

        #region Method
        public bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Require";

            if (string.IsNullOrWhiteSpace(txtTownshipCode.Text))
            {
                tooltip.SetToolTip(txtTownshipCode, "Require");
                tooltip.Show("Please fill up Township code!", txtTownshipCode);
                txtTownshipCode.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtTownshipNameEng.Text))
            {
                tooltip.SetToolTip(txtTownshipNameEng, "Require");
                tooltip.Show("Please fill up Township Name (English)!", txtTownshipNameEng);
                txtTownshipNameEng.Focus();
                hasError = false;
            }
            else if (string.IsNullOrWhiteSpace(txtTowsshipNameMM.Text))
            {
                tooltip.SetToolTip(txtTowsshipNameMM, "Require");
                tooltip.Show("Please fill up Township Name (Myanmar)!", txtTowsshipNameMM);
                txtTowsshipNameMM.Focus();
                hasError = false;
            }
            return hasError;
        }

        private void UpdateTownship()
        {
            try
            {
                MBMSEntities mbmsEntities = new MBMSEntities();

                int editTownshipCodeCount = 0, editTownshipNameEngCount = 0, editTownshipNameMM = 0;

                Township updateTownship = (from t in mbmsEntities.Townships where t.TownshipID == TownshipID select t).FirstOrDefault();
                if (txtTownshipCode.Text != updateTownship.TownshipCode)
                {
                    editTownshipCodeCount = (from t in mbmsEntities.Townships where (t.TownshipCode == txtTownshipCode.Text) && t.Active == true select t).ToList().Count;
                }
                if (txtTownshipNameEng.Text != updateTownship.TownshipNameInEng)
                {
                    editTownshipNameEngCount = (from t in mbmsEntities.Townships where (t.TownshipNameInEng == txtTownshipNameEng.Text) && t.Active == true select t).ToList().Count;
                }
                if (txtTowsshipNameMM.Text != updateTownship.TownshipNameInMM)
                {
                    editTownshipNameMM = (from t in mbmsEntities.Townships where (t.TownshipNameInMM == txtTowsshipNameMM.Text) && t.Active == true select t).ToList().Count;
                }

                if (editTownshipCodeCount > 0)
                {
                    tooltip.SetToolTip(txtTownshipCode, "Error");
                    tooltip.Show("Township Code is already exist!", txtTownshipCode);
                    return;
                }
                if (editTownshipNameEngCount > 0)
                {
                    tooltip.SetToolTip(txtTownshipNameEng, "Error");
                    tooltip.Show("Township Name is already exist!", txtTownshipNameEng);
                    return;
                }
                if (editTownshipNameEngCount > 0)
                {
                    tooltip.SetToolTip(txtTowsshipNameMM, "Error");
                    tooltip.Show("Township Name is already exist!", txtTowsshipNameMM);
                    return;
                }
                updateTownship.TownshipCode = txtTownshipCode.Text;
                updateTownship.TownshipNameInEng = txtTownshipNameEng.Text;
                updateTownship.TownshipNameInMM = txtTowsshipNameMM.Text;
                updateTownship.UpdatedUserID = UserID;
                updateTownship.UpdatedDate = DateTime.Now;
                townshipController.UpdatedByTownshipID(updateTownship);
                MessageBox.Show("Successfully updated Township!", "Update");
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

                Township township = new Township();
                int townshipCodeCount = 0, townshipNameEng = 0, townshipNameMM = 0;
                townshipCodeCount = (from t in mbmsEntities.Townships where t.TownshipCode == txtTownshipCode.Text && t.Active == true select t).ToList().Count;
                townshipNameEng = (from t in mbmsEntities.Townships where t.TownshipNameInEng == txtTownshipNameEng.Text && t.Active == true select t).ToList().Count;
                townshipNameMM = (from t in mbmsEntities.Townships where t.TownshipNameInMM == txtTowsshipNameMM.Text && t.Active == true select t).ToList().Count;

                if (townshipCodeCount > 0)
                {
                    tooltip.SetToolTip(txtTownshipCode, "Error");
                    tooltip.Show("Township Code is already exist!", txtTownshipCode);
                    return;
                }
                if (townshipNameEng > 0)
                {
                    tooltip.SetToolTip(txtTownshipNameEng, "Error");
                    tooltip.Show("Township Name is already exist!", txtTownshipNameEng);
                    return;
                }
                if (townshipNameMM > 0)
                {
                    tooltip.SetToolTip(txtTowsshipNameMM, "Error");
                    tooltip.Show("Township Name is already exist!", txtTowsshipNameMM);
                    return;
                }
                township.TownshipID = Guid.NewGuid().ToString();
                township.TownshipCode = txtTownshipCode.Text;
                township.TownshipNameInEng = txtTownshipNameEng.Text;
                township.TownshipNameInMM = txtTowsshipNameMM.Text;
                township.Active = true;
                township.CreatedUserID = UserID;
                township.CreatedDate = DateTime.Now;
                townshipController.Save(township);
                MessageBox.Show("Successfully registered Township! Please check it in'Township List'.", "Save Success");
                InitialState();
                FormRefresh();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void InitialState()
        {
            txtTownshipCode.Clear();
            txtTownshipNameEng.Clear();
            txtTowsshipNameMM.Clear();
            txtTownshipCode.Focus();
            isEdit = false;
            btnSave.Text = "Save";
        }

        public void FormRefresh()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();

            dgvTownship.AutoGenerateColumns = false;
            dgvTownship.DataSource = (from t in mbmsEntities.Townships where t.Active == true orderby t.TownshipID descending select t).ToList();
        }
        #endregion

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkValidation())
            {
                if (isEdit)
                {
                    UpdateTownship();
                }
                else
                {
                    Save();
                }
            }
        }

        private void dgvTownship_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    //DeleteForTownship
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        MBMSEntities mbmsEntities = new MBMSEntities();

                        DataGridViewRow row = dgvTownship.Rows[e.RowIndex];
                        Township townshipObj = (Township)row.DataBoundItem;
                        townshipObj = (from t in mbmsEntities.Townships where t.TownshipID == townshipObj.TownshipID select t).FirstOrDefault();
                        var quarterCount = (from t in townshipObj.Quarters where t.Active == true select t).Count();
                        //var customerCount = (from t in townshipObj.Customers where t.Active == true select t).Count();
                        if (quarterCount > 0)
                        {
                            MessageBox.Show("This Township cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //if (customerCount > 0)
                        //{
                        //    MessageBox.Show("This Township cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        TownshipID = Convert.ToString(row.Cells[0].Value);
                        dgvTownship.DataSource = "";
                        Township township = (from t in mbmsEntities.Townships where t.TownshipID == TownshipID select t).FirstOrDefault();
                        township.Active = false;
                        township.DeletedUserID = UserID;
                        township.DeletedDate = DateTime.Now;
                        townshipController.DeletedByTownship(township);
                        dgvTownship.DataSource = (from t in mbmsEntities.Townships where t.Active == true orderby t.TownshipCode descending select t).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitialState();
                        FormRefresh();
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    //EditTownship
                    DataGridViewRow row = dgvTownship.Rows[e.RowIndex];
                    TownshipID = Convert.ToString(row.Cells[0].Value);
                    txtTownshipCode.Text = Convert.ToString(row.Cells[1].Value);
                    txtTownshipNameEng.Text = Convert.ToString(row.Cells[2].Value);
                    txtTowsshipNameMM.Text = Convert.ToString(row.Cells[3].Value);
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

        #region GridBind
        private void dgvTownship_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTownship.Rows)
            {
                Township township = (Township)row.DataBoundItem;
                row.Cells[0].Value = township.TownshipID;
                row.Cells[1].Value = township.TownshipCode;
                row.Cells[2].Value = township.TownshipNameInEng;
                row.Cells[3].Value = township.TownshipNameInMM;
            }
        }
        #endregion

        #region KeyDowm
        private void txtTownshipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtTownshipNameEng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtTowsshipNameMM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }
        #endregion

        #region Mouse Move
        private void Townshipfrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtTownshipCode);
            tooltip.Hide(txtTownshipNameEng);
            tooltip.Hide(txtTowsshipNameMM);
        }
        #endregion

      

        private void txtTownshipNameEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
