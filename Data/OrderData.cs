using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class OrderData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order Create(Order order)
        {
            const string sqlStatement = "INSERT INTO dbo.Order ([ClientId], [OrderDate], [TotalPrice], [State], [OrderNumber], [CreatedBy]) " +
                "VALUES(@ClientId, @OrderDate, @TotalPrice, @State, @OrderNumber, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@ClientId", order.ClientId));
               cmd.Parameters.Add(Db.CreateParameter("@OrderDate", order.OrderDate));
               cmd.Parameters.Add(Db.CreateParameter("@TotalPrice", order.TotalPrice));
               cmd.Parameters.Add(Db.CreateParameter("@State", order.State));
               cmd.Parameters.Add(Db.CreateParameter("@OrderNumber", order.OrderNumber));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", order.CreatedBy));
               // Obtener el valor de la primary key.
               order.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return order;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="order"></param>
        public void UpdateById(Order order)
        {
            const string sqlStatement = "UPDATE dbo.Order " +
                "SET [ClientId]=@ClientId, " +
                    "[TotalPrice]=@TotalPrice, " +
                    "[State]=@State, " +
                    "[OrderNumber]=@OrderNumber, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@ClientId", order.ClientId));
               cmd.Parameters.Add(Db.CreateParameter("@TotalPrice", order.TotalPrice));
               cmd.Parameters.Add(Db.CreateParameter("@State", order.State));
               cmd.Parameters.Add(Db.CreateParameter("@OrderNumber", order.OrderNumber));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", order.CreatedBy));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", order.ChangedOn));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", order.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", order.Id));
               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Order WHERE [Id]=@Id ";
            var connection = Db.CreateConnection();
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
        public Order SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [OrderDate], [TotalPrice], [State], [OrderNumber], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Order WHERE [Id]=@Id ";

            Order order = null;
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) order = LoadOrder(dr);
               }
            }

            return order;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Order> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [ClientId], [OrderDate], [TotalPrice], [State], [OrderNumber], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Order";

            var result = new List<Order>();
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var order = LoadOrder(dr); // Mapper
                       result.Add(order);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea una nueva Order desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Order.</returns>
        private static Order LoadOrder(IDataReader dr)
        {
            var order = new Order
            {
                Id = GetDataValue<int>(dr, "Id"),
                ClientId = GetDataValue<int>(dr, "ClientId"),
                OrderDate = GetDataValue<DateTime>(dr, "OrderDate"),
                TotalPrice = GetDataValue<float>(dr, "TotalPrice"),
                State = GetDataValue<int>(dr, "State"),
                OrderNumber = GetDataValue<int>(dr, "OrderNumber"),
                ItemCount = GetDataValue<int>(dr, "ItemCount"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return order;
        }

    }
}
