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
    public partial class frmItem : Form
    {
        public string ItemID;
        public string ItemName;
        public string SalePrice;
        public double GSTPercentage;

        public frmItem()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = DALAccess.ExecuteDataTable("select * from Item where Name like '%" + textBox1.Text + "%' order by id asc");

            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Select();
            }
        }
       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ItemID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                ItemName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                SalePrice = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            DataTable dt = DALAccess.ExecuteDataTable("select ID,Name,SalePrice,BarCode,[GST%] from Item order by id asc");
            dataGridView1.DataSource = dt;
            textBox1.Select();
        }

        public void focusTextbox()
        {
            textBox1.Focus();
        }
     

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //DataGridViewSelectedRowCollection lst= dataGridView1.SelectedRows;

                //if (lst != null && lst.Count > 0)

                int index = dataGridView1.CurrentCell.RowIndex;

                {
                    ItemID = Convert.ToString(dataGridView1.Rows[index].Cells[0].Value);
                    ItemName = Convert.ToString(dataGridView1.Rows[index].Cells[1].Value);
                    SalePrice = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    GSTPercentage= Convert.ToDouble(dataGridView1.Rows[index].Cells[4].Value);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
