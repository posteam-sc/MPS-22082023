namespace MPS.Meter_Setup
{
    partial class MeterListfrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterListfrm));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboMeterTypeCode = new System.Windows.Forms.ComboBox();
            this.cboMeterBoxCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeterNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboPole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTransformer = new System.Windows.Forms.ComboBox();
            this.dgvMeterList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Remove = new System.Windows.Forms.DataGridViewLinkColumn();
            this.rdounregistermeter = new System.Windows.Forms.RadioButton();
            this.rdoregistermeter = new System.Windows.Forms.RadioButton();
            this.rdoremovedmeter = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRemoveMeter = new System.Windows.Forms.DataGridView();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemoveMeter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(932, 81);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 33);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cboMeterTypeCode
            // 
            this.cboMeterTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeterTypeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMeterTypeCode.FormattingEnabled = true;
            this.cboMeterTypeCode.Location = new System.Drawing.Point(486, 85);
            this.cboMeterTypeCode.Name = "cboMeterTypeCode";
            this.cboMeterTypeCode.Size = new System.Drawing.Size(176, 21);
            this.cboMeterTypeCode.TabIndex = 4;
            // 
            // cboMeterBoxCode
            // 
            this.cboMeterBoxCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeterBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMeterBoxCode.FormattingEnabled = true;
            this.cboMeterBoxCode.Location = new System.Drawing.Point(486, 30);
            this.cboMeterBoxCode.Name = "cboMeterBoxCode";
            this.cboMeterBoxCode.Size = new System.Drawing.Size(176, 21);
            this.cboMeterBoxCode.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(363, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Meter Type Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(363, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "MeterBox Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pole:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(781, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Meter No:";
            // 
            // txtMeterNo
            // 
            this.txtMeterNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterNo.Location = new System.Drawing.Point(850, 27);
            this.txtMeterNo.Name = "txtMeterNo";
            this.txtMeterNo.Size = new System.Drawing.Size(176, 20);
            this.txtMeterNo.TabIndex = 0;
            this.txtMeterNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMeterNo_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(784, 81);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 33);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboPole
            // 
            this.cboPole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPole.FormattingEnabled = true;
            this.cboPole.Location = new System.Drawing.Point(92, 81);
            this.cboPole.Name = "cboPole";
            this.cboPole.Size = new System.Drawing.Size(175, 21);
            this.cboPole.TabIndex = 3;
            this.cboPole.SelectedIndexChanged += new System.EventHandler(this.cboPole_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Transformer:";
            // 
            // cboTransformer
            // 
            this.cboTransformer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransformer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTransformer.FormattingEnabled = true;
            this.cboTransformer.Location = new System.Drawing.Point(92, 27);
            this.cboTransformer.Name = "cboTransformer";
            this.cboTransformer.Size = new System.Drawing.Size(176, 21);
            this.cboTransformer.TabIndex = 2;
            this.cboTransformer.SelectedIndexChanged += new System.EventHandler(this.cboTransformer_SelectedIndexChanged);
            // 
            // dgvMeterList
            // 
            this.dgvMeterList.AllowUserToAddRows = false;
            this.dgvMeterList.AllowUserToDeleteRows = false;
            this.dgvMeterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Remove});
            this.dgvMeterList.Location = new System.Drawing.Point(12, 194);
            this.dgvMeterList.Name = "dgvMeterList";
            this.dgvMeterList.ReadOnly = true;
            this.dgvMeterList.Size = new System.Drawing.Size(1244, 453);
            this.dgvMeterList.TabIndex = 1;
            this.dgvMeterList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeterList_CellClick);
            this.dgvMeterList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMeterList_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Meter No";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Meter Model";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Install Date ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Transformer";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Pole";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Status";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Meter Box Code";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Meter Box Sequence";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Meter Type Code";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Text = "View Detail";
            this.Column11.UseColumnTextForLinkValue = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Text = "Edit";
            this.Column12.UseColumnTextForLinkValue = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Text = "Delete";
            this.Column13.UseColumnTextForLinkValue = true;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "Remove";
            this.Remove.UseColumnTextForLinkValue = true;
            // 
            // rdounregistermeter
            // 
            this.rdounregistermeter.AutoSize = true;
            this.rdounregistermeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdounregistermeter.Location = new System.Drawing.Point(223, 132);
            this.rdounregistermeter.Name = "rdounregistermeter";
            this.rdounregistermeter.Size = new System.Drawing.Size(139, 19);
            this.rdounregistermeter.TabIndex = 8;
            this.rdounregistermeter.Text = "Unregister Meter List";
            this.rdounregistermeter.UseVisualStyleBackColor = true;
            this.rdounregistermeter.CheckedChanged += new System.EventHandler(this.rdounregistermeter_CheckedChanged);
            // 
            // rdoregistermeter
            // 
            this.rdoregistermeter.AutoSize = true;
            this.rdoregistermeter.Checked = true;
            this.rdoregistermeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoregistermeter.Location = new System.Drawing.Point(74, 132);
            this.rdoregistermeter.Name = "rdoregistermeter";
            this.rdoregistermeter.Size = new System.Drawing.Size(128, 19);
            this.rdoregistermeter.TabIndex = 7;
            this.rdoregistermeter.TabStop = true;
            this.rdoregistermeter.Text = "Register Meter List";
            this.rdoregistermeter.UseVisualStyleBackColor = true;
            this.rdoregistermeter.CheckedChanged += new System.EventHandler(this.rdounregistermeter_CheckedChanged);
            // 
            // rdoremovedmeter
            // 
            this.rdoremovedmeter.AutoSize = true;
            this.rdoremovedmeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoremovedmeter.Location = new System.Drawing.Point(386, 132);
            this.rdoremovedmeter.Name = "rdoremovedmeter";
            this.rdoremovedmeter.Size = new System.Drawing.Size(193, 19);
            this.rdoremovedmeter.TabIndex = 9;
            this.rdoremovedmeter.Text = "Removed/Damaged Meter List";
            this.rdoremovedmeter.UseVisualStyleBackColor = true;
            this.rdoremovedmeter.CheckedChanged += new System.EventHandler(this.rdounregistermeter_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdounregistermeter);
            this.groupBox1.Controls.Add(this.cboTransformer);
            this.groupBox1.Controls.Add(this.rdoregistermeter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboMeterBoxCode);
            this.groupBox1.Controls.Add(this.cboMeterTypeCode);
            this.groupBox1.Controls.Add(this.rdoremovedmeter);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboPole);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMeterNo);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1070, 176);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // dgvRemoveMeter
            // 
            this.dgvRemoveMeter.AllowUserToAddRows = false;
            this.dgvRemoveMeter.AllowUserToDeleteRows = false;
            this.dgvRemoveMeter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemoveMeter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20});
            this.dgvRemoveMeter.Location = new System.Drawing.Point(12, 195);
            this.dgvRemoveMeter.Name = "dgvRemoveMeter";
            this.dgvRemoveMeter.ReadOnly = true;
            this.dgvRemoveMeter.Size = new System.Drawing.Size(1244, 452);
            this.dgvRemoveMeter.TabIndex = 2;
            this.dgvRemoveMeter.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRemoveMeter_DataBindingComplete);
            // 
            // Column14
            // 
            this.Column14.HeaderText = "MeterHistoryID";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Old Meter No";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 150;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Used Customer Code";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 150;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Used Customer Name";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 200;
            // 
            // Column18
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Column18.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column18.HeaderText = "Remove Date";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 150;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "Remark";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Width = 150;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "Damage Type";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.Width = 150;
            // 
            // MeterListfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1326, 658);
            this.Controls.Add(this.dgvRemoveMeter);
            this.Controls.Add(this.dgvMeterList);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeterListfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter List";
            this.Load += new System.EventHandler(this.MeterListfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemoveMeter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboMeterTypeCode;
        private System.Windows.Forms.ComboBox cboMeterBoxCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeterNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboPole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTransformer;
        private System.Windows.Forms.DataGridView dgvMeterList;
        private System.Windows.Forms.RadioButton rdounregistermeter;
        private System.Windows.Forms.RadioButton rdoregistermeter;
        private System.Windows.Forms.RadioButton rdoremovedmeter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewLinkColumn Column11;
        private System.Windows.Forms.DataGridViewLinkColumn Column12;
        private System.Windows.Forms.DataGridViewLinkColumn Column13;
        private System.Windows.Forms.DataGridViewLinkColumn Remove;
        private System.Windows.Forms.DataGridView dgvRemoveMeter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
    }
}