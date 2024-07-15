namespace MPS.Setting_Setup {
    partial class StreetLightFeesUI {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StreetLightFeesUI));
            this.cboQuarterName = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboTownshipName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.txtstreetlightfeeamt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gvStreetLightFees = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuarterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TownshipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreetLightFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvStreetLightFees)).BeginInit();
            this.SuspendLayout();
            // 
            // cboQuarterName
            // 
            this.cboQuarterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuarterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQuarterName.FormattingEnabled = true;
            this.cboQuarterName.Location = new System.Drawing.Point(267, 62);
            this.cboQuarterName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboQuarterName.Name = "cboQuarterName";
            this.cboQuarterName.Size = new System.Drawing.Size(228, 21);
            this.cboQuarterName.TabIndex = 16;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label24);
            this.panel11.Controls.Add(this.label10);
            this.panel11.Location = new System.Drawing.Point(12, 60);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(233, 34);
            this.panel11.TabIndex = 18;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(112, 7);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(12, 15);
            this.label24.TabIndex = 1;
            this.label24.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Quarter Name";
            // 
            // cboTownshipName
            // 
            this.cboTownshipName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTownshipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTownshipName.FormattingEnabled = true;
            this.cboTownshipName.Location = new System.Drawing.Point(267, 19);
            this.cboTownshipName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTownshipName.Name = "cboTownshipName";
            this.cboTownshipName.Size = new System.Drawing.Size(228, 21);
            this.cboTownshipName.TabIndex = 15;
            this.cboTownshipName.SelectedIndexChanged += new System.EventHandler(this.cboTownshipName_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Township Name";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label25);
            this.panel10.Controls.Add(this.label11);
            this.panel10.Location = new System.Drawing.Point(12, 15);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(233, 34);
            this.panel10.TabIndex = 17;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(112, 7);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(12, 15);
            this.label25.TabIndex = 1;
            this.label25.Text = "*";
            // 
            // txtstreetlightfeeamt
            // 
            this.txtstreetlightfeeamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstreetlightfeeamt.Location = new System.Drawing.Point(267, 118);
            this.txtstreetlightfeeamt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtstreetlightfeeamt.Name = "txtstreetlightfeeamt";
            this.txtstreetlightfeeamt.Size = new System.Drawing.Size(228, 20);
            this.txtstreetlightfeeamt.TabIndex = 19;
            this.txtstreetlightfeeamt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtstreetlightfeeamt_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 111);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 34);
            this.panel1.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(106, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(12, 15);
            this.label15.TabIndex = 1;
            this.label15.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Street Light Fees:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Red;
            this.label29.Location = new System.Drawing.Point(270, 152);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(115, 15);
            this.label29.TabIndex = 21;
            this.label29.Text = "* is Mandatory Field";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(386, 171);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 32);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(254, 171);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 32);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gvStreetLightFees
            // 
            this.gvStreetLightFees.AllowUserToAddRows = false;
            this.gvStreetLightFees.AllowUserToDeleteRows = false;
            this.gvStreetLightFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvStreetLightFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.QuarterName,
            this.TownshipName,
            this.StreetLightFees,
            this.Edit,
            this.Delete});
            this.gvStreetLightFees.Location = new System.Drawing.Point(12, 219);
            this.gvStreetLightFees.Name = "gvStreetLightFees";
            this.gvStreetLightFees.ReadOnly = true;
            this.gvStreetLightFees.Size = new System.Drawing.Size(555, 240);
            this.gvStreetLightFees.TabIndex = 24;
            this.gvStreetLightFees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvStreetLightFees_CellClick);
            this.gvStreetLightFees.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvStreetLightFees_DataBindingComplete);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // QuarterName
            // 
            this.QuarterName.HeaderText = "Querter";
            this.QuarterName.Name = "QuarterName";
            this.QuarterName.ReadOnly = true;
            // 
            // TownshipName
            // 
            this.TownshipName.HeaderText = "Township";
            this.TownshipName.Name = "TownshipName";
            this.TownshipName.ReadOnly = true;
            // 
            // StreetLightFees
            // 
            this.StreetLightFees.HeaderText = "StreetLight Fees";
            this.StreetLightFees.Name = "StreetLightFees";
            this.StreetLightFees.ReadOnly = true;
            this.StreetLightFees.Width = 150;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            this.Edit.Width = 80;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            this.Delete.Width = 80;
            // 
            // StreetLightFeesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 476);
            this.Controls.Add(this.gvStreetLightFees);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtstreetlightfeeamt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboQuarterName);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.cboTownshipName);
            this.Controls.Add(this.panel10);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StreetLightFeesUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Street Light Fees";
            this.Load += new System.EventHandler(this.StreetLightFeesUI_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvStreetLightFees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.ComboBox cboQuarterName;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboTownshipName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtstreetlightfeeamt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gvStreetLightFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuarterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TownshipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreetLightFees;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
    }