using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Framework.Db
{
    public sealed class DatabaseFactory
    {
        private static Database _database = null;

        static DatabaseFactory()
        {
            try
            {
                _database = database;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Database database
        {
            get { return _database; }
        }
    }
}
