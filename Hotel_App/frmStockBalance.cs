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
    public partial class frmStockBalance : Form
    {
        public frmStockBalance()
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


            DataTable dtstockOpening = DALAccess.ExecuteDataTable(@"select Item.Name,Item.ID
                ,(select sum(quantity) from saledetail where itemid=Item.ID and  Format([saledetail.CreationDate],'MM/DD/YYYY')<='" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"') as OpeningSold
                ,(select sum(stock) from ItemStock where itemid=Item.ID and  Format([ItemStock.CreationDate],'MM/DD/YYYY')<='" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"') as OpeningStock
                ,(select sum(quantity) from saledetail where itemid=Item.ID and  Format([saledetail.CreationDate],'MM/DD/YYYY')>'" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"' and Format([saledetail.CreationDate],'MM/DD/YYYY')<='" + Convert.ToDateTime(enddate).ToString("MM/dd/yyyy") + @"') as ClosingSold
                ,(select sum(stock) from ItemStock where itemid=Item.ID and  Format([ItemStock.CreationDate],'MM/DD/YYYY')>'" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"' and Format([ItemStock.CreationDate],'MM/DD/YYYY')<='" + Convert.ToDateTime(enddate).ToString("MM/dd/yyyy") + @"') as ClosingStock
                    from
                    Item                 
                    order by Item.Name
                    ");

            var q = dtstockOpening.AsEnumerable().Select(x => new
            {
                Name = x.Field<object>("Name"),
                ID = x.Field<object>("ID"),
                OpeningStock = Convert.ToDouble(x.Field<object>("OpeningStock")) - Convert.ToDouble(x.Field<object>("OpeningSold")),
                NewStock = Convert.ToDouble(x.Field<object>("ClosingStock")),
                SoldStock = Convert.ToDouble(x.Field<object>("ClosingSold")),
                ClosingStock = Convert.ToDouble(x.Field<object>("ClosingStock")) - Convert.ToDouble(x.Field<object>("ClosingSold"))
            }).Select(x => new {
                x.Name,
                x.ID,
                x.OpeningStock,
                x.NewStock,
                x.SoldStock,
                ClosingStock = x.ClosingStock + x.OpeningStock
            }).ToList();





            ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", q);
            reportViewer1.LocalReport.ReportPath = "../../rptstockopening.rdlc";
            reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
            reportViewer1.LocalReport.EnableExternalImages = true;


            //double total = qsale.Sum(x => x.Total);
            //double totalPurchase = qsale.Sum(x => x.PurchasePrice * x.Quantity);
            //double discount = qsale.GroupBy(x => x.ItemID).Sum(x => x.FirstOrDefault().Discount);

            ReportParameter[] p = new ReportParameter[2];
            p[0] = new ReportParameter("StartDate", Convert.ToDateTime(startdate).ToString("MMM/dd/yyyy"));
            p[1] = new ReportParameter("EndDate", Convert.ToDateTime(enddate).ToString("MMM/dd/yyyy"));
            //p[2] = new ReportParameter("Total", (total).ToString());
            //p[3] = new ReportParameter("expense", expenseAmount.ToString());
            //p[4] = new ReportParameter("NET", ((total - totalPurchase) - discount - expenseAmount).ToString());
            //p[5] = new ReportParameter("Discount", (discount).ToString());
            //p[6] = new ReportParameter("other", "0");
            //p[7] = new ReportParameter("expense2", "0");
            //p[8] = new ReportParameter("Purchase", Convert.ToString(totalPurchase));

            reportViewer1.LocalReport.SetParameters(p);



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
