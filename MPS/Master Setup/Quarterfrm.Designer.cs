namespace MPS
{
    partial class Quarterfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quarterfrm));
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvQuarterList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoQuarterName = new System.Windows.Forms.RadioButton();
            this.rdoQuarterCode = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lblQuarter = new System.Windows.Forms.Label();
            this.txtSearchQuarter = new System.Windows.Forms.TextBox();
            this.cboSearchTownshipName = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cboTownshipName = new System.Windows.Forms.ComboBox();
            this.txtQuarterNameMM = new System.Windows.Forms.TextBox();
            this.txtQuarterNameEng = new System.Windows.Forms.TextBox();
            this.txtQuarterCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuarterList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(281, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "* is Mandatory Field";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnCancel.Location = new System.Drawing.Point(339, 306);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(216, 306);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 32);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvQuarterList
            // 
            this.dgvQuarterList.AllowUserToAddRows = false;
            this.dgvQuarterList.AllowUserToDeleteRows = false;
            this.dgvQuarterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuarterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column6,
            this.Column7});
            this.dgvQuarterList.Location = new System.Drawing.Point(6, 108);
            this.dgvQuarterList.Name = "dgvQuarterList";
            this.dgvQuarterList.ReadOnly = true;
            this.dgvQuarterList.Size = new System.Drawing.Size(688, 320);
            this.dgvQuarterList.TabIndex = 5;
            this.dgvQuarterList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuarterList_CellClick);
            this.dgvQuarterList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvQuarterList_DataBindingComplete);
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
            this.Column2.HeaderText = "Quarter Code";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Quarter Name Eng";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quarter Name MM";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Township Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Address";
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
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Text = "Delete";
            this.Column7.UseColumnTextForLinkValue = true;
            this.Column7.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoQuarterName);
            this.groupBox1.Controls.Add(this.rdoQuarterCode);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblQuarter);
            this.groupBox1.Controls.Add(this.dgvQuarterList);
            this.groupBox1.Controls.Add(this.txtSearchQuarter);
            this.groupBox1.Controls.Add(this.cboSearchTownshipName);
            this.groupBox1.Location = new System.Drawing.Point(496, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 441);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Quarter";
            // 
            // rdoQuarterName
            // 
            this.rdoQuarterName.AutoSize = true;
            this.rdoQuarterName.Location = new System.Drawing.Point(167, 24);
            this.rdoQuarterName.Name = "rdoQuarterName";
            this.rdoQuarterName.Size = new System.Drawing.Size(103, 19);
            this.rdoQuarterName.TabIndex = 8;
            this.rdoQuarterName.Text = "Quarter Name";
            this.rdoQuarterName.UseVisualStyleBackColor = true;
            this.rdoQuarterName.CheckedChanged += new System.EventHandler(this.rdoQuarterName_CheckedChanged);
            // 
            // rdoQuarterCode
            // 
            this.rdoQuarterCode.AutoSize = true;
            this.rdoQuarterCode.Checked = true;
            this.rdoQuarterCode.Location = new System.Drawing.Point(51, 24);
            this.rdoQuarterCode.Name = "rdoQuarterCode";
            this.rdoQuarterCode.Size = new System.Drawing.Size(98, 19);
            this.rdoQuarterCode.TabIndex = 7;
            this.rdoQuarterCode.TabStop = true;
            this.rdoQuarterCode.Text = "Quarter Code";
            this.rdoQuarterCode.UseVisualStyleBackColor = true;
            this.rdoQuarterCode.CheckedChanged += new System.EventHandler(this.rdoQuarterCode_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(565, 58);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(435, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "S&earch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label13.Location = new System.Drawing.Point(329, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "Township Name";
            // 
            // lblQuarter
            // 
            this.lblQuarter.AutoSize = true;
            this.lblQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblQuarter.Location = new System.Drawing.Point(48, 63);
            this.lblQuarter.Name = "lblQuarter";
            this.lblQuarter.Size = new System.Drawing.Size(80, 15);
            this.lblQuarter.TabIndex = 6;
            this.lblQuarter.Text = "Quarter Code";
            // 
            // txtSearchQuarter
            // 
            this.txtSearchQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtSearchQuarter.Location = new System.Drawing.Point(158, 60);
            this.txtSearchQuarter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchQuarter.Name = "txtSearchQuarter";
            this.txtSearchQuarter.Size = new System.Drawing.Size(148, 20);
            this.txtSearchQuarter.TabIndex = 0;
            // 
            // cboSearchTownshipName
            // 
            this.cboSearchTownshipName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchTownshipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.cboSearchTownshipName.FormattingEnabled = true;
            this.cboSearchTownshipName.Location = new System.Drawing.Point(462, 22);
            this.cboSearchTownshipName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSearchTownshipName.Name = "cboSearchTownshipName";
            this.cboSearchTownshipName.Size = new System.Drawing.Size(149, 21);
            this.cboSearchTownshipName.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(223, 162);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(233, 82);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // cboTownshipName
            // 
            this.cboTownshipName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTownshipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.cboTownshipName.FormattingEnabled = true;
            this.cboTownshipName.Location = new System.Drawing.Point(223, 120);
            this.cboTownshipName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTownshipName.Name = "cboTownshipName";
            this.cboTownshipName.Size = new System.Drawing.Size(233, 21);
            this.cboTownshipName.TabIndex = 3;
            this.cboTownshipName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTownshipName_KeyDown);
            // 
            // txtQuarterNameMM
            // 
            this.txtQuarterNameMM.Font = new System.Drawing.Font("Myanmar3", 9.5F);
            this.txtQuarterNameMM.Location = new System.Drawing.Point(223, 83);
            this.txtQuarterNameMM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuarterNameMM.Name = "txtQuarterNameMM";
            this.txtQuarterNameMM.Size = new System.Drawing.Size(233, 27);
            this.txtQuarterNameMM.TabIndex = 2;
            this.txtQuarterNameMM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuarterNameMM_KeyDown);
            // 
            // txtQuarterNameEng
            // 
            this.txtQuarterNameEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtQuarterNameEng.Location = new System.Drawing.Point(223, 52);
            this.txtQuarterNameEng.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuarterNameEng.Name = "txtQuarterNameEng";
            this.txtQuarterNameEng.Size = new System.Drawing.Size(233, 20);
            this.txtQuarterNameEng.TabIndex = 1;
            this.txtQuarterNameEng.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuarterNameEng_KeyDown);
            this.txtQuarterNameEng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuarterNameEng_KeyPress);
            // 
            // txtQuarterCode
            // 
            this.txtQuarterCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtQuarterCode.Location = new System.Drawing.Point(223, 19);
            this.txtQuarterCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuarterCode.MaxLength = 5;
            this.txtQuarterCode.Name = "txtQuarterCode";
            this.txtQuarterCode.Size = new System.Drawing.Size(233, 20);
            this.txtQuarterCode.TabIndex = 0;
            this.txtQuarterCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuarterCode_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(176, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Quarter Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(176, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label2.Location = new System.Drawing.Point(26, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Quarter Name (Eng)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(176, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label3.Location = new System.Drawing.Point(26, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Quarter Name (MM)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(176, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label4.Location = new System.Drawing.Point(26, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Township Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label5.Location = new System.Drawing.Point(26, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Address";
            // 
            // Quarterfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1206, 466);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQuarterCode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtQuarterNameEng);
            this.Controls.Add(this.txtQuarterNameMM);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboTownshipName);
            this.Controls.Add(this.txtAddress);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Quarterfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quarter Registration";
            this.Load += new System.EventHandler(this.Quarterfrm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Quarterfrm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuarterList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvQuarterList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblQuarter;
        private System.Windows.Forms.TextBox txtSearchQuarter;
        private System.Windows.Forms.ComboBox cboSearchTownshipName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cboTownshipName;
        private System.Windows.Forms.TextBox txtQuarterNameMM;
        private System.Windows.Forms.TextBox txtQuarterNameEng;
        private System.Windows.Forms.TextBox txtQuarterCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdoQuarterName;
        private System.Windows.Forms.RadioButton rdoQuarterCode;
    }
}