using MBMS.DAL;
using MPS.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.PC2HHUDB
{
    public partial class MeterList2HHUDB : Form
    {
        #region Variables
        List<Meter> meterList = new List<Meter>();
        #endregion

        public MeterList2HHUDB()
        {
            InitializeComponent();
            getDbFileList();
        }

        #region Method
        private void getDbFileList()
        {
            this.cbofileName.Items.Add("Select One");
            this.cbofileName.SelectedIndex = 0;
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings["dbFileListPath"]);
                FileInfo[] Files = dirInfo.GetFiles("*.db"); //Getting db files
                foreach (FileInfo file in Files)
                {
                    this.cbofileName.Items.Add(file.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void BuildSQLiteConnection()
        {
            string sqlitedbPath = System.Configuration.ConfigurationManager.AppSettings["DatabaseFile"] + cbofileName.SelectedItem;
            if (String.IsNullOrEmpty(Storage.ConnectionString))
            {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", sqlitedbPath));
            }
        }

        private void getMeterList()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            this.dgvMeterList.AutoGenerateColumns = false;
            meterList = (from m in mbmsEntities.Meters where m.Active == true && m.Status==true select m).ToList();
            dgvMeterList.DataSource = (from m in mbmsEntities.Meters where m.Active == true && m.Status==true select m).ToList(); ;
        }

        public void LoadData()
        {
            MBMSEntities mbsEntites = new MBMSEntities();
            var meter = mbsEntites.Meters.Where(u => u.Active == true && u.Status==true).ToList();
            if (rdoMeterNo.Checked == true)
            {
                if (!string.IsNullOrWhiteSpace(txtmeternoSearch.Text) && cbometerBox.SelectedIndex == 0)
                {
                    dgvMeterList.DataSource = meter.Where(u => u.MeterNo.IndexOf(txtmeternoSearch.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                    meterList = meter.Where(u => u.MeterNo.IndexOf(txtmeternoSearch.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                }


                else if (!string.IsNullOrWhiteSpace(txtmeternoSearch.Text) && cbometerBox.SelectedIndex > 0)
                {
                    dgvMeterList.DataSource = meter.Where(u => u.MeterNo.IndexOf(txtmeternoSearch.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                    u.MeterBox.MeterBoxCode.IndexOf(cbometerBox.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active==true).ToList();

                    meterList = meter.Where(u => u.MeterNo.IndexOf(txtmeternoSearch.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                     u.MeterBox.MeterBoxCode.IndexOf(cbometerBox.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                }

                else if (string.IsNullOrWhiteSpace(txtmeternoSearch.Text) && cbometerBox.SelectedIndex > 0)
                {

                    dgvMeterList.DataSource = meter.Where(u => u.MeterBox.MeterBoxCode.IndexOf(cbometerBox.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                    meterList= meter.Where(u => u.MeterBox.MeterBoxCode.IndexOf(cbometerBox.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                }
                else if (string.IsNullOrWhiteSpace(txtmeternoSearch.Text) && cbometerBox.SelectedIndex == 0)
                {

                    dgvMeterList.DataSource = meter.Where(u =>  u.Active == true).ToList();
                    meterList = meter.Where(u =>u.Active == true).ToList();
                }
            }

            else
            {
                if (!string.IsNullOrWhiteSpace(txtmeternoSearch.Text) && cbometerBox.SelectedIndex == 0)
                {

                    dgvMeterList.DataSource = meter.Where(u => u.Model.IndexOf(txtmeternoSearch.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                    meterList= meter.Where(u => u.Model.IndexOf(txtmeternoSearch.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                }

                else if (!string.IsNullOrWhiteSpace(txtmeternoSearch.Text) && cbometerBox.SelectedIndex > 0)
                {
                    dgvMeterList.DataSource = meter.Where(u => u.Model.IndexOf(txtmeternoSearch.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                    u.MeterBox.MeterBoxCode.IndexOf(cbometerBox.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                    meterList= meter.Where(u => u.Model.IndexOf(txtmeternoSearch.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                     u.MeterBox.MeterBoxCode.IndexOf(cbometerBox.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                }

                else if (string.IsNullOrWhiteSpace(txtmeternoSearch.Text) && cbometerBox.SelectedIndex > 0)
                {
                    dgvMeterList.DataSource = meter.Where(u => u.MeterBox.MeterBoxCode.IndexOf(cbometerBox.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                    meterList= meter.Where(u => u.MeterBox.MeterBoxCode.IndexOf(cbometerBox.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                }
                else if (string.IsNullOrWhiteSpace(txtmeternoSearch.Text) && cbometerBox.SelectedIndex == 0)
                {

                    dgvMeterList.DataSource = meter.Where(u => u.Active == true && u.Status==true).ToList();
                    meterList = meter.Where(u => u.Active == true && u.Status==true).ToList();
                }

            }

        }

        #endregion

        #region Form Load
        private void MeterList2HHUDB_Load(object sender, EventArgs e)
        {
            getMeterList();
            bindMeterBoxList();
        }
        #endregion

        #region Bind Combo
        public void bindMeterBoxList()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();

            List<MeterBox> meterboxList = new List<MeterBox>();
            MeterBox mb = new MeterBox();
            mb.MeterBoxID = Convert.ToString(0);
            mb.MeterBoxCode = "Select";
            meterboxList.Add(mb);
            meterboxList.AddRange(mbmsEntities.MeterBoxes.Where(x => x.Active == true).OrderBy(x => x.MeterBoxCode).ToList());
            cbometerBox.DataSource = meterboxList;
            cbometerBox.DisplayMember = "MeterBoxCode";
            cbometerBox.ValueMember = "MeterBoxID";
        }
        #endregion

        #region Button Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getMeterList();
            bindMeterBoxList();
            cbofileName.SelectedIndex = 0;
            rdoMeterNo.Checked = true;
        }

        private void btnSave2HHUDB_Click(object sender, EventArgs e)
        {

            if (meterList.Count == 0)
            {
                MessageBox.Show("There is no Meter data to save HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbofileName.SelectedItem.Equals("Select One"))
            {
                MessageBox.Show("Select HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.Yes)
            {
                MBMSEntities mbmsEntities = new MBMSEntities();

                BuildSQLiteConnection();
                MetersServices sqlitemetersservices = new MetersServices();
                List<MPS.SQLiteHelper.Meters> sqlpoleList = new List<MPS.SQLiteHelper.Meters>();
                string sqlCommand = string.Format("SELECT * FROM Meters");
                var data = sqlitemetersservices.GetAll(sqlCommand);
                foreach (var v in data)
                {
                    foreach (Meter m in meterList)
                    {
                        if (m.MeterNo == v.mtr_id)
                        {

                            meterList.Remove(m);
                            break;
                        }
                    }
                }

                if (meterList.Count != 0)
                {
                    foreach (Meter m in meterList)
                    {
                        MPS.SQLiteHelper.Meters meter = new MPS.SQLiteHelper.Meters();
                        meter.mtr_id = m.MeterNo;
                        meter.mtr_inst = m.InstalledDate.ToString();
                        meter.mtr_make = m.ManufactureBy;
                        meter.mtr_model = m.Model.ToString();
                        meter.mtr_create = m.CreatedDate.ToString();
                        Customer c = mbmsEntities.Customers.Where(x => x.MeterID == m.MeterID).SingleOrDefault();
                        if (c == null)
                        {
                            MessageBox.Show("set customer data for>" + m.MeterNo, "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        meter.mtr_csm_id = mbmsEntities.Customers.Where(x => x.MeterID == m.MeterID).FirstOrDefault().CustomerCode;
                        Pole p = mbmsEntities.Poles.Where(x => x.Transformer.QuarterID == c.QuarterID).FirstOrDefault();
                        if (p == null)
                        {
                            MessageBox.Show("set Pole data for>" + m.MeterNo, "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        meter.mtr_pole = p.PoleNo;
                        sqlpoleList.Add(meter);
                    }
                    try
                    {
                        sqlitemetersservices.AddRange(sqlpoleList);
                        LoadData();
                        MessageBox.Show("Meters data to HHU db file is successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occur when saving Meters to HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Meter is already exist in HHUDB","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadData();
                }
                
            }
        }

        #endregion

        #region Key Down

        private void txtmeternoSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void txtmetermodelsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }
        #endregion

        #region Check Changed
        private void rdoMeterNo_CheckedChanged(object sender, EventArgs e)
        {
            lblMeter.Text = "Meter No";
        }

        private void rdoMeterModel_CheckedChanged(object sender, EventArgs e)
        {
            lblMeter.Text = "Meter Model";
        }
        #endregion
    }
}
