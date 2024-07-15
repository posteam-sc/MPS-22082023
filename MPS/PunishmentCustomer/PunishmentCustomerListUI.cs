using MPS.BusinessLogic.PunishmentCustomerController;
using MPS.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.PunishmentCustomerList
{
    public partial class PunishmentCustomerListUI : Form
    {
        #region Variables
        IPunishmentCustomerServices service = null;
        #endregion
        public PunishmentCustomerListUI()
        {
            InitializeComponent();
            service = new PunishmentCustomerController();
        }

        #region Form Load
        private void PunishmentCustomerListUI_Load(object sender, EventArgs e)
        {
            dtpfromDate.Format = DateTimePickerFormat.Custom;
            dtpfromDate.CustomFormat = "MM/dd/yyyy";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "MM/dd/yyyy";
            pageRefresh();
        }
        #endregion

        #region Method
        private void pageRefresh()
        {
            gvpunishmentCustomer.AutoGenerateColumns = false;
            this.gvpunishmentCustomer.DataSource = service.GetPunishmentCustomer();
        }
        #endregion

        #region Button Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            gvpunishmentCustomer.DataSource = null;
            gvpunishmentCustomer.AutoGenerateColumns = false;
            List<PunishmentCustomerVM> data = service.GetPunishmentCustomerByFromDateCustomerID(dtpfromDate.Value, dtpToDate.Value);
            if (data.Count == 0)
            {
                MessageBox.Show("There is no data to show");

            }
            else
            {
                this.gvpunishmentCustomer.DataSource = data;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtpfromDate.Value = dtpToDate.Value = DateTime.Now;
            gvpunishmentCustomer.DataSource = null;
        }
        #endregion
    }
}
