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
    public partial class frmAddgameType : Form
    {
        public int glbItemID = -1;
        public frmAddgameType()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (glbItemID == -1)//Save new
            {
                DataTable dtduplicate= DALAccess.ExecuteDataTable("select * from gametype where gameName='"+txtname.Text+"'");
                if (dtduplicate == null || dtduplicate.Rows.Count == 0)
                {
                    string query = "insert into gametype (gameName,amount,amountstudent,isactive) values ('" + txtname.Text + "'," + txtstudentprice.Text + "," + txtprice.Text + ",1)";
                    DALAccess.ExecuteNonQuery(query);
                }
                else
                    MessageBox.Show("Duplicate Game found");
            }
            else // update
            {
                string query = "update gametype set gameName='" + txtname.Text + "',amountstudent=" + txtstudentprice.Text + ",amount=" + txtprice.Text + ",isactive=" + (chkisactive.Checked?"1":"0")+ " where ID="+glbItemID;
                DALAccess.ExecuteNonQuery(query);
                glbItemID = -1;               
            }

            chkisactive.Checked = true;
            txtname.Text = "";
            txtprice.Text = "";
            txtstudentprice.Text = "";

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
                DataTable dt = DALAccess.ExecuteDataTable("select * from gametype");
                dgmain.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        private void dgmain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnsave.Text = "Update";
            glbItemID = Convert.ToInt32(dgmain.Rows[e.RowIndex].Cells["ID"].Value);
            txtname.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["GameName"].Value);
            txtprice.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["NormalPrice"].Value);
            txtstudentprice.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["StudentPrice"].Value);
            chkisactive.Checked = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["isactive"].Value).ToLower() == "true" ? true : false;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Save";
            glbItemID = -1;
        }
    }
}
