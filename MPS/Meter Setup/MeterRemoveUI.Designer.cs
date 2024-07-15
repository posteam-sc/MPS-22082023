namespace MPS.Meter_Setup {
    partial class MeterRemoveUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterRemoveUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblinstallationdate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblmeterNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpremoveddate = new System.Windows.Forms.DateTimePicker();
            this.lblcustomername = new System.Windows.Forms.Label();
            this.gbNormal = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.gbDamage = new System.Windows.Forms.GroupBox();
            this.rdoBattery = new System.Windows.Forms.RadioButton();
            this.rdoWatt = new System.Windows.Forms.RadioButton();
            this.rdoLCDError = new System.Windows.Forms.RadioButton();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.rdoLED = new System.Windows.Forms.RadioButton();
            this.rdoPower = new System.Windows.Forms.RadioButton();
            this.rdoCommunication = new System.Windows.Forms.RadioButton();
            this.txtRemoveOtherRemark = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnremove = new System.Windows.Forms.Button();
            this.rdoDamage = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbNormal.SuspendLayout();
            this.gbDamage.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.gbNormal);
            this.groupBox1.Controls.Add(this.rdoNormal);
            this.groupBox1.Controls.Add(this.gbDamage);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnremove);
            this.groupBox1.Controls.Add(this.rdoDamage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(752, 582);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.lblinstallationdate);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.lblmeterNo);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dtpremoveddate);
            this.groupBox4.Controls.Add(this.lblcustomername);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(33, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(622, 184);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Meter Remove Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Meter No:";
            // 
            // lblinstallationdate
            // 
            this.lblinstallationdate.AutoSize = true;
            this.lblinstallationdate.Location = new System.Drawing.Point(338, 96);
            this.lblinstallationdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblinstallationdate.Name = "lblinstallationdate";
            this.lblinstallationdate.Size = new System.Drawing.Size(25, 15);
            this.lblinstallationdate.TabIndex = 0;
            this.lblinstallationdate.Text = "xxx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Remove Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Register Customer:";
            // 
            // lblmeterNo
            // 
            this.lblmeterNo.AutoSize = true;
            this.lblmeterNo.Location = new System.Drawing.Point(338, 22);
            this.lblmeterNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmeterNo.Name = "lblmeterNo";
            this.lblmeterNo.Size = new System.Drawing.Size(25, 15);
            this.lblmeterNo.TabIndex = 0;
            this.lblmeterNo.Text = "xxx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Installation Date:";
            // 
            // dtpremoveddate
            // 
            this.dtpremoveddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpremoveddate.Location = new System.Drawing.Point(332, 138);
            this.dtpremoveddate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpremoveddate.Name = "dtpremoveddate";
            this.dtpremoveddate.Size = new System.Drawing.Size(104, 20);
            this.dtpremoveddate.TabIndex = 1;
            // 
            // lblcustomername
            // 
            this.lblcustomername.AutoSize = true;
            this.lblcustomername.Location = new System.Drawing.Point(338, 57);
            this.lblcustomername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcustomername.Name = "lblcustomername";
            this.lblcustomername.Size = new System.Drawing.Size(25, 15);
            this.lblcustomername.TabIndex = 0;
            this.lblcustomername.Text = "xxx";
            // 
            // gbNormal
            // 
            this.gbNormal.Controls.Add(this.label5);
            this.gbNormal.Controls.Add(this.txtRemark);
            this.gbNormal.Location = new System.Drawing.Point(440, 224);
            this.gbNormal.Name = "gbNormal";
            this.gbNormal.Size = new System.Drawing.Size(302, 186);
            this.gbNormal.TabIndex = 5;
            this.gbNormal.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Remark:";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(10, 61);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(284, 118);
            this.txtRemark.TabIndex = 1;
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNormal.Location = new System.Drawing.Point(450, 205);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(66, 19);
            this.rdoNormal.TabIndex = 0;
            this.rdoNormal.TabStop = true;
            this.rdoNormal.Text = "Normal";
            this.rdoNormal.UseVisualStyleBackColor = true;
            this.rdoNormal.CheckedChanged += new System.EventHandler(this.rdoNormal_CheckedChanged);
            // 
            // gbDamage
            // 
            this.gbDamage.Controls.Add(this.rdoBattery);
            this.gbDamage.Controls.Add(this.rdoWatt);
            this.gbDamage.Controls.Add(this.rdoLCDError);
            this.gbDamage.Controls.Add(this.rdoOther);
            this.gbDamage.Controls.Add(this.rdoLED);
            this.gbDamage.Controls.Add(this.rdoPower);
            this.gbDamage.Controls.Add(this.rdoCommunication);
            this.gbDamage.Controls.Add(this.txtRemoveOtherRemark);
            this.gbDamage.Location = new System.Drawing.Point(33, 224);
            this.gbDamage.Name = "gbDamage";
            this.gbDamage.Size = new System.Drawing.Size(382, 274);
            this.gbDamage.TabIndex = 4;
            this.gbDamage.TabStop = false;
            // 
            // rdoBattery
            // 
            this.rdoBattery.AutoSize = true;
            this.rdoBattery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBattery.Location = new System.Drawing.Point(226, 98);
            this.rdoBattery.Name = "rdoBattery";
            this.rdoBattery.Size = new System.Drawing.Size(92, 19);
            this.rdoBattery.TabIndex = 9;
            this.rdoBattery.Text = "Battery Error";
            this.rdoBattery.UseVisualStyleBackColor = true;
            this.rdoBattery.CheckedChanged += new System.EventHandler(this.rdoBattery_CheckedChanged);
            // 
            // rdoWatt
            // 
            this.rdoWatt.AutoSize = true;
            this.rdoWatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoWatt.Location = new System.Drawing.Point(226, 61);
            this.rdoWatt.Name = "rdoWatt";
            this.rdoWatt.Size = new System.Drawing.Size(110, 19);
            this.rdoWatt.TabIndex = 9;
            this.rdoWatt.Text = "Watt-Hour Error";
            this.rdoWatt.UseVisualStyleBackColor = true;
            this.rdoWatt.CheckedChanged += new System.EventHandler(this.rdoWatt_CheckedChanged);
            // 
            // rdoLCDError
            // 
            this.rdoLCDError.AutoSize = true;
            this.rdoLCDError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLCDError.Location = new System.Drawing.Point(226, 30);
            this.rdoLCDError.Name = "rdoLCDError";
            this.rdoLCDError.Size = new System.Drawing.Size(79, 19);
            this.rdoLCDError.TabIndex = 9;
            this.rdoLCDError.Text = "LCD Error";
            this.rdoLCDError.UseVisualStyleBackColor = true;
            this.rdoLCDError.CheckedChanged += new System.EventHandler(this.rdoLCDError_CheckedChanged);
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoOther.Location = new System.Drawing.Point(22, 143);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(61, 19);
            this.rdoOther.TabIndex = 9;
            this.rdoOther.Text = "Others";
            this.rdoOther.UseVisualStyleBackColor = true;
            this.rdoOther.CheckedChanged += new System.EventHandler(this.rdoOther_CheckedChanged);
            // 
            // rdoLED
            // 
            this.rdoLED.AutoSize = true;
            this.rdoLED.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLED.Location = new System.Drawing.Point(22, 102);
            this.rdoLED.Name = "rdoLED";
            this.rdoLED.Size = new System.Drawing.Size(79, 19);
            this.rdoLED.TabIndex = 9;
            this.rdoLED.Text = "LED Error";
            this.rdoLED.UseVisualStyleBackColor = true;
            this.rdoLED.CheckedChanged += new System.EventHandler(this.rdoLED_CheckedChanged);
            // 
            // rdoPower
            // 
            this.rdoPower.AutoSize = true;
            this.rdoPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPower.Location = new System.Drawing.Point(22, 65);
            this.rdoPower.Name = "rdoPower";
            this.rdoPower.Size = new System.Drawing.Size(87, 19);
            this.rdoPower.TabIndex = 9;
            this.rdoPower.Text = "PowerError";
            this.rdoPower.UseVisualStyleBackColor = true;
            this.rdoPower.CheckedChanged += new System.EventHandler(this.rdoPower_CheckedChanged);
            // 
            // rdoCommunication
            // 
            this.rdoCommunication.AutoSize = true;
            this.rdoCommunication.Checked = true;
            this.rdoCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCommunication.Location = new System.Drawing.Point(22, 32);
            this.rdoCommunication.Name = "rdoCommunication";
            this.rdoCommunication.Size = new System.Drawing.Size(142, 19);
            this.rdoCommunication.TabIndex = 9;
            this.rdoCommunication.TabStop = true;
            this.rdoCommunication.Text = "Communication Error";
            this.rdoCommunication.UseVisualStyleBackColor = true;
            this.rdoCommunication.CheckedChanged += new System.EventHandler(this.rdoCommunication_CheckedChanged);
            // 
            // txtRemoveOtherRemark
            // 
            this.txtRemoveOtherRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemoveOtherRemark.Location = new System.Drawing.Point(22, 173);
            this.txtRemoveOtherRemark.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemoveOtherRemark.Multiline = true;
            this.txtRemoveOtherRemark.Name = "txtRemoveOtherRemark";
            this.txtRemoveOtherRemark.Size = new System.Drawing.Size(344, 94);
            this.txtRemoveOtherRemark.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(457, 521);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnremove
            // 
            this.btnremove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnremove.Location = new System.Drawing.Point(327, 521);
            this.btnremove.Margin = new System.Windows.Forms.Padding(4);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(100, 35);
            this.btnremove.TabIndex = 1;
            this.btnremove.Text = "&Remove";
            this.btnremove.UseVisualStyleBackColor = true;
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // rdoDamage
            // 
            this.rdoDamage.AutoSize = true;
            this.rdoDamage.Checked = true;
            this.rdoDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDamage.Location = new System.Drawing.Point(39, 205);
            this.rdoDamage.Name = "rdoDamage";
            this.rdoDamage.Size = new System.Drawing.Size(73, 19);
            this.rdoDamage.TabIndex = 0;
            this.rdoDamage.TabStop = true;
            this.rdoDamage.Text = "Damage";
            this.rdoDamage.UseVisualStyleBackColor = true;
            this.rdoDamage.CheckedChanged += new System.EventHandler(this.rdoDamage_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "MM/DD/YY";
            // 
            // MeterRemoveUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(796, 606);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MeterRemoveUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter Remove ";
            this.Load += new System.EventHandler(this.MeterRemoveUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbNormal.ResumeLayout(false);
            this.gbNormal.PerformLayout();
            this.gbDamage.ResumeLayout(false);
            this.gbDamage.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblmeterNo;
        private System.Windows.Forms.Label lblcustomername;
        private System.Windows.Forms.Label lblinstallationdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpremoveddate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnremove;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gbNormal;
        private System.Windows.Forms.RadioButton rdoNormal;
        private System.Windows.Forms.GroupBox gbDamage;
        private System.Windows.Forms.RadioButton rdoDamage;
        private System.Windows.Forms.TextBox txtRemoveOtherRemark;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rdoWatt;
        private System.Windows.Forms.RadioButton rdoLCDError;
        private System.Windows.Forms.RadioButton rdoPower;
        private System.Windows.Forms.RadioButton rdoCommunication;
        private System.Windows.Forms.RadioButton rdoBattery;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.RadioButton rdoLED;
        private System.Windows.Forms.Label label6;
    }
    }