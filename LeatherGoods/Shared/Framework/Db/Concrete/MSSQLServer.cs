using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Framework.Db.Concrete
{
    public class MSSQLServer : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

        public override IDbConnection CreateOpenConnection()
        {
            var connection = CreateConnection();
            connection.Open();
            return connection;
        }

        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            var command = CreateCommand();

            command.CommandText = commandText;
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            var command = CreateCommand();

            command.CommandText = procName;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }
    }
}
