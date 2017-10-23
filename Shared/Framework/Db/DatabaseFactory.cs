using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Framework.Db.Concrete;

namespace Framework.Db
{
    public sealed class DatabaseFactory
    {
        public Database GetDatabase()
        {
            return new MSSQLServer();
        }
    }
}
