using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class OrderNumberData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public OrderNumber Create(OrderNumber orderN)
        {
            const string sqlStatement = "INSERT INTO dbo.OrderNumber([Number], [CreatedBy]) " +
                "VALUES(@Number, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Number", orderN.Number));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", orderN.CreatedBy));
               // Obtener el valor de la primary key.
               orderN.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return orderN;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderNumber"></param>
        public void UpdateById(OrderNumber orderN)
        {
            const string sqlStatement = "UPDATE dbo.OrderNumber " +
                "SET [Number]=@Number, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Number", orderN.Number));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", orderN.ChangedOn));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", orderN.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", orderN.Id));
               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.OrderNumber WHERE [Id]=@Id ";
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderNumber SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Number], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.OrderNumber WHERE [Id]=@Id ";

            OrderNumber orderN = null;
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) orderN = LoadOrderNumber(dr);
               }
            }

            return orderN;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<OrderNumber> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Number], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.OrderNumber ";

            var result = new List<OrderNumber>();
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var orderN = LoadOrderNumber(dr); // Mapper
                       result.Add(orderN);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo OrderNumber desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto OrderNumber.</returns>
        private static OrderNumber LoadOrderNumber(IDataReader dr)
        {
            var orderN = new OrderNumber
            {
                Id = GetDataValue<int>(dr, "Id"),
                Number = GetDataValue<int>(dr, "Number"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return orderN;
        }

    }
}
