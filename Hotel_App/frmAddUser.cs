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
    public partial class frmAddUser : Form
    {
        public int glbUserID = -1;
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (glbUserID == -1)// add new
                {
                    DataTable dtduplicate= DALAccess.ExecuteDataTable("select * from [user] where username='"+txtname.Text+"'");
                    if (dtduplicate == null || dtduplicate.Rows.Count == 0)
                    {
                        DALAccess.ExecuteNonQuery("insert into [user] (username,[password],isactive,creationdate,roleid,displayname) values ('" + txtname.Text + "','" + txtpassword.Text + "','" + ((chkactive.Checked) ? "1" : "0") + "','" + DateTime.Now + "'," + ddlrole.SelectedValue + ",'" + txtdisplayname.Text + "')");
                    }
                    else
                        MessageBox.Show("Duplicate UserName found. Please try again.");
                }
                else
                {
                    DataTable dtduplicate = DALAccess.ExecuteDataTable("select * from [user] where username='" + txtname.Text + "' and id <>"+glbUserID);
                    if (dtduplicate == null || dtduplicate.Rows.Count == 0)
                    {
                        DALAccess.ExecuteNonQuery("update [user] set username='" + txtname.Text + "',[password]='" + txtpassword.Text + "',isactive=" + chkactive.Checked + ",roleid=" + ddlrole.SelectedValue + ",displayname='" + txtdisplayname.Text + "' where id=" + glbUserID);
                        glbUserID = -1;
                        btnsave.Text = "Save";
                        ddlrole.Enabled = true;
                    }
                    else
                        MessageBox.Show("Duplicate UserName found. Please try again.");
                }

                txtname.Text = "";
                txtpassword.Text = "";
                txtdisplayname.Text = "";
                BindUsers();

            }
            catch (Exception ex)
            {
            }
        }

        private void BindRoles()
        {
            try
            {
                DataTable dt = DALAccess.ExecuteDataTable("select * from role");
                ddlrole.DisplayMember = "RoleName";
                ddlrole.ValueMember = "ID";

                ddlrole.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        private void BindUsers()
        {
            try
            {
                string query = "select uu.id,uu.username,uu.[password],uu.creationdate,uu.isactive,rr.rolename,uu.roleid,uu.displayname from ([user] uu inner join [role] rr on rr.id=uu.roleid)";
                DataTable dt = DALAccess.ExecuteDataTable(query);
                dgmain.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            try
            {
                dgmain.AutoGenerateColumns = false;
                BindRoles();
                BindUsers();
            }
            catch (Exception)
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
                    frmConfirmDialog f = new frmConfirmDialog();
                    DialogResult r = f.ShowDialog();
                    if (f.confrmDelete)
                    {
                        DALAccess.ExecuteNonQuery("delete from [user] where id=" + glbUserID);
                        BindUsers();
                    }
                }
                else
                {
                    btnsave.Text = "Update";
                    txtname.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["UserName"].Value);
                    txtpassword.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["Password"].Value);
                    txtdisplayname.Text = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["displayname"].Value);
                    ddlrole.SelectedValue = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["RoleID"].Value);
                    chkactive.Checked = Convert.ToString(dgmain.Rows[e.RowIndex].Cells["IsActive"].Value).ToLower() == "true" ? true : false;
                    ddlrole.Enabled = false;
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
            ddlrole.Enabled = true;
        }

        private void dgmain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
