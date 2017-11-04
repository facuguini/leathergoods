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
                throw new Exception("Database name not defined in the environment");
            try
            {
                MSSQLServer db = new MSSQLServer();
                // Type database = Type.GetType(name);
                // Console.WriteLine("1");
                // ConstructorInfo constructor = database.GetConstructor(new Type[] { });
                // Console.WriteLine("2");
                // Database dbInstance = (Database)constructor.Invoke(null);
                // Console.WriteLine("3");
                // dbInstance.connectionString = connectionString;
                // Console.WriteLine("4");
                db.connectionString = connectionString;
                Console.WriteLine(connectionString);
                return db;
            }
            catch(Exception ex)
            {
                throw new Exception("Error instantiating database " + name + ". " + ex.Message);
            }
        }
    }
}
