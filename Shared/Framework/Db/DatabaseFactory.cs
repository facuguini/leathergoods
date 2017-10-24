using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Framework.Db.Concrete;

namespace Framework.Db
{
    public static class DatabaseFactory
    {
        public static Database CreateDatabase(string name, string connectionString)
        {
            if(name.Length == 0)
                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of web.config.");
            try
            {
                Type database = Type.GetType(name);
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });
                Database dbInstance = (Database)constructor.Invoke(null);
                dbInstance.connectionString = connectionString;
                return dbInstance;
            }
            catch(Exception ex)
            {
                throw new Exception("Error instantiating database " + name + ". " + ex.Message);
            }
        }
    }
}
