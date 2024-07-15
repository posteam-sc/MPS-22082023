using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
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

namespace MPS
{
    public partial class PolePC2HHUDB : Form
    {
        #region Variables
        public string UserID { get; set; }
        PoleController poleController = new PoleController();
        private List<Pole> poleList = new List<Pole>();
        #endregion

        public PolePC2HHUDB()
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

        public void loadData()
        {
            MBMSEntities mbsEntites = new MBMSEntities();
            var pole = mbsEntites.Poles.Where(u => u.Active == true).ToList();

            if (!string.IsNullOrWhiteSpace(txtSearchPoleName.Text) && cboSearchQuarterName.SelectedIndex == 0 && cboSearchTransformerName.SelectedIndex == 0)
            {
                poleList = pole.Where(u => u.PoleNo.IndexOf(txtSearchPoleName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active==true).ToList();
                dgvPoleList.DataSource = pole.Where(u => u.PoleNo.IndexOf(txtSearchPoleName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
            }

            else if (string.IsNullOrWhiteSpace(txtSearchPoleName.Text) && cboSearchQuarterName.SelectedIndex > 0 && cboSearchTransformerName.SelectedIndex == 0)
            {
                dgvPoleList.DataSource = pole.Where(u => u.Transformer.Quarter.QuarterNameInEng.IndexOf(cboSearchQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                poleList = pole.Where(u => u.Transformer.Quarter.QuarterNameInEng.IndexOf(cboSearchQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
            }

            else if (string.IsNullOrWhiteSpace(txtSearchPoleName.Text) && cboSearchQuarterName.SelectedIndex == 0 && cboSearchTransformerName.SelectedIndex > 0)
            {
                dgvPoleList.DataSource = pole.Where(u => u.Transformer.TransformerName.IndexOf(cboSearchTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                poleList = pole.Where(u => u.Transformer.TransformerName.IndexOf(cboSearchTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
            }

            else if (!string.IsNullOrWhiteSpace(txtSearchPoleName.Text) && cboSearchQuarterName.SelectedIndex > 0 && cboSearchTransformerName.SelectedIndex == 0)
            {
                dgvPoleList.DataSource = pole.Where(u => u.PoleNo.IndexOf(txtSearchPoleName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                u.Transformer.Quarter.QuarterNameInEng.IndexOf(cboSearchQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
                poleList = pole.Where(u => u.PoleNo.IndexOf(txtSearchPoleName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                  u.Transformer.Quarter.QuarterNameInEng.IndexOf(cboSearchQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

            }

            else if (!string.IsNullOrWhiteSpace(txtSearchPoleName.Text) && cboSearchQuarterName.SelectedIndex == 0 && cboSearchTransformerName.SelectedIndex > 0)
            {
                dgvPoleList.DataSource = pole.Where(u => u.PoleNo.IndexOf(txtSearchPoleName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                u.Transformer.TransformerName.IndexOf(cboSearchTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                poleList = pole.Where(u => u.PoleNo.IndexOf(txtSearchPoleName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                 u.Transformer.TransformerName.IndexOf(cboSearchTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

            }

            else if (string.IsNullOrWhiteSpace(txtSearchPoleName.Text) && cboSearchQuarterName.SelectedIndex > 0 && cboSearchTransformerName.SelectedIndex > 0)
            {
                dgvPoleList.DataSource = pole.Where(u => u.Transformer.Quarter.QuarterNameInEng.IndexOf(cboSearchQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                u.Transformer.TransformerName.IndexOf(cboSearchTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                poleList = pole.Where(u => u.Transformer.Quarter.QuarterNameInEng.IndexOf(cboSearchQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                  u.Transformer.TransformerName.IndexOf(cboSearchTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

            }

            else if (!string.IsNullOrWhiteSpace(txtSearchPoleName.Text) && cboSearchQuarterName.SelectedIndex > 0 && cboSearchTransformerName.SelectedIndex > 0)
            {
                dgvPoleList.DataSource = pole.Where(u => u.Transformer.Quarter.QuarterNameInEng.IndexOf(cboSearchQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                u.Transformer.TransformerName.IndexOf(cboSearchTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                u.PoleNo.IndexOf(txtSearchPoleName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();

                poleList = pole.Where(u => u.Transformer.Quarter.QuarterNameInEng.IndexOf(cboSearchQuarterName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                  u.Transformer.TransformerName.IndexOf(cboSearchTransformerName.Text, StringComparison.OrdinalIgnoreCase) != -1 &&
                  u.PoleNo.IndexOf(txtSearchPoleName.Text, StringComparison.OrdinalIgnoreCase) != -1 && u.Active == true).ToList();
            } else if (string.IsNullOrWhiteSpace(txtSearchPoleName.Text) && cboSearchQuarterName.SelectedIndex == 0 && cboSearchTransformerName.SelectedIndex == 0)
            {
                poleList = pole.Where(u => u.Active == true).ToList();
                dgvPoleList.DataSource = pole.Where(u =>u.Active == true).ToList();
            }

        }

        public void foundDataBind()
        {

            dgvPoleList.DataSource = "";

            if (poleList.Count < 1)
            {
                MessageBox.Show("No data Found", "Cannot find");
                dgvPoleList.DataSource = "";
                return;
            }
            else
            {
                dgvPoleList.DataSource = poleList;
            }
        }


        public void FormRefresh()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();

            this.poleList = (from p in mbmsEntities.Poles where p.Active == true orderby p.PoleNo descending select p).ToList();
            dgvPoleList.AutoGenerateColumns = false;
            dgvPoleList.DataSource = (from p in mbmsEntities.Poles where p.Active == true orderby p.PoleNo descending select p).ToList();

        }

        #endregion

        #region Form Load
        private void Polefrm_Load(object sender, EventArgs e)
        {
            bindSearchQuarterName();
            bindSearchTransformer();
            FormRefresh();
        }
        #endregion

        #region Bind Combo
        public void bindSearchTransformer()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();

            List<Transformer> transList = new List<Transformer>();
            Transformer trans = new Transformer();
            trans.TransformerID = Convert.ToString(0);
            trans.TransformerName = "Select";
            transList.Add(trans);
            transList.AddRange(mbmsEntities.Transformers.Where(x => x.Active == true).OrderBy(x => x.TransformerName).ToList());
            cboSearchTransformerName.DataSource = transList;
            cboSearchTransformerName.DisplayMember = "TransformerName";
            cboSearchTransformerName.ValueMember = "TransformerID";
        }
        public void bindSearchQuarterName()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();

            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true).OrderBy(x => x.QuarterNameInEng).ToList());
            cboSearchQuarterName.DataSource = quarterList;
            cboSearchQuarterName.DisplayMember = "QuarterNameInEng";
            cboSearchQuarterName.ValueMember = "QuarterID";
        }
        #endregion

        #region Data Bind by Datagrid

        private void dgvPoleList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPoleList.Rows)
            {
                Pole pole = (Pole)row.DataBoundItem;
                row.Cells[0].Value = pole.PoleNo;
                row.Cells[1].Value = pole.GPSX;
                row.Cells[2].Value = pole.GPSY;
                row.Cells[3].Value = pole.Transformer.TransformerName;
                row.Cells[4].Value = pole.Transformer.Quarter.QuarterNameInEng;
            }
        }

        #endregion

        #region Button Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchPoleName.Text = string.Empty;
            cboSearchQuarterName.SelectedIndex = 0;
            cboSearchTransformerName.SelectedIndex = 0;
            cbofileName.SelectedIndex = 0;
            FormRefresh();
        }

        private void btnSave2HHUDB_Click(object sender, EventArgs e)
        {
            if (poleList.Count == 0)
            {
                MessageBox.Show("There is no pole data to save HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                BuildSQLiteConnection();
                PoleServices sqlitepoleservices = new PoleServices();
                List<MPS.SQLiteHelper.Poles> sqlpoleList = new List<MPS.SQLiteHelper.Poles>();
                string sqlCommand = string.Format("SELECT * FROM Poles");
                var data = sqlitepoleservices.GetAll(sqlCommand);
                foreach (var v in data)
                {
                    foreach (Pole p in poleList)
                    {
                        if (p.PoleNo == v.pol_id)
                        {
                            poleList.Remove(p);
                            break;
                        }
                    }
                }

                if (poleList.Count != 0)
                {
                    foreach (Pole p in poleList)
                    {
                        MPS.SQLiteHelper.Poles pole = new MPS.SQLiteHelper.Poles();
                        pole.pol_id = p.PoleNo;
                        pole.pol_gps_x = p.GPSX.ToString();
                        pole.pol_gps_y = p.GPSY.ToString();
                        pole.pol_etc1 = p.PoleNo;
                        sqlpoleList.Add(pole);
                    }
                    try
                    {
                        sqlitepoleservices.AddRange(sqlpoleList);
                        FormRefresh();
                        MessageBox.Show("pole data to HHU db file is successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occur when saving pole to HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Pole Data is already exist in HHU db","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    loadData();
                }

            }
        }
        #endregion

        #region Key Down
        private void txtSearchPoleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }

        }
        #endregion
    }
}
