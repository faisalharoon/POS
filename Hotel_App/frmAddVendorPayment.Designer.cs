namespace General_App
{
    partial class frmAddVendorPayment
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgmain = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtamountpaid = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtamounttopay = new System.Windows.Forms.TextBox();
            this.ddlvendor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounttopay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvVendorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgmain)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(1868, 82);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Vendor Payment";
            // 
            // dgmain
            // 
            this.dgmain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgmain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Vendor,
            this.amounttopay,
            this.AmountPaid,
            this.Balance,
            this.CreationDate,
            this.gvVendorID});
            this.dgmain.Location = new System.Drawing.Point(4, 25);
            this.dgmain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgmain.Name = "dgmain";
            this.dgmain.RowHeadersWidth = 62;
            this.dgmain.Size = new System.Drawing.Size(1023, 542);
            this.dgmain.TabIndex = 0;
            this.dgmain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgmain_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgmain);
            this.groupBox2.Location = new System.Drawing.Point(18, 358);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1036, 571);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Items List";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(124, 186);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(112, 35);
            this.btncancel.TabIndex = 8;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Amount Paid";
            // 
            // txtamountpaid
            // 
            this.txtamountpaid.Location = new System.Drawing.Point(170, 100);
            this.txtamountpaid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtamountpaid.Name = "txtamountpaid";
            this.txtamountpaid.Size = new System.Drawing.Size(224, 26);
            this.txtamountpaid.TabIndex = 3;
            this.txtamountpaid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtamountpaid_KeyUp);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(3, 186);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(112, 35);
            this.btnsave.TabIndex = 5;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtbalance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtamounttopay);
            this.groupBox1.Controls.Add(this.ddlvendor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnprint);
            this.groupBox1.Controls.Add(this.btncancel);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtamountpaid);
            this.groupBox1.Location = new System.Drawing.Point(18, 91);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(440, 229);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 145);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Balance";
            this.label6.Visible = false;
            // 
            // txtbalance
            // 
            this.txtbalance.Enabled = false;
            this.txtbalance.Location = new System.Drawing.Point(170, 140);
            this.txtbalance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.Size = new System.Drawing.Size(224, 26);
            this.txtbalance.TabIndex = 4;
            this.txtbalance.Text = "0";
            this.txtbalance.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Amount To Pay";
            // 
            // txtamounttopay
            // 
            this.txtamounttopay.Location = new System.Drawing.Point(170, 62);
            this.txtamounttopay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtamounttopay.Name = "txtamounttopay";
            this.txtamounttopay.Size = new System.Drawing.Size(224, 26);
            this.txtamounttopay.TabIndex = 2;
            this.txtamounttopay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtamounttopay_KeyUp);
            // 
            // ddlvendor
            // 
            this.ddlvendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlvendor.FormattingEnabled = true;
            this.ddlvendor.Location = new System.Drawing.Point(170, 20);
            this.ddlvendor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlvendor.Name = "ddlvendor";
            this.ddlvendor.Size = new System.Drawing.Size(224, 28);
            this.ddlvendor.TabIndex = 1;
            this.ddlvendor.SelectedIndexChanged += new System.EventHandler(this.ddlvendor_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Vendor";
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(246, 186);
            this.btnprint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(112, 35);
            this.btnprint.TabIndex = 9;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(106, 329);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(349, 26);
            this.txtsearch.TabIndex = 13;
            this.txtsearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsearch_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 334);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Search";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.reportViewer1);
            this.groupBox4.Location = new System.Drawing.Point(1071, 91);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(732, 823);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Printing";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(4, 25);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(718, 788);
            this.reportViewer1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Width = 40;
            // 
            // Vendor
            // 
            this.Vendor.DataPropertyName = "VendorName";
            this.Vendor.HeaderText = "Vendor";
            this.Vendor.MinimumWidth = 8;
            this.Vendor.Name = "Vendor";
            this.Vendor.Width = 150;
            // 
            // amounttopay
            // 
            this.amounttopay.DataPropertyName = "amounttopay";
            this.amounttopay.HeaderText = "Amount to Pay";
            this.amounttopay.MinimumWidth = 8;
            this.amounttopay.Name = "amounttopay";
            this.amounttopay.Visible = false;
            this.amounttopay.Width = 150;
            // 
            // AmountPaid
            // 
            this.AmountPaid.DataPropertyName = "Amount";
            this.AmountPaid.HeaderText = "Amount Paid";
            this.AmountPaid.MinimumWidth = 8;
            this.AmountPaid.Name = "AmountPaid";
            this.AmountPaid.Width = 150;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.HeaderText = "Balance";
            this.Balance.MinimumWidth = 8;
            this.Balance.Name = "Balance";
            this.Balance.Visible = false;
            this.Balance.Width = 200;
            // 
            // CreationDate
            // 
            this.CreationDate.DataPropertyName = "Createdat";
            this.CreationDate.HeaderText = "CreationDate";
            this.CreationDate.MinimumWidth = 8;
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.Width = 150;
            // 
            // gvVendorID
            // 
            this.gvVendorID.DataPropertyName = "VendorID";
            this.gvVendorID.HeaderText = "gvVendorID";
            this.gvVendorID.MinimumWidth = 8;
            this.gvVendorID.Name = "gvVendorID";
            this.gvVendorID.Visible = false;
            this.gvVendorID.Width = 150;
            // 
            // frmAddVendorPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 932);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddVendorPayment";
            this.Text = "frmAddvendorPayment";
            this.Load += new System.EventHandler(this.frmAddItemStock_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgmain)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgmain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtamountpaid;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.GroupBox groupBox4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox ddlvendor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtamounttopay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounttopay;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvVendorID;
    }
}