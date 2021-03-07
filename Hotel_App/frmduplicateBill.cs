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
    public partial class frmduplicateBill : Form
    {
        public int glbSaleID = -1;
        public frmduplicateBill()
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

            Maindt.Columns.Add("ItemCategoryID");
            Maindt.Columns.Add("Discount%");

            Print();
        }


        DataTable Maindt;
        private void PrintReport()
        {
            try
            {
                reportViewer2.Clear();
                reportViewer2.LocalReport.DataSources.Clear();


                DataTable tmpdtinitial = DALAccess.ExecuteDataTable(@"SELECT 
sale.SalesTax
, i.ID
, i.Name
, sd.Quantity
, Format(sd.price,'0') AS Price
, sd.Total
, ItemCategory.DistributorProfitPercentage as [Discount%]
, i.ItemCategoryID
,ItemCategory.Code
            FROM((saledetail AS sd INNER JOIN item AS i ON sd.itemid = i.id) 
            INNER JOIN sale ON sd.saleid = sale.id) INNER JOIN ItemCategory ON i.ItemCategoryID = ItemCategory.ID 
            where sd.saleid=" + glbSaleID);




                var dtAll = tmpdtinitial.AsEnumerable().Select(x => new {
                    Name = Convert.ToString(x.Field<object>("Name")),
                    Price = Convert.ToDouble(x.Field<object>("Price")),
                    Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                    Total = Convert.ToDouble(x.Field<object>("Total")),
                    Discount = Math.Round((Convert.ToDouble(x.Field<object>("Discount%")) * Convert.ToDouble(x.Field<object>("Total"))) / 100, 0)
                });

                var dtBrush = tmpdtinitial.AsEnumerable().Where(x => Convert.ToString(x.Field<object>("Code")) =="brush").Select(x => new {
                    Name = Convert.ToString(x.Field<object>("Name")),
                    Price = Convert.ToDouble(x.Field<object>("Price")),
                    Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                    Total = Convert.ToDouble(x.Field<object>("Total")),
                    Discount = Math.Round((Convert.ToDouble(x.Field<object>("Discount%")) * Convert.ToDouble(x.Field<object>("Total"))) / 100, 0)
                }).ToList();


                //dtBrush.Add(new
                //{
                //    Name = "Total",
                //    Price = dtBrush.Sum(x=>x.Price),
                //    Quantity = dtBrush.Sum(x => x.Quantity),
                //    Total = dtBrush.Sum(x => x.Total),
                //    Discount = dtBrush.Sum(x => x.Discount)
                //});


                var dtDiaper = tmpdtinitial.AsEnumerable().Where(x => Convert.ToString(x.Field<object>("code")) == "diaper").Select(x => new {
                    Name = Convert.ToString(x.Field<object>("Name")),
                    Price = Convert.ToDouble(x.Field<object>("Price")),
                    Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                    Total = Convert.ToDouble(x.Field<object>("Total")),
                    Discount = Math.Round((Convert.ToDouble(x.Field<object>("Discount%")) * Convert.ToDouble(x.Field<object>("Total"))) / 100, 0)
                }).ToList();

                //dtDiaper.Add(new
                //{
                //    Name = "Total",
                //    Price = dtBrush.Sum(x => x.Price),
                //    Quantity = dtBrush.Sum(x => x.Quantity),
                //    Total = dtBrush.Sum(x => x.Total),
                //    Discount = dtBrush.Sum(x => x.Discount)
                //});


                //DataView dv = new DataView(tmpdt, "ID in (1,2,3)","", DataViewRowState.CurrentRows);
                //DataView dv2 = new DataView(tmpdt, "ID not in (1,2,3)","", DataViewRowState.CurrentRows);



                try
                {
                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dtDiaper);                   
                    reportViewer2.LocalReport.ReportPath = "../../Report1-Fullpage.rdlc";
                    reportViewer2.LocalReport.DataSources.Add(reportDSDetail);                   
                    reportViewer2.LocalReport.EnableExternalImages = true;

                    reportDSDetail = new ReportDataSource("DataSet2", dtBrush);
                    reportViewer2.LocalReport.DataSources.Add(reportDSDetail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("dataset2: " + ex.Message);
                }



                DataTable dtSale= DALAccess.ExecuteDataTable("select * from sale where id="+glbSaleID);


                double total = tmpdtinitial.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Total")));
                int discountPercentage = Convert.ToInt32(dtSale.Rows[0]["DiscountPercentage"]);
                var discountAmount= Convert.ToDouble(dtSale.Rows[0]["Discount"]);

                double totaldisoucnt = Convert.ToDouble(discountAmount);
                double gstpercentage = Convert.ToDouble(0);
                double grosstotal = (total - totaldisoucnt);
                double gst = Convert.ToDouble(dtSale.Rows[0]["SalesTax"]);

                DataTable dtCustomer = DALAccess.ExecuteDataTable("select * from customer where id=" + dtSale.Rows[0]["CustomerID"]);


                ReportParameter[] p = new ReportParameter[20];
                p[0] = new ReportParameter("Date", DateTime.Now.ToString());


                p[1] = new ReportParameter("Total", total.ToString());
                p[2] = new ReportParameter("GDiscount", dtAll.Sum(x => x.Discount).ToString());
                p[3] = new ReportParameter("GTotal", dtAll.Sum(x => x.Total).ToString());
                p[4] = new ReportParameter("OrderNo", dtSale.Rows[0]["OrderNo"].ToString());
                p[5] = new ReportParameter("Name", dtSale.Rows[0]["CustomerName"].ToString());
                p[6] = new ReportParameter("gst", gst.ToString());
                p[7] = new ReportParameter("ShopName", XmlExtension.GetSetupValues().CompanyName);
                p[8] = new ReportParameter("username", LoggedInUser.DisplayName);
                p[9] = new ReportParameter("ShopAddress", XmlExtension.GetSetupValues().CompanyAddress);


                p[10] = new ReportParameter("CNIC", Convert.ToString(dtCustomer.Rows[0]["CNIC"]));
                p[11] = new ReportParameter("Mobile", Convert.ToString(dtCustomer.Rows[0]["Mobile"]));
                p[12] = new ReportParameter("Address", Convert.ToString(dtCustomer.Rows[0]["Address"]));


                p[13] = new ReportParameter("Total2", dtBrush.Sum(x => x.Total).ToString());
                p[14] = new ReportParameter("Total1", dtDiaper.Sum(x => x.Total).ToString());

                p[15] = new ReportParameter("Discount2", dtBrush.Sum(x => x.Discount).ToString());
                p[16] = new ReportParameter("Discount1", dtDiaper.Sum(x => x.Discount).ToString());

                p[17] = new ReportParameter("GTotal2", (dtBrush.Sum(x => x.Total) - dtBrush.Sum(x => x.Discount)).ToString());
                p[18] = new ReportParameter("GTotal1", (dtDiaper.Sum(x => x.Total) - dtDiaper.Sum(x => x.Discount)).ToString());

                p[19] = new ReportParameter("FinalAmount", (dtAll.Sum(x => x.Total) - dtAll.Sum(x => x.Discount)).ToString());

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
