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
    public partial class frmAddItemfrv : Form
    {
        public int glbItemID = -1;
        public frmAddItemfrv()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtTotalPacksCatron.Text == "")
                txtTotalPacksCatron.Text = "1";

            if (glbItemID == -1)//Save new
            {
                DataTable dtduplicate = DALAccess.ExecuteDataTable("select * from item where Name='" + txtname.Text + "'");
                if (dtduplicate == null || dtduplicate.Rows.Count == 0)
                {
                    string query = "insert into item (Name,Saleprice,purchaseprice,barcode,CreationDate,itemcategoryid,bulkitems,[gst%]) values ('" + txtname.Text + "'," + txtsaleprice.Text + "," + txtpurchaseprice.Text + ",'" + txtbarcode.Text + "','" + DateTime.Now + "',"+ddlitemcategory.SelectedValue+","+txtTotalPacksCatron.Text+","+textBoxGST.Text+")";
                    int ItemID = Convert.ToInt32(DALAccess.ExecuteNonQuery(query));

                    MessageBox.Show("Data Saved Successfully");
                }
                else
                    MessageBox.Show("Duplicate item found");
            }
            else // update
            {
                string query = "update item set [gst%]="+textBoxGST.Text+", Name='" + txtname.Text + "',Saleprice=" + txtsaleprice.Text + ",purchaseprice=" + txtpurchaseprice.Text + ",barcode='" + txtbarcode.Text + "',ModifiedDate='" + DateTime.Now + "',itemcategoryid="+ddlitemcategory.SelectedValue+",bulkitems="+txtTotalPacksCatron.Text+" where ID=" + glbItemID;
                DALAccess.ExecuteNonQuery(query);
                glbItemID = -1;
                MessageBox.Show("Data Updated Successfully");
            }

            txtbarcode.Text = "";
            txtname.Text = "";
            txtpurchaseprice.Text = "";
            txtsaleprice.Text = "";
            ddlitemcategory.SelectedIndex = 0;
            txtTotalPacksCatron.Text = "";

            BindGrid();
        }

        private void frmAddItem_Load(object sender, EventArgs e)
        {
            try
            {
                dgmain.AutoGenerateColumns = false;
                BindGrid();


                DataTable dt = DALAccess.ExecuteDataTable("select * from itemCategory");
                ddlitemcategory.ValueMember = "ID";
                ddlitemcategory.DisplayMember = "Name";
                ddlitemcategory.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        public void BindGrid()
        {
            try
            {
                DataTable dt = DALAccess.ExecuteDataTable("select i.id,i.name,i.purchaseprice,i.saleprice,i.barcode,i.creationdate,ic.name as itemcategory,i.bulkitems,i.[gst%] as gst from item i left outer join itemcategory ic on i.itemcategoryid=ic.id");
                dgmain.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        private void dgmain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == dgmain.Columns["Delete"].Index)
                    {
                        int id= Convert.ToInt32(dgmain.Rows[e.RowIndex].Cells["ID"].Value);
                        DALAccess.ExecuteNonQuery("delete from item where id="+id);
                        MessageBox.Show("deleted.");
                        BindGrid();
                    }
                    else
                    {
                        btnsave.Text = "Update";
                        glbItemID = Convert.ToInt32(dgmain.Rows[e.RowIndex].Cells["ID"].Value);
                        txtname.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["ItemName"].Value);
                        txtpurchaseprice.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["PurchasePrice"].Value);
                        txtsaleprice.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["SalePrice"].Value);
                        txtbarcode.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["BarCode"].Value);
                        ddlitemcategory.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["ItemCategory"].Value);
                        txtTotalPacksCatron.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["BulkItems"].Value);
                        textBoxGST.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["gst"].Value);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Save";
            glbItemID = -1;
        }

        private void btnGenerateBarCode_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemBarcode f = new frmItemBarcode();
                f.Show();
            }
            catch (Exception)
            {

            }
        }


    }
}
