using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Reflection;

namespace HOGRegister.Data.Helper
{
    public static class Converter<TEntity> where TEntity: class
    {
        public static List<TEntity> DataTableToObject(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                          .Select(c => c.ColumnName)
                          .ToList();
            var properties = typeof(TEntity).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<TEntity>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        if (pI.CanWrite)
                            pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }
    }
}