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
    public partial class frmAddVendorInvoices : Form
    {

        public int glbItemID = -1;
        public DataTable glbdt;
        public frmAddVendorInvoices()
        {
            InitializeComponent();
        }

        private void frmAddItemStock_Load(object sender, EventArgs e)
        {
            try
            {
                dgmain.AutoGenerateColumns = false;
                BindItemDropDown();
                BindGrid();
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
                DataTable  dt = DALAccess.ExecuteDataTable("select * from Vendor order by Name asc");
                ddlvendor.DisplayMember = "Name";
                ddlvendor.ValueMember = "ID";
                ddlvendor.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                //int VendorID = Convert.ToInt32(ddlvendor.SelectedValue);
                //int AmountPaid= Convert.ToInt32(txtamountpaid.Text);
                //int Balance = Convert.ToInt32(txtbalance.Text);

                //DataTable dtItem= DALAccess.ExecuteDataTable("select * from itemstock where itemid="+ItemID);
                if (glbItemID!=-1) // Update
                {
                    //DALAccess.ExecuteNonQuery("update vendorpayment set amount="+ AmountPaid+",Modifiedat='"+DateTime.Now+"',vendorid="+ddlvendor.SelectedValue+",balance="+Balance+",modifiedby="+LoggedInUser.UserID+" where id="+glbItemID);
                    //txtamountpaid.Text = "0";
                }
                else // add new
                {
                    //DALAccess.ExecuteNonQuery("insert into vendorpayment (vendorid,amount,balance,Createdat,createdby,paiddate) values ("+VendorID+","+AmountPaid+","+Balance+",'"+DateTime.Now+ "',"+LoggedInUser.UserID+",'" + DateTime.Now + "') ");
                    //txtamountpaid.Text = "0";
                }
                //BindGrid(txtsearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void BindGrid()
        {
            try
            {
                //if (name == "")
                // name = "1=1";
                //else
                //  name = " vendor.Name like '%" + txtsearch.Text + "%'";
                int vendorid = Convert.ToInt32(ddlvendor.SelectedValue);

                DataTable dt = DALAccess.ExecuteDataTable(@"select vendorpayment.id,vendor.name as vendorname,vendorpayment.amounttopay,vendorpayment.balance,vendorpayment.amount,vendorpayment.paiddate,vendorpayment.createdat from vendorpayment inner join vendor on vendor.id=vendorpayment.vendorid
                where vendorpayment.vendorid= " + vendorid + @"
                    ");
                
                dgmain.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //BindGrid(txtsearch.Text);
            }
            catch (Exception)
            {
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

            int vendorid = Convert.ToInt32(ddlvendor.SelectedValue);
            DataTable dt = DALAccess.ExecuteDataTable("select vendor.name,vendorpayment.amounttopay,vendorpayment.balance,vendorpayment.amount,vendorpayment.paiddate from vendorpayment inner join vendor on vendor.id=vendorpayment.vendorid where vendor.id=" + vendorid);

            ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = "../../rptvendorpayment.rdlc";
            reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
            reportViewer1.LocalReport.EnableExternalImages = true;


            ReportParameter[] p = new ReportParameter[4];
            p[0] = new ReportParameter("Name", ddlvendor.Text);

            var totaltopay = dt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Amounttopay")));
            var totalpaid = dt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("amount")));

            p[1] = new ReportParameter("totaltopay",totaltopay.ToString() );
            p[2] = new ReportParameter("totalpaid", totalpaid.ToString() );
            p[3] = new ReportParameter("balance", (totaltopay-totalpaid).ToString());


            try
            {
                reportViewer1.LocalReport.SetParameters(p);
            }
            catch (Exception ex)
            {

                MessageBox.Show("set: " + ex.Message);
            }

            //reportViewer1.LocalReport.Refresh();

            //reportViewer1.RefreshReport();
            //reportViewer1.Visible = true;

            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

            //System.Threading.Thread.Sleep(1000);
        }
        private void dgmain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    //btnsave.Text = "Update";
                    glbItemID = Convert.ToInt32(dgmain.Rows[e.RowIndex].Cells["ID"].Value);
                    //ddlvendor.SelectedValue = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["gvVendorID"].Value);
                    //txtamountpaid.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["amountpaid"].Value);                    
                    //txtbalance.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["balance"].Value);
                    //txtamounttopay.Text = (Convert.ToInt32(txtamountpaid.Text)+ Convert.ToInt32(txtbalance.Text)).ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            //btnsave.Text = "Save";
            glbItemID = -1;
        }

        private void txtamounttopay_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
        }

        private void CalculateAmount()
        {
            //if (txtamounttopay.Text == "")
               // txtamounttopay.Text = "0";

            //if (txtamountpaid.Text == "")
              //  txtamountpaid.Text = "0";


            //int amounttopay=Convert.ToInt32(txtamounttopay.Text);
            //int amountpaid = Convert.ToInt32(txtamountpaid.Text);

           // txtbalance.Text = (amounttopay - amountpaid).ToString();
        }

        private void txtamountpaid_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
