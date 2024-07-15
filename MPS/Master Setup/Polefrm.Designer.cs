namespace MPS
{
    partial class Polefrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Polefrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPoleNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGPSX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGPSY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTransformerName = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTransformerCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuarterName = new System.Windows.Forms.TextBox();
            this.dgvPoleList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearchPoleName = new System.Windows.Forms.TextBox();
            this.cboSearchQuarterName = new System.Windows.Forms.ComboBox();
            this.cboSearchTransformerName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoleList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pole No. ";
            // 
            // txtPoleNo
            // 
            this.txtPoleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoleNo.Location = new System.Drawing.Point(327, 87);
            this.txtPoleNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPoleNo.MaxLength = 7;
            this.txtPoleNo.Name = "txtPoleNo";
            this.txtPoleNo.Size = new System.Drawing.Size(142, 20);
            this.txtPoleNo.TabIndex = 2;
            this.txtPoleNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPoleNo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "GPS  Latitude";
            // 
            // txtGPSX
            // 
            this.txtGPSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPSX.Location = new System.Drawing.Point(196, 181);
            this.txtGPSX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGPSX.Name = "txtGPSX";
            this.txtGPSX.Size = new System.Drawing.Size(223, 20);
            this.txtGPSX.TabIndex = 4;
            this.txtGPSX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGPSX_KeyDown);
            this.txtGPSX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGPSX_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "GPS Longitude";
            // 
            // txtGPSY
            // 
            this.txtGPSY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPSY.Location = new System.Drawing.Point(196, 231);
            this.txtGPSY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGPSY.Name = "txtGPSY";
            this.txtGPSY.Size = new System.Drawing.Size(223, 20);
            this.txtGPSY.TabIndex = 5;
            this.txtGPSY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGPSY_KeyDown);
            this.txtGPSY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGPSY_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Transformer Name";
            // 
            // cboTransformerName
            // 
            this.cboTransformerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransformerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTransformerName.FormattingEnabled = true;
            this.cboTransformerName.Location = new System.Drawing.Point(196, 36);
            this.cboTransformerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTransformerName.Name = "cboTransformerName";
            this.cboTransformerName.Size = new System.Drawing.Size(223, 21);
            this.cboTransformerName.TabIndex = 0;
            this.cboTransformerName.SelectedIndexChanged += new System.EventHandler(this.cboTransformerName_SelectedIndexChanged);
            this.cboTransformerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTransformerName_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(196, 287);
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
            this.btnCancel.Location = new System.Drawing.Point(345, 287);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(139, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(139, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(193, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "* is Mandatory Field";
            // 
            // txtTransformerCode
            // 
            this.txtTransformerCode.Enabled = false;
            this.txtTransformerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransformerCode.Location = new System.Drawing.Point(196, 87);
            this.txtTransformerCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTransformerCode.Name = "txtTransformerCode";
            this.txtTransformerCode.Size = new System.Drawing.Size(122, 20);
            this.txtTransformerCode.TabIndex = 1;
            this.txtTransformerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPoleNo_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Quarter Name";
            // 
            // txtQuarterName
            // 
            this.txtQuarterName.Enabled = false;
            this.txtQuarterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuarterName.Location = new System.Drawing.Point(196, 134);
            this.txtQuarterName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuarterName.Name = "txtQuarterName";
            this.txtQuarterName.Size = new System.Drawing.Size(223, 20);
            this.txtQuarterName.TabIndex = 3;
            // 
            // dgvPoleList
            // 
            this.dgvPoleList.AllowUserToAddRows = false;
            this.dgvPoleList.AllowUserToDeleteRows = false;
            this.dgvPoleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column6,
            this.Column7});
            this.dgvPoleList.Location = new System.Drawing.Point(23, 173);
            this.dgvPoleList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPoleList.Name = "dgvPoleList";
            this.dgvPoleList.ReadOnly = true;
            this.dgvPoleList.Size = new System.Drawing.Size(714, 354);
            this.dgvPoleList.TabIndex = 5;
            this.dgvPoleList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPoleList_CellClick);
            this.dgvPoleList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPoleList_DataBindingComplete);
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
            this.Column2.HeaderText = "Pole No";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "GPS-X";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "GPS-Y";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Transformer Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Quarter Name";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Text = "Edit";
            this.Column6.UseColumnTextForLinkValue = true;
            this.Column6.Width = 90;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Text = "Delete";
            this.Column7.UseColumnTextForLinkValue = true;
            this.Column7.Width = 90;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGPSY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPoleNo);
            this.groupBox1.Controls.Add(this.txtGPSX);
            this.groupBox1.Controls.Add(this.txtTransformerCode);
            this.groupBox1.Controls.Add(this.txtQuarterName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboTransformerName);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 350);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Register";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtSearchPoleName);
            this.groupBox2.Controls.Add(this.cboSearchQuarterName);
            this.groupBox2.Controls.Add(this.dgvPoleList);
            this.groupBox2.Controls.Add(this.cboSearchTransformerName);
            this.groupBox2.Location = new System.Drawing.Point(575, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(758, 543);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(553, 102);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 27);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(437, 102);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "S&earch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 15);
            this.label14.TabIndex = 10;
            this.label14.Text = "Quarter Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(323, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "Transformer Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Pole No";
            // 
            // txtSearchPoleName
            // 
            this.txtSearchPoleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchPoleName.Location = new System.Drawing.Point(120, 43);
            this.txtSearchPoleName.Name = "txtSearchPoleName";
            this.txtSearchPoleName.Size = new System.Drawing.Size(164, 20);
            this.txtSearchPoleName.TabIndex = 0;
            this.txtSearchPoleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchPoleName_KeyDown);
            // 
            // cboSearchQuarterName
            // 
            this.cboSearchQuarterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchQuarterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchQuarterName.FormattingEnabled = true;
            this.cboSearchQuarterName.Location = new System.Drawing.Point(120, 102);
            this.cboSearchQuarterName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSearchQuarterName.Name = "cboSearchQuarterName";
            this.cboSearchQuarterName.Size = new System.Drawing.Size(164, 21);
            this.cboSearchQuarterName.TabIndex = 2;
            this.cboSearchQuarterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTransformerName_KeyDown);
            // 
            // cboSearchTransformerName
            // 
            this.cboSearchTransformerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchTransformerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchTransformerName.FormattingEnabled = true;
            this.cboSearchTransformerName.Location = new System.Drawing.Point(467, 39);
            this.cboSearchTransformerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSearchTransformerName.Name = "cboSearchTransformerName";
            this.cboSearchTransformerName.Size = new System.Drawing.Size(175, 21);
            this.cboSearchTransformerName.TabIndex = 1;
            this.cboSearchTransformerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTransformerName_KeyDown);
            // 
            // Polefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 583);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Polefrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pole Registration";
            this.Load += new System.EventHandler(this.Polefrm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Polefrm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoleList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPoleNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGPSX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGPSY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTransformerName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvPoleList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuarterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSearchPoleName;
        private System.Windows.Forms.ComboBox cboSearchQuarterName;
        private System.Windows.Forms.ComboBox cboSearchTransformerName;
        private System.Windows.Forms.TextBox txtTransformerCode;
    }
}