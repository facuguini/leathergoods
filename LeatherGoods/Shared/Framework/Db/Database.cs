using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Framework.Db
{
    public abstract class Database
    {
        public string connectionString { get; set; }

        public abstract IDbConnection CreateConnection();
        public abstract IDbCommand CreateCommand();
        public abstract IDbConnection CreateOpenConnection();
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection);
        public abstract IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
        public abstract IDataParameter CreateParameter(string parameterName, object parameterValue);
    }
}
