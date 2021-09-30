using Microsoft.Reporting.WinForms;
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
    public partial class frmItemBarcode : Form
    {
        public string ItemID;
        public string ItemName;
        public string SalePrice;
        public string BarCode;

        public frmItemBarcode()
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
                BarCode = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                //this.DialogResult = DialogResult.OK;
                //this.Close();

                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = barcode.Draw("faisal", 50);

                PrintBarCode();
            }
        }

        private void PrintBarCode()
        {
            try
            {
                reportViewer1.Clear();
                reportViewer1.LocalReport.DataSources.Clear();

                DataTable dt = new DataTable();

                dt.Columns.Add("Barcode", typeof(byte[]));
                dt.Columns.Add("ItemName");

                ImageConverter converter = new ImageConverter();
                 byte [] tmp= (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));
                //byte[] ItemNamebytes = Encoding.ASCII.GetBytes(ItemName);
                //string strBase64 = Convert.ToBase64String(tmp);


                //byte[] rv = new byte[tmp.Length + ItemNamebytes.Length ];
                //System.Buffer.BlockCopy(tmp, 0, rv, 0, tmp.Length);
                //System.Buffer.BlockCopy(ItemNamebytes, 0, rv, tmp.Length, ItemNamebytes.Length);

                for (int i = 1; i < 15; i++)
                {
                    DataRow dr = dt.NewRow();
                    //dr["Barcode"] = "data:Image/png;base64," + strBase64;
                    dr["Barcode"] = tmp;
                    dr["ItemName"] = ItemName;
                    dt.Rows.Add(dr);
                }

                var o = dt.AsEnumerable().Select(x => new
                {
                    ItemName=x.Field<string>("ItemName"),
                    Barcode = x.Field<byte[]>("Barcode"),
                });


                try
                {
                    ReportDataSource reportDSDetail = new ReportDataSource("DataSet2", o);
                    //reportViewer2.LocalReport.ReportPath = "../../Report1-Fullpage.rdlc";
                    reportViewer1.LocalReport.ReportPath = "../../ReportBarcode.rdlc";
                    reportViewer1.LocalReport.DataSources.Add(reportDSDetail);
                    reportViewer1.LocalReport.EnableExternalImages = true;


                    //reportDSDetail = new ReportDataSource("DataSet2", dtBrush);
                    //reportViewer2.LocalReport.DataSources.Add(reportDSDetail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("dataset2: " + ex.Message);
                }
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();

                //System.Threading.Thread.Sleep(1000);
                printcount = 0;

                try
                {
                    reportViewer1.RenderingComplete += new RenderingCompleteEventHandler(PrintSales);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("render: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int printcount = 0;
        public void PrintSales(object sender, RenderingCompleteEventArgs e)
        {
            try
            {
                if (printcount == 0)
                {
                    reportViewer1.PrintDialog();
                    printcount++;
                }
            }
            catch (Exception ex)
            {
            }
        }


        

        private void frmItem_Load(object sender, EventArgs e)
        {
            DataTable dt = DALAccess.ExecuteDataTable("select * from Item order by id asc");
            dataGridView1.DataSource = dt;
            textBox1.Select();
            this.reportViewer1.RefreshReport();
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

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
