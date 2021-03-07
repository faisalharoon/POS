namespace General_App
{
    partial class frmUpdateSale
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnshowall = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtorderdate = new System.Windows.Forms.DateTimePicker();
            this.btnsearchorder = new System.Windows.Forms.Button();
            this.txtorderno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgsale = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgsaledetail = new System.Windows.Forms.DataGridView();
            this.SaleDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ddlcustomer = new System.Windows.Forms.ComboBox();
            this.btnsaledelete = new System.Windows.Forms.Button();
            this.btnsaleUpdate = new System.Windows.Forms.Button();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCancelItemDetail = new System.Windows.Forms.Button();
            this.btnsearchitem = new System.Windows.Forms.Button();
            this.btnupdateItem = new System.Windows.Forms.Button();
            this.txtitemunitprice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtitemquantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsale)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsaledetail)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnshowall);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtorderdate);
            this.groupBox1.Controls.Add(this.btnsearchorder);
            this.groupBox1.Controls.Add(this.txtorderno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1119, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnshowall
            // 
            this.btnshowall.Location = new System.Drawing.Point(752, 27);
            this.btnshowall.Name = "btnshowall";
            this.btnshowall.Size = new System.Drawing.Size(102, 20);
            this.btnshowall.TabIndex = 12;
            this.btnshowall.Text = "Show All";
            this.btnshowall.UseVisualStyleBackColor = true;
            this.btnshowall.Click += new System.EventHandler(this.btnshowall_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(481, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Order no";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Order date";
            this.label8.Visible = false;
            // 
            // txtorderdate
            // 
            this.txtorderdate.Location = new System.Drawing.Point(330, 27);
            this.txtorderdate.Name = "txtorderdate";
            this.txtorderdate.Size = new System.Drawing.Size(148, 20);
            this.txtorderdate.TabIndex = 10;
            this.txtorderdate.Visible = false;
            // 
            // btnsearchorder
            // 
            this.btnsearchorder.Location = new System.Drawing.Point(644, 26);
            this.btnsearchorder.Name = "btnsearchorder";
            this.btnsearchorder.Size = new System.Drawing.Size(102, 23);
            this.btnsearchorder.TabIndex = 9;
            this.btnsearchorder.Text = "Search Order";
            this.btnsearchorder.UseVisualStyleBackColor = true;
            this.btnsearchorder.Click += new System.EventHandler(this.btnsearchorder_Click);
            // 
            // txtorderno
            // 
            this.txtorderno.Location = new System.Drawing.Point(484, 27);
            this.txtorderno.Name = "txtorderno";
            this.txtorderno.Size = new System.Drawing.Size(154, 20);
            this.txtorderno.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Update Sale";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgsale);
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 222);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sale";
            // 
            // dgsale
            // 
            this.dgsale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DiscountPercentage,
            this.OrderNo,
            this.CustomerName,
            this.CreationDate,
            this.Discount,
            this.Amount,
            this.Print});
            this.dgsale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsale.Location = new System.Drawing.Point(3, 16);
            this.dgsale.Name = "dgsale";
            this.dgsale.Size = new System.Drawing.Size(567, 203);
            this.dgsale.TabIndex = 0;
            this.dgsale.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsale_CellClick);
            this.dgsale.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsale_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // DiscountPercentage
            // 
            this.DiscountPercentage.DataPropertyName = "DiscountPercentage";
            this.DiscountPercentage.HeaderText = "DiscountPercentage";
            this.DiscountPercentage.Name = "DiscountPercentage";
            this.DiscountPercentage.Visible = false;
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "OrderNo";
            this.OrderNo.HeaderText = "OrderNo";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Width = 45;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 160;
            // 
            // CreationDate
            // 
            this.CreationDate.DataPropertyName = "CreationDate";
            this.CreationDate.HeaderText = "CreationDate";
            this.CreationDate.Name = "CreationDate";
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.Width = 50;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Total";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 50;
            // 
            // Print
            // 
            this.Print.HeaderText = "Print";
            this.Print.Name = "Print";
            this.Print.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Print.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Print.Text = "Print";
            this.Print.ToolTipText = "Print";
            this.Print.UseColumnTextForButtonValue = true;
            this.Print.Width = 60;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgsaledetail);
            this.groupBox3.Location = new System.Drawing.Point(591, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(543, 219);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sale Detail";
            // 
            // dgsaledetail
            // 
            this.dgsaledetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsaledetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleDetailID,
            this.DetailItemID,
            this.ItemName,
            this.Quantity,
            this.Price,
            this.Total,
            this.dataGridViewTextBoxColumn2,
            this.Delete});
            this.dgsaledetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsaledetail.Location = new System.Drawing.Point(3, 16);
            this.dgsaledetail.Name = "dgsaledetail";
            this.dgsaledetail.Size = new System.Drawing.Size(537, 200);
            this.dgsaledetail.TabIndex = 0;
            this.dgsaledetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsaledetail_CellClick);
            // 
            // SaleDetailID
            // 
            this.SaleDetailID.DataPropertyName = "ID";
            this.SaleDetailID.HeaderText = "ID";
            this.SaleDetailID.Name = "SaleDetailID";
            this.SaleDetailID.Width = 50;
            // 
            // DetailItemID
            // 
            this.DetailItemID.DataPropertyName = "ItemID";
            this.DetailItemID.HeaderText = "ItemID";
            this.DetailItemID.Name = "DetailItemID";
            this.DetailItemID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 50;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.Width = 50;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CreationDate";
            this.dataGridViewTextBoxColumn2.HeaderText = "CreationDate";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Width = 60;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ddlcustomer);
            this.groupBox4.Controls.Add(this.btnsaledelete);
            this.groupBox4.Controls.Add(this.btnsaleUpdate);
            this.groupBox4.Controls.Add(this.txtamount);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtdiscount);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(15, 302);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(476, 198);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Update Sale";
            // 
            // ddlcustomer
            // 
            this.ddlcustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlcustomer.FormattingEnabled = true;
            this.ddlcustomer.Location = new System.Drawing.Point(130, 53);
            this.ddlcustomer.Name = "ddlcustomer";
            this.ddlcustomer.Size = new System.Drawing.Size(154, 21);
            this.ddlcustomer.TabIndex = 8;
            // 
            // btnsaledelete
            // 
            this.btnsaledelete.Location = new System.Drawing.Point(209, 128);
            this.btnsaledelete.Name = "btnsaledelete";
            this.btnsaledelete.Size = new System.Drawing.Size(75, 23);
            this.btnsaledelete.TabIndex = 7;
            this.btnsaledelete.Text = "Delete";
            this.btnsaledelete.UseVisualStyleBackColor = true;
            this.btnsaledelete.Click += new System.EventHandler(this.btnsaledelete_Click);
            // 
            // btnsaleUpdate
            // 
            this.btnsaleUpdate.Location = new System.Drawing.Point(108, 128);
            this.btnsaleUpdate.Name = "btnsaleUpdate";
            this.btnsaleUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnsaleUpdate.TabIndex = 6;
            this.btnsaleUpdate.Text = "Update";
            this.btnsaleUpdate.UseVisualStyleBackColor = true;
            this.btnsaleUpdate.Click += new System.EventHandler(this.btnsaleUpdate_Click);
            // 
            // txtamount
            // 
            this.txtamount.Enabled = false;
            this.txtamount.Location = new System.Drawing.Point(130, 102);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(154, 20);
            this.txtamount.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Amount";
            // 
            // txtdiscount
            // 
            this.txtdiscount.Location = new System.Drawing.Point(130, 76);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(154, 20);
            this.txtdiscount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Discount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer Name";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCancelItemDetail);
            this.groupBox5.Controls.Add(this.btnsearchitem);
            this.groupBox5.Controls.Add(this.btnupdateItem);
            this.groupBox5.Controls.Add(this.txtitemunitprice);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtitemquantity);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtItemName);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(494, 302);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(476, 198);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Update Sale Detail";
            // 
            // btnCancelItemDetail
            // 
            this.btnCancelItemDetail.Location = new System.Drawing.Point(232, 128);
            this.btnCancelItemDetail.Name = "btnCancelItemDetail";
            this.btnCancelItemDetail.Size = new System.Drawing.Size(75, 23);
            this.btnCancelItemDetail.TabIndex = 10;
            this.btnCancelItemDetail.Text = "Cancel";
            this.btnCancelItemDetail.UseVisualStyleBackColor = true;
            this.btnCancelItemDetail.Click += new System.EventHandler(this.btnCancelItemDetail_Click);
            // 
            // btnsearchitem
            // 
            this.btnsearchitem.Location = new System.Drawing.Point(290, 50);
            this.btnsearchitem.Name = "btnsearchitem";
            this.btnsearchitem.Size = new System.Drawing.Size(43, 20);
            this.btnsearchitem.TabIndex = 9;
            this.btnsearchitem.Text = ".....";
            this.btnsearchitem.UseVisualStyleBackColor = true;
            this.btnsearchitem.Click += new System.EventHandler(this.btnsearchitem_Click);
            // 
            // btnupdateItem
            // 
            this.btnupdateItem.Location = new System.Drawing.Point(151, 128);
            this.btnupdateItem.Name = "btnupdateItem";
            this.btnupdateItem.Size = new System.Drawing.Size(75, 23);
            this.btnupdateItem.TabIndex = 6;
            this.btnupdateItem.Text = "Update";
            this.btnupdateItem.UseVisualStyleBackColor = true;
            this.btnupdateItem.Click += new System.EventHandler(this.btnupdateItem_Click);
            // 
            // txtitemunitprice
            // 
            this.txtitemunitprice.Location = new System.Drawing.Point(130, 102);
            this.txtitemunitprice.Name = "txtitemunitprice";
            this.txtitemunitprice.Size = new System.Drawing.Size(154, 20);
            this.txtitemunitprice.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 105);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Unit Price";
            // 
            // txtitemquantity
            // 
            this.txtitemquantity.Location = new System.Drawing.Point(130, 76);
            this.txtitemquantity.Name = "txtitemquantity";
            this.txtitemquantity.Size = new System.Drawing.Size(154, 20);
            this.txtitemquantity.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Quantity";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(130, 50);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(154, 20);
            this.txtItemName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Item Name";
            // 
            // frmUpdateSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 512);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUpdateSale";
            this.Text = "frmUpdateSale";
            this.Load += new System.EventHandler(this.frmUpdateSale_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsale)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsaledetail)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgsale;
        private System.Windows.Forms.DataGridView dgsaledetail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnsaledelete;
        private System.Windows.Forms.Button btnsaleUpdate;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnupdateItem;
        private System.Windows.Forms.TextBox txtitemunitprice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtitemquantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewButtonColumn Print;
        private System.Windows.Forms.ComboBox ddlcustomer;
        private System.Windows.Forms.DateTimePicker txtorderdate;
        private System.Windows.Forms.Button btnsearchorder;
        private System.Windows.Forms.TextBox txtorderno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnshowall;
        private System.Windows.Forms.Button btnsearchitem;
        private System.Windows.Forms.Button btnCancelItemDetail;
    }
}