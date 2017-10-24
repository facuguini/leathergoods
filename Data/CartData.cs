using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class CartData : DataAccessComponent
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Cart> Select()
        {
            const string sqlStatement = "SELECT [Id], [Cookie], [CartDate], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Cart ";
            var result = new List<Cart>();

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var cart = LoadCart(dr); // Mapper
                       result.Add(cart);
                   }
               }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cart SelectById(int id)
        {
            Cart cart = null;
            const string sqlStatement = "SELECT [Id], [Cookie], [CartDate], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Cart WHERE [Id]=@Id ";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               Db.CreateParameter("@Id", id);
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) cart = LoadCart(dr);
               }
            }

            return cart;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Cart Create(Cart cart)
        {
            const string sqlStatement = "INSERT INTO dbo.Cart ([Cookie], [CreatedBy]) " +
                "VALUES(@Cookie, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               Db.CreateParameter("@Cookie", cart.Cookie);
               Db.CreateParameter("@CreatedBy", cart.CreatedBy);
               cart.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return cart;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cart"></param>
        public void UpdateById(Cart cart)
        {
            const string sqlStatement = "UPDATE dbo.Cart " +
                "SET [Cookie]=@Cookie, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               Db.CreateParameter("@Cookie", cart.Cookie);
               Db.CreateParameter("@ChangedOn", cart.ChangedOn);
               Db.CreateParameter("@ChangedBy", cart.ChangedBy);
               Db.CreateParameter("@Id", cart.Id);
               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Cart WHERE [Id]=@Id ";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               Db.CreateParameter("@Id", id);
               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Crea un nuevo Cart desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Cart.</returns>
        private static Cart LoadCart(IDataReader dr)
        {
            var cart = new Cart
            {
                Id = GetDataValue<int>(dr, "Id"),
                Cookie = GetDataValue<string>(dr, "Cookie"),
                CartDate = GetDataValue<DateTime>(dr, "CartDate"),
                ItemCount = GetDataValue<int>(dr, "ItemCount"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return cart;
        }

    }
}
