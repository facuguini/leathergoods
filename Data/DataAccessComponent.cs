using System;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using Framework;
using Framework.Db;

namespace Data
{
    /// <summary>
    /// Base data access component class.
    /// </summary>
    public abstract class DataAccessComponent
    {
        private static string ConnectionString = AppSettings.DbConnectionString;
        private static string DbProvider = AppSettings.DbProvider;
        internal static Database Db;

        static DataAccessComponent()
        {
            Db = DatabaseFactory.CreateDatabase(DbProvider, ConnectionString);
        }

        protected static T GetDataValue<T>(IDataReader dr, string columnName)
        {
            var i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return (T)dr.GetValue(i);
            return default(T);
        }

        protected string FormatFilterStatement(string filter)
        {
            return Regex.Replace(filter, "^(AND|OR)", string.Empty);
        }
    }
}

