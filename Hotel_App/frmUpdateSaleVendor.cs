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
    public partial class frmUpdateSaleVendor : Form
    {
        public int glbSaleID = -1;
        public int glbSaleDetailID = -1;
        public int glbItemID = -1;
        public frmUpdateSaleVendor()
        {
            InitializeComponent();
        }

        private void frmUpdateSale_Load(object sender, EventArgs e)
        {
            try
            {
                dgsale.AutoGenerateColumns = false;
                dgsaledetail.AutoGenerateColumns = false;

                BindSale();
                LoadCustomerDropDown();
            }
            catch (Exception)
            {
            }
        }

        private void LoadCustomerDropDown()
        {
            try
            {
                DataTable dtCust = DALAccess.ExecuteDataTable("select * from vendor order by name asc");
                ddlcustomer.ValueMember = "ID";
                ddlcustomer.DisplayMember = "Name";
                ddlcustomer.DataSource = dtCust;
            }
            catch (Exception)
            {
            }
        }

        private void BindSale()
        {
            try
            {

                string where = " 1=1";

                if (txtorderno.Text != "")
                {
                    where = " itemstockmaster.orderno="+ txtorderno.Text;
                    //where += " and Format([itemstockmaster.CreationDate],'MM/DD/YYYY')='" + Convert.ToDateTime(txtorderdate.Text).ToString("MM/dd/yyyy")+"'";
                }               

                DataTable dt = DALAccess.ExecuteDataTable(@"select itemstockmaster.id,itemstockmaster.discountpercentage,vendor.name as customername
                    ,itemstockmaster.orderno,itemstockmaster.creationdate,itemstockmaster.discount,itemstockmaster.total,itemstockmaster.addedby                        
                    from (itemstockmaster inner join vendor on itemstockmaster.vendorid=vendor.id) where " + where + " order by itemstockmaster.id desc");
                dgsale.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        private void dgsale_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BindSaleDetails(int SaleID)
        {
            try
            {

                DataTable dtsale = DALAccess.ExecuteDataTable("select * from itemstockmaster where id=" + SaleID);

                ddlcustomer.SelectedValue = Convert.ToString(dtsale.Rows[0]["vendorid"]);
                txtdiscount.Text = Convert.ToString(dtsale.Rows[0]["Discount"]);
                txtamount.Text = Convert.ToString(dtsale.Rows[0]["Total"]);

                glbSaleID = SaleID;

                DataTable dt = DALAccess.ExecuteDataTable(@"select sd.ID,i.Name as ItemName,sd.purchaseprice as price,sd.stock as quantity,sd.creationdate,sd.Total,i.ID as ItemID from 
                            (itemstock sd inner join itemstockmaster s on s.id=sd.itemstockmasterid)
                            inner join item i on i.id=sd.itemid
                            where sd.itemstockmasterid=" + SaleID);
                dgsaledetail.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgsale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //BindSaleDetails(e.RowIndex);
            }
            catch (Exception)
            {
            }
        }

        private void btnsaledelete_Click(object sender, EventArgs e)
        {
            if (glbSaleID != -1)
            {
                frmConfirmDialog f = new frmConfirmDialog();
                f.ShowDialog();
                if (f.confrmDelete)
                {

                    DataTable dtsaledetail= DALAccess.ExecuteDataTable("select * from itemstock where itemstockmasterid=" + glbSaleID);

                    DALAccess.ExecuteNonQuery("delete from itemstock where itemstockmasterid=" + glbSaleID);
                    DALAccess.ExecuteNonQuery("delete from itemstockmaster where id=" + glbSaleID);


                    if (dtsaledetail != null && dtsaledetail.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtsaledetail.Rows)
                        {
                            int itemid = Convert.ToInt32(dr["itemid"]);
                            int quantity = Convert.ToInt32(dr["quantity"]);

                            //DALAccess.ExecuteNonQuery("update itemstock set stock=stock+" + quantity+" where itemid="+itemid);
                        }
                    }

                    dgsaledetail.DataSource = null;

                    BindSale();
                    glbSaleID = -1;
                }
            }
        }

        private void btnsaleUpdate_Click(object sender, EventArgs e)
        {
            UpdateSaleData();
        }

        private void UpdateSaleData()
        {
            try
            {
                //double discountAmount = Math.Round((Convert.ToDouble(txtamount.Text) * Convert.ToDouble(txtdiscount.Text)) / 100, 0);
                double discountAmount = (Convert.ToDouble(txtdiscount.Text));
                double total = Convert.ToDouble(txtamount.Text);

                double STPercentage = Convert.ToDouble(XmlExtension.DeSerialize().CustomerSalesTax);
                double ST = Math.Round((((total- discountAmount) * STPercentage) / 100), 0);

                string query = "update itemstockmaster set SalesTax=" + ST+", vendorname='" + ddlcustomer.Text + "',ModifiedDate='" + DateTime.Now + "',ModifiedBy=" + LoggedInUser.UserID + ",Discount=" + discountAmount + ",Total=" + total + ",vendorid="+ddlcustomer.SelectedValue+" where ID=" + glbSaleID;
                DALAccess.ExecuteNonQuery(query);
                BindSale();
            }
            catch (Exception)
            {
            }
        }

        private void dgsaledetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgsaledetail.Columns["Delete"].Index)// delete button clicked
                {
                    frmConfirmDialog f = new frmConfirmDialog();
                    f.ShowDialog();
                    if (f.confrmDelete)
                    {
                        int saledetailid = Convert.ToInt32(dgsaledetail.Rows[e.RowIndex].Cells["SaleDetailID"].Value);
                        int total = Convert.ToInt32(dgsaledetail.Rows[e.RowIndex].Cells["Total"].Value);
                        int quantity = Convert.ToInt32(dgsaledetail.Rows[e.RowIndex].Cells["Quantity"].Value);
                        int DetailGridItemID = Convert.ToInt32(dgsaledetail.Rows[e.RowIndex].Cells["DetailItemID"].Value);

                        double STPercentage = Convert.ToDouble(XmlExtension.DeSerialize().CustomerSalesTax);
                        double ST = Math.Round(((total * STPercentage) / 100), 0);

                        DALAccess.ExecuteNonQuery("delete from saledetail where id=" + saledetailid);
                        DALAccess.ExecuteNonQuery("update sale set total=total-" + total + ",SalesTax=SalesTax-"+ST+" where id=" + glbSaleID);
                        //DALAccess.ExecuteNonQuery("update itemstock set quantity=quantity+" + quantity + " where itemid=" + DetailGridItemID);

                        //dgsaledetail.DataSource = null;
                        BindSaleDetails(glbSaleID);
                    }
                }
                else
                {
                    int saledetailid = Convert.ToInt32(dgsaledetail.Rows[e.RowIndex].Cells["SaleDetailID"].Value);
                    int itemID = Convert.ToInt32(dgsaledetail.Rows[e.RowIndex].Cells["DetailItemID"].Value);
                    txtItemName.Text = Convert.ToString(dgsaledetail.Rows[e.RowIndex].Cells["ItemName"].Value);
                    txtitemquantity.Text = Convert.ToString(dgsaledetail.Rows[e.RowIndex].Cells["Quantity"].Value);
                    txtitemunitprice.Text = Convert.ToString(dgsaledetail.Rows[e.RowIndex].Cells["Price"].Value);

                    glbSaleDetailID = saledetailid;
                    glbItemID = itemID;

                    btnupdateItem.Text = "Update";
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnupdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (glbSaleDetailID != -1)
                {
                    double quantity = Convert.ToDouble(txtitemquantity.Text);
                    double unitprice = Convert.ToDouble(txtitemunitprice.Text);
                    double total = quantity * unitprice;

                    DALAccess.ExecuteNonQuery("update itemstock set purchasePrice=" + unitprice + ",stock=" + quantity + ",Total=" + total + " where ID=" + glbSaleDetailID);


                    DataTable dtsale = DALAccess.ExecuteDataTable("select sum(total) from itemstock where itemstockmasterid=" + glbSaleID);

                    if (dtsale != null && dtsale.Rows.Count > 0)
                    {
                        double saletotal = Convert.ToDouble(dtsale.Rows[0][0]);
                        double STPercentage = Convert.ToDouble(XmlExtension.DeSerialize().CustomerSalesTax);
                        double ST=Math.Round(((saletotal* STPercentage)/100),0);
                        DALAccess.ExecuteNonQuery("update itemstockmaster set SalesTax="+ST+", total=" + saletotal + ",ModifiedBy=" + LoggedInUser.UserID + ",ModifiedDate='" + DateTime.Now + "' where id=" + glbSaleID);
                    }

                    dgsaledetail.DataSource = null;
                    BindSale();
                    MessageBox.Show("Item updated Successfully");
                }
                else
                {
                    double quantity = Convert.ToDouble(txtitemquantity.Text);
                    double unitprice = Convert.ToDouble(txtitemunitprice.Text);
                    double total = quantity * unitprice;

                    DALAccess.ExecuteNonQuery("insert into itemstock (itemid,itemstockmasterid,purchaseprice,stock,total,creationdate) values ("+glbItemID+","+glbSaleID+","+unitprice+","+quantity+","+total+",'"+DateTime.Now+"') ");


                    DataTable dtsale = DALAccess.ExecuteDataTable("select sum(total) from itemstock where saleid=" + glbSaleID);
                    DataTable dtdiscountPercentage = DALAccess.ExecuteDataTable("select discountpercentage from itemstock where saleid=" + glbSaleID);

                    if (dtsale != null && dtsale.Rows.Count > 0)
                    {
                        double saletotal = Convert.ToDouble(dtsale.Rows[0][0]);
                        double discountPercentage = Convert.ToDouble(dtdiscountPercentage.Rows[0][0]);

                        double discountamount = Math.Round((saletotal * discountPercentage) / 100,0);

                        DALAccess.ExecuteNonQuery("update itemstockmaster set total=" + saletotal + ",discount="+discountamount+",ModifiedBy=" + LoggedInUser.UserID + ",ModifiedDate='" + DateTime.Now + "' where id=" + glbSaleID);
                    }

                    dgsaledetail.DataSource = null;
                    BindSale();
                    MessageBox.Show("Item added Successfully");
                }

            }
            catch (Exception)
            {
            }
        }

        private void dgsale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgsale.Columns["Print"].Index == e.ColumnIndex)
                {
                    int SaleID = Convert.ToInt32(dgsale.Rows[e.RowIndex].Cells["ID"].Value);
                    frmduplicateBillVendor f = new frmduplicateBillVendor();
                    f.glbSaleID =SaleID;
                    f.Show();
                }
                else
                {
                    int SaleID = Convert.ToInt32(dgsale.Rows[e.RowIndex].Cells["ID"].Value);
                    glbSaleID = SaleID;
                    BindSaleDetails(SaleID);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnsearchorder_Click(object sender, EventArgs e)
        {
            try
            {
                BindSale();
            }
            catch (Exception)
            {
            }
        }

        private void btnshowall_Click(object sender, EventArgs e)
        {
            try
            {
                txtorderno.Text = "";
                BindSale();
            }
            catch (Exception)
            {
            }
        }

        private void btnsearchitem_Click(object sender, EventArgs e)
        {
            frmItem frm = new frmItem();
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtItemName.Text = frm.ItemName;
                glbItemID = Convert.ToInt32(frm.ItemID);
                txtitemunitprice.Text = frm.SalePrice;
            }
        }

        private void btnCancelItemDetail_Click(object sender, EventArgs e)
        {
            glbSaleDetailID = -1;
            btnupdateItem.Text = "Add New";
        }
    }
}
