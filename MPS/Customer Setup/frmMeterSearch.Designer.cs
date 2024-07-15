namespace MPS
{
    partial class frmMeterSearch
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
            this.chkAutoSearch = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.MeterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstalledDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufactureBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterBoxSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.cboFindColumn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAutoSearch
            // 
            this.chkAutoSearch.AutoSize = true;
            this.chkAutoSearch.Location = new System.Drawing.Point(387, 14);
            this.chkAutoSearch.Name = "chkAutoSearch";
            this.chkAutoSearch.Size = new System.Drawing.Size(85, 17);
            this.chkAutoSearch.TabIndex = 31;
            this.chkAutoSearch.Text = "&Auto Search";
            this.chkAutoSearch.UseVisualStyleBackColor = true;
            this.chkAutoSearch.Visible = false;
            this.chkAutoSearch.CheckedChanged += new System.EventHandler(this.chkAutoSearch_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Filter by";
            this.label2.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(725, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(629, 425);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 28;
            this.btnSelect.Text = "&Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeterId,
            this.MeterNo,
            this.Model,
            this.InstalledDate,
            this.ManufactureBy,
            this.MeterBoxSequence,
            this.AvailableYear});
            this.dgvSearch.Location = new System.Drawing.Point(15, 69);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.Size = new System.Drawing.Size(795, 350);
            this.dgvSearch.TabIndex = 27;
            this.dgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellDoubleClick);
            this.dgvSearch.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSearch_DataBindingComplete);
            // 
            // MeterId
            // 
            this.MeterId.HeaderText = "MeterId";
            this.MeterId.Name = "MeterId";
            this.MeterId.ReadOnly = true;
            this.MeterId.Visible = false;
            // 
            // MeterNo
            // 
            this.MeterNo.HeaderText = "Meter No";
            this.MeterNo.Name = "MeterNo";
            this.MeterNo.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // InstalledDate
            // 
            this.InstalledDate.HeaderText = "Installed Date";
            this.InstalledDate.Name = "InstalledDate";
            this.InstalledDate.ReadOnly = true;
            // 
            // ManufactureBy
            // 
            this.ManufactureBy.HeaderText = "Manufacture By";
            this.ManufactureBy.Name = "ManufactureBy";
            this.ManufactureBy.ReadOnly = true;
            // 
            // MeterBoxSequence
            // 
            this.MeterBoxSequence.HeaderText = "Meter Box Sequence";
            this.MeterBoxSequence.Name = "MeterBoxSequence";
            this.MeterBoxSequence.ReadOnly = true;
            // 
            // AvailableYear
            // 
            this.AvailableYear.HeaderText = "Available Year";
            this.AvailableYear.Name = "AvailableYear";
            this.AvailableYear.ReadOnly = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(288, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 26;
            this.btnFind.Text = "&Find Now";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Location = new System.Drawing.Point(66, 43);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(406, 20);
            this.txtFilterBy.TabIndex = 25;
            this.txtFilterBy.Visible = false;
            // 
            // cboFindColumn
            // 
            this.cboFindColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFindColumn.FormattingEnabled = true;
            this.cboFindColumn.Location = new System.Drawing.Point(66, 12);
            this.cboFindColumn.Name = "cboFindColumn";
            this.cboFindColumn.Size = new System.Drawing.Size(216, 21);
            this.cboFindColumn.TabIndex = 23;
            this.cboFindColumn.Visible = false;
            this.cboFindColumn.SelectedIndexChanged += new System.EventHandler(this.cboFindColumn_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Find by";
            this.label1.Visible = false;
            // 
            // frmMeterSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 456);
            this.Controls.Add(this.chkAutoSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvSearch);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.cboFindColumn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMeterSearch";
            this.Text = "Meter Search";
            this.Load += new System.EventHandler(this.frmMeterSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.ComboBox cboFindColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstalledDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufactureBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterBoxSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableYear;
    }
}