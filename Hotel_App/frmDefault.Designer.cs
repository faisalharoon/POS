namespace General_App
{
    partial class frmDefault
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefault));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsaveandPrint = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ddlcustomer = new System.Windows.Forms.ComboBox();
            this.btnOpenCustomerDialog = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtgst = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnViewBill = new System.Windows.Forms.Button();
            this.txtnet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stripSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAdditemcategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_addnewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAddExpense = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addVendorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePurchaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorPaymentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.distributorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDistributorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSaleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.distributorPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripReports = new System.Windows.Forms.ToolStripMenuItem();
            this.saleReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributorProfitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.distributorBalanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strigloggoff = new System.Windows.Forms.ToolStripMenuItem();
            this.stripexit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtoldorderNo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stockReport2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsaveandPrint);
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtItemName);
            this.groupBox2.Location = new System.Drawing.Point(12, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(562, 424);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enter Sale";
            // 
            // btnsaveandPrint
            // 
            this.btnsaveandPrint.Location = new System.Drawing.Point(338, 58);
            this.btnsaveandPrint.Name = "btnsaveandPrint";
            this.btnsaveandPrint.Size = new System.Drawing.Size(218, 35);
            this.btnsaveandPrint.TabIndex = 13;
            this.btnsaveandPrint.Text = "Print and Save Bill";
            this.btnsaveandPrint.UseVisualStyleBackColor = true;
            this.btnsaveandPrint.Click += new System.EventHandler(this.btnsaveandPrint_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(385, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 24);
            this.lblName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.AcceptsTab = true;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(109, 54);
            this.txtQuantity.Multiline = true;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(223, 41);
            this.txtQuantity.TabIndex = 11;
            this.txtQuantity.Text = "1";
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.ID,
            this.ItemName,
            this.Quantity,
            this.Price,
            this.Total,
            this.Discount,
            this.GrossTotal});
            this.dataGridView1.Location = new System.Drawing.Point(0, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(556, 317);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Text = "Del";
            this.Delete.Width = 30;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "Name";
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 180;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Qty";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 30;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.Width = 70;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 70;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.Width = 70;
            // 
            // GrossTotal
            // 
            this.GrossTotal.DataPropertyName = "GrossTotal";
            this.GrossTotal.HeaderText = "G.Total";
            this.GrossTotal.Name = "GrossTotal";
            this.GrossTotal.Width = 80;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(338, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 35);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = ".....";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Item";
            // 
            // txtItemName
            // 
            this.txtItemName.AcceptsTab = true;
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(109, 10);
            this.txtItemName.MaxLength = 25;
            this.txtItemName.Multiline = true;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(223, 39);
            this.txtItemName.TabIndex = 4;
            this.txtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "(ctrl + N)  for new Sale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Distributor Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Discount %";
            // 
            // txtdiscount
            // 
            this.txtdiscount.AcceptsTab = true;
            this.txtdiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiscount.Location = new System.Drawing.Point(136, 25);
            this.txtdiscount.Multiline = true;
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(186, 35);
            this.txtdiscount.TabIndex = 3;
            this.txtdiscount.Text = "0";
            this.txtdiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdiscount_KeyUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ddlcustomer);
            this.groupBox3.Controls.Add(this.btnOpenCustomerDialog);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtgst);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txttotal);
            this.groupBox3.Location = new System.Drawing.Point(399, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Distributor Information";
            // 
            // ddlcustomer
            // 
            this.ddlcustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlcustomer.FormattingEnabled = true;
            this.ddlcustomer.Location = new System.Drawing.Point(206, 22);
            this.ddlcustomer.Name = "ddlcustomer";
            this.ddlcustomer.Size = new System.Drawing.Size(262, 21);
            this.ddlcustomer.TabIndex = 18;
            this.ddlcustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlcustomer_KeyUp);
            // 
            // btnOpenCustomerDialog
            // 
            this.btnOpenCustomerDialog.Location = new System.Drawing.Point(474, 22);
            this.btnOpenCustomerDialog.Name = "btnOpenCustomerDialog";
            this.btnOpenCustomerDialog.Size = new System.Drawing.Size(47, 21);
            this.btnOpenCustomerDialog.TabIndex = 17;
            this.btnOpenCustomerDialog.Text = ".....";
            this.btnOpenCustomerDialog.UseVisualStyleBackColor = true;
            this.btnOpenCustomerDialog.Click += new System.EventHandler(this.btnOpenCustomerDialog_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(360, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 29);
            this.label8.TabIndex = 16;
            this.label8.Text = "GST %";
            this.label8.Visible = false;
            // 
            // txtgst
            // 
            this.txtgst.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgst.Location = new System.Drawing.Point(462, 57);
            this.txtgst.Name = "txtgst";
            this.txtgst.Size = new System.Drawing.Size(59, 35);
            this.txtgst.TabIndex = 15;
            this.txtgst.Text = "0";
            this.txtgst.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(122, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total";
            // 
            // txttotal
            // 
            this.txttotal.Enabled = false;
            this.txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.Location = new System.Drawing.Point(206, 57);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(125, 35);
            this.txttotal.TabIndex = 13;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.webBrowser1);
            this.groupBox4.Controls.Add(this.reportViewer2);
            this.groupBox4.Location = new System.Drawing.Point(580, 278);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(374, 395);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Print Option";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(368, 376);
            this.webBrowser1.TabIndex = 500;
            this.webBrowser1.Visible = false;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.Location = new System.Drawing.Point(3, 16);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(368, 376);
            this.reportViewer2.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnViewBill);
            this.groupBox5.Controls.Add(this.txtnet);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtdiscount);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(586, 118);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(368, 154);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Total";
            // 
            // btnViewBill
            // 
            this.btnViewBill.Location = new System.Drawing.Point(11, 125);
            this.btnViewBill.Name = "btnViewBill";
            this.btnViewBill.Size = new System.Drawing.Size(212, 23);
            this.btnViewBill.TabIndex = 10;
            this.btnViewBill.Text = "View Bill in Full Window";
            this.btnViewBill.UseVisualStyleBackColor = true;
            this.btnViewBill.Visible = false;
            this.btnViewBill.Click += new System.EventHandler(this.btnViewBill_Click);
            // 
            // txtnet
            // 
            this.txtnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnet.Location = new System.Drawing.Point(136, 72);
            this.txtnet.Name = "txtnet";
            this.txtnet.Size = new System.Drawing.Size(186, 35);
            this.txtnet.TabIndex = 8;
            this.txtnet.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtnet_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 29);
            this.label7.TabIndex = 9;
            this.label7.Text = "NET Total";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripSetup,
            this.vendorToolStripMenuItem1,
            this.distributorToolStripMenuItem,
            this.stripReports,
            this.strigloggoff,
            this.stripexit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(974, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stripSetup
            // 
            this.stripSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripAdditemcategory,
            this.menu_addnewItem,
            this.addUserToolStripMenuItem,
            this.stripAddExpense});
            this.stripSetup.Name = "stripSetup";
            this.stripSetup.Size = new System.Drawing.Size(49, 20);
            this.stripSetup.Text = "Setup";
            // 
            // stripAdditemcategory
            // 
            this.stripAdditemcategory.Name = "stripAdditemcategory";
            this.stripAdditemcategory.Size = new System.Drawing.Size(174, 22);
            this.stripAdditemcategory.Text = "Add Item Category";
            this.stripAdditemcategory.Click += new System.EventHandler(this.stripAdditemcategory_Click);
            // 
            // menu_addnewItem
            // 
            this.menu_addnewItem.Name = "menu_addnewItem";
            this.menu_addnewItem.Size = new System.Drawing.Size(174, 22);
            this.menu_addnewItem.Text = "Add New Item";
            this.menu_addnewItem.Click += new System.EventHandler(this.menu_addnewItem_Click);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // stripAddExpense
            // 
            this.stripAddExpense.Name = "stripAddExpense";
            this.stripAddExpense.Size = new System.Drawing.Size(174, 22);
            this.stripAddExpense.Text = "Add Expense";
            this.stripAddExpense.Click += new System.EventHandler(this.stripAddExpense_Click);
            // 
            // vendorToolStripMenuItem1
            // 
            this.vendorToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVendorToolStripMenuItem1,
            this.purchaseToolStripMenuItem,
            this.updatePurchaseToolStripMenuItem1,
            this.vendorPaymentToolStripMenuItem1,
            this.paymentDetailsToolStripMenuItem});
            this.vendorToolStripMenuItem1.Name = "vendorToolStripMenuItem1";
            this.vendorToolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            this.vendorToolStripMenuItem1.Text = "Vendor";
            // 
            // addVendorToolStripMenuItem1
            // 
            this.addVendorToolStripMenuItem1.Name = "addVendorToolStripMenuItem1";
            this.addVendorToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.addVendorToolStripMenuItem1.Text = "Add Vendor";
            this.addVendorToolStripMenuItem1.Click += new System.EventHandler(this.addVendorToolStripMenuItem1_Click);
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.purchaseToolStripMenuItem.Text = "Add Purchase";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // updatePurchaseToolStripMenuItem1
            // 
            this.updatePurchaseToolStripMenuItem1.Name = "updatePurchaseToolStripMenuItem1";
            this.updatePurchaseToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.updatePurchaseToolStripMenuItem1.Text = "Update Purchase";
            this.updatePurchaseToolStripMenuItem1.Click += new System.EventHandler(this.updatePurchaseToolStripMenuItem1_Click);
            // 
            // vendorPaymentToolStripMenuItem1
            // 
            this.vendorPaymentToolStripMenuItem1.Name = "vendorPaymentToolStripMenuItem1";
            this.vendorPaymentToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.vendorPaymentToolStripMenuItem1.Text = "Add Vendor Payment";
            this.vendorPaymentToolStripMenuItem1.Click += new System.EventHandler(this.vendorPaymentToolStripMenuItem1_Click);
            // 
            // distributorToolStripMenuItem
            // 
            this.distributorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDistributorToolStripMenuItem,
            this.updateSaleToolStripMenuItem1,
            this.distributorPaymentToolStripMenuItem});
            this.distributorToolStripMenuItem.Name = "distributorToolStripMenuItem";
            this.distributorToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.distributorToolStripMenuItem.Text = "Distributor";
            // 
            // addDistributorToolStripMenuItem
            // 
            this.addDistributorToolStripMenuItem.Name = "addDistributorToolStripMenuItem";
            this.addDistributorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addDistributorToolStripMenuItem.Text = "Add Distributor";
            this.addDistributorToolStripMenuItem.Click += new System.EventHandler(this.addDistributorToolStripMenuItem_Click);
            // 
            // updateSaleToolStripMenuItem1
            // 
            this.updateSaleToolStripMenuItem1.Name = "updateSaleToolStripMenuItem1";
            this.updateSaleToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.updateSaleToolStripMenuItem1.Text = "Update Sale";
            this.updateSaleToolStripMenuItem1.Click += new System.EventHandler(this.updateSaleToolStripMenuItem1_Click);
            // 
            // distributorPaymentToolStripMenuItem
            // 
            this.distributorPaymentToolStripMenuItem.Name = "distributorPaymentToolStripMenuItem";
            this.distributorPaymentToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.distributorPaymentToolStripMenuItem.Text = "Add Distributor Payment";
            this.distributorPaymentToolStripMenuItem.Click += new System.EventHandler(this.distributorPaymentToolStripMenuItem_Click);
            // 
            // stripReports
            // 
            this.stripReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saleReportToolStripMenuItem,
            this.stockReportToolStripMenuItem,
            this.distributorProfitToolStripMenuItem1,
            this.distributorBalanceToolStripMenuItem,
            this.stockReport2ToolStripMenuItem});
            this.stripReports.Name = "stripReports";
            this.stripReports.Size = new System.Drawing.Size(54, 20);
            this.stripReports.Text = "Report";
            // 
            // saleReportToolStripMenuItem
            // 
            this.saleReportToolStripMenuItem.Name = "saleReportToolStripMenuItem";
            this.saleReportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saleReportToolStripMenuItem.Text = "Sale Report";
            this.saleReportToolStripMenuItem.Click += new System.EventHandler(this.saleReportToolStripMenuItem_Click);
            // 
            // stockReportToolStripMenuItem
            // 
            this.stockReportToolStripMenuItem.Name = "stockReportToolStripMenuItem";
            this.stockReportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stockReportToolStripMenuItem.Text = "Stock Report";
            this.stockReportToolStripMenuItem.Click += new System.EventHandler(this.stockReportToolStripMenuItem_Click);
            // 
            // distributorProfitToolStripMenuItem1
            // 
            this.distributorProfitToolStripMenuItem1.Name = "distributorProfitToolStripMenuItem1";
            this.distributorProfitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.distributorProfitToolStripMenuItem1.Text = "Distributor Discount";
            this.distributorProfitToolStripMenuItem1.Click += new System.EventHandler(this.distributorProfitToolStripMenuItem1_Click);
            // 
            // distributorBalanceToolStripMenuItem
            // 
            this.distributorBalanceToolStripMenuItem.Name = "distributorBalanceToolStripMenuItem";
            this.distributorBalanceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.distributorBalanceToolStripMenuItem.Text = "Distributor Balance";
            this.distributorBalanceToolStripMenuItem.Click += new System.EventHandler(this.distributorBalanceToolStripMenuItem_Click);
            // 
            // strigloggoff
            // 
            this.strigloggoff.Name = "strigloggoff";
            this.strigloggoff.Size = new System.Drawing.Size(59, 20);
            this.strigloggoff.Text = "Log Off";
            this.strigloggoff.Click += new System.EventHandler(this.strigloggoff_Click);
            // 
            // stripexit
            // 
            this.stripexit.Name = "stripexit";
            this.stripexit.Size = new System.Drawing.Size(37, 20);
            this.stripexit.Text = "Exit";
            this.stripexit.Click += new System.EventHandler(this.stripexit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtoldorderNo);
            this.groupBox1.Location = new System.Drawing.Point(399, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Old Bill";
            this.groupBox1.Visible = false;
            // 
            // txtoldorderNo
            // 
            this.txtoldorderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoldorderNo.Location = new System.Drawing.Point(6, 19);
            this.txtoldorderNo.Multiline = true;
            this.txtoldorderNo.Name = "txtoldorderNo";
            this.txtoldorderNo.Size = new System.Drawing.Size(169, 75);
            this.txtoldorderNo.TabIndex = 17;
            this.txtoldorderNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtoldorderNo_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(371, 222);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // stockReport2ToolStripMenuItem
            // 
            this.stockReport2ToolStripMenuItem.Name = "stockReport2ToolStripMenuItem";
            this.stockReport2ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.stockReport2ToolStripMenuItem.Text = "Stock Generation Report";
            this.stockReport2ToolStripMenuItem.Click += new System.EventHandler(this.stockReport2ToolStripMenuItem_Click);
            // 
            // paymentDetailsToolStripMenuItem
            // 
            this.paymentDetailsToolStripMenuItem.Name = "paymentDetailsToolStripMenuItem";
            this.paymentDetailsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.paymentDetailsToolStripMenuItem.Text = "Payment Details";
            this.paymentDetailsToolStripMenuItem.Click += new System.EventHandler(this.paymentDetailsToolStripMenuItem_Click);
            // 
            // frmDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 718);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDefault";
            this.Text = "Point of Sale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.GroupBox groupBox4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtnet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtgst;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stripSetup;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripAddExpense;
        private System.Windows.Forms.ToolStripMenuItem stripReports;
        private System.Windows.Forms.ToolStripMenuItem saleReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strigloggoff;
        private System.Windows.Forms.ToolStripMenuItem stripexit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtoldorderNo;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem stripAdditemcategory;
        private System.Windows.Forms.ToolStripMenuItem menu_addnewItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpenCustomerDialog;
        private System.Windows.Forms.ComboBox ddlcustomer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnsaveandPrint;
        private System.Windows.Forms.ToolStripMenuItem stockReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addVendorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vendorPaymentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePurchaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem distributorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDistributorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateSaleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem distributorPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distributorProfitToolStripMenuItem1;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.ToolStripMenuItem distributorBalanceToolStripMenuItem;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossTotal;
        private System.Windows.Forms.ToolStripMenuItem stockReport2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentDetailsToolStripMenuItem;
    }
}

