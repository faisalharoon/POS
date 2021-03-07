using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
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
    public partial class frmInvoicePrint : Form
    {

        public int glbItemStockID = -1;
        public DataTable glbdt;


        public int VendorID = -1;
        public string VendorName = "";

        public frmInvoicePrint()
        {
            InitializeComponent();
        }

        private void frmAddItemStock_Load(object sender, EventArgs e)
        {
            try
            {
                BindGrid("");
                PrintClicked();
            }
            catch (Exception)
            {
            }
            this.reportViewer1.RefreshReport();
        }

        private void BindItemDropDown()
        {
            try
            {
                DataTable dt = DALAccess.ExecuteDataTable("select * from Item order by Name asc");
                


                dt = DALAccess.ExecuteDataTable("select * from Vendor order by Name asc");
                
            }
            catch (Exception)
            {
            }
        }        

        public void BindGrid(string name)
        {
            try
            {
                DataTable dtstock = DALAccess.ExecuteDataTable(@"select itemstock.ID,item.Name,itemstock.stock as Quantity,itemstock.Amount,itemstock.SaleTax,itemstock.WithholdingTax,itemstock.InvoiceNo from (itemstock inner join item on item.id=itemstock.itemid) where
                    itemstock.id="+glbItemStockID);

                

                glbdt =dtstock;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintClicked();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintClicked()
        {
            try
            {

                reportViewer1.LocalReport.DataSources.Clear();

                var q = glbdt.AsEnumerable().Select(x => new
                {
                    Name = x.Field<object>("Name"),
                    ID = x.Field<object>("ID"),
                    Quantity = Convert.ToDouble(x.Field<object>("Quantity")),
                    SaleTax = Convert.ToDouble(x.Field<object>("SaleTax")),
                    WithHoldingTax = Convert.ToDouble(x.Field<object>("WithHoldingTax")),
                    Amount = Convert.ToDouble(x.Field<object>("Amount")),
                    Total = Convert.ToDouble(x.Field<object>("Amount")) + Convert.ToDouble(x.Field<object>("WithHoldingTax")) + Convert.ToDouble(x.Field<object>("SaleTax")),
                    InvoiceNo = Convert.ToString(x.Field<object>("InvoiceNo"))
                }).ToList();

                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", q);
                reportViewer1.LocalReport.ReportPath = "../../rptInvoice.rdlc";
                reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                reportViewer1.LocalReport.EnableExternalImages = true;


                

                ReportParameter[] p = new ReportParameter[9];
                p[0] = new ReportParameter("Date", DateTime.Now.ToString());                

                p[1] = new ReportParameter("CompanyName", XmlExtension.GetSetupValues().CompanyName);
                p[2] = new ReportParameter("CompanyAddress", XmlExtension.GetSetupValues().CompanyAddress);
                p[3] = new ReportParameter("ST", q.Sum(x=>x.SaleTax).ToString());
                p[4] = new ReportParameter("WithHolding",q.Sum(x=>x.WithHoldingTax).ToString());
                p[5] = new ReportParameter("Total", q.Sum(x=>x.Amount).ToString());
                p[6] = new ReportParameter("Net", q.Sum(x => x.Total).ToString());
                p[7] = new ReportParameter("InvoiceNo", q.FirstOrDefault().InvoiceNo);
                p[8] = new ReportParameter("Vendor", VendorName);


                try
                {
                    reportViewer1.LocalReport.SetParameters(p);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("set: " + ex.Message);
                }


                reportViewer1.LocalReport.Refresh();

                reportViewer1.RefreshReport();
                reportViewer1.Visible = true;

                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();

                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
