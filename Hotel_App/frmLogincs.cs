using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_App
{
    public partial class frmLogincs : Form
    {
        public frmLogincs()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                dologin();
            }
            catch (Exception)
            {
            }
        }

        private void dologin()
        {
            bool isValidLicense = MatchProcessorID();

            if (!isValidLicense)
            {
                if (!checkTrial())
                {
                    MessageBox.Show("Your license expired. please try again.");
                    return;
                }
            }


            try
            {
                DataTable dt = DALAccess.ExecuteDataTable("select * from [user] where username='" + txtusername.Text + "' and [password]='" + txtpassword.Text + "' and isactive=true");
                if (dt != null && dt.Rows.Count > 0)
                {
                    LoggedInUser.UserID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    LoggedInUser.UserRoleID = Convert.ToInt32(dt.Rows[0]["RoleID"]);
                    LoggedInUser.DisplayName = Convert.ToString(dt.Rows[0]["DisplayName"]);
                    LoggedInUser.UserName = Convert.ToString(dt.Rows[0]["Username"]);

                    if (checkTrial())
                        IncrementTrial();

                    if (LoggedInUser.UserRoleID == 3)// entry user
                    {
                        frmDefault f = new frmDefault();
                        f.Show();
                    }
                    else if (LoggedInUser.UserRoleID == 1 || LoggedInUser.UserRoleID == 2)
                    {
                        frmDefault f = new frmDefault();
                        f.Show();
                    }
                    else if (LoggedInUser.UserRoleID == 4)// gaming
                    {
                        frmTicket f = new frmTicket();
                        f.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Not a Valid User. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogincs_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.T) // for combination of Alt + T
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WindowLicenseTrialEntry");
                    string val = Convert.ToString(key.GetValue("count"));
                    key.SetValue("count", "0");

                    key.Close();

                    MessageBox.Show("OK. T Renewed.");
                    CheckLicense();
                }
                if (e.Control && e.KeyCode == Keys.L) // for combination of Alt + T
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WindowLicenseTrialEntry");
                    string val = Convert.ToString(key.GetValue("ID"));
                    key.SetValue("ID", HardwareInfo.GetProcessorId());

                    key.Close();

                    MessageBox.Show("OK. Lic Renewed.");
                    CheckLicense();
                }
                if (e.Control && e.KeyCode == Keys.D) // for combination of Alt + T
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WindowLicenseTrialEntry");
                    string val = Convert.ToString(key.GetValue("ID"));
                    key.SetValue("ID", "");

                    key.Close();

                    MessageBox.Show("OK. Lic Deleted.");
                    CheckLicense();
                }

                if (e.Control && e.KeyCode == Keys.S) // for combination of Alt + T
                {
                    frmSetup s = new frmSetup();
                    s.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogincs_Load(object sender, EventArgs e)
        {
            try
            {
                var existingProcessName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location);



                if (Process.GetProcessesByName(existingProcessName).Count() > 1)
                {
                    frmApplicationExitConfirm f = new frmApplicationExitConfirm();
                    f.ShowDialog();
                    if (f.CloseApp)
                    {
                        Process[] allprocesses = Process.GetProcessesByName(existingProcessName);
                        foreach (var o in allprocesses)
                        {
                            if (o.Id != Process.GetCurrentProcess().Id)
                                o.Kill();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Application Already open. Shutting Down");
                        Application.Exit();
                    }
                }

                //bool isopen= IsProcessOpen(existingProcessName);
                //if (isopen)
                //{
                //    MessageBox.Show("Application Already open. Shutting Down");
                //    Application.Exit();
                //}

                CheckLicense();


            }
            catch (Exception ex)
            {
            }
        }

        private void CheckLicense()
        {
            try
            {
                bool isValidLicense = MatchProcessorID();

                if (isValidLicense)
                    lblTrial.Text = "Licensed";
                else
                    lblTrial.Text = "(" + GetTrialCount() + ")";
            }
            catch (Exception)
            {
            }
        }

        public bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }

            return false;
        }


        public int GetTrialCount()
        {
            int AttemptValue = 0;

            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WindowLicenseTrialEntry");
                string val = Convert.ToString(key.GetValue("count"));
                if (string.IsNullOrEmpty(val))
                    AttemptValue = 0;
                else
                    AttemptValue = Convert.ToInt32(val);



                key.Close();
            }
            catch (Exception)
            {
            }
            return AttemptValue;
        }


        public bool checkTrial()
        {
            try
            {
                int AttemptValue = GetTrialCount();


                if (AttemptValue > 3)
                {
                    return false;
                }

                return true;
            }
            catch (Exception exx)
            {
                return false;
            }
        }



        public void IncrementTrial()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WindowLicenseTrialEntry");
                string val = Convert.ToString(key.GetValue("count"));
                if (string.IsNullOrEmpty(val))
                    key.SetValue("count", "0");
                else
                    key.SetValue("count", Convert.ToString(Convert.ToInt32(val) + 1));

                key.Close();
            }
            catch (Exception exx)
            {
            }
        }


        public bool MatchProcessorID()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WindowLicenseTrialEntry");
                string val = Convert.ToString(key.GetValue("ID"));

                key.Close();



                if (val != HardwareInfo.GetProcessorId())
                {
                    return false;
                }

                return true;
            }
            catch (Exception exx)
            {
                return false;
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dologin();
        }

        private void frmLogincs_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //FormCollection formsList = Application.OpenForms;

                // foreach (Form o in formsList)
                //  o.Close();

                Application.Exit();
            }
            catch (Exception)
            {
            }
        }


    }


    public static class LoggedInUser
    {
        public static int UserID { get; set; }
        public static int UserRoleID { get; set; }
        public static string DisplayName { get; set; }

        public static string UserName { get; set; }
    }


    public static class Common
    {
        public static double Round(object val)
        {
            double f = 0;
            try
            {
                Math.Round(Convert.ToDouble(val), 0);
            }
            catch (Exception)
            {
            }
            return f;
        }

        public static double Percentage(object Totalval,object Percentage)
        {
            double f = 0;
            try
            {
                f = (Convert.ToDouble(Totalval) * Convert.ToDouble(Percentage)) / 100;
                f=Math.Round(f, 0);
            }
            catch (Exception)
            {
            }
            return f;
        }


    }
}
