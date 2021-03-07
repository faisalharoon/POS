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
    public partial class frmDistributorBalance : Form
    {

        public int customerid = 0;
        public string customerName = "";

        public frmDistributorBalance()
        {
            InitializeComponent();
            btnshow_Click();
        }

        private void btnshow_Click()
        {
            reportViewer1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();

            //DateTime startdate = dtmstart.SelectionStart.Date;
            //DateTime enddate = dtmend.SelectionStart.Date;

            //customerid = Convert.ToInt32(ddlcustomer.SelectedValue);
            //customerName = ddlcustomer.GetItemText(ddlcustomer.SelectedItem);

            string query = @"select customer.name
,sum(customerpayment.amounttopay) as amounttopay
,sum(customerpayment.amounttopay) as Price
,sum(customerpayment.balance) as balance
,sum(customerpayment.amount) as amount
,sum(customerpayment.amount) as Total
,sum((customerpayment.amounttopay - customerpayment.amount)) as PurchasePrice
from customerpayment inner join customer on customer.id=customerpayment.customerid group by customerpayment.customerid,customer.name";

            DataTable dt =DALAccess.ExecuteDataTable(query);





           
            
                //var q = dt.AsEnumerable().Select(x => new
                //{
                //    ID = Convert.ToInt32(x.Field<object>("ID")),
                //    Name = x.Field<object>("Name"),
                //    Total = Convert.ToInt32(x.Field<object>("Total")),
                //    Discount = Convert.ToInt32(x.Field<object>("Discount")),
                //    Price = Convert.ToInt32(x.Field<object>("Price")),
                //    Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                //    Date = Convert.ToDateTime(x.Field<object>("CreationDate")).ToString("dd/MM/yyyy"),
                //    ProfitPercentage= Convert.ToInt32(x.Field<object>("DistributorProfitPercentage"))
                //}).Select(x => new {
                //    Date = x.Date,
                //    Total = x.Total,
                //    Discount = x.Discount,
                //    x.Name,
                //    x.Price,
                //    Profit=0,
                //    x.Quantity
                //}).ToList();

                //var resultTable = Enumerable.Distinct(q);
                //DataTable dtlast = resultTable.ToADOTable(rec => new object[] { resultTable });


            var totaltopay = dt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Amounttopay")));
            var totalpaid = dt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("amount")));
            var balance = (totaltopay - totalpaid);


            ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.ReportPath = "../../rptDistributorBalance.rdlc";
                reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                reportViewer1.LocalReport.EnableExternalImages = true;

                double total = dt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Total")));
            double discount = 0;// dt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Discount")));

                ReportParameter[] p = new ReportParameter[8];
                p[0] = new ReportParameter("StartDate", "");
                p[1] = new ReportParameter("EndDate", "");
                p[2] = new ReportParameter("Total", (balance).ToString());
                p[3] = new ReportParameter("expense", "0");
                p[4] = new ReportParameter("NET", (total - discount).ToString());
                p[5] = new ReportParameter("Discount", (discount).ToString());
                p[6] = new ReportParameter("profit", "0");
                p[7] = new ReportParameter("Name", customerName);

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
            LoadCustomerDropDown();
            this.reportViewer1.RefreshReport();
        }
        private void LoadCustomerDropDown()
        {
            try
            {
                //DataTable dtCust = DALAccess.ExecuteDataTable("select * from customer order by id asc");
                //ddlcustomer.ValueMember = "ID";
                //ddlcustomer.DisplayMember = "Name";
                //ddlcustomer.DataSource = dtCust;
            }
            catch (Exception)
            {
            }
        }

      
    }
}
