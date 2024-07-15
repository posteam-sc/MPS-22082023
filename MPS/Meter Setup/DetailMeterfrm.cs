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

namespace MPS.Meter_Setup
{
    public partial class DetailMeterfrm : Form
    {
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String meterID { get; set; }
        public DetailMeterfrm()
        {
            InitializeComponent();
        }

        private void DetailMeterfrm_Load(object sender, EventArgs e)
        {
            Meter meter = (from m in mbmsEntities.Meters where m.MeterID == meterID select m).FirstOrDefault<Meter>();
            lblMeterNo.Text = meter.MeterNo;
            lblMeterModel.Text = meter.Model;
            lblInstallDate.Text =Convert.ToString( meter.InstalledDate);
            lblVoltage.Text =Convert.ToString( meter.Voltage);
            lblManufacture.Text = meter.ManufactureBy;
            if (meter.Status == true)
                lblStatus.Text = "Enable";
            else
                lblStatus.Text = "Disable";
            lblMeterboxCode.Text = meter.MeterBox.MeterBoxCode;
            lblMeterboxSequence.Text = meter.MeterBoxSequence;
            lblMeterTypeCode.Text = meter.MeterType.MeterTypeCode;

            lblAvailableYear.Text =Convert.ToString( meter.AvailableYear);
            lblPhrase.Text = meter.Phrase;
            lblWire.Text = meter.Wire;
            lblBasicCurrent.Text = meter.BasicCurrent;
            lblClass.Text = meter.Class !=""? meter.Class :"-";
            lblConstant.Text = meter.Constant !=""? meter.Constant:"-";


            lblAMP.Text = meter.AMP != "" ? meter.AMP: "-";
            lblFrequency.Text =Convert.ToString( meter.Frequency) != "" ?Convert.ToString( meter.Frequency): "-";
            lblHP.Text= Convert.ToString(meter.HP) != "" ? Convert.ToString(meter.HP) : "-";
            lbliMax.Text = Convert.ToString(meter.iMax) != "" ? Convert.ToString(meter.iMax) : "-";
            lblKVA.Text = Convert.ToString(meter.KVA) != "" ? Convert.ToString(meter.KVA) : "-";
            lblMultiplier.Text = Convert.ToString(meter.Multiplier) != "" ? Convert.ToString(meter.Multiplier) : "-";
            lblStandard.Text= Convert.ToString(meter.Standard) != "" ? Convert.ToString(meter.Standard) : "-";
            lblLosses.Text = Convert.ToString(meter.Losses) != "" ? Convert.ToString(meter.Losses) : "-";

        }
    }
}
