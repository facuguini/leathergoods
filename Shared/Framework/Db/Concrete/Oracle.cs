using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Text;

namespace Framework.Db.Concrete
{
    public class Oracle : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new OracleConnection(connectionString);
        }
        public override IDbCommand CreateCommand()
        {
            return new OracleCommand();
        }
        public override IDbConnection CreateOpenConnection()
        {
            OracleConnection connection = (OracleConnection)CreateConnection();
            connection.Open();
            return connection;
        }
        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            OracleCommand command = (OracleCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (OracleConnection)connection;
            command.CommandType = CommandType.Text;
            return command;
        }
        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            OracleCommand command = (OracleCommand)CreateCommand();
            command.CommandText = procName;
            command.Connection = (OracleConnection)connection;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new OracleParameter(parameterName, parameterValue);
        }

        public override string LastIdFunction()
        {
            return "SELECT @@IDENTITY;"; // TODO check it
        }
    }
}
