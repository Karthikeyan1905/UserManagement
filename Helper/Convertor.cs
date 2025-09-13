using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Helper
{
    public static class Convertor
    {
        public static List<T> ConvertTableToList<T>(DataTable table) where T : new()
        {
            var list = new List<T>();
            var props = typeof(T).GetProperties();

            foreach (DataRow row in table.Rows)
            {
                T obj = new T();

                foreach (var prop in props)
                {
                    if (table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                    {
                        prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType));
                    }
                }

                list.Add(obj);
            }

            return list;
        }
    }
}
