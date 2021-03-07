using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_App
{
    public partial class frmduplicateBillVendor : Form
    {
        public int glbSaleID = -1;
        public frmduplicateBillVendor()
        {
            InitializeComponent();
        }

        private void frmduplicateBill_Load(object sender, EventArgs e)
        {
            Maindt = new DataTable();
            Maindt.Columns.Add("ID");
            Maindt.Columns.Add("Name");
            Maindt.Columns.Add("Quantity");
            Maindt.Columns.Add("Price");
            Maindt.Columns.Add("Total");

            Print();
        }


        DataTable Maindt;
        private void PrintReport()
        {
            try
            {
                reportViewer2.Clear();
                reportViewer2.LocalReport.DataSources.Clear();


                DataTable tmpdtinitial = DALAccess.ExecuteDataTable("select itemstockmaster.SalesTax,i.ID,i.Name,sd.stock as Quantity,Format(sd.purchaseprice,'0') as Price,sd.Total from (itemstock sd inner join item i on i.id=sd.itemid) inner join itemstockmaster on itemstockmaster.id=sd.itemstockmasterid where sd.itemstockmasterid=" + glbSaleID);

               


                //DataView dv = new DataView(tmpdt, "ID in (1,2,3)","", DataViewRowState.CurrentRows);
                //DataView dv2 = new DataView(tmpdt, "ID not in (1,2,3)","", DataViewRowState.CurrentRows);



                try
                {
                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", tmpdtinitial);
                    //ReportDataSource reportDSDetail2 = new ReportDataSource("DataSet2", dv2.ToTable());
                    //if(lstfirst2!=null && lstfirst2.Count()>0 && lstfirst!=null && lstfirst.Count()>0)
                    //    reportViewer2.LocalReport.ReportPath = "../../ReportBill.rdlc";
                    //else
                    reportViewer2.LocalReport.ReportPath = "../../Report1-FullpageVendor.rdlc";
                    reportViewer2.LocalReport.DataSources.Add(reportDSDetail);
                    //reportViewer2.LocalReport.DataSources.Add(reportDSDetail2);
                    reportViewer2.LocalReport.EnableExternalImages = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("dataset2: " + ex.Message);
                }



                DataTable dtSale= DALAccess.ExecuteDataTable("select * from itemstockmaster where id="+glbSaleID);


                double total = tmpdtinitial.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Total")));
                int discountPercentage = Convert.ToInt32(dtSale.Rows[0]["DiscountPercentage"]);
                var discountAmount= Convert.ToDouble(dtSale.Rows[0]["Discount"]);


                ReportParameter[] p = new ReportParameter[10];
                p[0] = new ReportParameter("Date", DateTime.Now.ToString());

                //double totaldisoucnt = Convert.ToDouble(Math.Round(Convert.ToDecimal((total * discountPercentage) / 100), 0));
                double totaldisoucnt = Convert.ToDouble(discountAmount);
                double gstpercentage = Convert.ToDouble(0);
                double grosstotal = (total - totaldisoucnt);
                //double gst = Math.Round((grosstotal * gstpercentage) / 100, 0);
                double gst = Convert.ToDouble(dtSale.Rows[0]["SalesTax"]);

                p[1] = new ReportParameter("Total", total.ToString());
                p[2] = new ReportParameter("Discount", totaldisoucnt.ToString());
                p[3] = new ReportParameter("GTotal", (grosstotal + gst).ToString());
                p[4] = new ReportParameter("OrderNo", Convert.ToString(dtSale.Rows[0]["OrderNo"]));
                p[5] = new ReportParameter("Name", Convert.ToString(dtSale.Rows[0]["VendorName"]));
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


        private void Print()
        {
            try
            {                
                PrintReport();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

    }
}
