using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
namespace MPS {
    public partial class VersionInfo : Form{
        public VersionInfo(){
            InitializeComponent();
        }
        private void VersionInfo_Load(object sender, EventArgs e) {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            lblproductversion.Text = versionInfo.ProductVersion;
            lblcopyright.Text = versionInfo.LegalCopyright;
            lblcontact.Visible = lblcontact1.Visible = lblcontact2.Visible = true;
        }
    }
}
