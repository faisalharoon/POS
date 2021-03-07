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
    public partial class frmTicket : Form
    {
        public int glbSaleID = -1;
        public frmTicket()
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
            booljustloaded = true;

            if (LoggedInUser.UserRoleID == 2)// normal user
            {
            }



            try
            {
                txtItemName.Focus();

                Maindt = new DataTable();
                Maindt.Columns.Add("ID");
                Maindt.Columns.Add("Name");
                Maindt.Columns.Add("Quantity");
                Maindt.Columns.Add("Price");
                Maindt.Columns.Add("Total");

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
        }







        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSelectGameType frm = new frmSelectGameType();
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtItemName.Text = frm.GameTypeID;
                lblName.Text = frm.GameName;
                txtItemName.Focus();
                txtItemName.SelectionStart = txtItemName.Text.Length;
            }
            txtQuantity.Text = "";
        }

        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            txtItemName.Text = txtItemName.Text.Replace(Environment.NewLine, "");
            txtItemName.Text = txtItemName.Text.Replace("\t", "");

            try
            {
                DataTable dt = new DataTable();

                if (txtItemName.Text != "")
                {

                    try
                    {
                        int ItemID = Convert.ToInt32(txtItemName.Text);
                        dt = DALAccess.ExecuteDataTable("select * from gametype where id=" + txtItemName.Text);
                    }
                    catch (Exception exInt)
                    {

                    }



                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lblName.Text = dt.Rows[0]["GameName"].ToString();
                    }
                    else
                        lblName.Text = "";
                }
                else
                    lblName.Text = "";

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
        }





    

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            txtQuantity.Text = txtQuantity.Text.Replace(Environment.NewLine, "");
            txtQuantity.Text = txtQuantity.Text.Replace("\t", "");


            if (txtQuantity.Text == "")
                txtQuantity.Text = "0";

            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (lblName.Text != "")
                    {
                        txtItemName.Focus();
                        int itemid = Convert.ToInt32(txtItemName.Text);
                        int quantity = Convert.ToInt32(txtQuantity.Text);

                        DataTable dtstock = DALAccess.ExecuteDataTable("select * from gametype where id=" + itemid);


                        DataRow dr = Maindt.NewRow();
                        dr["ID"] = txtItemName.Text;
                        dr["Name"] = lblName.Text;
                        dr["Quantity"] = txtQuantity.Text;


                        if (dtstock != null && dtstock.Rows.Count > 0)
                        {
                            int price = 0;
                            if (chkisStudent.Checked)
                                price = Convert.ToInt32(Convert.ToString(dtstock.Rows[0]["AmountStudent"]));
                            else
                                price = Convert.ToInt32(Convert.ToString(dtstock.Rows[0]["Amount"]));

                            dr["Price"] = price;
                            dr["Total"] = (Convert.ToDouble(txtQuantity.Text) * Convert.ToDouble(price)).ToString();
                        }

                        Maindt.Rows.Add(dr);

                        dataGridView1.DataSource = Maindt;

                        txtQuantity.Text = "";
                        txtItemName.Text = "";
                        lblName.Text = "";

                        var total = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<string>("Total")));
                        txttotal.Text = total.ToString();

                        var dis = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                        var total2 = Math.Round((total * dis) / 100, 0);
                        txtnet.Text = (total - total2).ToString();
                    }
                    else
                    {

                        txtQuantity.Text = "";
                        txtItemName.Text = "";
                        lblName.Text = "";

                        txtItemName.Focus();
                    }
                }

                txtItemName.SelectionStart = txtItemName.Text.Length;
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
                string customername = txtcustomername.Text;
                double discount = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                double totalamount = Convert.ToDouble(txttotal.Text);

                double discountAmount = Math.Round((totalamount * discount) / 100, 0);

                int orderno = 1;


                if (glbSaleID == -1)
                {
                    if (Maindt != null && Maindt.Rows.Count > 0)
                    {
                        DataTable dtMaxOrder = DALAccess.ExecuteDataTable("select max(orderno) from Salegame where Format([CreationDate],'MM/DD/YYYY')='" + Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy") + "'");


                        if (dtMaxOrder != null && dtMaxOrder.Rows.Count > 0)
                            if (!string.IsNullOrEmpty(Convert.ToString(dtMaxOrder.Rows[0][0])))
                                orderno = Convert.ToInt32(dtMaxOrder.Rows[0][0]) + 1;



                        string str = "insert into Salegame (CustomerName,CreationDate,OrderNo,Discount,DiscountPercentage,Total,UserID,isstudent) values ('" + customername + "','" + DateTime.Now + "'," + orderno + "," + discountAmount + "," + discount + "," + totalamount + "," + LoggedInUser.UserID + "," + (chkisStudent.Checked ? "1" : "0") + ")";
                        int saleid = DALAccess.ExecuteNonQuery(str);

                        for (int i = 0; i < Maindt.Rows.Count; i++)
                        {
                            int itemid = Convert.ToInt32(Maindt.Rows[i]["ID"]);
                            double price = Convert.ToDouble(Maindt.Rows[i]["Price"]);
                            int Quantity = Convert.ToInt32(Maindt.Rows[i]["Quantity"]);
                            double total = price * Quantity;

                            str = "insert into salegamedetail (salegameid,gametypeid,Price,CreationDate,Quantity,total) values (" + saleid + "," + itemid + "," + price + ",'" + DateTime.Now + "'," + Quantity + "," + total + ")";
                            DALAccess.ExecuteNonQuery(str);
                        }
                        glbSaleID = saleid;
                    }
                }
                else // update sale
                {
                    if (Maindt != null && Maindt.Rows.Count > 0)
                    {
                        DataTable dtoldSale = DALAccess.ExecuteDataTable("select orderno from Salegame where id=" + glbSaleID);


                        if (dtoldSale != null && dtoldSale.Rows.Count > 0)
                            if (!string.IsNullOrEmpty(Convert.ToString(dtoldSale.Rows[0][0])))
                                orderno = Convert.ToInt32(dtoldSale.Rows[0]["orderno"]);



                        string str = @"update Salegame set CustomerName='" + txtcustomername.Text + @"',
                            Discount=" + discountAmount + @",DiscountPercentage=" + discount + @",Total=" + totalamount + @",modifiedDate='" + DateTime.Now + @"',ModifiedBy=" + LoggedInUser.UserID + @"
                            where id=" + glbSaleID;
                        DALAccess.ExecuteNonQuery(str);

                        DataTable dtoldSaledetail = DALAccess.ExecuteDataTable("select * from salegamedetail where saleid=" + glbSaleID);

                        foreach (DataRow dr in dtoldSaledetail.Rows)
                        {
                            int ItemID = Convert.ToInt32(dr["gametypeid"]);
                            int SaleDetailID = Convert.ToInt32(dr["ID"]);
                            int quantity = Convert.ToInt32(dr["quantity"]);

                            DALAccess.ExecuteNonQuery("delete from salegamedetail where id=" + SaleDetailID);
                        }


                        for (int i = 0; i < Maindt.Rows.Count; i++)
                        {
                            int itemid = Convert.ToInt32(Maindt.Rows[i]["ID"]);
                            double price = Convert.ToDouble(Maindt.Rows[i]["Price"]);
                            int Quantity = Convert.ToInt32(Maindt.Rows[i]["Quantity"]);
                            double total = price * Quantity;

                            str = "insert into salegamedetail (saleid,gametypeid,Price,CreationDate,Quantity,total) values (" + glbSaleID + "," + itemid + "," + price + ",'" + DateTime.Now + "'," + Quantity + "," + total + ")";
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

        private void PrintReport(int orderno)
        {
            try
            {
                reportViewer2.Clear();
                reportViewer2.LocalReport.DataSources.Clear();


                DataTable tmpdt = Maindt.Copy();

                try
                {
                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", tmpdt);
                    reportViewer2.LocalReport.ReportPath = "../../rptgaming.rdlc";
                    reportViewer2.LocalReport.DataSources.Add(reportDSDetail);
                    reportViewer2.LocalReport.EnableExternalImages = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("dataset2: " + ex.Message);
                }



                double total = tmpdt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<string>("Total")));
                int discount = Convert.ToInt32(txtdiscount.Text == "" ? "0" : txtdiscount.Text);


                ReportParameter[] p = new ReportParameter[9];
                p[0] = new ReportParameter("Date", DateTime.Now.ToString());

                double totaldisoucnt = Convert.ToDouble(Math.Round(Convert.ToDecimal((total * discount) / 100), 0));
                double gstpercentage = Convert.ToDouble(txtgst.Text);
                double grosstotal = (total - totaldisoucnt);
                double gst = Math.Round((grosstotal * gstpercentage) / 100, 0);
                p[1] = new ReportParameter("Total", total.ToString());
                p[2] = new ReportParameter("Discount", totaldisoucnt.ToString());
                p[3] = new ReportParameter("GTotal", (grosstotal + gst).ToString());
                p[4] = new ReportParameter("OrderNo", orderno.ToString());
                p[5] = new ReportParameter("Name", txtcustomername.Text);
                p[6] = new ReportParameter("gst", gst.ToString());
                p[7] = new ReportParameter("ShopName", Properties.Settings.Default.Name);
                p[8] = new ReportParameter("username", LoggedInUser.DisplayName);


                System.Threading.Thread.Sleep(1000);

                try
                {
                    reportViewer2.LocalReport.SetParameters(p);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("set: " + ex.Message);
                }

                reportViewer2.LocalReport.Refresh();

                reportViewer2.RefreshReport();
                reportViewer2.Visible = true;

                reportViewer2.LocalReport.Refresh();
                this.reportViewer2.RefreshReport();

                System.Threading.Thread.Sleep(1000);
                printcount = 0;

                try
                {
                    reportViewer2.RenderingComplete += new RenderingCompleteEventHandler(PrintSales);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("render: " + ex.Message);
                }
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
                if (e.Control && e.KeyCode == Keys.Q) // for combination of Ctrl + Q
                {
                    MessageBox.Show("Ctrl + Q");
                }
                if (e.Control && e.KeyCode == Keys.C) // for combination of Ctrl + Q
                {
                    txtcustomername.Focus();
                    txtcustomername.SelectionStart = txtcustomername.Text.Length;
                }
                if (e.Control && e.KeyCode == Keys.N) // for combination of Ctrl + Q
                {
                    Maindt.Rows.Clear();
                    txtItemName.Focus();
                    txtcustomername.Text = "";
                    txtdiscount.Text = "0";
                    txttotal.Text = "0";
                    txtnet.Text = "0";

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
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WindowLicenseTrialEntry");
                    string val = Convert.ToString(key.GetValue("count"));
                    key.SetValue("count", "0");

                    key.Close();

                    MessageBox.Show("OK. Registration Renewed.");
                }
                if (e.Control && e.KeyCode == Keys.O)
                {
                    frmAddEntry f = new frmAddEntry();
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtcustomername_KeyUp(object sender, KeyEventArgs e)
        {
            txtcustomername.Text = txtcustomername.Text.Replace(Environment.NewLine, "");
            txtcustomername.Text = txtcustomername.Text.Replace("\t", "");


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


            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (Maindt.Rows.Count > 0)
                    Print();
            }

            //if (txtdiscount.Text != "")
            {
                double totalall = Convert.ToDouble(txttotal.Text);
                double discount = Convert.ToDouble(txtdiscount.Text==""?"0":txtdiscount.Text);
                double total = Convert.ToDouble(Math.Round(Convert.ToDecimal((totalall * discount) / 100), 0));
                txtnet.Text = (totalall - total).ToString();
            }

            txtdiscount.SelectionStart = txtdiscount.Text.Length;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col == 0)
            {
                Maindt.Rows.RemoveAt(e.RowIndex);
                dataGridView1.DataSource = Maindt;

                var total = Maindt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<string>("Total")));
                txttotal.Text = total.ToString();

                var dis = Convert.ToDouble(txtdiscount.Text == "" ? "0" : txtdiscount.Text);
                var total2 = Math.Round((total * dis) / 100, 0);

                txtnet.Text = (total - total2).ToString();
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
            Application.Exit();
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
                    DataTable dtsale = DALAccess.ExecuteDataTable(@"select *,s.total as totalsale,sd.total as saledetailtotal,i.GameName as Name from 
                    (salegame s inner join salegamedetail sd on s.id=sd.salegameid)
                    inner join gametype i on i.id=sd.gametypeid
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
                            r["ID"] = Convert.ToString(dr["GametypeID"]);
                            r["Name"] = Convert.ToString(dr["Name"]);
                            r["Quantity"] = Convert.ToString(dr["Quantity"]);
                            r["Price"] = Convert.ToString(dr["Price"]);
                            r["Total"] = Convert.ToString(dr["saledetailtotal"]);

                            Maindt.Rows.Add(r);
                        }

                        glbSaleID = Convert.ToInt32(dtsale.Rows[0]["SalegameID"]);

                        dataGridView1.DataSource = Maindt;

                        txtcustomername.Text = Convert.ToString(dtsale.Rows[0]["CustomerName"]);
                        txttotal.Text = Convert.ToString(dtsale.Rows[0]["totalsale"]);
                        txtdiscount.Text = Convert.ToString(dtsale.Rows[0]["discountpercentage"]);


                        txtnet.Text = (Convert.ToDouble(txttotal.Text) - Convert.ToDouble(dtsale.Rows[0]["discount"])).ToString();
                    }
                }
            }
        }










    }
}
