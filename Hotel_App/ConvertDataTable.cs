using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;



    public static class ConvertDataTable
    {
        public static DataTable ToADOTable<T>(this IEnumerable<T> varlist, ConvertToDataTable.ConvertDataTable.CreateRowDelegate<T> fn)
        {

            DataTable dtReturn = new DataTable();
            PropertyInfo[] oProps = null;
            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType; if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow(); foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return (dtReturn);

        }

       

    }

    namespace ConvertToDataTable
    {
        public static class ConvertDataTable
        {
            public delegate object[] CreateRowDelegate<T>(T t);

        }
    }