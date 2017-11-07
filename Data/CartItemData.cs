using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    /// <summary>
    ///
    /// </summary>
    public class CartItemData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="cartitem"></param>
        /// <returns></returns>
        public CartItem Create(CartItem cartitem)
        {
            const string sqlStatement = "INSERT INTO dbo.CartItem ([CartId], [ProductId], [Price] , [Quantity], [CreatedBy]) " +
                "VALUES(@CartId, @ProductId, @Price, @Quantity, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@CartId", cartitem.CartId));
               cmd.Parameters.Add(Db.CreateParameter("@ProductId", cartitem.ProductId));
               cmd.Parameters.Add(Db.CreateParameter("@Price", cartitem.Price));
               cmd.Parameters.Add(Db.CreateParameter("@Quantity", cartitem.Quantity));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", cartitem.CreatedBy));
               // Obtener el valor de la primary key.
               cartitem.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return cartitem;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cartiitem"></param>
        public void UpdateById(CartItem cartitem)
        {
            const string sqlStatement = "UPDATE dbo.CartItem " +
                "SET [ProductId]=@ProductId, " +
                    "[Price]=@Price, " +
                    "[Quantity]=@Quantity, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@CartId", cartitem.CartId));
               cmd.Parameters.Add(Db.CreateParameter("@ProductId", cartitem.ProductId));
               cmd.Parameters.Add(Db.CreateParameter("@Price", cartitem.Price));
               cmd.Parameters.Add(Db.CreateParameter("@Quantity", cartitem.Quantity));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", cartitem.ChangedOn));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", cartitem.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", cartitem.Id));
               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.CartItem WHERE [Id]=@Id ";
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
        public CartItem SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [CartId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.CartItem WHERE [Id]=@Id ";

            CartItem cartitem = null;
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) cartitem = LoadCartItem(dr);
               }
            }

            return cartitem;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<CartItem> Select()
        {
            const string sqlStatement = "SELECT [Id], [CartId], [ProductId], [Price] , [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.CartItem ";

            var result = new List<CartItem>();
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var cartitem = LoadCartItem(dr); // Mapper
                       result.Add(cartitem);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo CartItem desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto CartItem.</returns>
        private static CartItem LoadCartItem(IDataReader dr)
        {
            var cartitem = new CartItem
            {
                Id = GetDataValue<int>(dr, "Id"),
                CartId = GetDataValue<int>(dr, "CartId"),
                ProductId = GetDataValue<int>(dr, "ProductId"),
                Price = GetDataValue<double>(dr, "Price"),
                Quantity = GetDataValue<int>(dr, "Quantity"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return cartitem;
        }

    }
}
