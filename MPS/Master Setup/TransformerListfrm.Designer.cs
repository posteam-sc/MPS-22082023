namespace MPS.Master_Setup
{
    partial class TransformerListfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransformerListfrm));
            this.dgvTransformerList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblTransformer = new System.Windows.Forms.Label();
            this.txtTransformerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboQuarterName = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddNewTrans = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoTransformerModel = new System.Windows.Forms.RadioButton();
            this.rdoTrasformerName = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvRemoveTransformerList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn3 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransformerList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemoveTransformerList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransformerList
            // 
            this.dgvTransformerList.AllowUserToAddRows = false;
            this.dgvTransformerList.AllowUserToDeleteRows = false;
            this.dgvTransformerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransformerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column10,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column11,
            this.Column9});
            this.dgvTransformerList.Location = new System.Drawing.Point(3, 0);
            this.dgvTransformerList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTransformerList.Name = "dgvTransformerList";
            this.dgvTransformerList.ReadOnly = true;
            this.dgvTransformerList.Size = new System.Drawing.Size(1027, 410);
            this.dgvTransformerList.TabIndex = 0;
            this.dgvTransformerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransformerList_CellClick);
            this.dgvTransformerList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransformerList_DataBindingComplete);
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
            this.Column2.HeaderText = "Transformer Code";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Model";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Maker";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Country Of Orgin";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Status";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Quarter Name";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Standard";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Text = "Edit";
            this.Column8.UseColumnTextForLinkValue = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Text = "View Detail";
            this.Column11.UseColumnTextForLinkValue = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Text = "Delete";
            this.Column9.UseColumnTextForLinkValue = true;
            // 
            // lblTransformer
            // 
            this.lblTransformer.AutoSize = true;
            this.lblTransformer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransformer.Location = new System.Drawing.Point(17, 92);
            this.lblTransformer.Name = "lblTransformer";
            this.lblTransformer.Size = new System.Drawing.Size(112, 15);
            this.lblTransformer.TabIndex = 1;
            this.lblTransformer.Text = "Transformer Code :";
            // 
            // txtTransformerName
            // 
            this.txtTransformerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransformerName.Location = new System.Drawing.Point(138, 89);
            this.txtTransformerName.Name = "txtTransformerName";
            this.txtTransformerName.Size = new System.Drawing.Size(198, 20);
            this.txtTransformerName.TabIndex = 2;
            this.txtTransformerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransformerName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(442, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Quarter Name";
            // 
            // cboQuarterName
            // 
            this.cboQuarterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuarterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQuarterName.FormattingEnabled = true;
            this.cboQuarterName.Location = new System.Drawing.Point(564, 29);
            this.cboQuarterName.Name = "cboQuarterName";
            this.cboQuarterName.Size = new System.Drawing.Size(198, 21);
            this.cboQuarterName.TabIndex = 3;
            this.cboQuarterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboQuarterName_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(526, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(662, 85);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddNewTrans
            // 
            this.btnAddNewTrans.Location = new System.Drawing.Point(835, 19);
            this.btnAddNewTrans.Name = "btnAddNewTrans";
            this.btnAddNewTrans.Size = new System.Drawing.Size(183, 36);
            this.btnAddNewTrans.TabIndex = 5;
            this.btnAddNewTrans.Text = "&Add New Transformer";
            this.btnAddNewTrans.UseVisualStyleBackColor = true;
            this.btnAddNewTrans.Click += new System.EventHandler(this.btnAddNewTrans_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoTransformerModel);
            this.groupBox1.Controls.Add(this.rdoTrasformerName);
            this.groupBox1.Controls.Add(this.lblTransformer);
            this.groupBox1.Controls.Add(this.btnAddNewTrans);
            this.groupBox1.Controls.Add(this.txtTransformerName);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cboQuarterName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 132);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search ";
            // 
            // rdoTransformerModel
            // 
            this.rdoTransformerModel.AutoSize = true;
            this.rdoTransformerModel.Location = new System.Drawing.Point(167, 28);
            this.rdoTransformerModel.Name = "rdoTransformerModel";
            this.rdoTransformerModel.Size = new System.Drawing.Size(130, 19);
            this.rdoTransformerModel.TabIndex = 6;
            this.rdoTransformerModel.Text = "Transformer Model";
            this.rdoTransformerModel.UseVisualStyleBackColor = true;
            this.rdoTransformerModel.CheckedChanged += new System.EventHandler(this.rdoTransformerModel_CheckedChanged);
            // 
            // rdoTrasformerName
            // 
            this.rdoTrasformerName.AutoSize = true;
            this.rdoTrasformerName.Checked = true;
            this.rdoTrasformerName.Location = new System.Drawing.Point(20, 27);
            this.rdoTrasformerName.Name = "rdoTrasformerName";
            this.rdoTrasformerName.Size = new System.Drawing.Size(124, 19);
            this.rdoTrasformerName.TabIndex = 6;
            this.rdoTrasformerName.TabStop = true;
            this.rdoTrasformerName.Text = "Transformer Code";
            this.rdoTrasformerName.UseVisualStyleBackColor = true;
            this.rdoTrasformerName.CheckedChanged += new System.EventHandler(this.rdoTrasformerName_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 150);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1030, 440);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvTransformerList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1022, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Active Trasnformer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvRemoveTransformerList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1022, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Remove Transformer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvRemoveTransformerList
            // 
            this.dgvRemoveTransformerList.AllowUserToAddRows = false;
            this.dgvRemoveTransformerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemoveTransformerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column12,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewLinkColumn3});
            this.dgvRemoveTransformerList.Location = new System.Drawing.Point(3, 2);
            this.dgvRemoveTransformerList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRemoveTransformerList.Name = "dgvRemoveTransformerList";
            this.dgvRemoveTransformerList.Size = new System.Drawing.Size(1017, 407);
            this.dgvRemoveTransformerList.TabIndex = 1;
            this.dgvRemoveTransformerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemoveTransformerList_CellClick);
            this.dgvRemoveTransformerList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRemoveTransformerList_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Old Transformer Code";
            this.Column12.Name = "Column12";
            this.Column12.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Transformer Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Model";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Maker";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Country Of Orgin";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 130;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Status";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Standard";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewLinkColumn3
            // 
            this.dataGridViewLinkColumn3.HeaderText = "";
            this.dataGridViewLinkColumn3.Name = "dataGridViewLinkColumn3";
            this.dataGridViewLinkColumn3.Text = "Delete";
            this.dataGridViewLinkColumn3.UseColumnTextForLinkValue = true;
            // 
            // TransformerListfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1057, 602);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TransformerListfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transformer List";
            this.Load += new System.EventHandler(this.TransformerListfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransformerList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemoveTransformerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransformerList;
        private System.Windows.Forms.Label lblTransformer;
        private System.Windows.Forms.TextBox txtTransformerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboQuarterName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddNewTrans;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column11;
        private System.Windows.Forms.DataGridViewLinkColumn Column9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvRemoveTransformerList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn3;
        private System.Windows.Forms.RadioButton rdoTransformerModel;
        private System.Windows.Forms.RadioButton rdoTrasformerName;
    }
}