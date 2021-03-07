using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_App
{
    public static class DALAccess
    {
        static  string conString = "";

        static DALAccess()
        {
            SetCon();
        }

        public static void RefershConnectionString() {
            SetCon();
        }


        private static void SetCon() {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "");
            if (path != "")
            {
                //path = path + "Database1.accdb";
                path = XmlExtension.DeSerialize().dbpath;
                conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Persist Security Info=False;";
            }
            else
                conString = Properties.Settings.Default.Constr;
        }


        public static DataTable ExecuteDataTable(string query)
        {
         
                
                OleDbConnection mycon;
                mycon = new OleDbConnection(conString);

                if (mycon.State == ConnectionState.Closed)
                {
                    mycon.Open();
                }
                try
                {
                    OleDbCommand accessCommand = new OleDbCommand();
                    DataTable dt = new DataTable();
                    accessCommand = new OleDbCommand(query, mycon);

                    using (OleDbDataReader myReader = accessCommand.ExecuteReader())
                    {
                        DataTable myTable = new DataTable();
                        myTable.Load(myReader);
                        return myTable;
                    }
                }
                finally
                {
                    mycon.Close();
                }
           
        }
        public static int ExecuteNonQuery(string query)
        {            
            OleDbConnection mycon;
            mycon = new OleDbConnection(conString);

            if (mycon.State == ConnectionState.Closed)
            {
                mycon.Open();
            }
            try
            {
                OleDbCommand accessCommand = new OleDbCommand();
                DataTable dt = new DataTable();
                accessCommand = new OleDbCommand(query, mycon);
                accessCommand.ExecuteScalar();

                accessCommand = new OleDbCommand("SELECT @@IDENTITY", mycon);
                return Convert.ToInt32(accessCommand.ExecuteScalar());
            }
            finally
            {
                mycon.Close();
            }
        }



    }
}
