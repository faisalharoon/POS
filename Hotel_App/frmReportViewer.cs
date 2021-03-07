using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace General_App
{
    public partial class frmReportViewer : Form
    {

        public DataTable dt;
        public int discount;
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            reportViewer1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();




            ReportDataSource reportDSDetail = new ReportDataSource("DataSet2", dt);
            reportViewer1.LocalReport.ReportPath = "../../Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
            reportViewer1.LocalReport.EnableExternalImages = true;

            double total = dt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<string>("Total")));

            ReportParameter[] p = new ReportParameter[4];
            p[0] = new ReportParameter("Date",DateTime.Now.ToString());
            p[1] = new ReportParameter("Total",total.ToString());
            p[2] = new ReportParameter("Discount",discount.ToString() );
           double totaldisoucnt = Convert.ToDouble( Math.Round(Convert.ToDecimal((total * discount) / 100), 0));
           p[3] = new ReportParameter("GTotal", (total - totaldisoucnt).ToString());




            reportViewer1.LocalReport.SetParameters(p);

            reportViewer1.LocalReport.Refresh();

            reportViewer1.RefreshReport();
            reportViewer1.Visible = true;
            
            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

            //reportViewer1.RenderingComplete += new RenderingCompleteEventHandler(PrintSales);


            System.Threading.Thread.Sleep(1000);

            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();

            //PrintPreviewDialog prd = new PrintPreviewDialog();
            //prd.Document = printDoc;
            //prd.ShowDialog();

            //printDoc.DocumentName = "Print Document";
            //printDlg.Document = printDoc;
            //printDlg.AllowSelection = true;
            //printDlg.AllowSomePages = true;
            //printDoc.Print();


        }


        public void PrintSales(object sender, RenderingCompleteEventArgs e)
        {
            try
            {

                reportViewer1.PrintDialog();
                reportViewer1.Clear();
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
