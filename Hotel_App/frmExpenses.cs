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
    public partial class frmExpenses : Form
    {
        public int glbUserID = -1;

        public frmExpenses()
        {
            InitializeComponent();
        }

        private void frmExpenses_Load(object sender, EventArgs e)
        {
            try
            {
                dgmain.AutoGenerateColumns = false;
                BindUsers();
            }
            catch (Exception)
            {
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (glbUserID == -1)// add new
                {
                    DALAccess.ExecuteNonQuery(@"insert into [expense] (title,amount,remarks,expensedate,addedby,addedat) values "+
                    "('" + txttitle.Text + "'," + txtamount.Text + ",'" + txtremarks.Text + "','" + DateTime.Now + "'," + LoggedInUser.UserID + ",'" + DateTime.Now + "')");
                }
                else
                {
                    DALAccess.ExecuteNonQuery(@"update [expense] set "+ 
                        "title='" + txttitle.Text + "'" +
                        ",amount=" + txtamount.Text +
                        ",remarks='" + txtremarks.Text + "'" +
                        ",modifiedby=" + LoggedInUser.UserID +
                        ",modifiedat ='" + DateTime.Now + "' where id="+glbUserID);


                    glbUserID = -1;
                    btnsave.Text = "Save";
                }

                txttitle.Text = "";
                txtamount.Text = "";
                txtremarks.Text = "";
                BindUsers();

            }
            catch (Exception ex)
            {
            }
        }       

        private void BindUsers()
        {
            try
            {
                string query = "select * from expense";
                DataTable dt = DALAccess.ExecuteDataTable(query);
                dgmain.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

       
        private void dgmain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                glbUserID = Convert.ToInt32(dgmain.Rows[e.RowIndex].Cells["ID"].Value);

                if (dgmain.Columns["Delete"].Index == e.ColumnIndex)
                {
                    DALAccess.ExecuteNonQuery("delete from [expense] where id=" + glbUserID);
                    BindUsers();
                }
                else
                {
                    btnsave.Text = "Update";
                    txttitle.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["Title"].Value);
                    txtamount.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["Amount"].Value);
                    txtremarks.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["Remarks"].Value);
                }

            }
            catch (Exception)
            {
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Save";
            glbUserID = -1;
        }

       
    }
}
