namespace MPS.PC2HHUDB {
    partial class MeterList2HHUDB {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterList2HHUDB));
            this.dgvMeterList = new System.Windows.Forms.DataGridView();
            this.MeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoMeterModel = new System.Windows.Forms.RadioButton();
            this.rdoMeterNo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cbofileName = new System.Windows.Forms.ComboBox();
            this.btnSave2HHUDB = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMeter = new System.Windows.Forms.Label();
            this.txtmeternoSearch = new System.Windows.Forms.TextBox();
            this.cbometerBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMeterList
            // 
            this.dgvMeterList.AllowUserToAddRows = false;
            this.dgvMeterList.AllowUserToDeleteRows = false;
            this.dgvMeterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeterNo,
            this.Column3,
            this.Column4});
            this.dgvMeterList.Location = new System.Drawing.Point(21, 206);
            this.dgvMeterList.Name = "dgvMeterList";
            this.dgvMeterList.ReadOnly = true;
            this.dgvMeterList.Size = new System.Drawing.Size(541, 162);
            this.dgvMeterList.TabIndex = 1;
            // 
            // MeterNo
            // 
            this.MeterNo.DataPropertyName = "MeterNo";
            this.MeterNo.HeaderText = "Meter No";
            this.MeterNo.Name = "MeterNo";
            this.MeterNo.ReadOnly = true;
            this.MeterNo.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Model";
            this.Column3.HeaderText = "Model";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "InstalledDate";
            this.Column4.HeaderText = "Installed Date";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoMeterModel);
            this.groupBox2.Controls.Add(this.rdoMeterNo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbofileName);
            this.groupBox2.Controls.Add(this.btnSave2HHUDB);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblMeter);
            this.groupBox2.Controls.Add(this.txtmeternoSearch);
            this.groupBox2.Controls.Add(this.cbometerBox);
            this.groupBox2.Location = new System.Drawing.Point(14, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(551, 171);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meter data to HHU Database file.";
            // 
            // rdoMeterModel
            // 
            this.rdoMeterModel.AutoSize = true;
            this.rdoMeterModel.Location = new System.Drawing.Point(134, 32);
            this.rdoMeterModel.Name = "rdoMeterModel";
            this.rdoMeterModel.Size = new System.Drawing.Size(95, 19);
            this.rdoMeterModel.TabIndex = 1;
            this.rdoMeterModel.Text = "Meter Model";
            this.rdoMeterModel.UseVisualStyleBackColor = true;
            this.rdoMeterModel.CheckedChanged += new System.EventHandler(this.rdoMeterModel_CheckedChanged);
            // 
            // rdoMeterNo
            // 
            this.rdoMeterNo.AutoSize = true;
            this.rdoMeterNo.Checked = true;
            this.rdoMeterNo.Location = new System.Drawing.Point(8, 32);
            this.rdoMeterNo.Name = "rdoMeterNo";
            this.rdoMeterNo.Size = new System.Drawing.Size(76, 19);
            this.rdoMeterNo.TabIndex = 0;
            this.rdoMeterNo.TabStop = true;
            this.rdoMeterNo.Text = "Meter No";
            this.rdoMeterNo.UseVisualStyleBackColor = true;
            this.rdoMeterNo.CheckedChanged += new System.EventHandler(this.rdoMeterNo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Db File:";
            // 
            // cbofileName
            // 
            this.cbofileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbofileName.FormattingEnabled = true;
            this.cbofileName.Location = new System.Drawing.Point(352, 86);
            this.cbofileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbofileName.Name = "cbofileName";
            this.cbofileName.Size = new System.Drawing.Size(164, 21);
            this.cbofileName.TabIndex = 4;
            // 
            // btnSave2HHUDB
            // 
            this.btnSave2HHUDB.Location = new System.Drawing.Point(437, 135);
            this.btnSave2HHUDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave2HHUDB.Name = "btnSave2HHUDB";
            this.btnSave2HHUDB.Size = new System.Drawing.Size(92, 24);
            this.btnSave2HHUDB.TabIndex = 7;
            this.btnSave2HHUDB.Text = "Save To HHU DB";
            this.btnSave2HHUDB.UseVisualStyleBackColor = true;
            this.btnSave2HHUDB.Click += new System.EventHandler(this.btnSave2HHUDB_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(356, 135);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(76, 24);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(274, 135);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 24);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "Meter Box:";
            // 
            // lblMeter
            // 
            this.lblMeter.AutoSize = true;
            this.lblMeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeter.Location = new System.Drawing.Point(271, 32);
            this.lblMeter.Name = "lblMeter";
            this.lblMeter.Size = new System.Drawing.Size(58, 15);
            this.lblMeter.TabIndex = 10;
            this.lblMeter.Text = "Meter No";
            // 
            // txtmeternoSearch
            // 
            this.txtmeternoSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmeternoSearch.Location = new System.Drawing.Point(352, 29);
            this.txtmeternoSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtmeternoSearch.Name = "txtmeternoSearch";
            this.txtmeternoSearch.Size = new System.Drawing.Size(164, 20);
            this.txtmeternoSearch.TabIndex = 2;
            this.txtmeternoSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmeternoSearch_KeyDown);
            // 
            // cbometerBox
            // 
            this.cbometerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbometerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbometerBox.FormattingEnabled = true;
            this.cbometerBox.Location = new System.Drawing.Point(78, 89);
            this.cbometerBox.Name = "cbometerBox";
            this.cbometerBox.Size = new System.Drawing.Size(151, 21);
            this.cbometerBox.TabIndex = 3;
            // 
            // MeterList2HHUDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 374);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvMeterList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MeterList2HHUDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter List 2 HHU DB";
            this.Load += new System.EventHandler(this.MeterList2HHUDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.DataGridView dgvMeterList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave2HHUDB;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMeter;
        private System.Windows.Forms.TextBox txtmeternoSearch;
        private System.Windows.Forms.ComboBox cbometerBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbofileName;
        private System.Windows.Forms.RadioButton rdoMeterModel;
        private System.Windows.Forms.RadioButton rdoMeterNo;
    }
    }