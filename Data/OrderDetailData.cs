using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class OrderDetailData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public OrderDetail Create(OrderDetail orderD)
        {
            const string sqlStatement = "INSERT INTO dbo.OrderDetail([OrderId], [ProductId], [Price], [Quantity], [CreatedBy]) " +
                "VALUES(@OrderId, @ProductId, @Price, @Quantity, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@OrderId", orderD.OrderId));
               cmd.Parameters.Add(Db.CreateParameter("@ProductId", orderD.ProductId));
               cmd.Parameters.Add(Db.CreateParameter("@Price", orderD.Price));
               cmd.Parameters.Add(Db.CreateParameter("@Quantity", orderD.Quantity));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", orderD.CreatedBy));
               // Obtener el valor de la primary key.
               orderD.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return orderD;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderDetail"></param>
        public void UpdateById(OrderDetail orderD)
        {
            const string sqlStatement = "UPDATE dbo.OrderDetail " +
                "SET [OrderId]=@OrderId, " +
                    "[ProductId]=@ProductId, " +
                    "[Price]=@Price, " +
                    "[Quantity]=@Quantity, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@OrderId", orderD.OrderId));
               cmd.Parameters.Add(Db.CreateParameter("@ProductId", orderD.ProductId));
               cmd.Parameters.Add(Db.CreateParameter("@Price", orderD.Price));
               cmd.Parameters.Add(Db.CreateParameter("@Quantity", orderD.Quantity));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", orderD.ChangedOn));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", orderD.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", orderD.Id));
               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.OrderDetail WHERE [Id]=@Id ";
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
        public OrderDetail SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.OrderDetail WHERE [Id]=@Id ";

            OrderDetail orderD = null;
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) orderD = LoadOrderDetail(dr);
               }
            }

            return orderD;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<OrderDetail> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.OrderDetail ";

            var result = new List<OrderDetail>();
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var orderD = LoadOrderDetail(dr); // Mapper
                       result.Add(orderD);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo OrderDetail desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto OrderDetail.</returns>
        private static OrderDetail LoadOrderDetail(IDataReader dr)
        {
            var orderD = new OrderDetail
            {
                Id = GetDataValue<int>(dr, "Id"),
                OrderId = GetDataValue<int>(dr, "OrderId"),
                ProductId = GetDataValue<int>(dr, "ProductId"),
                Price = GetDataValue<double>(dr, "Price"),
                Quantity = GetDataValue<int>(dr, "Quantity"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return orderD;
        }

    }
}
