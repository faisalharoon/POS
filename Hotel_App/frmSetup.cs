using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace General_App
{
    public partial class frmSetup : Form
    {
        public frmSetup()
        {
            InitializeComponent();
        }

        private void btnDatabasepath_Click(object sender, EventArgs e)
        {
            string initPath = "";

            try
            {
                initPath = Convert.ToString(XmlExtension.DeSerialize().dbpath);
            }
            catch (Exception)
            { 
            }
           

            try
            {
                //                StreamWriter sw = new StreamWriter("");

                openFileDialog2.InitialDirectory = initPath;

                DialogResult d = openFileDialog2.ShowDialog();
                txtDbPath.Text = openFileDialog2.FileName;
            }
            catch (Exception)
            {
            }
        }

        private void btnServerFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                //                StreamWriter sw = new StreamWriter("");

                openFileDialog1.InitialDirectory = XmlExtension.DeSerialize().dbpath;

                DialogResult d = openFileDialog1.ShowDialog();
                txtDbPath.Text = openFileDialog1.FileName;
            }
            catch (Exception)
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path.GetFileName("dbpath.txt")))
                {
                    SaveXML();
                }
                else
                {
                    File.Create(Path.GetFileName("dbpath.txt"));
                    SaveXML();
                }
                MessageBox.Show("Saved..");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        void SaveXML()
        {
            try
            {
                SetupClass s = new SetupClass();
                s.dbpath = txtDbPath.Text;
             
                string xml = s.Serialize();

                using (var writer = new System.IO.StreamWriter(Path.GetFileName("dbpath.txt")))
                {
                    writer.Write(xml);
                    writer.Flush();
                }



                s.CustomerSalesTax = Convert.ToDouble(txtCustomerSalesTax.Text);

                s.VendorSaleTaxFiler = Convert.ToDouble(txtSTFiler.Text);
                s.VendorWithHoldingTaxFiler = Convert.ToDouble(txtWithholdingFiler.Text);

                s.VendorSaleTaxNonFiler = Convert.ToDouble(txtSTNonFiler.Text);
                s.VendorWithHoldingTaxNonFiler = Convert.ToDouble(txtWithHoldingNonFiler.Text);

                s.CompanyAddress = txtCompanyAddress.Text;
                s.CompanyName = txtCompanyName.Text;

                DALAccess.RefershConnectionString();

                DALAccess.ExecuteNonQuery("update settings set DataValue='"+s.CustomerSalesTax+"' where datatext='CustomerGST'");

                DALAccess.ExecuteNonQuery("update settings set DataValue='" + s.VendorSaleTaxFiler + "' where datatext='VendorSalesTaxFiler'");
                DALAccess.ExecuteNonQuery("update settings set DataValue='" + s.VendorSaleTaxNonFiler + "' where datatext='VendorSalesTaxNonFiler'");

                DALAccess.ExecuteNonQuery("update settings set DataValue='" + s.VendorWithHoldingTaxFiler + "' where datatext='VendorwithHoldingFiler'");
                DALAccess.ExecuteNonQuery("update settings set DataValue='" + s.VendorWithHoldingTaxNonFiler + "' where datatext='VendorWithHoldingNonFiler'");

                DALAccess.ExecuteNonQuery("update settings set DataValue='" + s.CompanyAddress + "' where datatext='CompanyAddress'");
                DALAccess.ExecuteNonQuery("update settings set DataValue='" + s.CompanyName + "' where datatext='CompanyName'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        


        private void frmSetup_Load(object sender, EventArgs e)
        {
            try
            {
                
                txtDbPath.Text = XmlExtension.DeSerialize().dbpath;


                SetupClass s = XmlExtension.GetSetupValues();

               txtCustomerSalesTax.Text = Convert.ToString(s.CustomerSalesTax);

                txtSTFiler.Text = Convert.ToString(s.VendorSaleTaxFiler);
                txtWithholdingFiler.Text = Convert.ToString(s.VendorWithHoldingTaxFiler);

                txtSTNonFiler.Text = Convert.ToString(s.VendorSaleTaxNonFiler);
                txtWithHoldingNonFiler.Text = Convert.ToString(s.VendorWithHoldingTaxNonFiler);

                txtCompanyName.Text = Convert.ToString(s.CompanyName);
                txtCompanyAddress.Text = Convert.ToString(s.CompanyAddress);

            }
            catch (Exception ex) {
                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }



    public class SetupClass
    {
        public string ServerFilePath { get; set; }
        public string dbpath { get; set; }
        public double VendorSaleTaxFiler { get; set; }
        public double VendorWithHoldingTaxFiler { get; set; }
        public double VendorSaleTaxNonFiler { get; set; }
        public double VendorWithHoldingTaxNonFiler { get; set; }
        public double CustomerSalesTax { get; set; }

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
    }


    public static class XmlExtension
    {
        public static string Serialize<T>(this T value)
        {
            if (value == null) return string.Empty;

            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
                {
                    xmlSerializer.Serialize(xmlWriter, value);
                    return stringWriter.ToString();
                }
            }
        }
        public static SetupClass DeSerialize()
        {
            SetupClass obj = new SetupClass();
            try
            {
                if (File.Exists(Path.GetFileName("dbpath.txt")))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(SetupClass));

                    string xml= File.ReadAllText(Path.GetFileName("dbpath.txt"));

                    if (xml != "")
                    {
                        using (TextReader reader = new StringReader(xml))
                        {
                            obj = (SetupClass)xs.Deserialize(reader);
                        }
                    }
                                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return obj;
        }
        public static SetupClass GetSetupValues()
        {
            SetupClass s = new SetupClass();
            try
            {



                DataTable dt = DALAccess.ExecuteDataTable("select * from Settings");

                var q = dt.AsEnumerable().Select(x => new
                {
                    ItemID = Convert.ToInt32(x.Field<object>("ID")),
                    DataText = Convert.ToString(x.Field<object>("DataText")),
                    DataValue = Convert.ToString(x.Field<object>("DataValue"))
                });

                s.VendorSaleTaxFiler = Convert.ToDouble(q.Where(x => x.DataText == "VendorSalesTaxFiler").FirstOrDefault().DataValue);
                s.VendorWithHoldingTaxFiler = Convert.ToDouble(q.Where(x => x.DataText == "VendorwithHoldingFiler").FirstOrDefault().DataValue);

                s.VendorSaleTaxNonFiler = Convert.ToDouble(q.Where(x => x.DataText == "VendorSalesTaxNonFiler").FirstOrDefault().DataValue);
                s.VendorWithHoldingTaxNonFiler = Convert.ToDouble(q.Where(x => x.DataText == "VendorWithHoldingNonFiler").FirstOrDefault().DataValue);

                s.CustomerSalesTax = Convert.ToDouble(q.Where(x => x.DataText == "CustomerGST").FirstOrDefault().DataValue);

                s.CompanyAddress = Convert.ToString(q.Where(x => x.DataText == "CompanyAddress").FirstOrDefault().DataValue);
                s.CompanyName = Convert.ToString(q.Where(x => x.DataText == "CompanyName").FirstOrDefault().DataValue);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return s;
        }
    }


}
