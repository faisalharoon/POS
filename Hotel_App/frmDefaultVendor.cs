using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace General_App
{
    public partial class frmDefaultVendor : Form
    {

        public int glbSaleID = -1;
        public frmDefaultVendor()
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
            this.dataGridView1.Columns["Quantity"].ReadOnly = false;
            this.dataGridView1.Columns["Total"].ReadOnly = true;
            this.dataGridView1.Columns["GrossTotal"].ReadOnly = true;

            lblselecteditem.Text = "";

            booljustloaded = false;

           



            LoadCustomerDropDown();

            try
            {
                txtItemName.Focus();

                Maindt = new DataTable();
                Maindt.Columns.Add("ID");
                Maindt.Columns.Add("Name");
                Maindt.Columns.Add("Quantity");
                Maindt.Columns.Add("Price");
                Maindt.Columns.Add("Total");

                Maindt.Columns.Add("Discount");
                Maindt.Columns.Add("GrossTotal");

                if (!string.IsNullOrEmpty(General_App.Properties.Settings.Default.gst))
                    txtgst.Text = General_App.Properties.Settings.Default.gst;
                else
                    txtgst.Text = "0";

                //DataTable dt = access2dt();
                // this.reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.reportViewer2.RefreshReport();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void LoadCustomerDropDown()
        {
            try
            {
                DataTable dtCust = DALAccess.ExecuteDataTable("select * from vendor order by id asc");
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
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtItemName.Text = frm.ItemID;
                lblselecteditem.Text = frm.ItemName;
                txtItemName.Focus();
                txtItemName.SelectionStart = txtItemName.Text.Length;
            }
            txtQuantity.Text = "";
        }

        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtItemName.Text == "")
                return;


            txtItemName.Text = txtItemName.Text.Replace(Environment.NewLine, "");
            txtItemName.Text = txtItemName.Text.Replace("\t", "");

            try
            {
                DataTable dt = new DataTable();
                if (txtItemName.Text.Contains("%"))
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        string itemName = txtItemName.Text.Trim().Replace("%", "");
                        DataTable dtitem = DALAccess.ExecuteDataTable("select * from item where name like '%" + itemName + "%'");
                        if (dtitem != null && dtitem.Rows.Count > 0)
                        {
                            lblselecteditem.Text = dtitem.Rows[0]["Name"].ToString();
                            txtItemName.Text = dtitem.Rows[0]["ID"].ToString();
                            txtItemName.SelectionStart = txtItemName.Text.Length;
                        }
                    }
                }
                else
                {

                    if (txtItemName.Text != "")
                    {
                        bool isitemid = true;
                        try
                        {
                            int ItemID = Convert.ToInt32(txtItemName.Text);
                            if (txtItemName.Text.Length < 7)
                                dt = DALAccess.ExecuteDataTable("select * from Item where id=" + txtItemName.Text);
                            else
                                isitemid = false;

                        }
                        catch (Exception exInt)
                        {
                            isitemid = false;
                        }

                        if (!isitemid)
                        {
                            dt = DALAccess.ExecuteDataTable("select * from Item where [barcode]='" + txtItemName.Text + "'");
                        }

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            lblselecteditem.Text = dt.Rows[0]["Name"].ToString();
                        }
                        else
                            lblselecteditem.Text = "";
                    }
                    else
                        lblselecteditem.Text = "";
                }

                if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) && !booljustloaded)
                {
                    txtQuantity.Focus();
                }

                booljustloaded = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtQuantity.SelectionStart = txtQuantity.Text.Length;
        }







        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            
            txtQuantity.Text = txtQuantity.Text.Replace(Environment.NewLine, "");
            txtQuantity.Text = txtQuantity.Text.Replace("\t", "");


            if (txtQuantity.Text == "")
                return;

            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (lblselecteditem.Text != "")
                    {
                        txtItemName.Focus();
                        string itemid = Convert.ToString(txtItemName.Text);
                        int quantity = Convert.ToInt32(txtQuantity.Text);

                       
                    

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

                                    //double discountPercent = Convert.ToDouble(Maindt.Rows[innerIndex]["Discount%"]);
                                    double discountPercent = 0;
                                    double total = (Convert.ToDouble(alreadyCount) * Convert.ToDouble(Maindt.Rows[innerIndex]["Price"]));
                                    //double discountAmount = Math.Round((total * discountPercent) / 100, 0);
                                    double discountAmount = Convert.ToDouble(Maindt.Rows[innerIndex]["Discount"]);
                                    double gross = total - discountAmount;

                                    Maindt.Rows[innerIndex]["Quantity"] = alreadyCount;
                                    Maindt.Rows[innerIndex]["Discount"] = discountAmount.ToString();
                                    Maindt.Rows[innerIndex]["Total"] = total.ToString();
                                    Maindt.Rows[innerIndex]["GrossTotal"] = gross.ToString();
                                    dataGridView1.DataSource = Maindt;
                                    UpdateTotal(innerIndex, 0);

                                    //Maindt.Rows[innerIndex]["Quantity"] = alreadyCount;
                                    //Maindt.Rows[innerIndex]["Total"] = (Convert.ToDouble(alreadyCount) * Convert.ToDouble(Maindt.Rows[innerIndex]["Price"])).ToString();
                                    //dataGridView1.DataSource = Maindt;

                                }
                                else
                                {
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        DataRow dr = Maindt.NewRow();
                                        dr["ID"] = txtItemName.Text;
                                        dr["Name"] = lblselecteditem.Text;
                                        dr["Quantity"] = txtQuantity.Text;



                                        double SalePrice = Convert.ToDouble(dt.Rows[0]["PurchasePrice"]);
                                        double Quantity = Convert.ToDouble(txtQuantity.Text);
                                        double total = SalePrice * Quantity;

                                        //double discountAmount = Math.Round((total * discountPercent) / 100, 0);
                                        double discountAmount = Convert.ToDouble(0) ;
                                        double gross = total - discountAmount;

                                        //dr["Price"] = dt.Rows[0]["PurchasePrice"].ToString();
                                        //dr["Total"] = (Convert.ToDouble(txtQuantity.Text) * Convert.ToDouble(dt.Rows[0]["PurchasePrice"])).ToString();

                                        //.Rows.Add(dr);
                                        //dataGridView1.DataSource = Maindt;


                                        dr["Price"] = SalePrice.ToString();
                                        dr["Total"] = total.ToString();                                      
                                        dr["Discount"] = discountAmount;
                                        dr["GrossTotal"] = gross;

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
                        lblselecteditem.Text = "";

                        //var total = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<string>("Total")));
                        //txttotal.Text = total.ToString();
                        //txtnet.Text = total.ToString();

                        //var dis = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                        //var total2 = Math.Round((total * dis) / 100, 0);
                        //UpdateTotal(0,-1);
                    }
                    else
                    {

                        txtQuantity.Text = "1";
                        txtItemName.Text = "";
                        lblselecteditem.Text = "";

                        txtItemName.Focus();
                    }
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

        private void Print()
        {
            try
            {
                string customername = ddlcustomer.Text;
                double discount = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                double totalamount = Convert.ToDouble(txttotal.Text);

                //double discountAmount = Math.Round((totalamount * discount) / 100, 0);
                double discountAmount = Convert.ToDouble(txttotal.Text) - Convert.ToDouble(txtnet.Text);

                double NetAmount = Convert.ToDouble(txtnet.Text);
                double TaxPercentage = 0;
                double TaxAmount = 0;

                string custST = Convert.ToString(XmlExtension.DeSerialize().CustomerSalesTax);
                if (custST != "")
                    TaxPercentage = Convert.ToDouble(custST);


                TaxAmount = Math.Round(((NetAmount * TaxPercentage) / 100), 0);

                int orderno = 1;


                if (glbSaleID == -1)
                {
                    if (Maindt != null && Maindt.Rows.Count > 0)
                    {
                        //DataTable dtMaxOrder = DALAccess.ExecuteDataTable("select max(orderno) from itemstockmaster where Format([CreationDate],'MM/DD/YYYY')='" + Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy") + "'");
                        DataTable dtMaxOrder = DALAccess.ExecuteDataTable("select max(orderno) from itemstockmaster");


                        if (dtMaxOrder != null && dtMaxOrder.Rows.Count > 0)
                            if (!string.IsNullOrEmpty(Convert.ToString(dtMaxOrder.Rows[0][0])))
                                orderno = Convert.ToInt32(dtMaxOrder.Rows[0][0]) + 1;



                        string str = "insert into itemstockmaster (vendorName,CreationDate,OrderNo,Discount,DiscountPercentage,Total,UserID,VendorID,SalesTax) values ('" + customername + "','" + DateTime.Now + "'," + orderno + "," + discountAmount + "," + discount + "," + totalamount + "," + LoggedInUser.UserID + "," + ddlcustomer.SelectedValue + ","+ TaxAmount + ")";
                        int saleid = DALAccess.ExecuteNonQuery(str);

                        for (int i = 0; i < Maindt.Rows.Count; i++)
                        {
                            int itemid = Convert.ToInt32(Maindt.Rows[i]["ID"]);
                            double price = Convert.ToDouble(Maindt.Rows[i]["Price"]);
                            int Quantity = Convert.ToInt32(Maindt.Rows[i]["Quantity"]);
                            double total = price * Quantity;

                            DataTable dtpurchase = DALAccess.ExecuteDataTable("select purchaseprice from item where id=" + itemid);
                            var purchaseprice = Convert.ToInt32(dtpurchase.Rows[0][0]);

                            str = "insert into itemstock (itemstockmasterid,itemid,CreationDate,stock,total,purchaseprice) values (" + saleid + "," + itemid + ",'" + DateTime.Now + "'," + Quantity + "," + total + "," + price + ")";

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
                        DataTable dtoldSale = DALAccess.ExecuteDataTable("select orderno from itemstockmaster where id=" + glbSaleID);


                        if (dtoldSale != null && dtoldSale.Rows.Count > 0)
                            if (!string.IsNullOrEmpty(Convert.ToString(dtoldSale.Rows[0][0])))
                                orderno = Convert.ToInt32(dtoldSale.Rows[0]["orderno"]);



                        string str = @"update itemstockmaster set VendorName='" + ddlcustomer.Text + @"',
                            Discount=" + discountAmount + @",DiscountPercentage=" + discount + @",Total=" + totalamount + @",modifiedDate='" + DateTime.Now + @"',ModifiedBy=" + LoggedInUser.UserID + @"
                            where id=" + glbSaleID;
                        DALAccess.ExecuteNonQuery(str);

                        DataTable dtoldSaledetail = DALAccess.ExecuteDataTable("select * from itemstock where ItemStockMasterID=" + glbSaleID);

                        foreach (DataRow dr in dtoldSaledetail.Rows)
                        {
                            int ItemID = Convert.ToInt32(dr["itemid"]);
                            int SaleDetailID = Convert.ToInt32(dr["ID"]);
                            int quantity = Convert.ToInt32(dr["stock"]);

                            //DALAccess.ExecuteNonQuery("update itemstock set stock=stock+" + quantity + " where itemid=" + ItemID);
                            DALAccess.ExecuteNonQuery("delete from itemstock where id=" + SaleDetailID);
                        }


                        for (int i = 0; i < Maindt.Rows.Count; i++)
                        {
                            int itemid = Convert.ToInt32(Maindt.Rows[i]["ID"]);
                            double price = Convert.ToDouble(Maindt.Rows[i]["Price"]);
                            int Quantity = Convert.ToInt32(Maindt.Rows[i]["Quantity"]);
                            double total = price * Quantity;

                            DataTable dtpurchase = DALAccess.ExecuteDataTable("select purchaseprice from item where id=" + itemid);
                            var purchaseprice = Convert.ToInt32(dtpurchase.Rows[0][0]);

                            str = "insert into itemstock (ItemStockMasterID,itemid,Price,CreationDate,stock,total,purchasrprice) values (" + glbSaleID + "," + itemid + "," + price + ",'" + DateTime.Now + "'," + Quantity + "," + total + "," + purchaseprice + ")";

                            //DALAccess.ExecuteNonQuery("update itemstock set stock=stock-" + Quantity + " where itemid=" + itemid);
                            DALAccess.ExecuteNonQuery(str);
                        }

                        glbSaleID = -1;
                    }
                }
                PrintReport(orderno);
                ClearAllControls();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void ClearAllControls()
        {
            dataGridView1.DataSource = null;
            txtamountpaid.Text = "0";
            txtdiscount.Text = "0";
            txttotal.Text = "0";
        }

        private void InsertIntoVendorPayment(double totalAmountToPay)
        {
            try
            {
                double amountpaid = Convert.ToDouble(txtamountpaid.Text == "" ? "0" : txtamountpaid.Text);
                double balance = totalAmountToPay-amountpaid;
               

                string query = "insert into vendorpayment(vendorid,amounttopay,amount,balance,createdat,createdby,paiddate) values (" + ddlcustomer.SelectedValue + "," + totalAmountToPay + "," + amountpaid + "," + balance + ",'" + DateTime.Now + "'," + LoggedInUser.UserID + ",'" + DateTime.Now + "')";
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
                double grosstotal = (total - totaldisoucnt);
                double gst = Math.Round((grosstotal * gstpercentage) / 100, 0);



                try
                {
                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", Maindt);
                    //ReportDataSource reportDSDetail2 = new ReportDataSource("DataSet2", dv2.ToTable());
                    //if(lstfirst2!=null && lstfirst2.Count()>0 && lstfirst!=null && lstfirst.Count()>0)
                    //    reportViewer2.LocalReport.ReportPath = "../../ReportBill.rdlc";
                    //else
                    //reportViewer2.LocalReport.ReportPath = "../../Report1.rdlc";
                    reportViewer2.LocalReport.ReportPath = "../../Report1-FullpageVendor.rdlc";
                    reportViewer2.LocalReport.DataSources.Add(reportDSDetail);
                    //reportViewer2.LocalReport.DataSources.Add(reportDSDetail2);
                    reportViewer2.LocalReport.EnableExternalImages = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("dataset2: " + ex.Message);
                }





                ReportParameter[] p = new ReportParameter[10];
                p[0] = new ReportParameter("Date", DateTime.Now.ToString());


                p[1] = new ReportParameter("Total", total.ToString());
                p[2] = new ReportParameter("Discount", totaldisoucnt.ToString());
                p[3] = new ReportParameter("GTotal", (grosstotal + gst).ToString());
                p[4] = new ReportParameter("OrderNo", orderno.ToString());
                p[5] = new ReportParameter("Name", ddlcustomer.Text);
                p[6] = new ReportParameter("gst", gst.ToString());
                p[7] = new ReportParameter("ShopName", XmlExtension.GetSetupValues().CompanyName);
                p[8] = new ReportParameter("username", LoggedInUser.DisplayName);
                p[9] = new ReportParameter("ShopAddress", XmlExtension.GetSetupValues().CompanyAddress);


                //System.Threading.Thread.Sleep(1000);

                try
                {
                    reportViewer2.LocalReport.SetParameters(p);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("set: " + ex.Message);
                }

                InsertIntoVendorPayment(grosstotal);


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

        //private void InsertIntoVendorPayment(double totalAmountToPay)
        //{
        //    try
        //    {
        //        string query = "insert into Vendorpayment(vendorid,amounttopay,amount,balance,createdat,createdby,paiddate) values (" + ddlcustomer.SelectedValue + "," + totalAmountToPay + ",0," + totalAmountToPay + ",'" + DateTime.Now + "'," + LoggedInUser.UserID + ",'" + DateTime.Now + "')";
        //        DALAccess.ExecuteNonQuery(query);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

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
                        lblselecteditem.Text = frm.ItemName;
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

                    //webBrowser1.DocumentText = "";
                    reportViewer2.Clear();

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
                    frmAddEntry f = new frmAddEntry();
                    f.Show();
                }
                if (e.Control && e.KeyCode == Keys.G)
                {
                    frmTicket f = new frmTicket();
                    f.Show();
                }
                if (e.Control && e.KeyCode == Keys.P)
                {
                    //frmAddgameType f = new frmAddgameType();
                    //f.Show();

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

                    //var total = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<string>("Total")));
                    //txttotal.Text = total.ToString();
                    //txtnet.Text = total.ToString();

                    //var dis = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                    //var total2 = Math.Round((total * dis) / 100, 0);

                    //UpdateTotal(0);
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

        private void UpdateTotal(int rowinde, int colIndex)
        {
            try
            {
                if (rowinde >= 0)
                {

                    string PriceInGrid = Convert.ToString(dataGridView1.Rows[rowinde].Cells["Price"].Value);
                    string QuantityInGrid = Convert.ToString(dataGridView1.Rows[rowinde].Cells["Quantity"].Value);
                    string DiscountInGrid = Convert.ToString(dataGridView1.Rows[rowinde].Cells["Discount"].Value);


                    var singleprice = Convert.ToDouble(Maindt.Rows[rowinde]["Quantity"]);
                    var singleQuantity = Convert.ToDouble(Maindt.Rows[rowinde]["Price"]);
                    //var singleDiscountPercentage = Convert.ToDouble(Maindt.Rows[rowinde]["Discount%"]);
                    var singleDiscountPercentage = 0;
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
                    Maindt.Rows[rowinde]["GrossTotal"] = (singleTotal - singleDiscount).ToString();
                    dataGridView1.DataSource = Maindt;
                }




                try
                {
                    var price = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Price")) * Convert.ToDouble(x.Field<object>("Quantity")));
                    var discountGridAmount = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Discount")));

                    var discountPercentage = Convert.ToDouble(txtdiscount.Text);
                    var discountAmount = 0.0;

                    if (discountPercentage > 0)
                        discountAmount = Math.Round((price * discountPercentage) / 100, 0);
                    else
                        discountAmount = discountGridAmount;

                    var NetAmount = price - discountAmount;

                    txttotal.Text = price.ToString();
                    txtnet.Text = NetAmount.ToString();
                }
                catch (Exception)
                {
                }




            }
            catch (Exception)
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
            frmVendorDialog frm = new frmVendorDialog();
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
            if (txtnet.Text == "")
                return;


            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtamountpaid.Focus();
            }
            txtamountpaid.SelectionStart = txtamountpaid.Text.Length;

           

            //PrintDiscount(e.KeyCode);
        }

        private void btnsaveandPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Maindt.Rows.Count > 0)
                    Print();
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
            UpdateTotal(e.RowIndex,-1);
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

        private void txtamountpaid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                PrintDiscount(e.KeyCode);
                //this.reportViewer2.LocalReport.Print();
            }
        }
    }
}
