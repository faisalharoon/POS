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
    public partial class frmDistributorProfit : Form
    {

        public int customerid = 0;
        public string customerName = "";

        public frmDistributorProfit()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            reportViewer1.Clear();
            reportViewer1.LocalReport.DataSources.Clear();

            DateTime startdate = dtmstart.SelectionStart.Date;
            DateTime enddate = dtmend.SelectionStart.Date;

            customerid = Convert.ToInt32(ddlcustomer.SelectedValue);
            customerName = ddlcustomer.GetItemText(ddlcustomer.SelectedItem);

            string query = @"SELECT SaleDetail.ItemID, Item.ID, Item.SalePrice, Item.PurchasePrice, SaleDetail.Price, SaleDetail.Quantity, SaleDetail.Total, Sale.Discount, Sale.CreationDate, Format([Sale.CreationDate],'dd/mm/yyyy') AS CreationDateSale, Item.Name, ItemCategory.DistributorProfitPercentage
FROM ((SaleDetail INNER JOIN Item ON SaleDetail.ItemID = Item.ID) INNER JOIN Sale ON SaleDetail.SaleID = Sale.ID) INNER JOIN ItemCategory ON Item.ItemCategoryID = ItemCategory.ID
                            where Format([Sale.CreationDate],'MM/DD/YYYY')>='" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"'
                             and Format([Sale.CreationDate],'MM/DD/YYYY')<='" + Convert.ToDateTime(enddate).ToString("MM/dd/yyyy") + @"' 
                             and Sale.customerid="+ customerid;

            DataTable dt =DALAccess.ExecuteDataTable(query);





            DataTable dtexpense = DALAccess.ExecuteDataTable(@"select * from expense
                where Format([expenseDate], 'MM/DD/YYYY') >= '" + Convert.ToDateTime(startdate).ToString("MM/dd/yyyy") + @"'
                             and Format([expenseDate], 'MM/DD/YYYY')<= '" + Convert.ToDateTime(enddate).ToString("MM/dd/yyyy") + @"' ");


            var expenseAmount = 0.0;
            if (dtexpense != null && dtexpense.Rows.Count > 0)
            {
                expenseAmount = dtexpense.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<int>("Amount")));
            }

            
                var q = dt.AsEnumerable().Select(x => new
                {
                    ID = Convert.ToInt32(x.Field<object>("ID")),
                    Name = x.Field<object>("Name"),
                    Total = Convert.ToInt32(x.Field<object>("Total")),
                    Discount = Convert.ToInt32(x.Field<object>("Discount")),
                    Price = Convert.ToInt32(x.Field<object>("Price")),
                    Quantity = Convert.ToInt32(x.Field<object>("Quantity")),
                    Date = Convert.ToDateTime(x.Field<object>("CreationDate")).ToString("dd/MM/yyyy"),
                    ProfitPercentage= Convert.ToInt32(x.Field<object>("DistributorProfitPercentage"))
                }).Select(x => new {
                    Date = x.Date,
                    Total = x.Total,
                    Discount = x.Discount,
                    x.Name,
                    x.Price,
                    Profit=Math.Round(Convert.ToDouble(((x.Total*x.ProfitPercentage)/100)),0),
                    x.Quantity
                }).ToList();

                var resultTable = Enumerable.Distinct(q);
                DataTable dtlast = resultTable.ToADOTable(rec => new object[] { resultTable });




                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dtlast);
                reportViewer1.LocalReport.ReportPath = "../../rptProfitDistributor.rdlc";
                reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                reportViewer1.LocalReport.EnableExternalImages = true;

                double total = dt.AsEnumerable().Sum(x => x.Field<int>("Total"));
                double discount = dt.AsEnumerable().Sum(x => x.Field<int>("Discount"));

                ReportParameter[] p = new ReportParameter[8];
                p[0] = new ReportParameter("StartDate", Convert.ToDateTime(startdate).ToString("MMM/dd/yyyy"));
                p[1] = new ReportParameter("EndDate", Convert.ToDateTime(enddate).ToString("MMM/dd/yyyy"));
                p[2] = new ReportParameter("Total", (total).ToString());
                p[3] = new ReportParameter("expense", expenseAmount.ToString());
                p[4] = new ReportParameter("NET", (total - discount).ToString());
                p[5] = new ReportParameter("Discount", (discount).ToString());
                p[6] = new ReportParameter("profit", Convert.ToString(q.Sum(x=>x.Profit)));
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
                DataTable dtCust = DALAccess.ExecuteDataTable("select * from customer order by id asc");
                ddlcustomer.ValueMember = "ID";
                ddlcustomer.DisplayMember = "Name";
                ddlcustomer.DataSource = dtCust;
            }
            catch (Exception)
            {
            }
        }

        private void btnOpenCustomerDialog_Click(object sender, EventArgs e)
        {
            frmCustomerDialog frm = new frmCustomerDialog();
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                ddlcustomer.SelectedValue = frm.ItemID;                
            }
        }
    }
}
