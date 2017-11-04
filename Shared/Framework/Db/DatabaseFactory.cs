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
            if(string.IsNullOrWhiteSpace(name))
                throw new Exception("A concrete database name is required");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("A connection string is required");
            try
            {
                name = "Framework.Db.Concrete." + name; // TODO beautify it
                Type database = Type.GetType(name);
                if (database == null) throw new Exception("Concrete database not found");
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
