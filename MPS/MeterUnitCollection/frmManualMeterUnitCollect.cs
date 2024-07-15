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

    public partial class frmManualMeterUnitCollect : Form
    {
        #region Variables
        public string userID { get; set; }
        string customerId = null;
        #endregion

        public frmManualMeterUnitCollect()
        {
            InitializeComponent();
        }

        private void frmManualMeterUnitCollect_Load(object sender, EventArgs e)
        {
            Clear();
            CustomerCount();
            dtMeterCollectDate.Format = DateTimePickerFormat.Custom;
            dtMeterCollectDate.CustomFormat = "MM/dd/yyyy";
        }

        #region Button Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmManualMeterCollectList formManualMeterUnitCollectList = new frmManualMeterCollectList();

            if (!String.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                formManualMeterUnitCollectList.fromsearch = txtCustomerName.Text;
            }
            var result = formManualMeterUnitCollectList.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtCustomerName.Text = formManualMeterUnitCollectList.searchcode;
                customerId = formManualMeterUnitCollectList.customerId;
                BindData();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckRequireField())
            {
                Save();
                CustomerCount();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            txtMeterUnit.Focus();
            CustomerCount();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            int next = 0;
            if (customerId == null)
            {
                customerId = GetAll().Select(x => x.CustomerID).Last();
                next = GetAll().FindIndex(x => x.CustomerID == customerId && x.Active == true);
            }
            else
            {
                next = GetAll().FindIndex(x => x.CustomerID == customerId && x.Active == true) + 1;
            }

            if (next < GetAll().Count)
            {
                txtCustomerName.Text = GetAll()[next].Customer.CustomerNameInEng;
                customerId = GetAll()[next].CustomerID;
                BindData();
                if (next + 1 == GetAll().Count)
                {
                    btnNext.Enabled = false;

                }
                btnPrevoius.Enabled = true;
            }
        }

        private void btnPrevoius_Click(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            int previous = 0;
            if (customerId == null)
            {
                customerId = GetAll().Select(x => x.CustomerID).First();
                previous = GetAll().FindIndex(x => x.Customer.CustomerID == customerId && x.Active == true);
            }
            else
            {
                previous = GetAll().FindIndex(x => x.Customer.CustomerID == customerId && x.Active == true) - 1;
            }

            if (previous > -1)
            {
                txtCustomerName.Text = GetAll()[previous].Customer.CustomerNameInEng;
                customerId = GetAll()[previous].CustomerID;
                BindData();
                if (previous == 0)
                {
                    btnPrevoius.Enabled = false;
                }
                btnNext.Enabled = true;
            }
        }
        #endregion

        #region Method 
        private void BindData()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            var manual = mbsEntities.ManualMeterUnitCollects.Where(v => v.CustomerID == customerId && v.Customer.CustomerNameInEng.Trim() == txtCustomerName.Text.Trim() && v.Active == true).FirstOrDefault();
            if (manual != null)
            {
                txtCustomerName.Text = manual.Customer.CustomerNameInEng;
                txtBillCodeNo.Text = manual.BillCode;
                txtMeterNo.Text = manual.Meter.MeterNo;
                txtMeterUnit.Text = manual.TotalMeterUnit.ToString();
                txtPoleName.Text = manual.Pole.PoleNo;
                txtTransformerName.Text = manual.Transformer.TransformerName;
                dtMeterCollectDate.Value = manual.ToDate.Date;
                txtMeterUnit.Enabled = true;
                txtTransformerName.Enabled = false;
                txtPoleName.Enabled = false;
                txtMeterNo.Enabled = false;
                txtCustomerName.Enabled = false;
                txtTransformerName.Enabled = false;
                txtBillCodeNo.Enabled = false;
                dtMeterCollectDate.Enabled = false;
                btnSave.Enabled = true;
            }
        }
        private void CustomerCount()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            var count = mbsEntities.ManualMeterUnitCollects.Where(v => v.Active == true).Count();
            if (count != 0)
            {
                lblCount.Text = count.ToString();
            }
            else
            {
                lblCount.Text = "0";
                btnNext.Enabled = false;
                btnPrevoius.Enabled = false;
            }

        }

        private void Clear()
        {
            txtTransformerName.Clear();
            txtBillCodeNo.Clear();
            txtMeterNo.Clear();
            txtMeterUnit.Clear();
            txtPoleName.Clear();
            dtMeterCollectDate.Value = DateTime.Now;
            txtCustomerName.Clear();
            dtMeterCollectDate.Enabled = false;
            txtTransformerName.Enabled = false;
            txtBillCodeNo.Enabled = false;
            txtMeterNo.Enabled = false;
            txtPoleName.Enabled = false;
            txtMeterUnit.Enabled = false;
            btnSave.Enabled = false;
        }

        private List<ManualMeterUnitCollect> GetAll()
        {
            MBMSEntities dbContent = new MBMSEntities();
            return dbContent.ManualMeterUnitCollects.Where(x => x.Active == true).ToList();
        }

        private bool CheckRequireField()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            DateTime fromPrevoiusMonth = mbsEntities.ManualMeterUnitCollects.Where(v => v.CustomerID == customerId && v.Customer.CustomerNameInEng == txtCustomerName.Text && v.Active == true).Select(v => v.FromDate).FirstOrDefault();
            decimal checkUnit = mbsEntities.MeterUnitCollects.Where(v => v.CustomerID == customerId && v.Customer.CustomerNameInEng == txtCustomerName.Text && v.Active == true).OrderBy(v => v.ToDate).Select(v => v.TotalMeterUnit).FirstOrDefault();
            if (Convert.ToDecimal(txtMeterUnit.Text) - checkUnit < 0)
            {
                MessageBox.Show("Meter Unit should be greater than previous Month meter Unit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMeterUnit.Focus();
                return false;
            }
            return true;
        }

        private void Save()
        {
            try
            {
                MBMSEntities mbsEntities = new MBMSEntities();
                MBMS.DAL.MeterUnitCollect meterUnitCollect = new MBMS.DAL.MeterUnitCollect();
                var manual = mbsEntities.ManualMeterUnitCollects.Where(v => v.CustomerID == customerId && v.Active == true).FirstOrDefault();
                meterUnitCollect.MeterUnitCollectID = Guid.NewGuid().ToString();
                meterUnitCollect.CustomerID = manual.CustomerID;
                meterUnitCollect.FromDate = manual.FromDate;
                meterUnitCollect.ToDate = manual.ToDate;
                meterUnitCollect.TotalMeterUnit = Convert.ToDecimal(txtMeterUnit.Text);
                meterUnitCollect.BillMonth = manual.BillMonth;
                meterUnitCollect.TransformerID = manual.TransformerID;
                meterUnitCollect.PoleID = manual.PoleID;
                meterUnitCollect.MeterID = manual.MeterID;
                meterUnitCollect.UsedUnitKwh = manual.UsedUnitKwh;
                meterUnitCollect.GPSX = manual.GPSX;
                meterUnitCollect.GPSY = manual.GPSY;
                meterUnitCollect.MeterStatus = manual.MeterStatus;
                meterUnitCollect.OMRModelNo = manual.OMRModelNo;
                meterUnitCollect.DigitalModelNo = manual.DigitalModelNo;
                meterUnitCollect.BillCode = manual.BillCode;
                meterUnitCollect.CreatedUserID = userID;
                meterUnitCollect.CreatedDate = DateTime.Now;
                meterUnitCollect.Active = true;
                mbsEntities.MeterUnitCollects.Add(meterUnitCollect);

                manual.Active = false;

                mbsEntities.SaveChanges();
                Clear();
                MessageBox.Show("Save Sucessfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Preview Key Down
        private void txtCustomerName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //BindData();
            }
        }
        #endregion
    }
}
