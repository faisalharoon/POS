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
    public partial class frmAddCustomerPayment : Form
    {

        public int glbItemID = -1;
        public DataTable glbdt;
        public frmAddCustomerPayment()
        {
            InitializeComponent();
        }

        private void frmAddItemStock_Load(object sender, EventArgs e)
        {
            try
            {
                dgmain.AutoGenerateColumns = false;
                BindItemDropDown();
                BindGrid(txtsearch.Text);
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
                DataTable dt = DALAccess.ExecuteDataTable("select * from customer order by Name asc");

                DataRow dr = dt.NewRow();
                dr["Name"] = "---Select---";
                dr["ID"] = "0";
                dt.Rows.InsertAt(dr,0);


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
                int VendorID = Convert.ToInt32(ddlvendor.SelectedValue);
                int AmountPaid = Convert.ToInt32(txtamountpaid.Text);
                int Balance = Convert.ToInt32(txtbalance.Text);

                //DataTable dtItem= DALAccess.ExecuteDataTable("select * from itemstock where itemid="+ItemID);
                if (glbItemID != -1) // Update
                {
                    DALAccess.ExecuteNonQuery("update customerpayment set amount=" + AmountPaid + ",Modifiedat='" + DateTime.Now + "',customerid=" + ddlvendor.SelectedValue + ",balance=" + Balance + ",modifiedby=" + LoggedInUser.UserID + " where id=" + glbItemID);
                    txtamountpaid.Text = "0";
                    btncancel_Click(sender,e);
                }
                else // add new
                {
                    //DALAccess.ExecuteNonQuery("insert into customerpayment (customerid,amount,amounttopay,balance,Createdat,createdby,paiddate) values (" + VendorID + "," + AmountPaid + "," + txtamounttopay.Text + "," + Balance + ",'" + DateTime.Now + "'," + LoggedInUser.UserID + ",'" + DateTime.Now + "') ");
                    DALAccess.ExecuteNonQuery("insert into customerpayment (customerid,amount,amounttopay,balance,Createdat,createdby,paiddate) values (" + VendorID + "," + AmountPaid + ",0,0,'" + DateTime.Now + "'," + LoggedInUser.UserID + ",'" + DateTime.Now + "') ");
                    txtamountpaid.Text = "0";
                }
                BindGrid(txtsearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void BindGrid(string name)
        {
            try
            {
                if (name == "")
                    name = "1=1";
                else
                    name = " customer.Name like '%" + txtsearch.Text + "%'";

                DataTable dt = DALAccess.ExecuteDataTable(@"select customer.Name as VendorName,customerpayment.ID,customerpayment.amount,customerpayment.balance,
                customerpayment.createdat,customerpayment.customerid as vendorid,customerpayment.amounttopay
                    from (customer inner join customerpayment on customer.ID=customerpayment.customerid)
                    where " + name + @"
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
                BindGrid(txtsearch.Text);
            }
            catch (Exception)
            {
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

            int vendorid = Convert.ToInt32(ddlvendor.SelectedValue);
            DataTable dt = DALAccess.ExecuteDataTable("select customer.name,customerpayment.amounttopay,customerpayment.balance,customerpayment.amount,customerpayment.paiddate from customerpayment inner join customer on customer.id=customerpayment.customerid where customer.id=" + vendorid);

            ReportDataSource reportDSDetail = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = "../../rptcustomerpayment.rdlc";
            reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
            reportViewer1.LocalReport.EnableExternalImages = true;


            ReportParameter[] p = new ReportParameter[4];
            p[0] = new ReportParameter("Name", ddlvendor.Text);

            var totaltopay = dt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("Amounttopay")));
            var totalpaid = dt.AsEnumerable().Sum(x => Convert.ToDouble(x.Field<object>("amount")));

            p[1] = new ReportParameter("totaltopay", totaltopay.ToString());
            p[2] = new ReportParameter("totalpaid", totalpaid.ToString());
            p[3] = new ReportParameter("balance", (totaltopay - totalpaid).ToString());


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
                    btnsave.Text = "Update";
                    glbItemID = Convert.ToInt32(dgmain.Rows[e.RowIndex].Cells["ID"].Value);
                    ddlvendor.SelectedValue = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["gvVendorID"].Value);
                    txtamountpaid.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["amountpaid"].Value);
                    txtbalance.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["balance"].Value);
                    //txtamounttopay.Text = (Convert.ToInt32(txtamountpaid.Text) + Convert.ToInt32(txtbalance.Text)).ToString();
                    txtamounttopay.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["amounttopay"].Value);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtamountpaid.Text = "0";
            txtbalance.Text = "0";
            txtamounttopay.Text = "0";

            btnsave.Text = "Save";
            glbItemID = -1;
        }

        private void txtamounttopay_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
        }

        private void CalculateAmount()
        {
            if (txtamounttopay.Text == "")
                txtamounttopay.Text = "0";

            if (txtamountpaid.Text == "")
                txtamountpaid.Text = "0";


            int amounttopay = Convert.ToInt32(txtamounttopay.Text);
            int amountpaid = Convert.ToInt32(txtamountpaid.Text);

            txtbalance.Text = (amounttopay - amountpaid).ToString();
        }

        private void txtamountpaid_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
        }

        private void btnCustomerProfit_Click(object sender, EventArgs e)
        {
            int vendorid = Convert.ToInt32(ddlvendor.SelectedValue);

            frmDistributorProfit f = new frmDistributorProfit();
            f.customerid = vendorid;
            f.customerName = ddlvendor.GetItemText(ddlvendor.SelectedItem); 
            f.Show();
        }

        private void ddlvendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtamountpaid.Text = "0";
                txtamounttopay.Text = "0";
                txtbalance.Text = "0";

                int vendorid = Convert.ToInt32(ddlvendor.SelectedValue);

                string query = @"select 
                            sum(customerpayment.amounttopay) as amounttopay
                            ,sum(customerpayment.amounttopay) as Price
                            ,sum(customerpayment.balance) as balance
                            ,sum(customerpayment.amount) as amount
                            ,sum(customerpayment.amount) as Total
                            ,sum((customerpayment.amounttopay - customerpayment.amount)) as balance2
                            from customerpayment inner join customer on customer.id=customerpayment.customerid where customerpayment.customerid=" + vendorid;

                DataTable dt = DALAccess.ExecuteDataTable(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtamounttopay.Text = Convert.ToString(dt.Rows[0]["balance2"]);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
