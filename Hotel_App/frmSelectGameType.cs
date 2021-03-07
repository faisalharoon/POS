using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace General_App
{
    public partial class frmSelectGameType : Form
    {

       public string GameTypeID;
        public string GameName;
        public frmSelectGameType()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = DALAccess.ExecuteDataTable("select * from GameType where GameName like '%"+textBox1.Text+"%'");
        }



     

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GameTypeID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                GameName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
             DataTable dt= DALAccess.ExecuteDataTable("select * from GameType");
            dataGridView1.DataSource = dt;
        }
     

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //DataGridViewSelectedRowCollection lst= dataGridView1.SelectedRows;

                //if (lst != null && lst.Count > 0)

                int index= dataGridView1.CurrentCell.RowIndex;

                {
                    GameTypeID = Convert.ToString(dataGridView1.Rows[index].Cells[0].Value);
                    GameName = Convert.ToString(dataGridView1.Rows[index].Cells[1].Value);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
