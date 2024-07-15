namespace MPS.Reports
{
    partial class frmBillingReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBillingReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoCurrentWithArrear = new System.Windows.Forms.RadioButton();
            this.rdoCurrentList = new System.Windows.Forms.RadioButton();
            this.rdoArrear = new System.Windows.Forms.RadioButton();
            this.rdoAdvance = new System.Windows.Forms.RadioButton();
            this.rdoLedger = new System.Windows.Forms.RadioButton();
            this.rdoBillCode = new System.Windows.Forms.RadioButton();
            this.rvBillReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboLineNo = new System.Windows.Forms.ComboBox();
            this.cboPageNo = new System.Windows.Forms.ComboBox();
            this.cboBookCode = new System.Windows.Forms.ComboBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoCurrentWithArrear);
            this.groupBox1.Controls.Add(this.rdoCurrentList);
            this.groupBox1.Controls.Add(this.rdoArrear);
            this.groupBox1.Controls.Add(this.rdoAdvance);
            this.groupBox1.Controls.Add(this.rdoLedger);
            this.groupBox1.Controls.Add(this.rdoBillCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 241);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdoCurrentWithArrear
            // 
            this.rdoCurrentWithArrear.AutoSize = true;
            this.rdoCurrentWithArrear.Checked = true;
            this.rdoCurrentWithArrear.Location = new System.Drawing.Point(6, 202);
            this.rdoCurrentWithArrear.Name = "rdoCurrentWithArrear";
            this.rdoCurrentWithArrear.Size = new System.Drawing.Size(148, 19);
            this.rdoCurrentWithArrear.TabIndex = 5;
            this.rdoCurrentWithArrear.TabStop = true;
            this.rdoCurrentWithArrear.Text = "Current List with Arrear";
            this.rdoCurrentWithArrear.UseVisualStyleBackColor = true;
            this.rdoCurrentWithArrear.CheckedChanged += new System.EventHandler(this.rdoCurrentWithArrear_CheckedChanged);
            // 
            // rdoCurrentList
            // 
            this.rdoCurrentList.AutoSize = true;
            this.rdoCurrentList.Location = new System.Drawing.Point(6, 166);
            this.rdoCurrentList.Name = "rdoCurrentList";
            this.rdoCurrentList.Size = new System.Drawing.Size(87, 19);
            this.rdoCurrentList.TabIndex = 4;
            this.rdoCurrentList.Text = "Current List";
            this.rdoCurrentList.UseVisualStyleBackColor = true;
            this.rdoCurrentList.CheckedChanged += new System.EventHandler(this.rdoCurrentList_CheckedChanged);
            // 
            // rdoArrear
            // 
            this.rdoArrear.AutoSize = true;
            this.rdoArrear.Location = new System.Drawing.Point(6, 130);
            this.rdoArrear.Name = "rdoArrear";
            this.rdoArrear.Size = new System.Drawing.Size(86, 19);
            this.rdoArrear.TabIndex = 3;
            this.rdoArrear.Text = "Arrears List";
            this.rdoArrear.UseVisualStyleBackColor = true;
            this.rdoArrear.CheckedChanged += new System.EventHandler(this.rdoArrear_CheckedChanged);
            // 
            // rdoAdvance
            // 
            this.rdoAdvance.AutoSize = true;
            this.rdoAdvance.Location = new System.Drawing.Point(6, 92);
            this.rdoAdvance.Name = "rdoAdvance";
            this.rdoAdvance.Size = new System.Drawing.Size(93, 19);
            this.rdoAdvance.TabIndex = 2;
            this.rdoAdvance.Text = "Advance List";
            this.rdoAdvance.UseVisualStyleBackColor = true;
            this.rdoAdvance.CheckedChanged += new System.EventHandler(this.rdoAdvance_CheckedChanged);
            // 
            // rdoLedger
            // 
            this.rdoLedger.AutoSize = true;
            this.rdoLedger.Location = new System.Drawing.Point(6, 54);
            this.rdoLedger.Name = "rdoLedger";
            this.rdoLedger.Size = new System.Drawing.Size(120, 19);
            this.rdoLedger.TabIndex = 1;
            this.rdoLedger.Text = "Ledger Summary";
            this.rdoLedger.UseVisualStyleBackColor = true;
            this.rdoLedger.CheckedChanged += new System.EventHandler(this.rdoLedger_CheckedChanged);
            // 
            // rdoBillCode
            // 
            this.rdoBillCode.AutoSize = true;
            this.rdoBillCode.Location = new System.Drawing.Point(6, 19);
            this.rdoBillCode.Name = "rdoBillCode";
            this.rdoBillCode.Size = new System.Drawing.Size(130, 19);
            this.rdoBillCode.TabIndex = 0;
            this.rdoBillCode.Text = "Bill Code Summary";
            this.rdoBillCode.UseVisualStyleBackColor = true;
            this.rdoBillCode.CheckedChanged += new System.EventHandler(this.rdoBillCode_CheckedChanged);
            // 
            // rvBillReport
            // 
            this.rvBillReport.Location = new System.Drawing.Point(190, 126);
            this.rvBillReport.Name = "rvBillReport";
            this.rvBillReport.Size = new System.Drawing.Size(1085, 478);
            this.rvBillReport.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.cboLineNo);
            this.groupBox2.Controls.Add(this.cboPageNo);
            this.groupBox2.Controls.Add(this.cboBookCode);
            this.groupBox2.Controls.Add(this.dtpToDate);
            this.groupBox2.Controls.Add(this.dtpFromDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1226, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(877, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSearch);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1009, 54);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboLineNo
            // 
            this.cboLineNo.Enabled = false;
            this.cboLineNo.FormattingEnabled = true;
            this.cboLineNo.Location = new System.Drawing.Point(1028, 14);
            this.cboLineNo.Name = "cboLineNo";
            this.cboLineNo.Size = new System.Drawing.Size(84, 21);
            this.cboLineNo.TabIndex = 4;
            // 
            // cboPageNo
            // 
            this.cboPageNo.Enabled = false;
            this.cboPageNo.FormattingEnabled = true;
            this.cboPageNo.Location = new System.Drawing.Point(909, 13);
            this.cboPageNo.Name = "cboPageNo";
            this.cboPageNo.Size = new System.Drawing.Size(84, 21);
            this.cboPageNo.TabIndex = 3;
            // 
            // cboBookCode
            // 
            this.cboBookCode.Enabled = false;
            this.cboBookCode.FormattingEnabled = true;
            this.cboBookCode.Location = new System.Drawing.Point(671, 16);
            this.cboBookCode.Name = "cboBookCode";
            this.cboBookCode.Size = new System.Drawing.Size(84, 21);
            this.cboBookCode.TabIndex = 2;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(364, 16);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(116, 20);
            this.dtpToDate.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(77, 16);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(116, 20);
            this.dtpFromDate.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(486, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "MM/DD/YY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "MM/DD/YY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1004, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(793, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Page No/Line No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Book Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // frmBillingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 601);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rvBillReport);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBillingReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter Bill Report";
            this.Load += new System.EventHandler(this.frmBillingReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoArrear;
        private System.Windows.Forms.RadioButton rdoAdvance;
        private System.Windows.Forms.RadioButton rdoLedger;
        private System.Windows.Forms.RadioButton rdoBillCode;
        private System.Windows.Forms.RadioButton rdoCurrentWithArrear;
        private System.Windows.Forms.RadioButton rdoCurrentList;
        private Microsoft.Reporting.WinForms.ReportViewer rvBillReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboLineNo;
        private System.Windows.Forms.ComboBox cboPageNo;
        private System.Windows.Forms.ComboBox cboBookCode;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
    }
}