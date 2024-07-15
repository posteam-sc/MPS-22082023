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
    public partial class MeterListfrm : Form
    {
        #region Variables        
        MeterController meterController = new MeterController();
        private List<Meter> meterList = new List<Meter>();
        string meterID;
        public string UserID { get; set; }
        #endregion
        public MeterListfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void MeterListfrm_Load(object sender, EventArgs e)
        {

            bindMeterBoxCode();
            bindMeterTypeCode();
            bindTransformer();
            bindPole();
            InitialState();
            SearchMeter();
        }
        #endregion

        #region Bind Combo
        public void bindMeterBoxCode()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<MeterBox> meterboxList = new List<MeterBox>();
            MeterBox meterbox = new MeterBox();
            meterbox.MeterBoxID = Convert.ToString(0);
            meterbox.MeterBoxCode = "Select";
            meterboxList.Add(meterbox);
            meterboxList.AddRange(mbsEntities.MeterBoxes.Where(x => x.Active == true && x.Pole.PoleNo == cboPole.Text).ToList());
            cboMeterBoxCode.DataSource = meterboxList;
            cboMeterBoxCode.DisplayMember = "MeterBoxCode";
            cboMeterBoxCode.ValueMember = "MeterBoxID";
        }

        public void bindMeterTypeCode()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<MeterType> meterTypeList = new List<MeterType>();
            MeterType meterType = new MeterType();
            meterType.MeterTypeID = Convert.ToString(0);
            meterType.MeterTypeCode = "Select";
            meterTypeList.Add(meterType);
            meterTypeList.AddRange(mbsEntities.MeterTypes.Where(x => x.Active == true).ToList());
            cboMeterTypeCode.DataSource = meterTypeList;
            cboMeterTypeCode.DisplayMember = "MeterTypeCode";
            cboMeterTypeCode.ValueMember = "MeterTypeID";
        }

        public void bindPole()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<Pole> poleList = new List<Pole>();
            Pole pole = new Pole();
            pole.PoleID = Convert.ToString(0);
            pole.PoleNo = "Select";
            poleList.Add(pole);
            poleList.AddRange(mbsEntities.Poles.Where(x => x.Active == true && x.Transformer.TransformerName == cboTransformer.Text).ToList());
            cboPole.DataSource = poleList;
            cboPole.DisplayMember = "PoleNo";
            cboPole.ValueMember = "PoleID";
        }

        public void bindTransformer()
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            List<Transformer> transformerList = new List<Transformer>();
            Transformer transformer = new Transformer();
            transformer.TransformerID = Convert.ToString(0);
            transformer.TransformerName = "Select";
            transformerList.Add(transformer);
            transformerList.AddRange(mbsEntities.Transformers.Where(x => x.Active == true).ToList());
            cboTransformer.DataSource = transformerList;
            cboTransformer.DisplayMember = "TransformerName";
            cboTransformer.ValueMember = "TransformerID";
        }
        #endregion

        #region Method

        //public void FormRefresh()
        //{
        //    MBMSEntities mbsEntities = new MBMSEntities();
        //    dgvMeterList.AutoGenerateColumns = false;
        //    meterList = (from m in mbsEntities.Meters where m.Active == true orderby m.MeterNo descending select m).ToList();
        //    dgvMeterList.DataSource = meterList;
        //}
        private class RemoveMeterHistory
        {
            public string meterHistoryID { get; set; }
            public string MeterSerialNo { get; set; }
            public string UsedCustomerCode { get; set; }
            public string UsedCustomerName { get; set; }
            public DateTime RemoveDate { get; set; }
            public string Remark { get; set; }
            public string DamageType { get; set; }

        }


        private void SearchMeterRemove()
        {
            MBMSEntities mbmsEntites = new MBMSEntities();
            dgvRemoveMeter.AutoGenerateColumns = false;
            List<RemoveMeterHistory> searchMeterHistory = new List<RemoveMeterHistory>();
            List<RemoveMeterHistory> meterHistory = (from mh in mbmsEntites.MeterHistories
                                                     join m in mbmsEntites.Meters on mh.OldMeterID equals m.MeterID
                                                     join c in mbmsEntites.Customers on mh.CustomerID equals c.CustomerID
                                                     where mh.Active == true
                                                     select new RemoveMeterHistory
                                                     {
                                                         meterHistoryID = mh.MeterHistoryID,
                                                         MeterSerialNo = m.MeterNo,
                                                         UsedCustomerCode = c.CustomerCode,
                                                         UsedCustomerName = c.CustomerNameInEng,
                                                         RemoveDate = mh.RemovedDate,
                                                         Remark = mh.Remark,
                                                         DamageType = mh.DamageType,

                                                     }).ToList();
            //Transformer & Pole & MeterBox & MeterType
            if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex != 0 && cboMeterBoxCode.SelectedIndex != 0 && cboMeterTypeCode.SelectedIndex != 0)
            {
                searchMeterHistory = (from mh in mbmsEntites.MeterHistories
                                      join m in mbmsEntites.Meters on mh.OldMeterID equals m.MeterID
                                      join c in mbmsEntites.Customers on mh.CustomerID equals c.CustomerID
                                      join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                                      join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                                      join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                                      join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                                      where t.TransformerName == cboTransformer.Text && p.PoleNo == cboPole.Text
                                      && mb.MeterBoxCode == cboMeterBoxCode.Text && mt.MeterTypeCode == cboMeterTypeCode.Text
                                      && mh.Active == true
                                      select new RemoveMeterHistory
                                      {
                                          meterHistoryID = mh.MeterHistoryID,
                                          MeterSerialNo = m.MeterNo,
                                          UsedCustomerCode = c.CustomerCode,
                                          UsedCustomerName = c.CustomerNameInEng,
                                          RemoveDate = mh.RemovedDate,
                                          Remark = mh.Remark,
                                          DamageType = mh.DamageType,

                                      }).ToList();
                if (searchMeterHistory.Count > 0)
                {
                    dgvRemoveMeter.DataSource = searchMeterHistory;
                }
                else
                {
                    MessageBox.Show("No Data Found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRemoveMeter.DataSource = "";
                }


            }
            //Transformer & Pole & MeterBox
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex != 0 && cboMeterBoxCode.SelectedIndex != 0 && cboMeterTypeCode.SelectedIndex == 0)
            {
                searchMeterHistory = (from mh in mbmsEntites.MeterHistories
                                      join m in mbmsEntites.Meters on mh.OldMeterID equals m.MeterID
                                      join c in mbmsEntites.Customers on mh.CustomerID equals c.CustomerID
                                      join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                                      join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                                      join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                                      join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                                      where t.TransformerName == cboTransformer.Text && p.PoleNo == cboPole.Text
                                      && mb.MeterBoxCode == cboMeterBoxCode.Text && mh.Active == true
                                      select new RemoveMeterHistory
                                      {
                                          meterHistoryID = mh.MeterHistoryID,
                                          MeterSerialNo = m.MeterNo,
                                          UsedCustomerCode = c.CustomerCode,
                                          UsedCustomerName = c.CustomerNameInEng,
                                          RemoveDate = mh.RemovedDate,
                                          Remark = mh.Remark,
                                          DamageType = mh.DamageType,

                                      }).ToList();
                if (searchMeterHistory.Count > 0)
                {
                    dgvRemoveMeter.DataSource = searchMeterHistory;
                }
                else
                {
                    MessageBox.Show("No Data Found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRemoveMeter.DataSource = "";
                }


            }
            //Transformer & Pole & MeterType
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex != 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex != 0)
            {
                searchMeterHistory = (from mh in mbmsEntites.MeterHistories
                                      join m in mbmsEntites.Meters on mh.OldMeterID equals m.MeterID
                                      join c in mbmsEntites.Customers on mh.CustomerID equals c.CustomerID
                                      join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                                      join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                                      join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                                      join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                                      where t.TransformerName == cboTransformer.Text && p.PoleNo == cboPole.Text
                                      && mt.MeterTypeCode == cboMeterTypeCode.Text && mh.Active == true
                                      select new RemoveMeterHistory
                                      {
                                          meterHistoryID = mh.MeterHistoryID,
                                          MeterSerialNo = m.MeterNo,
                                          UsedCustomerCode = c.CustomerCode,
                                          UsedCustomerName = c.CustomerNameInEng,
                                          RemoveDate = mh.RemovedDate,
                                          Remark = mh.Remark,
                                          DamageType = mh.DamageType,

                                      }).ToList();
                if (searchMeterHistory.Count > 0)
                {
                    dgvRemoveMeter.DataSource = searchMeterHistory;
                }
                else
                {
                    MessageBox.Show("No Data Found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRemoveMeter.DataSource = "";
                }

            }
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex != 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex == 0)
            {
                searchMeterHistory = (from mh in mbmsEntites.MeterHistories
                                      join m in mbmsEntites.Meters on mh.OldMeterID equals m.MeterID
                                      join c in mbmsEntites.Customers on mh.CustomerID equals c.CustomerID
                                      join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                                      join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                                      join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                                      join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                                      where t.TransformerName == cboTransformer.Text && p.PoleNo == cboPole.Text && mh.Active == true
                                      select new RemoveMeterHistory
                                      {
                                          meterHistoryID = mh.MeterHistoryID,
                                          MeterSerialNo = m.MeterNo,
                                          UsedCustomerCode = c.CustomerCode,
                                          UsedCustomerName = c.CustomerNameInEng,
                                          RemoveDate = mh.RemovedDate,
                                          Remark = mh.Remark,
                                          DamageType = mh.DamageType,

                                      }).ToList();
                if (searchMeterHistory.Count > 0)
                {
                    dgvRemoveMeter.DataSource = searchMeterHistory;
                }
                else
                {
                    MessageBox.Show("No Data Found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRemoveMeter.DataSource = "";
                }


            }
            //Transformer & MeterType
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex == 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex != 0)
            {
                searchMeterHistory = (from mh in mbmsEntites.MeterHistories
                                      join m in mbmsEntites.Meters on mh.OldMeterID equals m.MeterID
                                      join c in mbmsEntites.Customers on mh.CustomerID equals c.CustomerID
                                      join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                                      join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                                      join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                                      join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                                      where t.TransformerName == cboTransformer.Text
                                      && mt.MeterTypeCode == cboMeterTypeCode.Text && mh.Active == true
                                      select new RemoveMeterHistory
                                      {
                                          meterHistoryID = mh.MeterHistoryID,
                                          MeterSerialNo = m.MeterNo,
                                          UsedCustomerCode = c.CustomerCode,
                                          UsedCustomerName = c.CustomerNameInEng,
                                          RemoveDate = mh.RemovedDate,
                                          Remark = mh.Remark,
                                          DamageType = mh.DamageType,

                                      }).ToList();
                if (searchMeterHistory.Count > 0)
                {
                    dgvRemoveMeter.DataSource = searchMeterHistory;
                }
                else
                {
                    MessageBox.Show("No Data Found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRemoveMeter.DataSource = "";
                }


            }
            //Transformer
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex == 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex == 0)
            {
                searchMeterHistory = (from mh in mbmsEntites.MeterHistories
                                      join m in mbmsEntites.Meters on mh.OldMeterID equals m.MeterID
                                      join c in mbmsEntites.Customers on mh.CustomerID equals c.CustomerID
                                      join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                                      join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                                      join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                                      join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                                      where t.TransformerName == cboTransformer.Text && mh.Active == true
                                      select new RemoveMeterHistory
                                      {
                                          meterHistoryID = mh.MeterHistoryID,
                                          MeterSerialNo = m.MeterNo,
                                          UsedCustomerCode = c.CustomerCode,
                                          UsedCustomerName = c.CustomerNameInEng,
                                          RemoveDate = mh.RemovedDate,
                                          Remark = mh.Remark,
                                          DamageType = mh.DamageType,

                                      }).ToList();
                if (searchMeterHistory.Count > 0)
                {
                    dgvRemoveMeter.DataSource = searchMeterHistory;
                }
                else
                {
                    MessageBox.Show("No Data Found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRemoveMeter.DataSource = "";
                }

            }
            //MeterType
            else if (cboTransformer.SelectedIndex == 0 && cboPole.SelectedIndex == 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex != 0)
            {
                searchMeterHistory = (from mh in mbmsEntites.MeterHistories
                                      join m in mbmsEntites.Meters on mh.OldMeterID equals m.MeterID
                                      join c in mbmsEntites.Customers on mh.CustomerID equals c.CustomerID
                                      join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                                      join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                                      join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                                      join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                                      where mt.MeterTypeCode == cboMeterTypeCode.Text && mh.Active == true
                                      select new RemoveMeterHistory
                                      {
                                          meterHistoryID = mh.MeterHistoryID,
                                          MeterSerialNo = m.MeterNo,
                                          UsedCustomerCode = c.CustomerCode,
                                          UsedCustomerName = c.CustomerNameInEng,
                                          RemoveDate = mh.RemovedDate,
                                          Remark = mh.Remark,
                                          DamageType = mh.DamageType,

                                      }).ToList();
                if (searchMeterHistory.Count > 0)
                {
                    dgvRemoveMeter.DataSource = searchMeterHistory;
                }
                else
                {
                    MessageBox.Show("No Data Found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRemoveMeter.DataSource = "";
                }

            }
            else if (!String.IsNullOrWhiteSpace(txtMeterNo.Text))
            {
                dgvRemoveMeter.DataSource = meterHistory.Where(m => m.MeterSerialNo.IndexOf(txtMeterNo.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            }
            else
            {
                dgvRemoveMeter.DataSource = meterHistory.ToList();

            }

            //dgvRemoveMeter.DataSource = meterHistory;
        }
        public void SearchMeter()
        {
            MBMSEntities mbmsEntites = new MBMSEntities();
            List<Meter> allMeter = new List<Meter>();
            List<Meter> registerMeter = new List<Meter>();
            List<Meter> unregisterMeter = new List<Meter>();
            List<Meter> removeMeter = new List<Meter>();
            List<Meter> result = new List<Meter>();
            List<Meter> meter = new List<Meter>();
            List<MeterHistory> meterHistory = new List<MeterHistory>();

            dgvMeterList.AutoGenerateColumns = false;

            //AllMeter
            allMeter = mbmsEntites.Meters.ToList();

            registerMeter = (from m in allMeter
                             join c in mbmsEntites.Customers on m.MeterID equals c.MeterID
                             where m.Active == true && m.Status == true
                             select m).ToList();


            unregisterMeter = allMeter.Except(registerMeter).Where(m => m.Active == true && m.Status == true).ToList();

            //removeMeter = allMeter.Where(x => x.Status == false && x.Active == true).ToList();


            if (rdoregistermeter.Checked == true)
            {
                result = registerMeter;
            }
            else if (rdounregistermeter.Checked == true)
            {
                result = unregisterMeter;
            }


            //Transformer & Pole & MeterBox & MeterType
            if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex != 0 && cboMeterBoxCode.SelectedIndex != 0 && cboMeterTypeCode.SelectedIndex != 0)
            {
                meter = (from m in result
                         join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                         join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                         join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                         join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                         where t.TransformerName == cboTransformer.Text && p.PoleNo == cboPole.Text
                         && mb.MeterBoxCode == cboMeterBoxCode.Text && mt.MeterTypeCode == cboMeterTypeCode.Text
                         select m).ToList();

            }
            //Transformer & Pole & MeterBox
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex != 0 && cboMeterBoxCode.SelectedIndex != 0 && cboMeterTypeCode.SelectedIndex == 0)
            {
                meter = (from m in result
                         join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                         join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                         join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                         join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                         where t.TransformerName == cboTransformer.Text && p.PoleNo == cboPole.Text
                         && mb.MeterBoxCode == cboMeterBoxCode.Text
                         select m).ToList();
            }
            //Transformer & Pole & MeterType
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex != 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex != 0)
            {
                meter = (from m in result
                         join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                         join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                         join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                         join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                         where t.TransformerName == cboTransformer.Text && p.PoleNo == cboPole.Text
                         && mt.MeterTypeCode == cboMeterTypeCode.Text
                         select m).ToList();
            }
            //Transformer & Pole
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex != 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex == 0)
            {
                meter = (from m in result
                         join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                         join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                         join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                         join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                         where t.TransformerName == cboTransformer.Text && p.PoleNo == cboPole.Text
                         select m).ToList();
            }
            //Transformer & MeterType
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex == 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex != 0)
            {
                meter = (from m in result
                         join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                         join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                         join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                         join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                         where t.TransformerName == cboTransformer.Text
                         && mt.MeterTypeCode == cboMeterTypeCode.Text
                         select m).ToList();
            }
            //Transformer
            else if (cboTransformer.SelectedIndex != 0 && cboPole.SelectedIndex == 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex == 0)
            {
                meter = (from m in result
                         join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                         join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                         join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                         join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                         where t.TransformerName == cboTransformer.Text
                         select m).ToList();

            }
            //MeterType
            else if (cboTransformer.SelectedIndex == 0 && cboPole.SelectedIndex == 0 && cboMeterBoxCode.SelectedIndex == 0 && cboMeterTypeCode.SelectedIndex != 0)
            {
                meter = (from m in result
                         join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                         join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                         join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                         join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                         where mt.MeterTypeCode == cboMeterTypeCode.Text
                         select m).ToList();
            }
            else
            {
                meter = (from m in result
                         join mb in mbmsEntites.MeterBoxes on m.MeterBoxID equals mb.MeterBoxID
                         join p in mbmsEntites.Poles on mb.PoleID equals p.PoleID
                         join t in mbmsEntites.Transformers on p.TransformerID equals t.TransformerID
                         join mt in mbmsEntites.MeterTypes on m.MeterTypeID equals mt.MeterTypeID
                         select m).ToList();

            }

            if (!String.IsNullOrWhiteSpace(txtMeterNo.Text))
            {
                dgvMeterList.DataSource = meter.Where(m => m.MeterNo.IndexOf(txtMeterNo.Text, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            }
            else
            {
                dgvMeterList.DataSource = meter.ToList();

            }
        }

        private void InitialState()
        {

            cboTransformer.SelectedIndex = 0;
            cboPole.SelectedIndex = 0;
            txtMeterNo.Text = string.Empty;
            cboMeterBoxCode.SelectedIndex = 0;
            cboMeterTypeCode.SelectedIndex = 0;
            rdoregistermeter.Checked = true;
            rdoremovedmeter.Checked = false;
            rdounregistermeter.Checked = false;
            dgvRemoveMeter.Hide();
            dgvMeterList.Show();
        }

        public void foundDataBind()
        {
            dgvMeterList.DataSource = "";
            dgvRemoveMeter.DataSource = "";

            if (meterList.Count < 1)
            {
                MessageBox.Show("No data Found", "Cannot find");
                dgvMeterList.DataSource = "";

                return;
            }
            else
            {
                dgvMeterList.DataSource = meterList;

            }
        }

        public void buttonClick()
        {
            btnSearch_Click(this, new EventArgs());
        }

        #endregion

        #region Data Grid Bind
        private void dgvMeterList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMeterList.Rows)
            {
                Meter meter = (Meter)row.DataBoundItem;
                row.Cells[0].Value = meter.MeterID;
                row.Cells[1].Value = meter.MeterNo;
                row.Cells[2].Value = meter.Model;
                row.Cells[3].Value = meter.InstalledDate;
                row.Cells[4].Value = meter.MeterBox.Pole.Transformer.TransformerName;
                row.Cells[5].Value = meter.MeterBox.Pole.PoleNo;
                if (meter.Status == true)
                    row.Cells[6].Value = "Enable";
                else
                    row.Cells[6].Value = "Disable";

                row.Cells[7].Value = meter.MeterBox.MeterBoxCode;
                row.Cells[8].Value = meter.MeterBoxSequence;
                row.Cells[9].Value = meter.MeterType.MeterTypeCode;
            }
        }

        private void dgvRemoveMeter_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRemoveMeter.Rows)
            {
                RemoveMeterHistory meterHistory = (RemoveMeterHistory)row.DataBoundItem;
                row.Cells[0].Value = meterHistory.meterHistoryID;
                row.Cells[1].Value = meterHistory.MeterSerialNo;
                row.Cells[2].Value = meterHistory.UsedCustomerCode;
                row.Cells[3].Value = meterHistory.UsedCustomerName;
                row.Cells[4].Value = meterHistory.RemoveDate;
                row.Cells[5].Value = meterHistory.Remark;
                row.Cells[6].Value = meterHistory.DamageType;
            }
        }
        #endregion

        #region Datagrid Cell Click

        private void dgvMeterList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 12)
                {
                    //DeleteForMeter
                    if (!CheckingRoleManagementFeature("MeterEditOrDelete"))
                    {
                        MessageBox.Show("Access Deined for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        MBMSEntities mbsEntities = new MBMSEntities();
                        DataGridViewRow row = dgvMeterList.Rows[e.RowIndex];
                        meterID = Convert.ToString(row.Cells[0].Value);
                        Meter meterObj = (Meter)row.DataBoundItem;
                        meterObj = (from m in mbsEntities.Meters where m.MeterID == meterObj.MeterID select m).FirstOrDefault();
                        var customerCount = (from c in meterObj.Customers where c.Active == true select c).Count();
                        if (customerCount > 0)
                        {
                            MessageBox.Show("This Meter No cannot deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvMeterList.DataSource = "";
                        Meter meter = (from m in mbsEntities.Meters where m.MeterID == meterID select m).FirstOrDefault();
                        meter.Active = false;
                        meter.DeletedUserID = UserID;
                        meter.DeletedDate = DateTime.Now;
                        meterController.DeletedMeter(meter);
                        dgvMeterList.DataSource = (from m in mbsEntities.Meters where m.Active == true orderby m.MeterNo descending select m).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SearchMeter();

                    }

                }
                else if (e.ColumnIndex == 10)
                {

                    DetailMeterfrm detailmeterForm = new DetailMeterfrm();
                    detailmeterForm.meterID = Convert.ToString(dgvMeterList.Rows[e.RowIndex].Cells[0].Value);
                    detailmeterForm.ShowDialog();

                }
                else if (e.ColumnIndex == 11)
                {
                    //EditMeter
                    if (!CheckingRoleManagementFeature("MeterEditOrDelete"))
                    {
                        MessageBox.Show("Access Deined for this function.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MeterFrm meterForm = new MeterFrm();
                    meterForm.isEdit = true;
                    meterForm.Text = "Edit Meter";
                    meterForm.meterID = Convert.ToString(dgvMeterList.Rows[e.RowIndex].Cells[0].Value);
                    meterForm.UserID = UserID;
                    meterForm.isAdd = true;
                    var result = meterForm.ShowDialog();
                    if (result == DialogResult.OK)
                        SearchMeter();

                }
                //remove funciton here
                else if (e.ColumnIndex == 13)
                {
                    if (!CheckingRoleManagementFeature("MeterEditOrDelete"))
                    {
                        MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataGridViewRow row = dgvMeterList.Rows[e.RowIndex];
                    Meter _meter = (Meter)row.DataBoundItem;
                    if (rdounregistermeter.Checked || rdoremovedmeter.Checked)
                    {
                        MessageBox.Show("Unregister meter list or removed meter list can't remove", "Access deined");
                        return;
                    }
                    MeterRemoveUI meterremoveui = new MeterRemoveUI();
                    meterremoveui.meter = _meter;
                    var result = meterremoveui.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        SearchMeter();
                    }
                }
            }
        }
        #endregion

        #region Button Click

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoregistermeter.Checked || rdounregistermeter.Checked)
            {
                SearchMeter();

            }
            else
            {
                SearchMeterRemove();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            InitialState();
            SearchMeter();
        }
        #endregion

        #region Data Permision for Role Mgt
        private bool CheckingRoleManagementFeature(string ProgramName)
        {
            MBMSEntities mbsEntities = new MBMSEntities();
            bool IsAllowed = false;
            string roleID = mbsEntities.Users.Where(x => x.Active == true && x.UserID == UserID).SingleOrDefault().RoleID;
            List<RoleManagement> rolemgtList = mbsEntities.RoleManagements.Where(x => x.Active == true && x.RoleID == roleID).ToList();
            foreach (RoleManagement item in rolemgtList)
            {
                //bill payment Menu Permission CustomerView
                if (item.RoleFeatureName.Equals(ProgramName) && item.IsAllowed) IsAllowed = item.IsAllowed;
            }
            return IsAllowed;
        }
        #endregion

        #region Radio Button Check Changed
        private void rdounregistermeter_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoregistermeter.Checked)
            {
                rdounregistermeter.Checked = rdoremovedmeter.Checked = false;
                dgvRemoveMeter.Hide();
                dgvMeterList.Show();
            }
            else if (rdounregistermeter.Checked)
            {
                rdoregistermeter.Checked = rdoremovedmeter.Checked = false;
                dgvRemoveMeter.Hide();
                dgvMeterList.Show();
            }
            else if (rdoremovedmeter.Checked)
            {
                rdoregistermeter.Checked = rdounregistermeter.Checked = false;
                dgvMeterList.Hide();
                dgvRemoveMeter.Show();
                SearchMeterRemove();

            }
        }
        #endregion

        #region Key Down
        private void txtMeterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }
        #endregion

        #region IndexChanged
        private void cboTransformer_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindPole();
        }

        private void cboPole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindMeterBoxCode();
        }

        #endregion

       
    }
}
