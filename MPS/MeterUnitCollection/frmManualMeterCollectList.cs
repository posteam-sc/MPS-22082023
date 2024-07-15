using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.MeterUnitCollection
{
    public partial class frmManualMeterCollectList : Form
    {
        string code;
        public string fromsearch { get; set; }
        public string searchcode { get; set; }
        public string customerId { get; set; }
        public frmManualMeterCollectList()
        {
            InitializeComponent();
        }

     
        private void frmManualMeterCollectList_Load(object sender, EventArgs e)
        {
            dgvManualCollectList.AutoGenerateColumns = false;
            BindFindBy();
            BindFindType();
            if (fromsearch != null)
            {
                chkAutoSearch.Checked = true;
                txtFilterBy.Text = fromsearch;
                txtFilterBy.Focus();
            }
            Search();
        }

        #region Method
        private void BindFindBy()
        {
            List<string> FindBy = new List<string>
            {
                "Customer Name",
                "Transformer Name",
                "Pole No",
                "Meter No",
                "Bill Code"
            };
            cboFindColumn.DataSource = null;
            cboFindColumn.Items.AddRange(FindBy.ToArray());
            cboFindColumn.SelectedIndex = 0;
        }
        private void BindFindType()
        {
            List<string> FindType = new List<string>
            {
                "Contains",
                "Starts with"
            };
            cboFindType.DataSource = null;
            cboFindType.Items.AddRange(FindType.ToArray());
            cboFindType.SelectedIndex = 0;
        }
        private void Search()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            var psn = mbmsEntities.ManualMeterUnitCollects.Where(x=>x.Active==true).OrderBy(p => p.ManualMeterUnitCollectID).ToList();
            if (!String.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                dgvManualCollectList.DataSource = null;
                if (cboFindType.Text == "Contains")
                {
                    switch (cboFindColumn.Text)
                    {
                        case "Customer Name":
                            dgvManualCollectList.DataSource = psn.Where(p => p.Customer.CustomerNameInEng.IndexOf(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) != -1 && p.Active == true).ToList();
                            break;
                        case "Transformer Name":
                            dgvManualCollectList.DataSource = psn.Where(p => p.Transformer.TransformerName.IndexOf(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) != -1 && p.Active == true).ToList();
                            break;
                        case "Pole No":
                            dgvManualCollectList.DataSource = psn.Where(p => p.Pole.PoleNo.IndexOf(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) != -1 && p.Active == true).ToList();
                            break;
                        case "Meter No":
                            dgvManualCollectList.DataSource = psn.Where(p => p.Meter.MeterNo.IndexOf(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) != -1 && p.Active == true).ToList();
                            break;
                        case "Bill Code":
                            dgvManualCollectList.DataSource = psn.Where(p => p.BillCode.ToString().IndexOf(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) != -1 && p.Active == true).ToList();
                            break;
                        default:
                            dgvManualCollectList.DataSource = psn.ToList();
                            break;
                    }
                }
                else
                {
                    switch (cboFindColumn.Text)
                    {
                        case "Customer Name":
                            dgvManualCollectList.DataSource = psn.Where(p => p.Customer.CustomerNameInEng.StartsWith(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) && p.Active == true).ToList();
                            break;
                        case "Transformer Name":
                            dgvManualCollectList.DataSource = psn.Where(p => p.Transformer.TransformerName.StartsWith(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) && p.Active == true).ToList();
                            break;
                        case "Pole No":
                            dgvManualCollectList.DataSource = psn.Where(p => p.Pole.PoleNo.StartsWith(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) && p.Active == true).ToList();
                            break;
                        case "Meter No":
                            dgvManualCollectList.DataSource = psn.Where(p => p.Meter.MeterNo.StartsWith(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) && p.Active == true).ToList();
                            break;
                        case "Bill Code":
                            dgvManualCollectList.DataSource = psn.Where(p => p.BillCode.ToString().StartsWith(txtFilterBy.Text, StringComparison.OrdinalIgnoreCase) && p.Active == true).ToList();
                            break;
                        default:
                            dgvManualCollectList.DataSource = psn.ToList();
                            break;
                    }
                }
            }
            else
            {
                dgvManualCollectList.DataSource = psn.ToList();
            }
            dgvManualCollectList.Refresh();
        }
        #endregion
        
        #region Data Binding to Grid View 
        private void dgvManualCollectList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvManualCollectList.Rows)
            {
                ManualMeterUnitCollect manualMeterUnitCollect = (ManualMeterUnitCollect)row.DataBoundItem;
                row.Cells[0].Value = manualMeterUnitCollect.ManualMeterUnitCollectID.Trim();
                row.Cells[1].Value = manualMeterUnitCollect.CustomerID.Trim();
                row.Cells[2].Value = manualMeterUnitCollect.Customer.CustomerNameInEng.Trim();
                row.Cells[3].Value = manualMeterUnitCollect.Transformer.TransformerName;
                row.Cells[4].Value = manualMeterUnitCollect.FromDate.Date;
                row.Cells[5].Value = manualMeterUnitCollect.Pole.PoleNo.Trim();
                row.Cells[6].Value = manualMeterUnitCollect.TotalMeterUnit;
                row.Cells[7].Value = manualMeterUnitCollect.Meter.MeterNo.Trim();
                row.Cells[8].Value = manualMeterUnitCollect.BillCode;
            }
            code = null;
            btnSelect.Enabled = dgvManualCollectList.RowCount != 0 ? true : false;
        }
        #endregion

        #region Key Up
        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnFind.Enabled == false)
            {
                Search();
            }
        }
        #endregion

        #region Datagrid View Cell Click

       private void dgvManualCollectList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            code = dgvManualCollectList.Rows[e.RowIndex].Cells[2].Value.ToString();
            customerId = dgvManualCollectList.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.searchcode = code;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region Button Click 
        private void btnFind_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvManualCollectList.CurrentRow.Index != -1 && code == null)
            {
                code = dgvManualCollectList.CurrentRow.Cells[2].Value.ToString();
                customerId = dgvManualCollectList.CurrentRow.Cells[1].Value.ToString();
            }
            this.searchcode = code;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Selected Index Change

        private void cboFindColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnFind.Enabled == false)
            {
                Search();
            }
        }

        private void cboFindType_SelectedIndexChanged(object sender, EventArgs e)
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
