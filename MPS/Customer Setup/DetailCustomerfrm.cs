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

namespace MPS.Customer_Setup
{
    public partial class DetailCustomerfrm : Form
    {
        
        public String customerID { get; set; }
        public DetailCustomerfrm()
        {
            InitializeComponent();
        }

        #region Form Load
        private void DetailCustomerfrm_Load(object sender, EventArgs e)
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            Customer customer = (from c in mbmsEntities.Customers where c.CustomerID == customerID select c).FirstOrDefault<Customer>();
            Customer oldCustomer = (from c in mbmsEntities.Customers where c.PreviousID == customerID && c.Active == false select c).FirstOrDefault<Customer>();
            lblAddressEng.Text = customer.CustomerAddressInEng;
            lblAddressMM.Text = customer.CustomerAddressInMM;
            lblBillCodeNo.Text = Convert.ToString(customer.BillCode7Layer.BillCode7LayerNo);
            lblBookCode.Text = Convert.ToString(customer.Ledger.BookCode);
            lblCustomerCode.Text = customer.CustomerCode;
            lblCustomerNameEng.Text = customer.CustomerNameInEng;
            lblCustomerNameMM.Text = customer.CustomerNameInMM;
            lblLineNo.Text = Convert.ToString(customer.LineNo);
            lblPageNo.Text = Convert.ToString(customer.PageNo);
            lblNRC.Text = customer.NRC;
            lblMeterNo.Text = customer.Meter.MeterNo;
            lblPh.Text = customer.PhoneNo;
            lblPostalCode.Text = customer.Post;
            lblQuarterName.Text = customer.Quarter.QuarterNameInEng;
            lblTransformer.Text = customer.Transformer.TransformerName;
            
            if (oldCustomer != null)
            {
                dgvOldList.Show();
                var oldCustomerList = mbmsEntities.Customers.Where(c => c.PreviousID != null && c.Active == false).ToList();
                FormRefresh();
            }
            else
            {
                dgvOldList.Hide();
            }
            //lblTownshipName.Text = customer.Township.TownshipNameInEng;
        }
        #endregion

        #region Method
        public void FormRefresh()
        {
            MBMSEntities mbmsEntities = new MBMSEntities();
            dgvOldList.AutoGenerateColumns = false;
            dgvOldList.DataSource = (from c in mbmsEntities.Customers where c.Active == false && c.PreviousID == customerID orderby c.CustomerCode descending select c).ToList();
        }
        #endregion

        #region Grid Bind
        private void dgvOldList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvOldList.Rows)
            {
                Customer customer = (Customer)row.DataBoundItem;
                row.Cells[0].Value = customer.PreviousID;
                row.Cells[1].Value = customer.Quarter.QuarterNameInEng;
                row.Cells[2].Value = customer.Meter.MeterNo;
                row.Cells[3].Value = customer.CustomerAddressInEng;
            }
        }
        #endregion
    }
}
