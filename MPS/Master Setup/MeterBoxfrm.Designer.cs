namespace MPS
{
    partial class MeterBoxfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterBoxfrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeterBoxCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMeterBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTransfomerName = new System.Windows.Forms.TextBox();
            this.cboPoleNo = new System.Windows.Forms.ComboBox();
            this.txtQuarterName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboMeterBoxName = new System.Windows.Forms.ComboBox();
            this.dgvMeterboxList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchMeterBoxCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSearchPoleNo = new System.Windows.Forms.ComboBox();
            this.cboSearchQuarterName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterboxList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Meter Box Code";
            // 
            // txtMeterBoxCode
            // 
            this.txtMeterBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterBoxCode.Location = new System.Drawing.Point(342, 70);
            this.txtMeterBoxCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMeterBoxCode.MaxLength = 7;
            this.txtMeterBoxCode.Name = "txtMeterBoxCode";
            this.txtMeterBoxCode.Size = new System.Drawing.Size(161, 20);
            this.txtMeterBoxCode.TabIndex = 2;
            this.txtMeterBoxCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMeterBoxCode_KeyDown);
            this.txtMeterBoxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMeterBoxCode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Meter Box Sequence";
            // 
            // txtMeterBox
            // 
            this.txtMeterBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMeterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterBox.Location = new System.Drawing.Point(168, 145);
            this.txtMeterBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMeterBox.MaxLength = 1;
            this.txtMeterBox.Name = "txtMeterBox";
            this.txtMeterBox.Size = new System.Drawing.Size(153, 20);
            this.txtMeterBox.TabIndex = 4;
            this.txtMeterBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMeterBox_KeyDown);
            this.txtMeterBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMeterBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pole No";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(168, 256);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 32);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(317, 256);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(143, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(143, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(165, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "* is Mandatory Field";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quarter Name ";
            // 
            // txtTransfomerName
            // 
            this.txtTransfomerName.Enabled = false;
            this.txtTransfomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransfomerName.Location = new System.Drawing.Point(168, 70);
            this.txtTransfomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTransfomerName.Name = "txtTransfomerName";
            this.txtTransfomerName.Size = new System.Drawing.Size(168, 20);
            this.txtTransfomerName.TabIndex = 1;
            this.txtTransfomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuarterName_KeyDown);
            // 
            // cboPoleNo
            // 
            this.cboPoleNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPoleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPoleNo.FormattingEnabled = true;
            this.cboPoleNo.Location = new System.Drawing.Point(168, 35);
            this.cboPoleNo.Name = "cboPoleNo";
            this.cboPoleNo.Size = new System.Drawing.Size(233, 21);
            this.cboPoleNo.TabIndex = 0;
            this.cboPoleNo.SelectedIndexChanged += new System.EventHandler(this.cboPoleNo_SelectedIndexChanged);
            this.cboPoleNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboPoleNo_KeyDown);
            // 
            // txtQuarterName
            // 
            this.txtQuarterName.Enabled = false;
            this.txtQuarterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuarterName.Location = new System.Drawing.Point(168, 107);
            this.txtQuarterName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuarterName.Name = "txtQuarterName";
            this.txtQuarterName.Size = new System.Drawing.Size(233, 20);
            this.txtQuarterName.TabIndex = 3;
            this.txtQuarterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuarterName_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(143, 193);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Meter Box Type";
            // 
            // cboMeterBoxName
            // 
            this.cboMeterBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeterBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMeterBoxName.FormattingEnabled = true;
            this.cboMeterBoxName.Location = new System.Drawing.Point(168, 187);
            this.cboMeterBoxName.Name = "cboMeterBoxName";
            this.cboMeterBoxName.Size = new System.Drawing.Size(233, 21);
            this.cboMeterBoxName.TabIndex = 5;
            this.cboMeterBoxName.SelectedIndexChanged += new System.EventHandler(this.cboPoleNo_SelectedIndexChanged);
            this.cboMeterBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboPoleNo_KeyDown);
            // 
            // dgvMeterboxList
            // 
            this.dgvMeterboxList.AllowUserToAddRows = false;
            this.dgvMeterboxList.AllowUserToDeleteRows = false;
            this.dgvMeterboxList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeterboxList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column4,
            this.Column8,
            this.Column3,
            this.Column6,
            this.Column7});
            this.dgvMeterboxList.Location = new System.Drawing.Point(6, 154);
            this.dgvMeterboxList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMeterboxList.Name = "dgvMeterboxList";
            this.dgvMeterboxList.ReadOnly = true;
            this.dgvMeterboxList.Size = new System.Drawing.Size(700, 328);
            this.dgvMeterboxList.TabIndex = 8;
            this.dgvMeterboxList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeterboxList_CellClick);
            this.dgvMeterboxList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMeterboxList_DataBindingComplete);
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
            this.Column2.HeaderText = "Meter Box Code";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Pole Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quarter Name";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 110;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Meter Box Name";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Meter Box";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Text = "Edit";
            this.Column6.UseColumnTextForLinkValue = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Text = "Delete";
            this.Column7.UseColumnTextForLinkValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cboMeterBoxName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtQuarterName);
            this.groupBox1.Controls.Add(this.txtMeterBoxCode);
            this.groupBox1.Controls.Add(this.txtMeterBox);
            this.groupBox1.Controls.Add(this.txtTransfomerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cboPoleNo);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 312);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Register";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtSearchMeterBoxCode);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dgvMeterboxList);
            this.groupBox2.Controls.Add(this.cboSearchPoleNo);
            this.groupBox2.Controls.Add(this.cboSearchQuarterName);
            this.groupBox2.Location = new System.Drawing.Point(571, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(712, 498);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search List";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(579, 93);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 31);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(478, 95);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 31);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "S&earch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchMeterBoxCode
            // 
            this.txtSearchMeterBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchMeterBoxCode.Location = new System.Drawing.Point(165, 38);
            this.txtSearchMeterBoxCode.Name = "txtSearchMeterBoxCode";
            this.txtSearchMeterBoxCode.Size = new System.Drawing.Size(187, 20);
            this.txtSearchMeterBoxCode.TabIndex = 0;
            this.txtSearchMeterBoxCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchMeterBoxCode_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(420, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Pole No";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "Quarter Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Meter Box Code";
            // 
            // cboSearchPoleNo
            // 
            this.cboSearchPoleNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchPoleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchPoleNo.FormattingEnabled = true;
            this.cboSearchPoleNo.Location = new System.Drawing.Point(478, 37);
            this.cboSearchPoleNo.Name = "cboSearchPoleNo";
            this.cboSearchPoleNo.Size = new System.Drawing.Size(187, 21);
            this.cboSearchPoleNo.TabIndex = 1;
            this.cboSearchPoleNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSearchPoleNo_KeyDown);
            // 
            // cboSearchQuarterName
            // 
            this.cboSearchQuarterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchQuarterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchQuarterName.FormattingEnabled = true;
            this.cboSearchQuarterName.Location = new System.Drawing.Point(165, 95);
            this.cboSearchQuarterName.Name = "cboSearchQuarterName";
            this.cboSearchQuarterName.Size = new System.Drawing.Size(187, 21);
            this.cboSearchQuarterName.TabIndex = 2;
            this.cboSearchQuarterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSearchQuarterName_KeyDown);
            // 
            // MeterBoxfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1294, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MeterBoxfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter Box Registration";
            this.Load += new System.EventHandler(this.MeterBoxfrm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MeterBoxfrm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterboxList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeterBoxCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMeterBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvMeterboxList;
        private System.Windows.Forms.ComboBox cboPoleNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuarterName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchMeterBoxCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSearchPoleNo;
        private System.Windows.Forms.ComboBox cboSearchQuarterName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboMeterBoxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.TextBox txtTransfomerName;
    }
}