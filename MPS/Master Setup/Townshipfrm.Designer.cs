namespace MPS
{
    partial class Townshipfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Townshipfrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTownshipCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTownshipNameEng = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTowsshipNameMM = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvTownship = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTownship)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Township Code";
            // 
            // txtTownshipCode
            // 
            this.txtTownshipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTownshipCode.Location = new System.Drawing.Point(209, 18);
            this.txtTownshipCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtTownshipCode.MaxLength = 7;
            this.txtTownshipCode.Name = "txtTownshipCode";
            this.txtTownshipCode.Size = new System.Drawing.Size(180, 20);
            this.txtTownshipCode.TabIndex = 0;
            this.txtTownshipCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTownshipCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Township Name (Eng)";
            // 
            // txtTownshipNameEng
            // 
            this.txtTownshipNameEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTownshipNameEng.Location = new System.Drawing.Point(209, 54);
            this.txtTownshipNameEng.Margin = new System.Windows.Forms.Padding(4);
            this.txtTownshipNameEng.Name = "txtTownshipNameEng";
            this.txtTownshipNameEng.Size = new System.Drawing.Size(180, 20);
            this.txtTownshipNameEng.TabIndex = 1;
            this.txtTownshipNameEng.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTownshipNameEng_KeyDown);
            this.txtTownshipNameEng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTownshipNameEng_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Township Name (MM)";
            // 
            // txtTowsshipNameMM
            // 
            this.txtTowsshipNameMM.Font = new System.Drawing.Font("Myanmar3", 9.5F);
            this.txtTowsshipNameMM.Location = new System.Drawing.Point(209, 89);
            this.txtTowsshipNameMM.Margin = new System.Windows.Forms.Padding(4);
            this.txtTowsshipNameMM.Name = "txtTowsshipNameMM";
            this.txtTowsshipNameMM.Size = new System.Drawing.Size(180, 27);
            this.txtTowsshipNameMM.TabIndex = 2;
            this.txtTowsshipNameMM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTowsshipNameMM_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(195, 141);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnCancel.Location = new System.Drawing.Point(319, 141);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(155, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(228, 122);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "* is Mandatory Field";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(156, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(156, 92);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "*";
            // 
            // dgvTownship
            // 
            this.dgvTownship.AllowUserToAddRows = false;
            this.dgvTownship.AllowUserToDeleteRows = false;
            this.dgvTownship.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTownship.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvTownship.Location = new System.Drawing.Point(13, 186);
            this.dgvTownship.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTownship.Name = "dgvTownship";
            this.dgvTownship.ReadOnly = true;
            this.dgvTownship.Size = new System.Drawing.Size(662, 277);
            this.dgvTownship.TabIndex = 5;
            this.dgvTownship.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTownship_CellClick);
            this.dgvTownship.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTownship_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TownshipID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Township Code";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 130;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Township Name Eng";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Township Name MM";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 140;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Text = "Edit";
            this.Column4.UseColumnTextForLinkValue = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Text = "Delete";
            this.Column5.UseColumnTextForLinkValue = true;
            // 
            // Townshipfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 477);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvTownship);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTownshipCode);
            this.Controls.Add(this.txtTownshipNameEng);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTowsshipNameMM);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Townshipfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Township Registration";
            this.Load += new System.EventHandler(this.Townshipfrm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Townshipfrm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTownship)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTownshipCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTownshipNameEng;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTowsshipNameMM;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
    }
}