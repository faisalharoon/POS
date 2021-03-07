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
    public partial class frmApplicationExitConfirm : Form
    {

        public bool CloseApp;
        public frmApplicationExitConfirm()
        {
            InitializeComponent();
        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            CloseApp = true;
            this.Close();
        }

        private void btnno_Click(object sender, EventArgs e)
        {
            CloseApp = false;
            this.Close();
        }
    }
}
