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
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDatabasepath
            // 
            this.btnDatabasepath.Location = new System.Drawing.Point(341, 69);
            this.btnDatabasepath.Name = "btnDatabasepath";
            this.btnDatabasepath.Size = new System.Drawing.Size(108, 20);
            this.btnDatabasepath.TabIndex = 0;
            this.btnDatabasepath.Text = "Select Database";
            this.btnDatabasepath.UseVisualStyleBackColor = true;
            this.btnDatabasepath.Click += new System.EventHandler(this.btnDatabasepath_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(199, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 53);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vendor Sale Tax % Filer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vendor With Holding Tax % Filer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vendor Sale Tax % Non Filer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vendor Sale Tax % Non Filer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Customer Sale Tax %";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtSTFiler
            // 
            this.txtSTFiler.Location = new System.Drawing.Point(175, 130);
            this.txtSTFiler.Name = "txtSTFiler";
            this.txtSTFiler.Size = new System.Drawing.Size(274, 20);
            this.txtSTFiler.TabIndex = 1;
            // 
            // txtWithholdingFiler
            // 
            this.txtWithholdingFiler.Location = new System.Drawing.Point(175, 159);
            this.txtWithholdingFiler.Name = "txtWithholdingFiler";
            this.txtWithholdingFiler.Size = new System.Drawing.Size(274, 20);
            this.txtWithholdingFiler.TabIndex = 2;
            // 
            // txtSTNonFiler
            // 
            this.txtSTNonFiler.Location = new System.Drawing.Point(175, 185);
            this.txtSTNonFiler.Name = "txtSTNonFiler";
            this.txtSTNonFiler.Size = new System.Drawing.Size(274, 20);
            this.txtSTNonFiler.TabIndex = 3;
            // 
            // txtWithHoldingNonFiler
            // 
            this.txtWithHoldingNonFiler.Location = new System.Drawing.Point(175, 211);
            this.txtWithHoldingNonFiler.Name = "txtWithHoldingNonFiler";
            this.txtWithHoldingNonFiler.Size = new System.Drawing.Size(274, 20);
            this.txtWithHoldingNonFiler.TabIndex = 4;
            // 
            // txtCustomerSalesTax
            // 
            this.txtCustomerSalesTax.Location = new System.Drawing.Point(175, 237);
            this.txtCustomerSalesTax.Name = "txtCustomerSalesTax";
            this.txtCustomerSalesTax.Size = new System.Drawing.Size(274, 20);
            this.txtCustomerSalesTax.TabIndex = 5;
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.Location = new System.Drawing.Point(175, 289);
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.Size = new System.Drawing.Size(274, 20);
            this.txtCompanyAddress.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Company Address";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(175, 263);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(274, 20);
            this.txtCompanyName.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Company Name";
            // 
            // txtDbPath
            // 
            this.txtDbPath.Location = new System.Drawing.Point(6, 69);
            this.txtDbPath.Name = "txtDbPath";
            this.txtDbPath.Size = new System.Drawing.Size(329, 20);
            this.txtDbPath.TabIndex = 16;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 325);
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
    }
}