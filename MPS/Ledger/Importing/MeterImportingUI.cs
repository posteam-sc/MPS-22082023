using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using MPS.BusinessLogic.MeterController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Importing
{
    public partial class MeterImportingUI : Form
    {
        IMeter meterservices;
        List<Meter> meterList = new List<Meter>();
        DataTable dt = new DataTable();
        public string UserID { get; set; }
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        private bool check;

        public MeterImportingUI()
        {
            InitializeComponent();
            meterservices = new MeterController();
        }

        #region Form Load
        private void MeterImportingUI_Load(object sender, EventArgs e)
        {
            check = false;
            CheckSaveButton();
        }
        #endregion

        #region Method
        private void CheckSaveButton()
        {
            btnSave.Enabled = (check == true ? true : false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            for (int i = 1; i <= 100; i++)
            {
                // Wait 50 milliseconds.  
                Thread.Sleep(50);
                progressBar1.Value = i;
            }
            if (Convert.ToInt32(progressBar1.Value) == 100)
            {
                timer1.Enabled = false;
            }
        }
        #endregion

        #region Select
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ofdSelect.ShowDialog();
        }

        private void ofdSelect_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = ofdSelect.FileName;
            string extension = Path.GetExtension(filePath);
            string conString = "";
            string sheetName = "";
            switch (extension)
            {
                case ".xls":
                    conString = string.Format(Excel03ConString, filePath, "YES");
                    break;
                case ".xlsx":
                    conString = string.Format(Excel07ConString, filePath, "YES");
                    break;
                default:
                    MessageBox.Show("Invalid file", "Informtion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dt.Rows[0]["Table_Name"].ToString();
                    con.Close();
                }
            }
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    OleDbDataAdapter oda = new OleDbDataAdapter();
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    oda.SelectCommand = cmd;
                    oda.Fill(dt);
                    con.Close();
                    gvMeter.DataSource = dt;
                }
            }
        }
        #endregion

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gvMeter.Rows.Count > 0)
            {
                DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ok == DialogResult.Yes)
                {
                    for (int i = 0; i < gvMeter.Rows.Count - 1; i++)
                    {
                        Meter meter = new Meter();
                        progressBar1.Visible = true;
                        timer1.Enabled = true;
                        meter.MeterNo = gvMeter.Rows[i].Cells["MeterNo"].Value.ToString();
                        meter.MeterID = Guid.NewGuid().ToString();
                        meter.Model = gvMeter.Rows[i].Cells["Model"].Value.ToString();
                        meter.InstalledDate = Convert.ToDateTime(gvMeter.Rows[i].Cells["InstalledDate"].Value.ToString());
                        meter.Phrase = gvMeter.Rows[i].Cells["Phrase"].Value.ToString();
                        meter.Wire = gvMeter.Rows[i].Cells["Wire"].Value.ToString();
                        meter.BasicCurrent = gvMeter.Rows[i].Cells["BasicCurrent"].Value.ToString();
                        meter.iMax = Convert.ToInt32(gvMeter.Rows[i].Cells["iMax"].Value);
                        meter.Voltage = Convert.ToInt32(gvMeter.Rows[i].Cells["Voltage"].Value);
                        meter.ManufactureBy = gvMeter.Rows[i].Cells["ManufactureBy"].Value.ToString();
                        if (gvMeter.Rows[i].Cells["Status"].Value.ToString() == "Enable" || gvMeter.Rows[i].Cells["Status"].Value.ToString() == "enable")
                            meter.Status = true;
                        else
                            meter.Status = false;
                        //meter.Status =Convert.ToBoolean(gvMeter.Rows[i].Cells["Status"].Value);
                        meter.AvailableYear = Convert.ToInt32(gvMeter.Rows[i].Cells["AvailableYear"].Value);
                        MeterBox meterbox = meterservices.getMeterBoxByMeterBoxNo(gvMeter.Rows[i].Cells["MeterBoxCode"].Value.ToString());
                        bool checkmeterboxsequence = meterservices.getMeterByMeterboxIdBoxSequence(meterbox.MeterBoxID, Convert.ToString(gvMeter.Rows[i].Cells["MeterBoxSequence"].Value));
                        meter.MeterBoxID = meterbox.MeterBoxID;
                        meter.MeterBoxSequence = Convert.ToString(gvMeter.Rows[i].Cells["MeterBoxSequence"].Value);
                        MeterType metertype = meterservices.getMeterTypeByMeterTypeCode(gvMeter.Rows[i].Cells["MeterTypeCode"].Value.ToString());
                        meter.MeterTypeID = metertype.MeterTypeID;
                        meter.Active = true;
                        meter.CreatedDate = DateTime.Now;
                        meter.CreatedUserID = UserID;
                        meterList.Add(meter);
                    }
                    if (meterList.Count > 0)
                    {
                        try
                        {
                            meterservices.SaveRange(meterList);
                            MessageBox.Show("Importing Meter data is successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gvMeter.DataSource = null;
                            gvMeter.Rows.Clear();
                            gvMeter.Refresh();
                            check = false;
                            CheckSaveButton();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error occur :(", "information");
                        }
                    }
                }//end of Yes Dialog
            }//end of gvMeter.rows.Count>0
        }
        #endregion

        #region Check
        private void btnCheck_Click(object sender, EventArgs e)
        {
            check = true;
            for (int i = 0; i < gvMeter.Rows.Count - 1; i++)
            {
                bool checkcolor = false;
                bool meterNo = false;
                bool meterboxCode = false;
                bool meterboxSquare = false;
                bool metertypeCode = false;

                bool isdataexit = meterservices.getMeterByMeterNo(gvMeter.Rows[i].Cells["MeterNo"].Value.ToString());
                if (isdataexit)
                {
                    //MessageBox.Show("Meter data already exists in the system for>" + gvMeter.Rows[i].Cells["MeterNo"].ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                    gvMeter.Rows[i].Cells["MeterNo"].Style.BackColor = Color.Red;
                    check = false;
                    checkcolor = true;
                }
                else
                {
                    meterNo = true;
                }

                string d = gvMeter.Rows[i].Cells["MeterBoxCode"].Value.ToString();
                MeterBox meterbox = meterservices.getMeterBoxByMeterBoxNo(gvMeter.Rows[i].Cells["MeterBoxCode"].Value.ToString());
                if (meterbox == null)
                {
                    //MessageBox.Show("Please define Meter Box Code for>" + meter.MeterNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                    gvMeter.Rows[i].Cells["MeterBoxCode"].Style.BackColor = Color.Red;
                    check = false;
                    checkcolor = true;
                }
                else
                {
                    meterboxCode = true;
                }

                bool checkmeterboxsequence;
                if (meterbox != null)
                {
                    checkmeterboxsequence = meterservices.getMeterByMeterboxIdBoxSequence(meterbox.MeterBoxID, Convert.ToString(gvMeter.Rows[i].Cells["MeterBoxSequence"].Value));
                }
                else
                {
                    checkmeterboxsequence = false;
                }
                if (checkmeterboxsequence)
                {
                    //MessageBox.Show("Meter Box Sequence is already used!!>" + meter.MeterNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                    gvMeter.Rows[i].Cells["MeterBoxSequence"].Style.BackColor = Color.Red;
                    check = false;
                    checkcolor = true;
                }
                else
                {
                    meterboxSquare = true;
                }

                MeterType metertype = meterservices.getMeterTypeByMeterTypeCode(gvMeter.Rows[i].Cells["MeterTypeCode"].Value.ToString());
                if (metertype == null)
                {
                    //MessageBox.Show("Please define Meter Type Code for>" + meter.MeterNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                    gvMeter.Rows[i].Cells["MeterTypeCode"].Style.BackColor = Color.Red;
                    check = false;
                    checkcolor = true;
                }
                else
                {
                    metertypeCode = true; 
                }

                gvMeter.Rows[i].DefaultCellStyle.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                if (meterNo == true)
                {
                    gvMeter.Rows[i].Cells["MeterNo"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                }
                if (meterboxCode == true)
                {
                    gvMeter.Rows[i].Cells["MeterBoxCode"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                }
                if (meterboxSquare == true)
                {
                    gvMeter.Rows[i].Cells["MeterBoxSequence"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                }
                if (metertypeCode == true)
                {
                    gvMeter.Rows[i].Cells["MeterTypeCode"].Style.BackColor = (checkcolor == false ? Color.White : Color.Yellow);
                }
            }
            CheckSaveButton();
        }
        #endregion
    }
}
