using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace General_App
{
    public partial class frmreport : Form
    {
        public frmreport()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            reportViewer1.Clear();
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.EnableExternalImages = true;


            string startdate = Convert.ToDateTime(dtmstart.SelectionStart.Date).ToShortDateString();
            string enddate = Convert.ToDateTime(dtmend.SelectionStart.Date).ToString();

            string query = @"SELECT Saledetail.ItemID,Sale.ID,Saledetail.Price as SalePrice, SaleDetail.PurchasePrice, SaleDetail.Price, SaleDetail.Quantity, SaleDetail.Total, Sale.Discount, Sale.CreationDate
                            , Item.Name,Item.BulkItems,Saledetail.GSTAmount as GST
                            FROM (SaleDetail INNER JOIN Item ON SaleDetail.ItemID = Item.ID) INNER JOIN Sale ON SaleDetail.SaleID = Sale.ID";
            //where Format([Sale.CreationDate],'MM/DD/YYYY')>='" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"'
            //and Format([Sale.CreationDate],'MM/DD/YYYY')<='" + Convert.ToDateTime(enddate).ToString("MM/dd/yyyy") + @"'                                 "


            DataTable dt = DALAccess.ExecuteDataTable(query);

            var qsale = dt.AsEnumerable().Select(x => new
            {
                ItemID = Convert.ToInt32(x.Field<object>("ItemID")),
                ID = Convert.ToInt32(x.Field<object>("ID")),
                SalePrice = Convert.ToDouble(x.Field<object>("SalePrice")),
                PurchasePrice = Convert.ToDouble(x.Field<object>("PurchasePrice")),
                Price = Convert.ToDouble(x.Field<object>("Price")),
                Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                Total = Convert.ToDouble(x.Field<object>("Total")),
                Discount = Convert.ToDouble(x.Field<object>("Discount")),
                CreationDate = Convert.ToDateTime(x.Field<object>("CreationDate")).Date,
                CreationDateSale = Convert.ToDateTime(x.Field<object>("CreationDate")).ToString("DD/MM/YYYY"),
                Name = Convert.ToString(x.Field<object>("Name")),
                BulkItems = Convert.ToDouble(x.Field<object>("BulkItems")),
                GST= Convert.ToDouble(x.Field<object>("GST")),
                GrossTotal= Convert.ToDouble(x.Field<object>("Total"))+ Convert.ToDouble(x.Field<object>("GST"))- Convert.ToDouble(x.Field<object>("Discount"))

            }).Where(x => x.CreationDate.Date >= Convert.ToDateTime(startdate) && x.CreationDate.Date <= Convert.ToDateTime(enddate)).ToList();




            DataTable dtexpense = DALAccess.ExecuteDataTable(@"select * from expense");
            //where Format([expenseDate], 'MM/DD/YYYY') >= '" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"'
            //and Format([expenseDate], 'MM/DD/YYYY')<= '" + Convert.ToDateTime(enddate).ToString("MM/dd/yyyy") + @"'");

            var qexpense = dtexpense.AsEnumerable().Select(x => new
            {
                Amount = Convert.ToDouble(x.Field<object>("Amount")),
                ExpenseDate = Convert.ToDateTime(x.Field<object>("ExpenseDate")).Date
            }).Where(x => x.ExpenseDate.Date >= Convert.ToDateTime(startdate) && x.ExpenseDate.Date <= Convert.ToDateTime(enddate)).ToList();

            //var qOtherCanteenExpenseAmount = dtexpenseOtherCanteen.AsEnumerable().Sum(x => Convert.ToInt32(x.Field<object>("Amount")));
            //var qOtherCanteenSaleAmount = dtSaleOtherCanteen.AsEnumerable().Sum(x => Convert.ToInt32(x.Field<object>("Total")));
            //var qOtherCanteenDiscountAmount = dtSaleOtherCanteen.AsEnumerable().Sum(x => Convert.ToInt32(x.Field<object>("Discount")));
            //var qOtherFinal = qOtherCanteenSaleAmount ;


            var expenseAmount = 0.0;
            //var profit40Percent = Convert.ToDouble(qOtherFinal-qOtherCanteenExpenseAmount-qOtherCanteenDiscountAmount);
            //profit40Percent = Math.Round((profit40Percent * 60) / 100, 0);


            if (dtexpense != null && dtexpense.Rows.Count > 0)
            {
                expenseAmount = qexpense.Sum(x => x.Amount);
            }

            if (rdbtndaily.Checked)
            {
                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", qsale);
                reportViewer1.LocalReport.ReportPath = "../../Report2.rdlc";
                reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                reportViewer1.LocalReport.EnableExternalImages = true;


                double total = qsale.Sum(x => x.Total);
                double totalPurchase = qsale.Sum(x => x.PurchasePrice * x.Quantity);
                double discount = qsale.GroupBy(x=>x.ID).Sum(x => x.FirstOrDefault().Discount);
                double gst = qsale.Sum(x => x.GST);

                ReportParameter[] p = new ReportParameter[10];
                p[0] = new ReportParameter("StartDate", Convert.ToDateTime(startdate).ToString("MMM/dd/yyyy"));
                p[1] = new ReportParameter("EndDate", Convert.ToDateTime(enddate).ToString("MMM/dd/yyyy"));
                p[2] = new ReportParameter("Total", (total).ToString());
                p[3] = new ReportParameter("expense", expenseAmount.ToString());
                p[4] = new ReportParameter("NET", ((total - totalPurchase) - discount - expenseAmount-gst).ToString());
                p[5] = new ReportParameter("Discount", (discount).ToString());
                p[6] = new ReportParameter("other", "0");
                p[7] = new ReportParameter("expense2", "0");
                p[8] = new ReportParameter("Purchase", Convert.ToString(totalPurchase));
                p[9] = new ReportParameter("GST", Convert.ToString(gst));

                reportViewer1.LocalReport.SetParameters(p);
            }
            else if (rdbtnItemvise.Checked || rdbtnCottonVise.Checked)
            {
                var q = qsale.GroupBy(x => x.ItemID).Select(x => new
                {
                    Name = x.FirstOrDefault().Name,
                    Total = x.Sum(xx => xx.Total),
                    Price = x.Sum(xx => xx.Price * xx.Quantity),
                    PurchasePrice = x.Sum(xx => xx.PurchasePrice * xx.Quantity),
                    Quantity = Convert.ToDouble(x.Sum(xx => xx.Quantity)),
                    Discount = x.Sum(xx => xx.Discount),
                    BulkItems=x.FirstOrDefault().BulkItems,
                    GST= x.Sum(xx => xx.GST),
                }).ToList();


                if (rdbtnCottonVise.Checked)
                {
                    q = q.Select(x => new
                    {
                        Name = x.Name,
                        Total = x.Total,
                        Price = x.Price,
                        PurchasePrice = x.PurchasePrice,
                        Quantity = Math.Round(Convert.ToDouble(x.Quantity/x.BulkItems),0),
                        Discount = x.Discount,
                        x.BulkItems,
                        x.GST
                    }).ToList();
                }


                var resultTable = Enumerable.Distinct(q);
                DataTable dtlast = resultTable.ToADOTable(rec => new object[] { resultTable });


                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dtlast);
                reportViewer1.LocalReport.ReportPath = "../../Report2.rdlc";
                reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                reportViewer1.LocalReport.EnableExternalImages = true;

                double total = qsale.Sum(x => x.Total);
                double totalPurchase = qsale.Sum(x => x.PurchasePrice * x.Quantity);
                double discount = qsale.GroupBy(x=>x.ID).Sum(x => x.FirstOrDefault().Discount);
                double gst= qsale.Sum(x => x.GST);

                ReportParameter[] p = new ReportParameter[10];
                p[0] = new ReportParameter("StartDate", Convert.ToDateTime(startdate).ToString("MMM/dd/yyyy"));
                p[1] = new ReportParameter("EndDate", Convert.ToDateTime(enddate).ToString("MMM/dd/yyyy"));
                p[2] = new ReportParameter("Total", (total).ToString());
                p[3] = new ReportParameter("expense", expenseAmount.ToString());
                p[4] = new ReportParameter("NET", ((total - totalPurchase) - discount - expenseAmount-gst).ToString());
                p[5] = new ReportParameter("Discount", (discount).ToString());
                p[6] = new ReportParameter("other", "0");
                p[7] = new ReportParameter("expense2", "0");
                p[8] = new ReportParameter("Purchase", totalPurchase.ToString());
                p[9] = new ReportParameter("GST", gst.ToString());

                reportViewer1.LocalReport.SetParameters(p);

            }









            reportViewer1.LocalReport.Refresh();

            reportViewer1.RefreshReport();
            reportViewer1.Visible = true;

            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

            System.Threading.Thread.Sleep(1000);
        }




        private void frmreport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

    }
}
