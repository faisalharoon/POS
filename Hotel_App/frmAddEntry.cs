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
    public partial class frmAddEntry : Form
    {

        public int glbSaleID = -1;
        public frmAddEntry()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                txtPrice.Focus();
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



        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            txtPrice.Text = txtPrice.Text.Replace(Environment.NewLine, "");
            txtPrice.Text = txtPrice.Text.Replace("\t", "");

            try
            {
                loadNetAmount();


                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadNetAmount()
        {
            try
            {
                int quantity = Convert.ToInt32(txtQuantity.Text == "" ? "0" : txtQuantity.Text);
                int unitprice = Convert.ToInt32(txtPrice.Text == "" ? "0" : txtPrice.Text);
                double discountPercentage= Convert.ToInt32(txtdiscountpercentage.Text == "" ? "0" : txtdiscountpercentage.Text);
                double discount=Math.Round( ((quantity*unitprice)*discountPercentage)/100,0);

                txtnet.Text = Convert.ToString((quantity * unitprice)-discount);
            }
            catch (Exception)
            {

            }
        }

       

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            txtQuantity.Text = txtQuantity.Text.Replace(Environment.NewLine, "");
            txtQuantity.Text = txtQuantity.Text.Replace("\t", "");
            try
            {
                txtPrice.SelectionStart = txtPrice.Text.Length;
                loadNetAmount();

                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtdiscountpercentage.Focus();
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
                int orderno = 1;

                DataTable dtMaxOrder = DALAccess.ExecuteDataTable("select max(orderno) from Entrance where Format([createdat],'MM/DD/YYYY')='" + Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy") + "'");

                if (dtMaxOrder != null && Convert.ToString(dtMaxOrder.Rows[0][0])!="")
                {
                    orderno = Convert.ToInt32(dtMaxOrder.Rows[0][0])+1;
                }


                int quantity = Convert.ToInt32(txtQuantity.Text == "" ? "0" : txtQuantity.Text);
                int unitprice = Convert.ToInt32(txtPrice.Text == "" ? "0" : txtPrice.Text);
                double discountPercentage = Convert.ToInt32(txtdiscountpercentage.Text == "" ? "0" : txtdiscountpercentage.Text);
                double discount = Math.Round(((quantity * unitprice) * discountPercentage) / 100, 0);


                DALAccess.ExecuteNonQuery(@"insert into entrance (OrderNo,UnitPrice,Quantity,Discount,DiscountPercentage,createdat,createdby,total,islumpsum) values
                ("+orderno+","+txtPrice.Text+","+txtQuantity.Text+","+discount+","+discountPercentage+",'"+DateTime.Now+"',"+LoggedInUser.UserID+","+txtnet.Text+",0)");



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
                

                try
                {
                    //ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dtRefined);
                    reportViewer2.LocalReport.ReportPath = "../../rptEntry.rdlc";
                    //reportViewer2.LocalReport.DataSources.Add(reportDSDetail);
                    reportViewer2.LocalReport.EnableExternalImages = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("dataset2: " + ex.Message);
                }


                int quantity = Convert.ToInt32(txtQuantity.Text == "" ? "0" : txtQuantity.Text);
                int unitprice = Convert.ToInt32(txtPrice.Text == "" ? "0" : txtPrice.Text);
                double discountPercentage = Convert.ToInt32(txtdiscountpercentage.Text == "" ? "0" : txtdiscountpercentage.Text);
                double discount = Math.Round(((quantity * unitprice) * discountPercentage) / 100, 0);


                ReportParameter[] p = new ReportParameter[8];
                p[0] = new ReportParameter("Date", DateTime.Now.ToString());                
                p[1] = new ReportParameter("Total", txtnet.Text);
                p[2] = new ReportParameter("Quantity", txtQuantity.Text);
                p[3] = new ReportParameter("OrderNo", orderno.ToString());
                p[4] = new ReportParameter("ShopName", Properties.Settings.Default.Name);
                p[5] = new ReportParameter("username", LoggedInUser.DisplayName);
                p[6] = new ReportParameter("UnitPrice", txtPrice.Text);
                p[7] = new ReportParameter("Discount", discount.ToString());


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
                }
                if (e.Control && e.KeyCode == Keys.N) // for combination of Ctrl + Q
                {
                    txtPrice.Focus();
                    txtQuantity.Text = "";
                    txtPrice.Text = "";
                    txtnet.Text = "";
                    txtdiscountpercentage.Text = "0";

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void txtnet_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                loadNetAmount();
                Print();
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    txtQuantity.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void frmAddEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
            }
        }

        private void txtdiscountpercentage_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtdiscountpercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtdiscountpercentage_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {                
                loadNetAmount();
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    Print();
                    txtQuantity.Focus();
                }
            }
            catch (Exception)
            {
            }
        }


    }
}
