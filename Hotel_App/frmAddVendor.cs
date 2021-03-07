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
    public partial class frmAddVendor : Form
    {
        public int glbItemID = -1;
        public frmAddVendor()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (glbItemID == -1)//Save new
            {
                DataTable dtduplicate = DALAccess.ExecuteDataTable("select * from vendor where mobile='" + txtmobile.Text + "'");
                if (dtduplicate == null || dtduplicate.Rows.Count == 0)
                {
                    string query = "insert into vendor (Name,email,mobile,address,IsFiler) values ('" + txtname.Text + "','" + txtemail.Text + "','" + txtmobile.Text + "','" + txtaddress.Text + "',"+chkIsFiler.Checked+")";
                    int ItemID = Convert.ToInt32(DALAccess.ExecuteNonQuery(query));

                    //DALAccess.ExecuteNonQuery("insert into itemstock (itemid,stock,CreationDate) values (" + ItemID + ",1000,'" + DateTime.Now + "') ");
                }
                else
                    MessageBox.Show("Duplicate found");
            }
            else // update
            {
                string query = "update vendor set IsFiler=" + chkIsFiler.Checked + ", Name='" + txtname.Text + "',email='" + txtemail.Text + "',mobile='" + txtmobile.Text + "',address='" + txtaddress.Text + "' where ID=" + glbItemID;
                DALAccess.ExecuteNonQuery(query);
                glbItemID = -1;
            }

            txtaddress.Text = "";
            txtname.Text = "";
            txtmobile.Text = "";
            txtemail.Text = "";

            BindGrid();
        }

        private void frmAddItem_Load(object sender, EventArgs e)
        {
            try
            {
                dgmain.AutoGenerateColumns = false;
                BindGrid();
            }
            catch (Exception)
            {
            }
        }

        public void BindGrid()
        {
            try
            {
                DataTable dt = DALAccess.ExecuteDataTable("select * from vendor");
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
                    btnsave.Text = "Update";
                    glbItemID = Convert.ToInt32(dgmain.Rows[e.RowIndex].Cells["ID"].Value);
                    txtname.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["VendorName"].Value);
                    txtemail.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["email"].Value);
                    txtmobile.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["mobile"].Value);
                    txtaddress.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["Address"].Value);
                    chkIsFiler.Checked = Convert.ToBoolean(dgmain.Rows[e.RowIndex].Cells["IsFiler"].Value);
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
    }
}
