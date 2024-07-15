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

namespace MPS.Master_Setup
{
    public partial class TransformerDetailfrm : Form
    {
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String transformerID { get; set; }
        public TransformerDetailfrm()
        {
            InitializeComponent();
        }

        private void TransformerDetailfrm_Load(object sender, EventArgs e)
        {
            Transformer transformer = (from t in mbmsEntities.Transformers where t.TransformerID == transformerID select t).FirstOrDefault<Transformer>();
            lblTransformerName.Text = transformer.TransformerName;
            lblTransformerModel.Text = transformer.Model;
            lblMaker.Text = transformer.Maker;
            lblQuarterName.Text = transformer.Quarter.QuarterNameInEng;
            if (transformer.Status == true)
            {
                lblStatus.Text = "Enable";
            }else
            {
                lblStatus.Text = "Disable";
            }
            
            lblCountry.Text = transformer.CountryOfOrgin;
            lblStandard.Text = transformer.Standard !=""? transformer.Standard:"-" ;
            lblRatedofPower.Text =Convert.ToString( transformer.RatedOutputPower) !=""? Convert.ToString(transformer.RatedOutputPower):"-";
            lblVoltageRatio.Text = Convert.ToString(transformer.VoltageRatio) !=""? Convert.ToString(transformer.VoltageRatio):"-";
            lblVectorGroup.Text = transformer.VectorGroup !=""? transformer.VectorGroup:"-" ;
            lblCooling.Text = transformer.TypeofCooling !=""? transformer.TypeofCooling:"-";
            lblEfficiency.Text =Convert.ToString( transformer.EfficiencyLoad) !=""? Convert.ToString(transformer.EfficiencyLoad):"-";
            lblImpedanceVoltage.Text =Convert.ToString( transformer.ImpendanceVoltage) !=""? Convert.ToString(transformer.ImpendanceVoltage):"-";
            lblNoLoadLoss.Text =Convert.ToString( transformer.NoloadLoss) !=""? Convert.ToString(transformer.NoloadLoss):"-" ;
            lblFullLoadLoss.Text =Convert.ToString( transformer.FullLoadLoss) !=""? Convert.ToString(transformer.FullLoadLoss):"-" ;
            lblTappingRange.Text = transformer.TappingRange;
        }
    }
}
