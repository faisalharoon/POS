namespace General_App
{
    partial class frmSetup
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDatabasepath = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSTFiler = new System.Windows.Forms.TextBox();
            this.txtWithholdingFiler = new System.Windows.Forms.TextBox();
            this.txtSTNonFiler = new System.Windows.Forms.TextBox();
            this.txtWithHoldingNonFiler = new System.Windows.Forms.TextBox();
            this.txtCustomerSalesTax = new System.Windows.Forms.TextBox();
            this.txtCompanyAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDbPath = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.txtNTN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSTRN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPOSID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDatabasepath
            // 
            this.btnDatabasepath.Location = new System.Drawing.Point(512, 106);
            this.btnDatabasepath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDatabasepath.Name = "btnDatabasepath";
            this.btnDatabasepath.Size = new System.Drawing.Size(162, 31);
            this.btnDatabasepath.TabIndex = 0;
            this.btnDatabasepath.Text = "Select Database";
            this.btnDatabasepath.UseVisualStyleBackColor = true;
            this.btnDatabasepath.Click += new System.EventHandler(this.btnDatabasepath_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(298, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 82);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vendor Sale Tax % Filer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 249);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vendor With Holding Tax % Filer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 289);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vendor Sale Tax % Non Filer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 329);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vendor Sale Tax % Non Filer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 375);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Customer Sale Tax %";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtSTFiler
            // 
            this.txtSTFiler.Location = new System.Drawing.Point(262, 200);
            this.txtSTFiler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSTFiler.Name = "txtSTFiler";
            this.txtSTFiler.Size = new System.Drawing.Size(409, 26);
            this.txtSTFiler.TabIndex = 1;
            // 
            // txtWithholdingFiler
            // 
            this.txtWithholdingFiler.Location = new System.Drawing.Point(262, 245);
            this.txtWithholdingFiler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWithholdingFiler.Name = "txtWithholdingFiler";
            this.txtWithholdingFiler.Size = new System.Drawing.Size(409, 26);
            this.txtWithholdingFiler.TabIndex = 2;
            // 
            // txtSTNonFiler
            // 
            this.txtSTNonFiler.Location = new System.Drawing.Point(262, 285);
            this.txtSTNonFiler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSTNonFiler.Name = "txtSTNonFiler";
            this.txtSTNonFiler.Size = new System.Drawing.Size(409, 26);
            this.txtSTNonFiler.TabIndex = 3;
            // 
            // txtWithHoldingNonFiler
            // 
            this.txtWithHoldingNonFiler.Location = new System.Drawing.Point(262, 325);
            this.txtWithHoldingNonFiler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWithHoldingNonFiler.Name = "txtWithHoldingNonFiler";
            this.txtWithHoldingNonFiler.Size = new System.Drawing.Size(409, 26);
            this.txtWithHoldingNonFiler.TabIndex = 4;
            // 
            // txtCustomerSalesTax
            // 
            this.txtCustomerSalesTax.Location = new System.Drawing.Point(262, 365);
            this.txtCustomerSalesTax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerSalesTax.Name = "txtCustomerSalesTax";
            this.txtCustomerSalesTax.Size = new System.Drawing.Size(409, 26);
            this.txtCustomerSalesTax.TabIndex = 5;
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.Location = new System.Drawing.Point(262, 445);
            this.txtCompanyAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.Size = new System.Drawing.Size(409, 26);
            this.txtCompanyAddress.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 455);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Company Address";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(262, 405);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(409, 26);
            this.txtCompanyName.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 415);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Company Name";
            // 
            // txtDbPath
            // 
            this.txtDbPath.Location = new System.Drawing.Point(9, 106);
            this.txtDbPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDbPath.Name = "txtDbPath";
            this.txtDbPath.Size = new System.Drawing.Size(492, 26);
            this.txtDbPath.TabIndex = 16;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // txtNTN
            // 
            this.txtNTN.Location = new System.Drawing.Point(262, 481);
            this.txtNTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNTN.Name = "txtNTN";
            this.txtNTN.Size = new System.Drawing.Size(409, 26);
            this.txtNTN.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 491);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "NTN";
            // 
            // txtSTRN
            // 
            this.txtSTRN.Location = new System.Drawing.Point(262, 517);
            this.txtSTRN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSTRN.Name = "txtSTRN";
            this.txtSTRN.Size = new System.Drawing.Size(409, 26);
            this.txtSTRN.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 527);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "STRN";
            // 
            // txtPOSID
            // 
            this.txtPOSID.Location = new System.Drawing.Point(262, 553);
            this.txtPOSID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPOSID.Name = "txtPOSID";
            this.txtPOSID.Size = new System.Drawing.Size(409, 26);
            this.txtPOSID.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 559);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "POSID";
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 639);
            this.Controls.Add(this.txtPOSID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSTRN);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNTN);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDbPath);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCompanyAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCustomerSalesTax);
            this.Controls.Add(this.txtWithHoldingNonFiler);
            this.Controls.Add(this.txtSTNonFiler);
            this.Controls.Add(this.txtWithholdingFiler);
            this.Controls.Add(this.txtSTFiler);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDatabasepath);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSetup";
            this.Text = "frmSetup";
            this.Load += new System.EventHandler(this.frmSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDatabasepath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSTFiler;
        private System.Windows.Forms.TextBox txtWithholdingFiler;
        private System.Windows.Forms.TextBox txtSTNonFiler;
        private System.Windows.Forms.TextBox txtWithHoldingNonFiler;
        private System.Windows.Forms.TextBox txtCustomerSalesTax;
        private System.Windows.Forms.TextBox txtCompanyAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDbPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox txtNTN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSTRN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPOSID;
        private System.Windows.Forms.Label label10;
    }
}