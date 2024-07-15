using MBMS.DAL;
using MPS.BusinessLogic.MeterUnitCollectionController;
using MPS.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MPS.MeterUnitCollect
{
    public partial class MeterUnitCollectionsfrm : Form
    {
        #region Variables
        StringBuilder ErrorList = new StringBuilder();

        public string UserID { get; set; }
        List<NodeMeter> nodeMeterList = null;
        #endregion
        public MeterUnitCollectionsfrm()
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
            Storage.ConnectionString = null;
            if (String.IsNullOrEmpty(Storage.ConnectionString))
            {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", sqlitedbPath));
            }
        }
        private bool SaveMeterUnitCollection(List<NodeMeter> data)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            IMeterUnitCollections iMeterUnitColleciton = new MeterUnitCollectionController();
            IManualMeterUnitCollect iManualMeterUnitCollect = new ManualMeterUnitCollectController();

            ErrorList.Clear();
            DateTime fromDate = dtpfromDate.Value.Date;
            DateTime toDate = dtptoDate.Value.Date;
            string transformerId = string.Empty;
            if (!cboTransformer.SelectedValue.Equals("0"))
            {
                transformerId = cboTransformer.SelectedValue.ToString();
            }
            bool checkData = false;
            if (!string.IsNullOrEmpty(transformerId))
            {
                checkData = mbmsEntities.MeterBills.Any(x => EntityFunctions.TruncateTime(x.InvoiceDate) >= fromDate && EntityFunctions.TruncateTime(x.InvoiceDate) <= toDate
                && x.MeterUnitCollect.TransformerID == transformerId);
            }
            else
            {
                checkData = mbmsEntities.MeterBills.Any(x => EntityFunctions.TruncateTime(x.InvoiceDate) >= fromDate && EntityFunctions.TruncateTime(x.InvoiceDate) <= toDate);
            }

            var previousManualUnit = mbmsEntities.ManualMeterUnitCollects.Where(m => m.FromDate < dtpfromDate.Value && m.TransformerID == transformerId && m.Active==true).ToList();
            if (previousManualUnit.Count != 0)
            {
                MessageBox.Show("Please Add Previous Manual Meter Unit in Manual Meter Unit Form.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (checkData)
            {
                MessageBox.Show("Bill Units can't re-collect because data is already calculated and printed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {

                List<MBMS.DAL.MeterUnitCollect> meterUnitCollectList = new List<MBMS.DAL.MeterUnitCollect>();
                List<MBMS.DAL.ManualMeterUnitCollect> manualMeterUnitCollectList = new List<MBMS.DAL.ManualMeterUnitCollect>();
                foreach (NodeMeter item in data)
                {
                    string y = item.nod_bill_from;
                    string m = item.nod_bill_from;
                    string d = item.nod_bill_from;
                    var checkIsMeter = mbmsEntities.Meters.Where(x => x.MeterNo == item.nod_id && x.Active == true).FirstOrDefault();
                    if (checkIsMeter == null)
                    {
                        ErrorList.Append("Set Meter No for : " + item.nod_id);
                        MessageBox.Show(ErrorList.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    
                    var checkMeterAviable = mbmsEntities.Meters.Where(x => x.MeterNo == item.nod_id && x.Status == true && x.Active == true).FirstOrDefault();
                    if (checkMeterAviable == null)
                    {
                        ErrorList.Append("This meter No : " + item.nod_id + " is Disable!");
                        MessageBox.Show(ErrorList.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    Customer customerinfo = mbmsEntities.Customers.Where(x => x.CustomerCode == item.nod_csm_id && x.Active == true).FirstOrDefault();//eg >>450-050-545-450-TPYTR05-00000428
                    if (customerinfo == null)
                    {
                        ErrorList.Append("Set customer record for : " + item.nod_csm_name);
                        MessageBox.Show(ErrorList.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    Transformer transformer = mbmsEntities.Transformers.Where(x => x.QuarterID == customerinfo.QuarterID && x.Active == true).SingleOrDefault();
                    if (transformer == null)
                    {
                        ErrorList.Append("Set transformer record for : " + customerinfo.Quarter.QuarterNameInEng);
                        MessageBox.Show(ErrorList.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    var poleID = customerinfo.Meter.MeterBox.Pole.PoleID;
                    Pole p = mbmsEntities.Poles.Where(x => x.PoleID == poleID && x.Active == true).SingleOrDefault();
                    if (p == null)
                    {
                        ErrorList.Append("Set Pole record for : " + customerinfo.Quarter.QuarterNameInEng);
                        MessageBox.Show(ErrorList.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (item.nod_pres_eng != 0)
                    {
                        DateTime date = Convert.ToDateTime(y.Substring(0, 4) + "-" + m.Substring(4, 2) + "-" + d.Substring(6, 2)).AddMonths(-1);
                        decimal previousMeterUnit = mbmsEntities.MeterUnitCollects
                            .Where(x => x.FromDate.Month == date.Month
                            && x.Meter.MeterNo == item.nod_id).Select(x => x.TotalMeterUnit).FirstOrDefault();

                        //No previous Meterunit
                        if (previousMeterUnit !=0)
                        {
                            if ((item.nod_pres_eng - Convert.ToDouble(previousMeterUnit)) != 0)
                            {
                                #region Meter Unit Collect
                                MBMS.DAL.MeterUnitCollect meterUnit = new MBMS.DAL.MeterUnitCollect();
                                meterUnit.MeterUnitCollectID = Guid.NewGuid().ToString();
                                meterUnit.CustomerID = customerinfo.CustomerID;
                                meterUnit.FromDate = item.nod_bill_from == "" ? dtpfromDate.Value : Convert.ToDateTime(y.Substring(0, 4) + "-" + m.Substring(4, 2) + "-" + d.Substring(6, 2));
                                meterUnit.ToDate = item.nod_bill_to == "" ? dtptoDate.Value : Convert.ToDateTime(item.nod_bill_to);
                                meterUnit.TotalMeterUnit = (decimal)item.nod_pres_eng;
                                meterUnit.BillMonth = (int)item.nod_bill_month;
                                meterUnit.TransformerID = transformer.TransformerID;
                                meterUnit.PoleID = p.PoleID;
                                meterUnit.MeterID = customerinfo.MeterID;
                                meterUnit.GPSX = Convert.ToDecimal(!String.IsNullOrWhiteSpace(item.nod_gps_h) ? item.nod_gps_h : null);
                                meterUnit.GPSY = Convert.ToDecimal(!String.IsNullOrWhiteSpace(item.nod_gps_l) ? item.nod_gps_l : null);
                                meterUnit.MeterStatus = item.nod_status;
                                meterUnit.OMRModelNo = item.nod_model;
                                meterUnit.DigitalModelNo = item.nod_model;
                                meterUnit.BillCode = customerinfo.BillCode7Layer.BillCode7LayerNo.ToString();
                                meterUnit.Active = true;
                                meterUnit.CreatedDate = DateTime.Now;
                                meterUnit.CreatedUserID = UserID;
                                meterUnitCollectList.Add(meterUnit);
                                #endregion
                            }
                            else
                            {
                                #region MMUC
                                MBMS.DAL.ManualMeterUnitCollect manualMeterUnit = new MBMS.DAL.ManualMeterUnitCollect();
                                manualMeterUnit.ManualMeterUnitCollectID = Guid.NewGuid().ToString();
                                manualMeterUnit.CustomerID = customerinfo.CustomerID;
                                manualMeterUnit.FromDate = item.nod_bill_from == "" ? dtpfromDate.Value : Convert.ToDateTime(y.Substring(0, 4) + "-" + m.Substring(4, 2) + "-" + d.Substring(6, 2));
                                manualMeterUnit.ToDate = item.nod_bill_to == "" ? dtptoDate.Value : Convert.ToDateTime(item.nod_bill_to);
                                manualMeterUnit.TotalMeterUnit = (decimal)item.nod_pres_eng;
                                manualMeterUnit.BillMonth = (int)item.nod_bill_month;
                                manualMeterUnit.TransformerID = transformer.TransformerID;
                                manualMeterUnit.PoleID = p.PoleID;
                                manualMeterUnit.MeterID = customerinfo.MeterID;
                                manualMeterUnit.GPSX = Convert.ToDecimal(!String.IsNullOrWhiteSpace(item.nod_gps_h) ? item.nod_gps_h : null);
                                manualMeterUnit.GPSY = Convert.ToDecimal(!String.IsNullOrWhiteSpace(item.nod_gps_l) ? item.nod_gps_l : null);
                                manualMeterUnit.MeterStatus = item.nod_status;
                                manualMeterUnit.OMRModelNo = item.nod_model;
                                manualMeterUnit.DigitalModelNo = item.nod_model;
                                manualMeterUnit.BillCode = customerinfo.BillCode7Layer.BillCode7LayerNo.ToString();
                                manualMeterUnit.Active = true;
                                manualMeterUnit.CreatedDate = DateTime.Now;
                                manualMeterUnit.CreatedUserID = UserID;
                                manualMeterUnitCollectList.Add(manualMeterUnit);
                                #endregion
                            }
                        }
                        else
                        {
                            #region Meter Unit Collect
                            MBMS.DAL.MeterUnitCollect meterUnit = new MBMS.DAL.MeterUnitCollect();
                            meterUnit.MeterUnitCollectID = Guid.NewGuid().ToString();
                            meterUnit.CustomerID = customerinfo.CustomerID;
                            meterUnit.FromDate = item.nod_bill_from == "" ? dtpfromDate.Value : Convert.ToDateTime(y.Substring(0, 4) + "-" + m.Substring(4, 2) + "-" + d.Substring(6, 2));
                            meterUnit.ToDate = item.nod_bill_to == "" ? dtptoDate.Value : Convert.ToDateTime(item.nod_bill_to);
                            meterUnit.TotalMeterUnit = (decimal)item.nod_pres_eng;
                            meterUnit.BillMonth = (int)item.nod_bill_month;
                            meterUnit.TransformerID = transformer.TransformerID;
                            meterUnit.PoleID = p.PoleID;
                            meterUnit.MeterID = customerinfo.MeterID;
                            meterUnit.GPSX = Convert.ToDecimal(!String.IsNullOrWhiteSpace(item.nod_gps_h) ? item.nod_gps_h : null);
                            meterUnit.GPSY = Convert.ToDecimal(!String.IsNullOrWhiteSpace(item.nod_gps_l) ? item.nod_gps_l : null);
                            meterUnit.MeterStatus = item.nod_status;
                            meterUnit.OMRModelNo = item.nod_model;
                            meterUnit.DigitalModelNo = item.nod_model;
                            meterUnit.BillCode = customerinfo.BillCode7Layer.BillCode7LayerNo.ToString();
                            meterUnit.Active = true;
                            meterUnit.CreatedDate = DateTime.Now;
                            meterUnit.CreatedUserID = UserID;
                            meterUnitCollectList.Add(meterUnit);
                            #endregion
                        }
                    }

                    else
                    {
                        
                        #region MMUC
                        MBMS.DAL.ManualMeterUnitCollect manualMeterUnit = new MBMS.DAL.ManualMeterUnitCollect();
                        manualMeterUnit.ManualMeterUnitCollectID = Guid.NewGuid().ToString();
                        manualMeterUnit.CustomerID = customerinfo.CustomerID;
                        manualMeterUnit.FromDate = item.nod_bill_from == "" ? dtpfromDate.Value : Convert.ToDateTime(y.Substring(0, 4) + "-" + m.Substring(4, 2) + "-" + d.Substring(6, 2));
                        manualMeterUnit.ToDate = item.nod_bill_to == "" ? dtptoDate.Value : Convert.ToDateTime(item.nod_bill_to);
                        manualMeterUnit.TotalMeterUnit = (decimal)item.nod_pres_eng;
                        manualMeterUnit.BillMonth = (int)item.nod_bill_month;
                        manualMeterUnit.TransformerID = transformer.TransformerID;
                        manualMeterUnit.PoleID = p.PoleID;
                        manualMeterUnit.MeterID = customerinfo.MeterID;
                        manualMeterUnit.GPSX = Convert.ToDecimal(!String.IsNullOrWhiteSpace(item.nod_gps_h) ? item.nod_gps_h : null);
                        manualMeterUnit.GPSY = Convert.ToDecimal(!String.IsNullOrWhiteSpace(item.nod_gps_l) ? item.nod_gps_l : null);
                        manualMeterUnit.MeterStatus = item.nod_status;
                        manualMeterUnit.OMRModelNo = item.nod_model;
                        manualMeterUnit.DigitalModelNo = item.nod_model;
                        manualMeterUnit.BillCode = customerinfo.BillCode7Layer.BillCode7LayerNo.ToString();
                        manualMeterUnit.Active = true;
                        manualMeterUnit.CreatedDate = DateTime.Now;
                        manualMeterUnit.CreatedUserID = UserID;
                        manualMeterUnitCollectList.Add(manualMeterUnit);
                        #endregion
                    }
                }

                iMeterUnitColleciton.MeterUnitCollectionsProces(meterUnitCollectList);
                if (manualMeterUnitCollectList != null)
                {
                    iManualMeterUnitCollect.Save(manualMeterUnitCollectList);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occur" + ex.Message, "Error");
                return false;
            }
        }

        private void InitialState()
        {
            if (!CheckingRoleManagementFeature("BillUnitCollectView"))
            {
                MessageBox.Show("Access Denied For this Function", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            if (!CheckingRoleManagementFeature("BillUnitCollectEditOrDelete"))
            {
                btncollectmeterunit.Enabled = false;
                btnSave.Enabled = false;
            }
            dtpfromDate.Format = DateTimePickerFormat.Custom;
            dtpfromDate.CustomFormat = "MM/dd/yyyy";
            dtptoDate.Format = DateTimePickerFormat.Custom;
            dtptoDate.CustomFormat = "MM/dd/yyyy";
            dtptoDate.Value = DateTime.Now;
            cboQuarter.SelectedIndex = 0;
            cbofileName.SelectedIndex = cboTransformer.SelectedIndex = 0;
            this.Text = "Meter Unit Collections";
            this.gvnodemeter.DataSource = null;
            this.gvnodemeter.Refresh();
        }

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

        private void GetMeterUnitData(string fromDate, string toDate, string QuarterID)
        {
            nodeMeterList = null;
            this.BuildSQLiteConnection();
            NodeMeterServices NodeMetersvc = new NodeMeterServices();
            string sqlCommand = string.Empty;
            if (string.IsNullOrEmpty(QuarterID))
            {
                sqlCommand = string.Format("SELECT * FROM NodeMeter WHERE nod_bill_from>='{0}' AND nod_bill_to<='{1}' ", fromDate, toDate);
            }
            else
            {
                sqlCommand = string.Format("SELECT * FROM NodeMeter WHERE nod_bill_from>='{0}' AND nod_bill_to<='{1}' AND nod_village_code in (select vlg_code from Villages where vlg_code='{2}')", fromDate, toDate, QuarterID);
            }
            nodeMeterList = NodeMetersvc.GetAll(sqlCommand).ToList();
            this.gvnodemeter.DataSource = nodeMeterList;
            if (nodeMeterList.Count == 0)
            {
                MessageBox.Show("There is no data to collect.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion

        #region Form Load
        private void MeterUnitCollectionsfrm_Load(object sender, EventArgs e)
        {
            bindQuarter();
            bindTransformer();
            InitialState();
        }
        #endregion

        #region Button Click
        private void btncollectmeterunit_Click(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            string fromdate = dtpfromDate.Value.ToString("yyyyMMdd");
            string todate = dtptoDate.Value.ToString("yyyy-MM-dd");
            string qCode = string.Empty;
            string qid = cboQuarter.SelectedValue.ToString();
            if (!cboQuarter.SelectedValue.Equals("0"))
            {
                qCode = mbmsEntities.Quarters.Where(x => x.QuarterID == qid).SingleOrDefault().QuarterCode;
            }
            if (cbofileName.SelectedItem.Equals("Select One"))
            {
                MessageBox.Show("Select HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GetMeterUnitData(fromdate, todate, qCode);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitialState();

        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure to collect all of meter unit data to the system?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == result)
            {
                if (SaveMeterUnitCollection(nodeMeterList))
                {
                    MessageBox.Show("Meter Unit Collection process is successully complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gvnodemeter.DataSource = null;
                }
            }
        }
        #endregion

        #region Bind Township & Transformer Data List            
        private void bindTransformer()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Transformer> transformerList = new List<Transformer>();
            Transformer transformer = new Transformer();
            transformer.TransformerID = Convert.ToString(0);
            transformer.TransformerName = "Select";
            transformerList.Add(transformer);
            transformerList.AddRange(mbmsEntities.Transformers.Where(x => x.Active == true).OrderBy(x => x.TransformerName).ToList());
            cboTransformer.DataSource = transformerList;
            cboTransformer.DisplayMember = "TransformerName";
            cboTransformer.ValueMember = "TransformerID";

        }
        private void bindQuarter()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            List<Quarter> quarterList = new List<Quarter>();
            Quarter q = new Quarter();
            q.QuarterID = Convert.ToString(0);
            q.QuarterNameInEng = "Select";
            quarterList.Add(q);
            quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true).OrderBy(x => x.QuarterNameInEng).ToList());
            cboQuarter.DataSource = quarterList;
            cboQuarter.DisplayMember = "QuarterNameInEng";
            cboQuarter.ValueMember = "QuarterID";

        }
        #endregion

        #region Combo Selected Index
        private void cboQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            if (cboQuarter.SelectedIndex > 0)
            {
                string qid = cboQuarter.SelectedValue.ToString();
                List<Transformer> data = mbmsEntities.Transformers.Where(x => x.Active == true && x.QuarterID == qid).OrderBy(x => x.TransformerName).ToList();
                if (data.Count > 0)
                    cboTransformer.DataSource = data;
                else
                {
                    MessageBox.Show("There is no transformer data.");
                    this.bindTransformer();
                }
            }
        }

        #endregion

       
    }
}
