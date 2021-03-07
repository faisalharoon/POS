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
    public partial class frmConfirmDialog : Form
    {
        public bool confrmDelete;
        public frmConfirmDialog()
        {
            InitializeComponent();
        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            confrmDelete = true;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            confrmDelete = false;
            this.Close();
        }
    }
}
