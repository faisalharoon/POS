﻿namespace General_App
{
    partial class frmreportProfit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnshow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtmend = new System.Windows.Forms.MonthCalendar();
            this.dtmstart = new System.Windows.Forms.MonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbtndaily = new System.Windows.Forms.RadioButton();
            this.rdbtnItemvise = new System.Windows.Forms.RadioButton();
            this.rdbtnDayvise = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnshow);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtmend);
            this.panel1.Controls.Add(this.dtmstart);
            this.panel1.Location = new System.Drawing.Point(24, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 210);
            this.panel1.TabIndex = 0;
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(230, 184);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(75, 23);
            this.btnshow.TabIndex = 4;
            this.btnshow.Text = "Show";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // dtmend
            // 
            this.dtmend.Location = new System.Drawing.Point(274, 22);
            this.dtmend.Name = "dtmend";
            this.dtmend.TabIndex = 1;
            // 
            // dtmstart
            // 
            this.dtmstart.Location = new System.Drawing.Point(29, 22);
            this.dtmstart.Name = "dtmstart";
            this.dtmstart.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 375);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(3, 16);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(860, 353);
            this.reportViewer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbtndaily);
            this.groupBox2.Controls.Add(this.rdbtnItemvise);
            this.groupBox2.Controls.Add(this.rdbtnDayvise);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(604, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 210);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // rdbtndaily
            // 
            this.rdbtndaily.AutoSize = true;
            this.rdbtndaily.Checked = true;
            this.rdbtndaily.Location = new System.Drawing.Point(93, 24);
            this.rdbtndaily.Name = "rdbtndaily";
            this.rdbtndaily.Size = new System.Drawing.Size(48, 17);
            this.rdbtndaily.TabIndex = 7;
            this.rdbtndaily.TabStop = true;
            this.rdbtndaily.Text = "Daily";
            this.rdbtndaily.UseVisualStyleBackColor = true;
            // 
            // rdbtnItemvise
            // 
            this.rdbtnItemvise.AutoSize = true;
            this.rdbtnItemvise.Location = new System.Drawing.Point(93, 70);
            this.rdbtnItemvise.Name = "rdbtnItemvise";
            this.rdbtnItemvise.Size = new System.Drawing.Size(68, 17);
            this.rdbtnItemvise.TabIndex = 6;
            this.rdbtnItemvise.Text = "Item Vise";
            this.rdbtnItemvise.UseVisualStyleBackColor = true;
            // 
            // rdbtnDayvise
            // 
            this.rdbtnDayvise.AutoSize = true;
            this.rdbtnDayvise.Location = new System.Drawing.Point(93, 47);
            this.rdbtnDayvise.Name = "rdbtnDayvise";
            this.rdbtnDayvise.Size = new System.Drawing.Size(67, 17);
            this.rdbtnDayvise.TabIndex = 5;
            this.rdbtnDayvise.Text = "Day Vise";
            this.rdbtnDayvise.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Report Type";
            // 
            // frmreportProfit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 666);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmreportProfit";
            this.Text = "frmreport";
            this.Load += new System.EventHandler(this.frmreport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar dtmend;
        private System.Windows.Forms.MonthCalendar dtmstart;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbtndaily;
        private System.Windows.Forms.RadioButton rdbtnItemvise;
        private System.Windows.Forms.RadioButton rdbtnDayvise;
    }
}