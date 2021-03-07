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
    public partial class frmAddCustomer : Form
    {
        public int glbItemID = -1;
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (glbItemID == -1)//Save new
            {
                DataTable dtduplicate = DALAccess.ExecuteDataTable("select * from customer where mobile='" + txtmobile.Text + "' and mobile<>'' ");
                if (dtduplicate == null || dtduplicate.Rows.Count == 0)
                {
                    string query = "insert into customer (Name,email,mobile,address,CNIC) values ('" + txtname.Text + "','" + txtemail.Text + "','" + txtmobile.Text + "','" + txtaddress.Text + "','"+txtCNIC.Text+"')";
                    int ItemID = Convert.ToInt32(DALAccess.ExecuteNonQuery(query));

                    MessageBox.Show("Customer Added Successfully");
                }
                else
                    MessageBox.Show("Duplicate found");
            }
            else // update
            {
                string query = "update customer set Name='" + txtname.Text + "',email='" + txtemail.Text + "',mobile='" + txtmobile.Text + "',address='" + txtaddress.Text + "',CNIC='"+txtCNIC.Text+"' where ID=" + glbItemID;
                DALAccess.ExecuteNonQuery(query);
                glbItemID = -1;
                MessageBox.Show("Customer Updated Successfully");
            }

            txtaddress.Text = "";
            txtname.Text = "";
            txtmobile.Text = "";
            txtemail.Text = "";
            txtCNIC.Text = "";

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
                DataTable dt = DALAccess.ExecuteDataTable("select * from customer");
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
                    txtCNIC.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["CNIC"].Value);
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
