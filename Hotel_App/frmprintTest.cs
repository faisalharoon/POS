using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_App
{
    public partial class frmprintTest : Form
    {
        public frmprintTest()
        {
            InitializeComponent();
        }

        private void frmprintTest_Load(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("<html>");

            str.Append(@"<head>
                <style type=""text/css"">
                table tr td { border: 1px black dashed;font-size:10px;}
                table {border-collapse: collapse;}
                body  
                {   
                    margin: 0px;  
                } 
                </style >
                <style type=""text/css"" media=""print"">
                body {
                    size:4.27in 4.69in; 
                    margin:.1in .1in .1in .1in;
                }
                </style >
                </head>");


            str.AppendFormat("<body>");

            str.AppendFormat("<table style='width:300px;'>");

            str.AppendFormat("<tr>");
            str.AppendFormat("<td colspan='2'>{0}</td>", "gggggg gggggg gggg gggg gggg");
            str.AppendFormat("</tr>");

            str.AppendFormat("<tr>");
            str.AppendFormat("<td width='30%'>{0}</td>", "Date");
            str.AppendFormat("<td width='70%'>{0}</td>", DateTime.Now.ToString());
            str.AppendFormat("</tr>");

            str.AppendFormat("<tr>");
            str.AppendFormat("<td>{0}</td>", "Order No");
            str.AppendFormat("<td>{0}</td>", "1");
            str.AppendFormat("</tr>");

            str.AppendFormat("<tr>");
            str.AppendFormat("<td>{0}</td>", "Operator");
            str.AppendFormat("<td>{0}</td>", "Administrator");
            str.AppendFormat("</tr>");

            str.AppendFormat("</table>");



            str.AppendFormat("<table style='width:300px;'>");
            str.AppendFormat("<tr>");
            str.AppendFormat("<td><b>{0}</b></td>", "ID");
            str.AppendFormat("<td><b>{0}</b></td>", "Name");
            str.AppendFormat("<td><b>{0}</b></td>", "Price");
            str.AppendFormat("<td><b>{0}</b></td>", "Quantity");
            str.AppendFormat("<td><b>{0}</b></td>", "Total");
            str.AppendFormat("</tr>");

            str.AppendFormat("<tr>");
            str.AppendFormat("<td>{0}</td>", "1");
            str.AppendFormat("<td>{0}</td>", "Salad");
            str.AppendFormat("<td>{0}</td>", "15");
            str.AppendFormat("<td>{0}</td>", "2");
            str.AppendFormat("<td>{0}</td>", "30");
            str.AppendFormat("</tr>");

            str.AppendFormat("<tr>");
            str.AppendFormat("<td>{0}</td>", "2");
            str.AppendFormat("<td>{0}</td>", "Coffee");
            str.AppendFormat("<td>{0}</td>", "30");
            str.AppendFormat("<td>{0}</td>", "3");
            str.AppendFormat("<td>{0}</td>", "90");
            str.AppendFormat("</tr>");

            str.AppendFormat("</table>");


            str.AppendFormat("<table style='width:300px;'>");
            str.AppendFormat("<tr>");
            str.AppendFormat("<td>{0}</td>", "Total");
            str.AppendFormat("<td>{0}</td>", "300");
            str.AppendFormat("</tr>");

            str.AppendFormat("<tr>");
            str.AppendFormat("<td>{0}</td>", "Discount");
            str.AppendFormat("<td>{0}</td>", "0");
            str.AppendFormat("</tr>");

            str.AppendFormat("<tr>");
            str.AppendFormat("<td>{0}</td>", "Grand Total");
            str.AppendFormat("<td>{0}</td>", "300");
            str.AppendFormat("</tr>");

            str.AppendFormat("</table>");

            str.AppendFormat("</body>");
            str.AppendFormat("</html>");

            webBrowser1.DocumentText = str.ToString();



            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(PrintDocument);
        }

        private void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.ShowPrintDialog();
            //webBrowser1.ShowPageSetupDialog();



            //PrintDocument pd = new PrintDocument();
            
            //PrintDialog p = new PrintDialog();
            //p.Document = pd;
            //DialogResult dr = p.ShowDialog();



        }
    }
}
