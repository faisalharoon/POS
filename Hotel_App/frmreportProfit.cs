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
    public partial class frmreportProfit : Form
    {
        public frmreportProfit()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            reportViewer1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();

            DateTime startdate = dtmstart.SelectionStart.Date;
            DateTime enddate = dtmend.SelectionStart.Date;

            string query = @"SELECT saledetail.ItemID,Item.ID,Item.SalePrice, Item.PurchasePrice, SaleDetail.Price, SaleDetail.Quantity, SaleDetail.Total, Sale.Discount, Sale.CreationDate,Format([Sale.CreationDate],'DD/MM/YYYY') as CreationDateSale
                            , Item.Name
                            FROM (SaleDetail INNER JOIN Item ON SaleDetail.ItemID = Item.ID) INNER JOIN Sale ON SaleDetail.SaleID = Sale.ID
                            where Format([Sale.CreationDate],'MM/DD/YYYY')>='" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"'
                             and Format([Sale.CreationDate],'MM/DD/YYYY')<='" + Convert.ToDateTime(enddate).ToString("MM/dd/yyyy") + @"' 
                             and ((Item.Name like '%coffee%') or  (Item.Name  like  '%ice cream%') or  (Item.Name like '%tea%'))";

            DataTable dt =DALAccess.ExecuteDataTable(query);





            DataTable dtexpense = DALAccess.ExecuteDataTable(@"select * from expense
                where Format([expenseDate], 'MM/DD/YYYY') >= '" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"'
                             and Format([expenseDate], 'MM/DD/YYYY')<= '" + Convert.ToDateTime(enddate).ToString("MM/dd/yyyy") + @"'
               and title like '%!expense%' ");


            var expenseAmount = 0.0;
            if (dtexpense != null && dtexpense.Rows.Count > 0)
            {
                expenseAmount = dtexpense.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<int>("Amount")));
            }




            if (rdbtndaily.Checked)
            {
                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.ReportPath = "../../rptprofit.rdlc";
                reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                reportViewer1.LocalReport.EnableExternalImages = true;

                double total = dt.AsEnumerable().Sum(x => x.Field<int>("Total"));
                double discount = dt.AsEnumerable().Sum(x => x.Field<int>("Discount"));

                ReportParameter[] p = new ReportParameter[7];
                p[0] = new ReportParameter("StartDate", Convert.ToDateTime(startdate).ToString("MMM/dd/yyyy"));
                p[1] = new ReportParameter("EndDate", Convert.ToDateTime(enddate).ToString("MMM/dd/yyyy"));
                p[2] = new ReportParameter("Total", (total).ToString());
                p[3] = new ReportParameter("expense", expenseAmount.ToString());
                p[4] = new ReportParameter("NET", (total - discount).ToString());
                p[5] = new ReportParameter("Discount", (discount).ToString());
                p[6] = new ReportParameter("profit", Math.Round((((total - expenseAmount - discount) * 40) / 100), 0).ToString());

                reportViewer1.LocalReport.SetParameters(p);
            }
            else if(rdbtnDayvise.Checked)
            {

                var q = dt.AsEnumerable().Select(x => new
                {
                    ID = Convert.ToInt32(x.Field<object>("ID")),
                    Name = x.Field<object>("Name"),
                    Total = Convert.ToInt32(x.Field<object>("Total")),
                    Discount = Convert.ToInt32(x.Field<object>("Discount")),
                    Price = Convert.ToInt32(x.Field<object>("Price")),
                    CreationDate = Convert.ToDateTime(x.Field<object>("CreationDate")).ToString("dd/MM/yyyy")
                }).GroupBy(x => x.CreationDate).Select(x => new {
                    Date = x.FirstOrDefault().CreationDate,
                    Total = x.Sum(xx => xx.Total),
                    Discount = x.Sum(xx => xx.Discount),
                    Expense = dtexpense.AsEnumerable().Where(xx => Convert.ToDateTime(xx.Field<object>("expensedate")).ToString("dd/MM/yyyy") == x.FirstOrDefault().CreationDate).Sum(xx => Convert.ToInt32(xx.Field<object>("Amount"))),
                }).ToList();

                var resultTable = Enumerable.Distinct(q);
                DataTable dtlast = resultTable.ToADOTable(rec => new object[] { resultTable });




                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dtlast);
                reportViewer1.LocalReport.ReportPath = "../../rptprofitMonthly.rdlc";
                reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                reportViewer1.LocalReport.EnableExternalImages = true;

                double total = dt.AsEnumerable().Sum(x => x.Field<int>("Total"));
                double discount = dt.AsEnumerable().Sum(x => x.Field<int>("Discount"));

                ReportParameter[] p = new ReportParameter[7];
                p[0] = new ReportParameter("StartDate", Convert.ToDateTime(startdate).ToString("MMM/dd/yyyy"));
                p[1] = new ReportParameter("EndDate", Convert.ToDateTime(enddate).ToString("MMM/dd/yyyy"));
                p[2] = new ReportParameter("Total", (total).ToString());
                p[3] = new ReportParameter("expense", expenseAmount.ToString());
                p[4] = new ReportParameter("NET", (total - discount).ToString());
                p[5] = new ReportParameter("Discount", (discount).ToString());
                p[6] = new ReportParameter("profit", Math.Round((((total - expenseAmount - discount) * 40) / 100), 0).ToString());

                reportViewer1.LocalReport.SetParameters(p);
            }
            else if (rdbtnItemvise.Checked)
            {

                var q = dt.AsEnumerable().Select(x => new
                {
                    ID = Convert.ToInt32(x.Field<object>("ItemID")),
                    Name = x.Field<object>("Name"),
                    Total = Convert.ToInt32(x.Field<object>("Total")),
                    Discount = Convert.ToInt32(x.Field<object>("Discount")),
                    Price = Convert.ToInt32(x.Field<object>("Price")),
                    Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                    CreationDate = Convert.ToDateTime(x.Field<object>("CreationDate")).ToString("dd/MM/yyyy")
                }).GroupBy(x => x.ID).Select(x => new {
                    Name= x.FirstOrDefault().Name,
                    Total = x.Sum(xx => xx.Total),
                    Price = x.FirstOrDefault().Price,
                    Quantity = x.Sum(xx => xx.Quantity),
                    Discount = x.Sum(xx => xx.Discount)                    
                }).ToList();

                var resultTable = Enumerable.Distinct(q);
                DataTable dtlast = resultTable.ToADOTable(rec => new object[] { resultTable });




                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dtlast);
                reportViewer1.LocalReport.ReportPath = "../../rptprofit.rdlc";
                reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                reportViewer1.LocalReport.EnableExternalImages = true;

                double total = dt.AsEnumerable().Sum(x => x.Field<int>("Total"));
                double discount = dt.AsEnumerable().Sum(x => x.Field<int>("Discount"));

                ReportParameter[] p = new ReportParameter[7];
                p[0] = new ReportParameter("StartDate", Convert.ToDateTime(startdate).ToString("MMM/dd/yyyy"));
                p[1] = new ReportParameter("EndDate", Convert.ToDateTime(enddate).ToString("MMM/dd/yyyy"));
                p[2] = new ReportParameter("Total", (total).ToString());
                p[3] = new ReportParameter("expense", expenseAmount.ToString());
                p[4] = new ReportParameter("NET", (total - discount).ToString());
                p[5] = new ReportParameter("Discount", (discount).ToString());
                p[6] = new ReportParameter("profit", Math.Round((((total - expenseAmount - discount) * 40) / 100), 0).ToString());

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
