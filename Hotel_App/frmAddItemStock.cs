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
    public partial class frmAddItemStock : Form
    {

        public int glbItemID = -1;
        public object glbdt;

        public double glbWithHoldingTax = 0;
        public double glbST = 0;
        public double glbItemPurchasePrice = 0;


        public double glbtotalsale = 0;
        public double glbtotalpurchase =0;

        public frmAddItemStock()
        {
            InitializeComponent();
        }

        private void frmAddItemStock_Load(object sender, EventArgs e)
        {
            try
            {
                BindGrid("");
                print();
            }
            catch (Exception)
            {
            }
            this.reportViewer1.RefreshReport();
        }


        public void BindGrid(string name)
        {
            try
            {
                if (name == "")
                    name = "1=1";
                //else
                   // name = " i.Name like '%" + txtsearch.Text + "%' or v.Name like '%" + txtsearch.Text + "%'";

                DataTable dt = DALAccess.ExecuteDataTable(@"select i.Name,s.ID,s.Stock,s.Stock as Quantity,s.Amount,
                s.CreationDate,i.ID as ItemID,v.name as vendor ,s.InvoiceNo
                    from (itemstock s inner join item i on i.ID=s.ItemID)
                    left outer join vendor v on v.id=s.vendorid where " + name + @"
                    ");


                DataTable dtstock = DALAccess.ExecuteDataTable(@"select Item.Name,Item.ID
                ,(select sum(quantity) from saledetail where itemid=Item.ID) as Used
                ,sum(ItemStock.stock) as Quantity
                ,Max(item.SalePrice) as SalePrice
                ,max(item.PurchasePrice) as PurchasePrice
                    from
                    (Item INNER JOIN ItemStock ON Item.ID = ItemStock.ItemID) 
                    group by Item.ID,Item.Name             
                    ");

                var q = dtstock.AsEnumerable().Select(x => new
                {
                    Name = x.Field<object>("Name"),
                    ID = x.Field<object>("ID"),
                    Quantity = Convert.ToDouble(x.Field<object>("Quantity")) - Convert.ToDouble(x.Field<object>("Used")),
                    Total = Convert.ToDouble(x.Field<object>("SalePrice")),
                    Price = Convert.ToDouble(x.Field<object>("PurchasePrice")),
                }).Select(x=>new {
                    x.Name,
                    x.ID,
                    x.Quantity,
                    Total=x.Quantity*x.Total,
                    Price=x.Quantity*x.Price
                }).ToList();

                glbdt = q;
                glbtotalpurchase = q.Sum(x=>x.Price);
                glbtotalsale =q.Sum(x=>x.Total);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void print() {
            try
            {
               

                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", glbdt);
                reportViewer1.LocalReport.ReportPath = "../../rptstock.rdlc";
                reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                reportViewer1.LocalReport.EnableExternalImages = true;

                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
                reportViewer1.Visible = true;



                ReportParameter[] p = new ReportParameter[2];
                p[0] = new ReportParameter("TotalSale", Convert.ToString(glbtotalsale));
                p[1] = new ReportParameter("TotalPurchase", Convert.ToString(glbtotalpurchase));


                //System.Threading.Thread.Sleep(1000);

                try
                {
                    reportViewer1.LocalReport.SetParameters(p);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("set: " + ex.Message);
                }



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
