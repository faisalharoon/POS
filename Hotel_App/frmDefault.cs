using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace General_App
{
    public partial class frmDefault : Form
    {

        public int glbSaleID = -1;
        public frmDefault()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        DataTable Maindt;
        bool booljustloaded = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            //GenerateFBRInvoice();
            //return;


            this.dataGridView1.Columns["GrossTotal"].ReadOnly = true;
            this.dataGridView1.Columns["Total"].ReadOnly = true;

            booljustloaded = true;

            if (LoggedInUser.UserRoleID == 3)// entry user
            {
                stripSetup.Visible = false;
                stripReports.Visible = false;
            }



            LoadCustomerDropDown();

            try
            {
                txtItemName.Focus();

                Maindt = new DataTable();
                Maindt.Columns.Add("SN");
                Maindt.Columns.Add("ID");
                Maindt.Columns.Add("Name");
                Maindt.Columns.Add("Quantity");
                Maindt.Columns.Add("Price");
                Maindt.Columns.Add("Total");

                Maindt.Columns.Add("ItemCategoryID");
                Maindt.Columns.Add("Discount%");
                Maindt.Columns.Add("Code");
                Maindt.Columns.Add("Discount");
                Maindt.Columns.Add("GrossTotal");
                Maindt.Columns.Add("GST");
                Maindt.Columns.Add("GST%");

                //if (!string.IsNullOrEmpty(General_App.Properties.Settings.Default.gst))
                // txtgst.Text = General_App.Properties.Settings.Default.gst;
                // else
                // txtgst.Text = "0";

                //DataTable dt = access2dt();
                // this.reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.reportViewer2.RefreshReport();
            dataGridView1.AutoGenerateColumns = false;

            fillItemSearch();


        }

        private void fillItemSearch()
        {
            try
            {
                AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
                DataTable dtCust = DALAccess.ExecuteDataTable("select * from item order by id asc");
                for (int i = 0; i < dtCust.Rows.Count; i++)
                {
                    coll.Add(dtCust.Rows[i]["Name"].ToString());
                }


                // txtItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //txtItemName.AutoCompleteSource = coll;
            }
            catch (Exception)
            {


            }
        }

        private void LoadCustomerDropDown()
        {
            try
            {
                DataTable dtCust = DALAccess.ExecuteDataTable("select * from customer order by id asc");
                ddlcustomer.ValueMember = "ID";
                ddlcustomer.DisplayMember = "Name";
                ddlcustomer.DataSource = dtCust;
            }
            catch (Exception)
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmItem frm = new frmItem();
            frm.focusTextbox();
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtItemName.Text = frm.ItemID;
                lblName.Text = frm.ItemName;
                txtItemName.Focus();
                txtItemName.SelectionStart = txtItemName.Text.Length;

                txtQuantity.Text = "1";
                txtQuantity.Focus();
                txtQuantity.SelectionStart = txtQuantity.Text.Length;

            }
            else
                txtQuantity.Text = "";

        }

        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            string ItemID = "";

            if (txtItemName.Text == "")
                return;

            bool isbarcode = false;
            if (txtItemName.Text.Length >= 8)
            {
                isbarcode = true;
            }

            txtItemName.Text = txtItemName.Text.Replace(Environment.NewLine, "");
            txtItemName.Text = txtItemName.Text.Replace("\t", "");

            try
            {
                DataTable dt = new DataTable();
                if (txtItemName.Text.Contains("%"))
                {
                    string itemName = txtItemName.Text.Trim().Replace("%", "");
                    DataTable dtitem = DALAccess.ExecuteDataTable("select * from item where name like '%" + itemName + "%'");
                    if (dtitem != null && dtitem.Rows.Count > 0)
                    {
                        lblName.Text = dtitem.Rows[0]["Name"].ToString();
                        //ItemID = dtitem.Rows[0]["Name"].ToString();
                    }
                    else
                        lblName.Text = "";

                    if (e.KeyCode == Keys.Enter)
                    {

                        if (dtitem != null && dtitem.Rows.Count > 0)
                        {
                            ItemID = dtitem.Rows[0]["ID"].ToString();
                            //txtItemName.Text = dtitem.Rows[0]["ID"].ToString();
                            //txtItemName.SelectionStart = txtItemName.Text.Length;
                        }
                        else
                        {
                            txtItemName.Text = "";
                        }
                    }
                }
                else
                {
                    
                    if (txtItemName.Text != "")
                    {
                        dt = DALAccess.ExecuteDataTable("select * from Item");

                        var dt2 = dt.AsEnumerable()
                       .Where(row => Convert.ToString(row.Field<int>("ID")) == txtItemName.Text || row.Field<String>("BarCode") == txtItemName.Text || row.Field<String>("Name").ToLower().Contains(txtItemName.Text.ToLower()))
                       .OrderByDescending(row => row.Field<int>("ID")).ToList();

                        if (dt2 != null && dt2.Count() > 0)
                        {
                            lblName.Text = dt2.First().Field<string>("Name");
                            ItemID = Convert.ToString(dt2.First().Field<int>("ID"));
                            //txtItemName.Text = Convert.ToString(dt2.First().Field<int>("ID"));
                            //txtItemName.SelectionStart = txtItemName.Text.Length;
                        }
                        else
                            lblName.Text = "";
                    }
                    else
                        lblName.Text = "";
                }


                if (isbarcode)
                {
                    txtItemName.Text = ItemID;
                    txtQuantity.Text = "1";
                    autosaveBarcode = 1;
                    txtQuantity_KeyUp(sender, e);
                }


                if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) && lblName.Text != "")
                {
                    txtItemName.Text = ItemID;
                    txtItemName.SelectionStart = txtItemName.Text.Length;

                    txtQuantity.Text = "1";
                    txtQuantity.Focus();
                    txtQuantity.SelectionStart = txtQuantity.Text.Length;
                }

                booljustloaded = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtQuantity.SelectionStart = txtQuantity.Text.Length;
        }






        int autosaveBarcode = 0;
        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {

            txtQuantity.Text = txtQuantity.Text.Replace(Environment.NewLine, "");
            txtQuantity.Text = txtQuantity.Text.Replace("\t", "");


            if (txtQuantity.Text == "")
                return;

            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || autosaveBarcode==1)
                {
                    
                    if (lblName.Text != "")
                    {
                        txtItemName.Focus();
                        string itemid = Convert.ToString(txtItemName.Text);
                        int quantity = Convert.ToInt32(txtQuantity.Text);

                        DataTable dtstock = DALAccess.ExecuteDataTable(@"select 
                    sum(ItemStock.stock)- (select IIF(sum(quantity) Is Null,0,sum(quantity)) from saledetail where itemid=Item.ID) as Quantity
                    from
                    (Item INNER JOIN ItemStock ON Item.ID = ItemStock.ItemID) 
                    where Item.ID=" + itemid + @"
                    group by Item.ID,Item.Name             
                            ");

                        //if (dtstock != null && dtstock.Rows.Count > 0)
                        //{
                        //    int availablestock = Convert.ToInt32(dtstock.Rows[0][0]);
                        //    if (quantity > availablestock)
                        //    {
                        //        MessageBox.Show("You are exceeding Stock limit..");

                        //        txtQuantity.Text = "0";
                        //        txtQuantity.Focus();

                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    txtItemName.Text = "";
                        //    txtItemName.Focus();
                        //    MessageBox.Show("Please Enter selected Item Stock.");
                        //    return;
                        //}

                        if (Convert.ToInt32(txtQuantity.Text) > 0)
                        {

                            DataTable dt = DALAccess.ExecuteDataTable("select * from Item where ID=" + itemid);


                            if (Maindt != null)
                            {
                                var innerGridItem = Maindt.AsEnumerable().Where(x => Convert.ToString(x.Field<object>("ID")) == itemid).FirstOrDefault();
                                if (innerGridItem != null)
                                {
                                    var alreadyCount = Convert.ToInt32(innerGridItem.Field<object>("Quantity")) + quantity;
                                    var innerIndex = Maindt.AsEnumerable().ToList().IndexOf(innerGridItem);

                                    double discountPercent = Convert.ToDouble(Maindt.Rows[innerIndex]["Discount%"]);
                                    double total = (Convert.ToDouble(alreadyCount) * Convert.ToDouble(Maindt.Rows[innerIndex]["Price"]));
                                    double discountAmount = Math.Round((total * discountPercent) / 100, 0);
                                    double gross = total - discountAmount;

                                    Maindt.Rows[innerIndex]["Quantity"] = alreadyCount;
                                    Maindt.Rows[innerIndex]["Discount"] = discountAmount.ToString();
                                    Maindt.Rows[innerIndex]["Total"] = total.ToString();
                                    Maindt.Rows[innerIndex]["GrossTotal"] = gross.ToString();

                                    double gstpercentage = Convert.ToDouble(Maindt.Rows[innerIndex]["GST%"]);
                                    double gst = Math.Round((gross * gstpercentage) / 100, 0);
                                    Maindt.Rows[innerIndex]["GST"] = gst.ToString();
                                    Maindt.Rows[innerIndex]["GST%"] = gstpercentage.ToString();

                                    dataGridView1.DataSource = Maindt;
                                    UpdateTotal(innerIndex, 0);
                                }
                                else
                                {
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        DataRow dr = Maindt.NewRow();
                                        dr["ID"] = txtItemName.Text;
                                        dr["Name"] = lblName.Text;
                                        dr["Quantity"] = txtQuantity.Text;

                                        double SalePrice = Convert.ToDouble(dt.Rows[0]["SalePrice"]);
                                        double Quantity = Convert.ToDouble(txtQuantity.Text);
                                        double total = SalePrice * Quantity;
                                        int itemcategoryId = Convert.ToInt32(dt.Rows[0]["ItemCategoryID"]);
                                        DataTable dtItemCategory = DALAccess.ExecuteDataTable("select * from ItemCategory where ID=" + itemcategoryId);
                                        double discountPercent = Convert.ToDouble(dtItemCategory.Rows[0]["DistributorProfitPercentage"]);
                                        double discountAmount = Math.Round((total * discountPercent) / 100, 0);
                                        double gross = total - discountAmount;

                                        dr["Price"] = SalePrice.ToString();
                                        dr["Total"] = total.ToString();
                                        dr["ItemCategoryID"] = dt.Rows[0]["ItemCategoryID"].ToString();
                                        dr["Discount%"] = discountPercent.ToString();
                                        dr["code"] = dtItemCategory.Rows[0]["code"].ToString();
                                        dr["Discount"] = discountAmount;
                                        dr["GrossTotal"] = gross;

                                        double gstpercentage = Convert.ToDouble(Convert.ToString(dt.Rows[0]["GST%"]) == "" ? 0 : dt.Rows[0]["GST%"]);
                                        double gst = Math.Round((gross * gstpercentage) / 100, 0);
                                        dr["GST"] = gst.ToString();
                                        dr["GST%"] = gstpercentage.ToString();
                                        dr["SN"] = Maindt.Rows.Count + 1;

                                        int currentRow = Maindt.Rows.Count;
                                        Maindt.Rows.Add(dr);
                                        dataGridView1.DataSource = Maindt;

                                        UpdateTotal(currentRow, 0);
                                    }
                                }
                            }



                        }

                        txtQuantity.Text = "";
                        txtItemName.Text = "";
                        lblName.Text = "";

                        //var total = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<string>("Total")));
                        //txttotal.Text = total.ToString();
                        //txtnet.Text = total.ToString();

                        //var dis = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                        //var total2 = Math.Round((total * dis) / 100, 0);



                    }
                    else
                    {

                        txtQuantity.Text = "1";
                        txtItemName.Text = "";
                        lblName.Text = "";

                        txtItemName.Focus();
                    }
                    autosaveBarcode = 0;
                }


            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        String FBRInvoiceNo = "";
        private void Print()
        {
            try
            {
                string customername = ddlcustomer.Text;
                double discount = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                double totalamount = Convert.ToDouble(txttotal.Text);

                //double discountAmount = Math.Round((totalamount * discount) / 100, 0);
                //double discountAmount = Convert.ToDouble(txtnet.Text) - Convert.ToDouble(txttotal.Text);
                double discountAmount = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<Object>("Discount")));

                double NetAmount = Convert.ToDouble(txtnet.Text);
                double TaxPercentage = 0;
                double TaxAmount = 0;

                string custST = Convert.ToString(XmlExtension.DeSerialize().CustomerSalesTax);
                if (custST != "")
                    TaxPercentage = Convert.ToDouble(custST);


                TaxAmount = Math.Round(((NetAmount * TaxPercentage) / 100), 0);

                int orderno = 1;
                //FBRInvoiceNo= GenerateFBRInvoice();
               // if (string.IsNullOrEmpty(FBRInvoiceNo))
                //{
                   // MessageBox.Show("Unable to generate FBR Invoice No. please try again.");
                   // return;
                //}

                if (glbSaleID == -1)
                {
                    if (Maindt != null && Maindt.Rows.Count > 0)
                    {
                        //DataTable dtMaxOrder = DALAccess.ExecuteDataTable("select max(orderno) from Sale where Format([CreationDate],'MM/DD/YYYY')='" + Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy") + "'");
                        DataTable dtMaxOrder = DALAccess.ExecuteDataTable("select max(orderno) from Sale");


                        if (dtMaxOrder != null && dtMaxOrder.Rows.Count > 0)
                            if (!string.IsNullOrEmpty(Convert.ToString(dtMaxOrder.Rows[0][0])))
                                orderno = Convert.ToInt32(dtMaxOrder.Rows[0][0]) + 1;



                        string str = "insert into Sale (CustomerName,CreationDate,OrderNo,Discount,DiscountPercentage,Total,UserID,CustomerID,SalesTax,gst,FBRInvoiceNo,NET) values ('" + customername + "','" + DateTime.Now + "'," + orderno + "," + discountAmount + "," + discount + "," + totalamount + "," + LoggedInUser.UserID + "," + ddlcustomer.SelectedValue + "," + TaxAmount + "," + txtgst.Text + ",'"+FBRInvoiceNo+"',"+txtnet.Text+")";
                        int saleid = DALAccess.ExecuteNonQuery(str);

                        for (int i = 0; i < Maindt.Rows.Count; i++)
                        {
                            int itemid = Convert.ToInt32(Maindt.Rows[i]["ID"]);
                            double price = Convert.ToDouble(Maindt.Rows[i]["Price"]);
                            int Quantity = Convert.ToInt32(Maindt.Rows[i]["Quantity"]);
                            double gst = Convert.ToInt32(Maindt.Rows[i]["GST"]);
                            double gstpercentage = Convert.ToInt32(Maindt.Rows[i]["GST%"]);
                            double total = price * Quantity;

                            DataTable dtpurchase = DALAccess.ExecuteDataTable("select purchaseprice from item where id=" + itemid);
                            var purchaseprice = Convert.ToInt32(dtpurchase.Rows[0][0]);

                            str = "insert into saledetail (saleid,itemid,Price,CreationDate,Quantity,total,purchaseprice,gstAmount,[GST%]) values (" + saleid + "," + itemid + "," + price + ",'" + DateTime.Now + "'," + Quantity + "," + total + "," + purchaseprice + "," + gst + "," + gstpercentage + ")";

                            //DALAccess.ExecuteNonQuery("update itemstock set stock=stock-" + Quantity + " where itemid=" + itemid);

                            DALAccess.ExecuteNonQuery(str);
                        }
                        glbSaleID = saleid;
                    }
                }
                else // update sale
                {
                    if (Maindt != null && Maindt.Rows.Count > 0)
                    {
                        DataTable dtoldSale = DALAccess.ExecuteDataTable("select orderno from Sale where id=" + glbSaleID);


                        if (dtoldSale != null && dtoldSale.Rows.Count > 0)
                            if (!string.IsNullOrEmpty(Convert.ToString(dtoldSale.Rows[0][0])))
                                orderno = Convert.ToInt32(dtoldSale.Rows[0]["orderno"]);



                        string str = @"update Sale set CustomerName='" + ddlcustomer.Text + @"',
                            Discount=" + discountAmount + @",DiscountPercentage=" + discount + @",Total=" + totalamount + @",modifiedDate='" + DateTime.Now + @"',ModifiedBy=" + LoggedInUser.UserID + @"
                            where id=" + glbSaleID;
                        DALAccess.ExecuteNonQuery(str);

                        DataTable dtoldSaledetail = DALAccess.ExecuteDataTable("select * from saledetail where saleid=" + glbSaleID);

                        foreach (DataRow dr in dtoldSaledetail.Rows)
                        {
                            int ItemID = Convert.ToInt32(dr["itemid"]);
                            int SaleDetailID = Convert.ToInt32(dr["ID"]);
                            int quantity = Convert.ToInt32(dr["quantity"]);

                            //DALAccess.ExecuteNonQuery("update itemstock set stock=stock+" + quantity + " where itemid=" + ItemID);
                            DALAccess.ExecuteNonQuery("delete from saledetail where id=" + SaleDetailID);
                        }


                        for (int i = 0; i < Maindt.Rows.Count; i++)
                        {
                            int itemid = Convert.ToInt32(Maindt.Rows[i]["ID"]);
                            double price = Convert.ToDouble(Maindt.Rows[i]["Price"]);
                            int Quantity = Convert.ToInt32(Maindt.Rows[i]["Quantity"]);
                            double total = price * Quantity;

                            DataTable dtpurchase = DALAccess.ExecuteDataTable("select purchaseprice from item where id=" + itemid);
                            var purchaseprice = Convert.ToInt32(dtpurchase.Rows[0][0]);

                            str = "insert into saledetail (saleid,itemid,Price,CreationDate,Quantity,total,purchaseprice) values (" + glbSaleID + "," + itemid + "," + price + ",'" + DateTime.Now + "'," + Quantity + "," + total + "," + purchaseprice + ")";

                            //DALAccess.ExecuteNonQuery("update itemstock set stock=stock-" + Quantity + " where itemid=" + itemid);
                            DALAccess.ExecuteNonQuery(str);
                        }

                        glbSaleID = -1;
                    }
                }
                PrintReport(orderno);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void InsertIntoCustomerPayment(double totalAmountToPay)
        {
            try
            {
                double amountpaid = Convert.ToDouble(txtamountpaid.Text == "" ? "0" : txtamountpaid.Text);
                double balance = totalAmountToPay-amountpaid;

                if (balance < 0)
                    balance = 0;

                if (amountpaid > totalAmountToPay)
                    amountpaid = totalAmountToPay;

                string query = "insert into customerpayment(customerid,amounttopay,amount,balance,createdat,createdby,paiddate) values (" + ddlcustomer.SelectedValue + "," + totalAmountToPay + "," + amountpaid + "," + balance + ",'" + DateTime.Now + "'," + LoggedInUser.UserID + ",'" + DateTime.Now + "')";
                DALAccess.ExecuteNonQuery(query);
            }
            catch (Exception)
            {
            }
        }

        private void PrintReport(int orderno)
        {
            try
            {
                reportViewer2.Clear();
                reportViewer2.LocalReport.DataSources.Clear();

                string dtmNow = DateTime.Now.ToString();

                DataTable tmpdt = Maindt.Copy();




                double total = tmpdt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<string>("Total")));
                int discount = Convert.ToInt32(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                //double totaldisoucnt = Convert.ToDouble(Math.Round(Convert.ToDecimal((total * discount) / 100), 0));
                double totaldisoucnt = Convert.ToDouble(txttotal.Text) - Convert.ToDouble(txtnet.Text);
                double gstpercentage = Convert.ToDouble(XmlExtension.DeSerialize().CustomerSalesTax);
                double gst = Convert.ToDouble(txtgst.Text);
                double grosstotal = (total - totaldisoucnt + gst);


                //var dtAll = Maindt.AsEnumerable().Select(x => new
                //{
                //    Name = Convert.ToString(x.Field<object>("Name")),
                //    Price = Convert.ToDouble(x.Field<object>("Price")),
                //    Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                //    Total = Convert.ToDouble(x.Field<object>("Total")),
                //    //Discount = Math.Round((Convert.ToDouble(x.Field<object>("Discount%")) * Convert.ToDouble(x.Field<object>("Total"))) / 100, 0)
                //    Discount = Convert.ToDouble(x.Field<object>("Discount"))
                //});

                //var dtBrush = Maindt.AsEnumerable().Where(x => Convert.ToString(x.Field<object>("code"))=="brush").Select(x=>new {
                // Name= Convert.ToString(x.Field<object>("Name")),
                // Price=Convert.ToDouble(x.Field<object>("Price")),
                //Quantity=Convert.ToInt32(x.Field<object>("Quantity")),
                //Total=Convert.ToDouble(x.Field<object>("Total")),
                //Discount = Math.Round((Convert.ToDouble(x.Field<object>("Discount%"))* Convert.ToDouble(x.Field<object>("Total")))/100,0)
                // Discount = Convert.ToDouble(x.Field<object>("Discount"))
                // }).ToList();


                //dtBrush.Add(new
                //{
                //    Name = "Total",
                //    Price = dtBrush.Sum(x=>x.Price),
                //    Quantity = dtBrush.Sum(x => x.Quantity),
                //    Total = dtBrush.Sum(x => x.Total),
                //    Discount = dtBrush.Sum(x => x.Discount)
                //});


                var dtDiaper = Maindt.AsEnumerable()
                    //.Where(x => Convert.ToString(x.Field<object>("code")) == "diaper")
                    .Select(x => new
                    {
                        SN = Convert.ToString(x.Field<object>("SN")),
                        Name = Convert.ToString(x.Field<object>("Name")),
                        Price = Convert.ToDouble(x.Field<object>("Price")),
                        Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                        Total = Convert.ToDouble(x.Field<object>("Total")),
                        //Discount = Math.Round((Convert.ToDouble(x.Field<object>("Discount%")) * Convert.ToDouble(x.Field<object>("Total"))) / 100, 0)
                        Discount = Convert.ToDouble(x.Field<object>("Discount")),
                        GST = Convert.ToDouble(x.Field<object>("GST")),
                        GSTPercentage = Convert.ToDouble(x.Field<object>("GST%")),
                        GrossTotal = Convert.ToDouble(x.Field<object>("GrossTotal"))
                    }).ToList();

                //dtDiaper.Add(new
                //{
                //    Name = "Total",
                //    Price = dtBrush.Sum(x => x.Price),
                //    Quantity = dtBrush.Sum(x => x.Quantity),
                //    Total = dtBrush.Sum(x => x.Total),
                //    Discount = dtBrush.Sum(x => x.Discount)
                //});


                try
                {


                    //Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                    Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;

                    pictureBox2.Image = qrcode.Draw(FBRInvoiceNo, 50);
                    ImageConverter converter = new ImageConverter();
                    byte[] tmp = (byte[])converter.ConvertTo(pictureBox2.Image, typeof(byte[]));


                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dtDiaper);
                    //reportViewer2.LocalReport.ReportPath = "../../Report1-Fullpage.rdlc";
                    reportViewer2.LocalReport.ReportPath = "../../Report1.rdlc";
                    reportViewer2.LocalReport.DataSources.Add(reportDSDetail);

                    DataTable dtbarcode = new DataTable();
                    dtbarcode.Columns.Add("Barcode", typeof(byte[]));
                    dtbarcode.Columns.Add("InvoiceNo");
                    DataRow dr = dtbarcode.NewRow();
                    dr["Barcode"] = tmp;
                    dr["InvoiceNo"] = FBRInvoiceNo;
                    dtbarcode.Rows.Add(dr);

                    ReportDataSource reportDSDetail2 = new ReportDataSource("DataSet2", dtbarcode);
                    reportViewer2.LocalReport.DataSources.Add(reportDSDetail2);


                    reportViewer2.LocalReport.EnableExternalImages = true;


                    //reportDSDetail = new ReportDataSource("DataSet2", dtBrush);
                    //reportViewer2.LocalReport.DataSources.Add(reportDSDetail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("dataset2: " + ex.Message);
                }


                DataTable dtCustomer = DALAccess.ExecuteDataTable("select * from customer where id=" + ddlcustomer.SelectedValue);


                ReportParameter[] p = new ReportParameter[14];
                p[0] = new ReportParameter("Date", DateTime.Now.ToString());


                double Discount = dtDiaper.Sum(x => x.Discount);

                p[1] = new ReportParameter("Total", total.ToString());
                p[2] = new ReportParameter("Discount", (Discount).ToString());
                p[3] = new ReportParameter("GTotal", txtnet.Text);
                p[4] = new ReportParameter("OrderNo", orderno.ToString());
                p[5] = new ReportParameter("Name", ddlcustomer.Text);
                p[6] = new ReportParameter("gst", gst.ToString());
                p[7] = new ReportParameter("ShopName", XmlExtension.GetSetupValues().CompanyName);
                p[8] = new ReportParameter("username", LoggedInUser.DisplayName);
                p[9] = new ReportParameter("ShopAddress", XmlExtension.GetSetupValues().CompanyAddress);

                p[10] = new ReportParameter("NTN", XmlExtension.GetSetupValues().NTN);
                p[11] = new ReportParameter("STRN", XmlExtension.GetSetupValues().STRN);
                p[12] = new ReportParameter("InvoiceNo", FBRInvoiceNo);
                p[13] = new ReportParameter("POSID", XmlExtension.GetSetupValues().POSID);



                //p[13] = new ReportParameter("Barcode", "");


                //p[10] = new ReportParameter("CNIC", Convert.ToString(dtCustomer.Rows[0]["CNIC"]));
                //p[11] = new ReportParameter("Mobile", Convert.ToString(dtCustomer.Rows[0]["Mobile"]));
                //p[12] = new ReportParameter("Address", Convert.ToString(dtCustomer.Rows[0]["Address"]));


                //p[13] = new ReportParameter("Total2", dtBrush.Sum(x=>x.Total).ToString());
                //p[14] = new ReportParameter("Total1", dtDiaper.Sum(x => x.Total).ToString());

                //p[15] = new ReportParameter("Discount2", dtBrush.Sum(x => x.Discount).ToString());
                //p[16] = new ReportParameter("Discount1", dtDiaper.Sum(x => x.Discount).ToString());

                //p[17] = new ReportParameter("GTotal2", (dtBrush.Sum(x => x.Total)-dtBrush.Sum(x => x.Discount)).ToString());
                //p[18] = new ReportParameter("GTotal1", (dtDiaper.Sum(x => x.Total)-dtDiaper.Sum(x => x.Discount)).ToString());

                //p[19] = new ReportParameter("FinalAmount", (dtAll.Sum(x => x.Total) - dtAll.Sum(x => x.Discount)).ToString());


                double totalnetAmount = (dtDiaper.Sum(x => x.Total) - dtDiaper.Sum(x => x.Discount) + gst);
                InsertIntoCustomerPayment(totalnetAmount);

                //System.Threading.Thread.Sleep(1000);

                try
                {
                    reportViewer2.LocalReport.SetParameters(p);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("set: " + ex.Message);
                }

                //reportViewer2.LocalReport.Refresh();

                //reportViewer2.RefreshReport();
                //reportViewer2.Visible = true;

                reportViewer2.LocalReport.Refresh();
                this.reportViewer2.RefreshReport();

                //System.Threading.Thread.Sleep(1000);
                printcount = 0;

                try
                {
                    reportViewer2.RenderingComplete += new RenderingCompleteEventHandler(PrintSales);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("render: " + ex.Message);
                }


                // string ReportTitle = "rpt title faisl";
                // string ReportName = "rpt report name";

                // ReportBuilder reportBuilder = new ReportBuilder();
                // reportBuilder.DataSource = new DataSet();
                // reportBuilder.Page = new ReportPage();
                // ReportSections reportFooter = new ReportSections();
                // ReportItems reportFooterItems = new ReportItems();
                // ReportTextBoxControl[] footerTxt = new ReportTextBoxControl[3];
                // string footer = string.Format
                // ("Copyright  {0}         Report Generated On  {1}          Page  {2}  of {3} ",
                // DateTime.Now.Year, DateTime.Now, ReportGlobalParameters.CurrentPageNumber,
                //ReportGlobalParameters.TotalPages);
                // footerTxt[0] = new ReportTextBoxControl()
                // { Name = "txtCopyright", ValueOrExpression = new string[] { footer } };
                // reportFooterItems.TextBoxControls = footerTxt;
                // reportFooter.ReportControlItems = reportFooterItems;
                // reportBuilder.Page.ReportFooter = reportFooter;
                // ReportSections reportHeader = new ReportSections();
                // reportHeader.Size = new ReportScale();
                // reportHeader.Size.Height = 0.56849;
                // ReportItems reportHeaderItems = new ReportItems();
                // ReportTextBoxControl[] headerTxt = new ReportTextBoxControl[1];
                // headerTxt[0] = new ReportTextBoxControl()
                // {
                //     Name = "txtReportTitle",
                //     ValueOrExpression = new string[] { "Report Name: " + ReportTitle }
                // };
                // reportHeaderItems.TextBoxControls = headerTxt;
                // reportHeader.ReportControlItems = reportHeaderItems;
                // reportBuilder.Page.ReportHeader = reportHeader;
                // reportViewer2.LocalReport.LoadReportDefinition(ReportEngine.GenerateReport(reportBuilder));
                // reportViewer2.LocalReport.DisplayName = ReportName;

            }
            catch (Exception ex)
            {
                MessageBox.Show("got error : " + ex.Message);
            }
        }

        int printcount = 0;
        public void PrintSales(object sender, RenderingCompleteEventArgs e)
        {
            try
            {
                if (printcount == 0)
                {
                    reportViewer2.PrintDialog();
                    printcount++;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Alt && e.KeyCode == Keys.T) // for combination of Alt + T
                {
                    MessageBox.Show("Alt + T");
                }
                if (e.Control && e.KeyCode == Keys.I) // for combination of Alt + T
                {
                    frmItem frm = new frmItem();
                    DialogResult dr = frm.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        txtItemName.Text = frm.ItemID;
                        lblName.Text = frm.ItemName;
                        txtItemName.Focus();
                        txtItemName.SelectionStart = txtItemName.Text.Length;
                    }
                    txtQuantity.Text = "";
                }

                if (e.Control && e.KeyCode == Keys.Q) // for combination of Ctrl + Q
                {
                    MessageBox.Show("Ctrl + Q");
                }
                if (e.Control && e.KeyCode == Keys.C) // for combination of Ctrl + Q
                {
                    //txtcustomername.Focus();
                    //txtcustomername.SelectionStart = txtcustomername.Text.Length;
                    ddlcustomer.Focus();
                }
                if (e.Control && e.KeyCode == Keys.N) // for combination of Ctrl + Q
                {
                    Maindt.Rows.Clear();
                    txtItemName.Focus();
                    ddlcustomer.SelectedIndex = 0;
                    txtdiscount.Text = "0";
                    txttotal.Text = "0";
                    txtnet.Text = "0";
                    txtamountpaid.Text = "0";

                    //webBrowser1.DocumentText = "";
                    reportViewer2.Clear();
                    btnViewBill.Visible = false;

                    glbSaleID = -1;
                }
                if (e.Shift && e.KeyCode == Keys.D) // for combination of Shift + D
                {
                    MessageBox.Show("Shift + D");
                }
                if (e.Alt && e.KeyCode == (Keys.RButton | Keys.ShiftKey | Keys.ControlKey)) // Alt + Shift
                {
                    MessageBox.Show("Shift + Alt");
                }
                if (e.Alt && e.KeyCode == Keys.R) // for combination of Alt + T
                {
                    //RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WindowLicenseTrialEntry");
                    // string val = Convert.ToString(key.GetValue("count"));
                    //key.SetValue("count", "0");

                    // key.Close();

                    // MessageBox.Show("OK. Registration Renewed.");
                }
                if (e.Control && e.KeyCode == Keys.O)
                {
                    //frmAddEntry f = new frmAddEntry();
                    //f.Show();
                    frmItem frm = new frmItem();
                    frm.focusTextbox();
                    DialogResult dr = frm.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        txtItemName.Text = frm.ItemID;
                        lblName.Text = frm.ItemName;
                        txtItemName.Focus();
                        txtItemName.SelectionStart = txtItemName.Text.Length;

                        txtQuantity.Text = "1";
                        txtQuantity.Focus();
                        txtQuantity.SelectionStart = txtQuantity.Text.Length;

                    }
                    else
                        txtQuantity.Text = "";
                }
                if (e.Control && e.KeyCode == Keys.G)
                {
                    frmTicket f = new frmTicket();
                    f.Show();
                }
                if (e.Control && e.KeyCode == Keys.Z)
                {
                    frmAddgameType f = new frmAddgameType();
                    f.Show();
                }
                if (e.Control && e.KeyCode == Keys.P)
                {
                    txtamountpaid.Focus();
                    txtamountpaid.SelectionStart = txtamountpaid.Text.Length;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtcustomername_KeyUp(object sender, KeyEventArgs e)
        {
            //txtcustomername.Text = txtcustomername.Text.Replace(Environment.NewLine, "");
            //txtcustomername.Text = txtcustomername.Text.Replace("\t", "");


            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtdiscount.Text = "0";
                txtdiscount.Focus();
                txtdiscount.SelectionStart = txtdiscount.Text.Length;
            }
        }

        private void txtdiscount_KeyUp(object sender, KeyEventArgs e)
        {
            txtdiscount.Text = txtdiscount.Text.Replace(Environment.NewLine, "");
            txtdiscount.Text = txtdiscount.Text.Replace("\t", "");


            if (txtdiscount.Text == "")
                return;


            if (txtdiscount.Text != "0")
            {
                txtnet.Text = Math.Round(
                    (Convert.ToDouble(txttotal.Text)) -
                    ((Convert.ToDouble(txttotal.Text) * Convert.ToDouble(txtdiscount.Text)) / 100)
                , 0).ToString();
            }


            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtnet.Focus();
            }
            txtnet.SelectionStart = txtnet.Text.Length;
            UpdateTotal(-1, 0);
        }


        private void PrintDiscount(Keys KeyCode)
        {

            if (txtdiscount.Text == "")
                txtdiscount.Text = "0";

            if (KeyCode == Keys.Enter || KeyCode == Keys.Tab)
            {
                if (Maindt.Rows.Count > 0)
                    Print();
            }

            //if (txtdiscount.Text != "")
            {
                double totalall = Convert.ToDouble(txttotal.Text);
                double discount = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                //double total = Convert.ToDouble(Math.Round(Convert.ToDecimal((totalall * discount) / 100), 0));
                double total = Convert.ToDouble(txttotal.Text) - Convert.ToDouble(txtnet.Text);
                txtnet.Text = (totalall - total).ToString();
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                int col = e.ColumnIndex;
                if (col == 0)
                {
                    Maindt.Rows.RemoveAt(e.RowIndex);
                    dataGridView1.DataSource = Maindt;

                    var total = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<string>("Total")));
                    txttotal.Text = total.ToString();
                    txtnet.Text = total.ToString();

                    var dis = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                    var total2 = Math.Round((total * dis) / 100, 0);
                }
                else
                {
                    //UpdateTotal(e.RowIndex);
                }

                UpdateTotal(-1, e.ColumnIndex);
            }
            catch (Exception)
            {
            }
        }


        private void updateGridSN()
        {

            for (int i = 1; i <= Maindt.Rows.Count; i++)
            {
                Maindt.Rows[i - 1]["SN"] = i;
            }
        }

        private void UpdateTotal(int rowinde, int colIndex)
        {
            try
            {
                if (rowinde >= 0)
                {

                    string PriceInGrid = Convert.ToString(dataGridView1.Rows[rowinde].Cells["Price"].Value);
                    string QuantityInGrid = Convert.ToString(dataGridView1.Rows[rowinde].Cells["Quantity"].Value);
                    string DiscountInGrid = Convert.ToString(dataGridView1.Rows[rowinde].Cells["Discount"].Value);


                    var singleprice = Convert.ToDouble(Maindt.Rows[rowinde]["Price"]);
                    var singleQuantity = Convert.ToDouble(Maindt.Rows[rowinde]["Quantity"]);
                    var singleDiscountPercentage = Convert.ToDouble(Maindt.Rows[rowinde]["Discount%"]);
                    var singleTotal = singleprice * singleQuantity;
                    //var singleDiscount = Common.Percentage(singleTotal, singleDiscountPercentage);
                    var singleDiscount = Convert.ToDouble(DiscountInGrid);

                    if (colIndex == dataGridView1.Columns["Discount"].Index)
                    {
                        if (Convert.ToDouble(DiscountInGrid) >= 0)
                            singleDiscount = Convert.ToDouble(DiscountInGrid);
                    }

                    Maindt.Rows[rowinde]["Total"] = singleTotal.ToString();
                    Maindt.Rows[rowinde]["Discount"] = singleDiscount.ToString();


                    double gstpercentage = Convert.ToDouble(Convert.ToString(Maindt.Rows[rowinde]["GST%"]));
                    double gst = Math.Round(((singleTotal - singleDiscount) * gstpercentage) / 100, 0);
                    Maindt.Rows[rowinde]["GST"] = gst.ToString();

                    Maindt.Rows[rowinde]["GrossTotal"] = (singleTotal - singleDiscount + gst).ToString();
                    dataGridView1.DataSource = Maindt;
                }



                updateGridSN();




                try
                {
                    var price = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Price")) * Convert.ToDouble(x.Field<object>("Quantity")));
                    var discountGridAmount = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Discount")));
                    var gst = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("gst")));

                    var discountPercentage = Convert.ToDouble(txtdiscount.Text);
                    var discountAmount = 0.0;

                    if (discountPercentage > 0)
                        discountAmount = Math.Round((price * discountPercentage) / 100, 0);
                    else
                        discountAmount = discountGridAmount;

                    var NetAmount = price - discountAmount + gst;

                    txttotal.Text = price.ToString();
                    txtnet.Text = NetAmount.ToString();
                    txtgst.Text = gst.ToString();
                }
                catch (Exception ex)
                {
                }




            }
            catch (Exception ex)
            {
            }
        }

        private void btnSaleReport_Click(object sender, EventArgs e)
        {
            frmreport r = new frmreport();
            r.Show();
        }

        private void menu_addnewItem_Click(object sender, EventArgs e)
        {
            frmAddItemfrv i = new frmAddItemfrv();
            i.Show();
        }

        private void strip_addItemStock_Click(object sender, EventArgs e)
        {
            frmAddItemStock s = new frmAddItemStock();
            s.Show();
        }

        private void updateSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateSale s = new frmUpdateSale();
            s.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser u = new frmAddUser();
            u.Show();
        }

        private void stripAddExpense_Click(object sender, EventArgs e)
        {
            frmExpenses f = new frmExpenses();
            f.Show();
        }

        private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmreport r = new frmreport();
            r.Show();
        }

        private void txtcustomername_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            //{                
            //    txtdiscount.Focus();
            //    txtdiscount.Text = "0";
            //}
        }

        private void strigloggoff_Click(object sender, EventArgs e)
        {
            FormCollection formsList = Application.OpenForms;

            foreach (Form o in formsList)
                o.Hide();

            frmLogincs l = new frmLogincs();
            l.Show();
        }

        private void stripexit_Click(object sender, EventArgs e)
        {
            try
            {
                //FormCollection formsList = Application.OpenForms;

                //foreach (Form o in formsList)
                //    o.Close();

                Application.Exit();
            }
            catch (Exception)
            {
            }
        }

        private void profitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmreportProfit r = new frmreportProfit();
            r.Show();
        }


        private void txtoldorderNo_KeyDown(object sender, KeyEventArgs e)
        {
            txtoldorderNo.Text = txtoldorderNo.Text.Replace(Environment.NewLine, "");
            txtoldorderNo.Text = txtoldorderNo.Text.Replace("\r", "");
            txtoldorderNo.SelectionStart = txtoldorderNo.Text.Length;

            if (e.KeyCode == Keys.Enter)
            {
                if (txtoldorderNo.Text != "")
                {
                    DataTable dtsale = DALAccess.ExecuteDataTable(@"select *,s.total as totalsale,sd.total as saledetailtotal from 
                    (sale s inner join saledetail sd on s.id=sd.saleid)
                    inner join item i on i.id=sd.itemid
                    where
                    Format([s.CreationDate], 'MM/DD/YYYY') = '" + DateTime.Now.ToString("MM/dd/yyyy") + @"'
                    and s.orderno=" + txtoldorderNo.Text);

                    if (dtsale != null && dtsale.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = null;
                        Maindt.Rows.Clear();

                        foreach (DataRow dr in dtsale.Rows)
                        {
                            DataRow r = Maindt.NewRow();
                            r["ID"] = Convert.ToString(dr["ItemID"]);
                            r["Name"] = Convert.ToString(dr["Name"]);
                            r["Quantity"] = Convert.ToString(dr["Quantity"]);
                            r["Price"] = Convert.ToString(dr["Price"]);
                            r["Total"] = Convert.ToString(dr["saledetailtotal"]);

                            Maindt.Rows.Add(r);
                        }

                        glbSaleID = Convert.ToInt32(dtsale.Rows[0]["SaleID"]);

                        dataGridView1.DataSource = Maindt;

                        ddlcustomer.Text = Convert.ToString(dtsale.Rows[0]["CustomerName"]);
                        txttotal.Text = Convert.ToString(dtsale.Rows[0]["totalsale"]);
                        txtdiscount.Text = Convert.ToString(dtsale.Rows[0]["discountpercentage"]);
                        //txtnet.Text = (Convert.ToDouble(txttotal.Text) - Convert.ToDouble(dtsale.Rows[0]["discount"])).ToString();
                        txtnet.Text = Convert.ToString(dtsale.Rows[0]["totalsale"]);
                    }
                }
            }
        }

        private void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //webBrowser1.ShowPrintDialog();
            //webBrowser1.ShowPageSetupDialog();



            //PrintDocument pd = new PrintDocument();

            //PrintDialog p = new PrintDialog();
            //p.Document = pd;
            //DialogResult dr = p.ShowDialog();



        }

        private void addGameTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddgameType f = new frmAddgameType();
            f.Show();
        }

        private void stripAdditemcategory_Click(object sender, EventArgs e)
        {
            frmAddItemCategory f = new frmAddItemCategory();
            f.Show();
        }

        private void addVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddVendor v = new frmAddVendor();
            v.Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCustomer c = new frmAddCustomer();
            c.FormClosed += new FormClosedEventHandler(FrmAddCustomerClosed);
            c.Show();
        }
        private void FrmAddCustomerClosed(object sender, FormClosedEventArgs e)
        {
            LoadCustomerDropDown();
        }
        private void btnOpenCustomerDialog_Click(object sender, EventArgs e)
        {
            frmCustomerDialog frm = new frmCustomerDialog();
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                ddlcustomer.SelectedValue = frm.ItemID;
                txtdiscount.Focus();
                txtdiscount.Text = "";
            }
        }

        private void ddlcustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtdiscount.Focus();
                txtdiscount.Text = "0";
                txtdiscount.SelectionStart = txtdiscount.Text.Length;
            }
        }

        private void vendorPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddVendorPayment f = new frmAddVendorPayment();
            f.Show();
        }

        private void txtnet_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtnet.Text == "")
            //return;

            //PrintDiscount(e.KeyCode);
            //btnViewBill.Visible = true;

            //LocalReport report = new LocalReport();
            //report.ReportEmbeddedResource = "Your.Reports.Path.rdlc";
            //report.DataSources.Add(new ReportDataSource("DataSet1", getYourDatasource()));
            //report.PrintToPrinter();

            //this.reportViewer2.LocalReport.Print();

            //txtnet.Text = txtdiscount.Text.Replace(Environment.NewLine, "");
            //txtnet.Text = txtdiscount.Text.Replace("\t", "");

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtamountpaid.Focus();
            }
            txtamountpaid.SelectionStart = txtamountpaid.Text.Length;


        }

        private void btnsaveandPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Maindt.Rows.Count > 0)
                {
                    Print();
                    btnViewBill.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //UpdateTotal(e.RowIndex);
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotal(e.RowIndex, e.ColumnIndex);
        }

        private void customerPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCustomerPayment f = new frmAddCustomerPayment();
            f.Show();
        }

        private void distributorProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCustomerPayment f = new frmAddCustomerPayment();
            f.Show();
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDefaultVendor f = new frmDefaultVendor();
            f.Show();
        }

        private void updatePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateSaleVendor f = new frmUpdateSaleVendor();
            f.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddItemStock s = new frmAddItemStock();
            s.Show();
        }

        private void addVendorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddVendor v = new frmAddVendor();
            v.Show();
        }

        private void vendorPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddVendorPayment f = new frmAddVendorPayment();
            f.Show();
        }

        private void updatePurchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUpdateSaleVendor f = new frmUpdateSaleVendor();
            f.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDefaultVendor f = new frmDefaultVendor();
            f.Show();
        }

        private void addDistributorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCustomer c = new frmAddCustomer();
            c.FormClosed += new FormClosedEventHandler(FrmAddCustomerClosed);
            c.Show();
        }

        private void updateSaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUpdateSale s = new frmUpdateSale();
            s.Show();
        }

        private void distributorPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCustomerPayment f = new frmAddCustomerPayment();
            f.Show();
        }

        private void distributorProfitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDistributorProfit f = new frmDistributorProfit();
            f.Show();
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            frmduplicateBill f = new frmduplicateBill();
            f.glbSaleID = glbSaleID;
            f.Show();
        }

        private void distributorBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDistributorBalance f = new frmDistributorBalance();
            f.Show();
        }

        private void stockReport2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockBalance f = new frmStockBalance();
            f.Show();
        }

        private void paymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddVendorInvoices f = new frmAddVendorInvoices();
            f.Show();
        }

        private void distributorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtamountpaid_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtnet.Text == "")
                    return;


                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    PrintDiscount(e.KeyCode);
                    //this.reportViewer2.LocalReport.Print();
                }


                //btnViewBill.Visible = true;

                //LocalReport report = new LocalReport();
                //report.ReportEmbeddedResource = "Your.Reports.Path.rdlc";
                //report.DataSources.Add(new ReportDataSource("DataSet1", getYourDatasource()));
                //report.PrintToPrinter();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public string GenerateFBRInvoice()
        {
            FBRResponse flight = new FBRResponse();

            try
            {
                var q = Maindt.AsEnumerable()
                    .Select(x => new
                    {
                        SN = Convert.ToString(x.Field<object>("SN")),
                        Name = Convert.ToString(x.Field<object>("Name")),
                        Price = Convert.ToDouble(x.Field<object>("Price")),
                        Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                        Total = Convert.ToInt32(x.Field<object>("Total")),
                        Discount = Convert.ToInt32(x.Field<object>("Discount")),
                        GST = Convert.ToInt32(x.Field<object>("GST")),
                        GSTPercentage = Convert.ToInt32(x.Field<object>("GST%")),
                        GrossTotal = Convert.ToInt32(x.Field<object>("GrossTotal"))
                    }).ToList();


                Invoice objInv = new Invoice();
                objInv.InvoiceNumber = string.Empty;
                objInv.POSID = XmlExtension.GetSetupValues().POSID;
                objInv.USIN = "BF9B3480";
                objInv.DateTime = DateTime.Now;
                objInv.BuyerNTN = "1234567-9";
                objInv.BuyerCNIC = "12345-1234567-8";
                objInv.BuyerName =ddlcustomer.Text ;
                objInv.BuyerPhoneNumber = "0345-1234567";
                objInv.PaymentMode = 1;
                objInv.TotalSaleValue = q.Sum(x=>x.Total);
                objInv.TotalQuantity = q.Sum(x => x.Quantity);
                objInv.TotalBillAmount = q.Sum(x => x.GrossTotal) ;
                objInv.TotalTaxCharged = q.Sum(x => x.GST);
                objInv.Discount = q.Sum(x => x.Discount);
                objInv.FurtherTax = 0;
                objInv.InvoiceType = 1;




                List<InvoiceItems> lst = new List<InvoiceItems>();

                foreach (var o in q)
                {
                    InvoiceItems objItem = new InvoiceItems();
                    objItem.ItemCode = "0000";
                    objItem.ItemName = o.Name;
                    objItem.Quantity = o.Quantity;
                    objItem.TotalAmount = Convert.ToDouble(o.GrossTotal);
                    objItem.SaleValue = Convert.ToDouble(o.Total);
                    objItem.TaxCharged = Convert.ToDouble(o.GST);
                    objItem.TaxRate = o.GSTPercentage;
                    objItem.PCTCode = "11001010";
                    objItem.FurtherTax = 0;
                    objItem.InvoiceType = 1;
                    objItem.Discount = o.Discount;

                    lst.Add(objItem);
                }

                objInv.Items = lst;






                HttpClient Client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(objInv), Encoding.UTF8, "application/json");
                HttpResponseMessage response = Client.PostAsync("http://localhost:8524/api/IMSFiscal/GetInvoiceNumberByModel", content).Result;
                //HttpResponseMessage response = Client.PostAsync("https://gw.fbr.gov.pk/imsp/v1/api/Live/PostData", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    //Console.WriteLine("Response from API");

                    flight = Newtonsoft.Json.JsonConvert.DeserializeObject<FBRResponse>(response.Content.ReadAsStringAsync().Result);
                    //Console.WriteLine("———————————————");
                    //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                }

            }
            catch (Exception ex)
            {
            }

            return flight.InvoiceNumber;
        }


        public string TestGenerateFBRInvoice()
        {
            FBRResponse flight=new FBRResponse();

            try
            {
                Invoice objInv = new Invoice();
                objInv.InvoiceNumber = string.Empty;
                objInv.POSID = "944172";
                objInv.USIN = "BF9B3480";
                objInv.DateTime = DateTime.Now;
                objInv.BuyerNTN = "1234567-9";
                objInv.BuyerCNIC = "12345-1234567-8";
                objInv.BuyerName = "Buyer Name";
                objInv.BuyerPhoneNumber = "0345-1234567";
                objInv.PaymentMode = 1;
                objInv.TotalSaleValue = 0;
                objInv.TotalQuantity = 0;
                objInv.TotalBillAmount = 0;
                objInv.TotalTaxCharged = 0;
                objInv.Discount = 1000;
                objInv.FurtherTax = 100;
                objInv.InvoiceType = 1;




                List<InvoiceItems> lst = new List<InvoiceItems>();
                InvoiceItems objItem = new InvoiceItems();
                objItem.ItemCode = "0000";
                objItem.ItemName = "Item Name";
                objItem.Quantity = 3;
                objItem.TotalAmount = Convert.ToDouble(3000.00);
                objItem.SaleValue = Convert.ToDouble(3180);
                objItem.TaxCharged = Convert.ToDouble(180);
                objItem.TaxRate = 6;
                objItem.PCTCode = "11001010";
                objItem.FurtherTax = 20;
                objItem.InvoiceType = 1;
                objItem.Discount = 500;

                lst.Add(objItem);

                objInv.Items = lst;





                HttpClient Client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(objInv), Encoding.UTF8, "application/json");
                HttpResponseMessage response = Client.PostAsync("http://localhost:8524/api/IMSFiscal/GetInvoiceNumberByModel", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Response from API");

                    flight = Newtonsoft.Json.JsonConvert.DeserializeObject<FBRResponse>(response.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("———————————————");
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                }

            }
            catch (Exception ex)
            {
            }

            return flight.InvoiceNumber;
        }

        private void txtQuantity_ImeModeChanged(object sender, EventArgs e)
        {

        }
    }


    public class ItemDetails
    {
        int ID { get; set; }
        string Name { get; set; }
        int Quantity { get; set; }
        double Price { get; set; }
        double Total { get; set; }
        int ItemCategoryID { get; set; }
        double DiscountPercentage { get; set; }
        string Code { get; set; }
        double Discount { get; set; }
        double GrossTotal { get; set; }
        double GST { get; set; }
        double GSTPercentage { get; set; }
    }



    public class Invoice
    {

        public string InvoiceNumber { get; set; }

        public string POSID { get; set; }

        public string USIN { get; set; }

        public DateTime DateTime { get; set; }

        public string BuyerNTN { get; set; }

        public string BuyerCNIC { get; set; }

        public string BuyerName { get; set; }

        public string BuyerPhoneNumber { get; set; }

        public int PaymentMode { get; set; }

        public int TotalSaleValue { get; set; }

        public int TotalQuantity { get; set; }

        public int TotalBillAmount { get; set; }

        public int TotalTaxCharged { get; set; }

        public int Discount { get; set; }

        public int FurtherTax { get; set; }

        public int InvoiceType { get; set; }

        public List<InvoiceItems> Items { get; set; }
    }

    public class InvoiceItems
    {
        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public double TotalAmount { get; set; }

        public double SaleValue { get; set; }

        public double TaxCharged { get; set; }

        public int TaxRate { get; set; }

        public string PCTCode { get; set; }

        public int FurtherTax { get; set; }

        public int InvoiceType { get; set; }

        public int Discount { get; set; }
    }


    public class FBRResponse
    { 
    public string InvoiceNumber { get; set; }
        public string Code { get; set; }
        public string Response { get; set; }
        public string Errors { get; set; }
    }

}
