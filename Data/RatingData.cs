using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class RatingData : DataAccessComponent
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public Rating Create(Rating rating)
        {
            const string sqlStatement = "INSERT INTO dbo.Rating ([ClientId], [ProductId], [Stars], [CreatedBy]) " +
                "VALUES(@ClientId, @ProductId, @Stars, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@ClientId", rating.ClientId));
               cmd.Parameters.Add(Db.CreateParameter("@ProductId", rating.ProductId));
               cmd.Parameters.Add(Db.CreateParameter("@Stars", rating.Stars));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", rating.CreatedBy));
               // Obtener el valor de la primary key.
               rating.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return rating;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rating"></param>
        public void UpdateById(Rating rating)
        {
            const string sqlStatement = "UPDATE dbo.Rating " +
                "SET [ClientId]=@ClientId, " +
                    "[ProductId]=@ProductId, " +
                    "[Stars]=@Stars, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@ClientId", rating.ClientId));
               cmd.Parameters.Add(Db.CreateParameter("@ProductId", rating.ProductId));
               cmd.Parameters.Add(Db.CreateParameter("@Stars", rating.Stars));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", rating.ChangedOn));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", rating.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", rating.Id));

               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Rating WHERE [Id]=@Id ";
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
        public Rating SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [ProductId], [Stars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Rating WHERE [Id]=@Id ";

            Rating rating = null;
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) rating = LoadRating(dr);
               }
            }

            return rating;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Rating> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [ClientId], [ProductId], [Stars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Rating ";

            var result = new List<Rating>();
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var rating = LoadRating(dr); // Mapper
                       result.Add(rating);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo Rating desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Rating.</returns>
        private static Rating LoadRating(IDataReader dr)
        {
            var rating = new Rating
            {
                Id = GetDataValue<int>(dr, "Id"),
                ClientId = GetDataValue<int>(dr, "ClientId"),
                ProductId = GetDataValue<int>(dr, "ProductId"),
                Stars = GetDataValue<int>(dr, "Stars"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return rating;
        }

    }
}
