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
    public partial class frmAddItemCategory : Form
    {
        public int glbItemID = -1;
        public frmAddItemCategory()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (glbItemID == -1)//Save new
            {
                DataTable dtduplicate = DALAccess.ExecuteDataTable("select * from itemCategory where Name='" + txtname.Text + "'");
                if (dtduplicate == null || dtduplicate.Rows.Count == 0)
                {
                    string query = "insert into itemCategory (Name,DistributorProfitPercentage) values ('" + txtname.Text + "',"+txtDistributorPercentage.Text+")";
                    int ItemID = Convert.ToInt32(DALAccess.ExecuteNonQuery(query));

                    //DALAccess.ExecuteNonQuery("insert into itemstock (itemid,stock,CreationDate) values (" + ItemID + ",1000,'" + DateTime.Now + "') ");
                }
                else
                    MessageBox.Show("Duplicate found");
            }
            else // update
            {
                string query = "update itemCategory set Name='" + txtname.Text + "',DistributorProfitPercentage="+txtDistributorPercentage.Text+" where ID=" + glbItemID;
                DALAccess.ExecuteNonQuery(query);
                glbItemID = -1;
            }

            
            txtname.Text = "";
            
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
                DataTable dt = DALAccess.ExecuteDataTable("select * from itemCategory");
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
                    glbItemID = Convert.ToInt32(dgmain.Rows[e.RowIndex].Cells[0].Value);
                    txtname.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells[1].Value);
                    txtDistributorPercentage.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells[2].Value);
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
