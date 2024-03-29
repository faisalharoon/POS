﻿using System;
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
    public partial class frmVendorDialog : Form
    {

       public string ItemID;
        public string ItemName;
        public frmVendorDialog()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.DataSource = DALAccess.ExecuteDataTable("select * from vendor where Name like '%" + textBox1.Text + "%' order by id asc");
        }



      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ItemID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                ItemName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
             DataTable dt=DALAccess.ExecuteDataTable("select * from vendor order by id asc");
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
                    ItemID = Convert.ToString(dataGridView1.Rows[index].Cells[0].Value);
                    ItemName = Convert.ToString(dataGridView1.Rows[index].Cells[1].Value);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
