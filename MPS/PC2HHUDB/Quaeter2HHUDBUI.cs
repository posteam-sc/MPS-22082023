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
    public partial class Quaeter2HHUDBUI : Form
    {
        #region Variables
        MBMSEntities mbmsEntities = new MBMSEntities();
        List<Quarter> qList = new List<Quarter>();
        #endregion

        public Quaeter2HHUDBUI()
        {
            InitializeComponent();
            getDbFileList();
        }

        #region Method
        private void BuildSQLiteConnection()
        {
            string sqlitedbPath = System.Configuration.ConfigurationManager.AppSettings["DatabaseFile"] + cbofileName.SelectedItem;
            if (String.IsNullOrEmpty(Storage.ConnectionString))
            {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", sqlitedbPath));
            }
        }
        public void FormRefresh()
        {
            dgvQuarterList.AutoGenerateColumns = false;
            qList = (from q in mbmsEntities.Quarters where q.Active == true orderby q.QuarterCode descending select q).ToList();
            dgvQuarterList.DataSource = (from q in mbmsEntities.Quarters where q.Active == true orderby q.QuarterCode descending select q).ToList();
        }
        #endregion

        #region Form Load
        private void Quaeter2HHUDBUI_Load(object sender, EventArgs e)
        {
            FormRefresh();
        }

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
        #endregion

        #region Button Click
        private void btnSave2HHUDB_Click(object sender, EventArgs e)
        {
            if (qList.Count == 0)
            {
                MessageBox.Show("There is no Villages(Quarter) data to save HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                VillageServices sqlitevillage = new VillageServices();
                List<MPS.SQLiteHelper.Villages> sqlvillageList = new List<MPS.SQLiteHelper.Villages>();
                string sqlCommand = string.Format("SELECT * FROM Villages");
                var data = sqlitevillage.GetAll(sqlCommand);
                foreach (var v in data)
                {
                    foreach (Quarter q in qList)
                    {
                        if (q.QuarterCode == v.vlg_code)
                        {
                            //MessageBox.Show("(" + q.QuarterCode + ") Villages(Quarter) code already exists in HHU db file.", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            //continue;
                            qList.Remove(q);
                            break;
                        }

                    }

                }
                if (qList.Count == 0)
                {
                    MessageBox.Show(" Villages(Quarter) code already exists in HHU db file.", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FormRefresh();

                }
                else
                {
                    foreach (Quarter q in qList)
                    {
                        MPS.SQLiteHelper.Villages v = new MPS.SQLiteHelper.Villages();
                        v.vlg_code = q.QuarterCode;
                        v.vlg_address = q.Address;
                        v.vlg_name = q.QuarterNameInEng;
                        v.vlg_value = q.QuarterNameInMM;
                        sqlvillageList.Add(v);
                    }
                    try
                    {
                        sqlitevillage.AddRange(sqlvillageList);
                        MessageBox.Show("Villages(Quarter) data to HHU db file is successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRefresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occur when saving Villages to HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
        }

        private void Search()
        {
            dgvQuarterList.AutoGenerateColumns = false;
            qList = (from q in mbmsEntities.Quarters where q.Active == true && q.QuarterCode == txtQuarterCode.Text orderby q.QuarterCode descending select q).ToList();
            dgvQuarterList.DataSource = qList;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtQuarterCode.Text = string.Empty;
            cbofileName.SelectedIndex = 0;
            FormRefresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        #endregion

        #region Key Down
        private void txtQuarterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }
        #endregion

        private void dgvQuarterList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvQuarterList.Rows)
            {
                Quarter quarter = (Quarter)row.DataBoundItem;               
                row.Cells[0].Value = quarter.QuarterCode;
                row.Cells[1].Value = quarter.QuarterNameInEng;
                row.Cells[2].Value = quarter.QuarterNameInMM;
                row.Cells[3].Value = quarter.Township.TownshipNameInEng;
                row.Cells[4].Value = quarter.Address;
            }
        }

        private void txtQuarterCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar==Convert.ToChar(Keys.Tab) )
            {
                Search();
            }
        }
    }
}
