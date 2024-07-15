using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MBMS.DAL;

namespace MPS
{
    public partial class frmMeterSearch : Form
    {
        #region variable
        string code;
        public string meterNo { get; set; }
        public string meterId { get; set; }
        public string transformer { get; set; }
        #endregion

        public frmMeterSearch()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmMeterSearch_Load(object sender, EventArgs e)
        {
            dgvSearch.AutoGenerateColumns = false;
            BindFindBy();
            Search();
        }
        #endregion

        #region Method
        private void BindFindBy()
        {
            List<string> FindBy = new List<string>
            {
                "Meter No"
            };
            cboFindColumn.DataSource = null;
            cboFindColumn.Items.AddRange(FindBy.ToArray());
            cboFindColumn.SelectedIndex = 0;
        }

        private void Search()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Meter> allMeter = new List<Meter>();
            List<Meter> registerMeter = new List<Meter>();
            allMeter = (from m in mbmsEntities.Meters
                        join mb in mbmsEntities.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                        join p in mbmsEntities.Poles on mb.PoleID equals p.PoleID
                        join t in mbmsEntities.Transformers on p.TransformerID equals t.TransformerID
                        where t.TransformerName == transformer && m.Active == true
                        select m).ToList();
            registerMeter = (from m in mbmsEntities.Meters
                             join c in mbmsEntities.Customers on m.MeterID equals c.MeterID
                             select m).ToList();
            var meter = (allMeter.Except(registerMeter)).Where(x=>x.Status==true);
            //var meter = (from m in mbmsEntities.Meters
            //            join mb in mbmsEntities.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
            //            join p in mbmsEntities.Poles on mb.PoleID equals p.PoleID
            //            join t in mbmsEntities.Transformers on p.TransformerID equals t.TransformerID
            //            where t.TransformerName == transformer && m.Active==true
            //            select m).ToList();
            if (!String.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                dgvSearch.DataSource = null;
                switch (cboFindColumn.Text)
                {
                    case "Meter No":
                        dgvSearch.DataSource = meter.Where(m => m.MeterNo.IndexOf(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) != -1 && m.Active == true).ToList();
                        break;
                    //case "Meter Type":
                    //    dgvSearch.DataSource = meter.Where(m => m.MeterType.MeterTypeCode.IndexOf(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();
                    //    break;
                    default:
                        dgvSearch.DataSource = meter.ToList();
                        break;
                }
            }
            else
            {
                dgvSearch.DataSource = meter.ToList();
            }
            dgvSearch.Refresh();
        }
        #endregion

        #region Data Binding Grid
        private void dgvSearch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvSearch.Rows)
            {
                Meter m = (Meter)row.DataBoundItem;
                row.Cells[0].Value = m.MeterID;
                row.Cells[1].Value = m.MeterNo.Trim();
                row.Cells[2].Value = m.Model.Trim();
                row.Cells[3].Value = m.InstalledDate.ToString();
                row.Cells[4].Value = m.ManufactureBy.Trim();
                row.Cells[5].Value = m.MeterBoxSequence.Trim();
                row.Cells[6].Value = m.AvailableYear;
            }
            code = null;
            btnSelect.Enabled = dgvSearch.RowCount != 0 ? true : false;
        }
        #endregion

        #region Click Event
        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            code = dgvSearch.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.meterId = dgvSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.meterNo = code;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvSearch.CurrentRow.Index != -1 && code == null)
            {
                code = dgvSearch.CurrentRow.Cells[1].Value.ToString();
                this.meterId = dgvSearch.CurrentRow.Cells[0].Value.ToString();
            }
            this.meterNo = code;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region Changed Event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboFindColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnFind.Enabled == false)
            {
                Search();
            }
        }

        private void chkAutoSearch_CheckedChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = chkAutoSearch.Checked == true ? false : true;
        }
        #endregion
    }
}
