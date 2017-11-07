using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class ProductData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product Create(Product product)
        {
            const string sqlStatement = "INSERT INTO dbo.Product ([Title], [Description], [DealerId], [Image], [Price], [CreatedBy]) " +
                "VALUES(@Title, @Description, @DealerId, @Image, @Price, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Title", product.Title));
               cmd.Parameters.Add(Db.CreateParameter("@Description", product.Description));
               cmd.Parameters.Add(Db.CreateParameter("@DealerId", product.DealerId));
               cmd.Parameters.Add(Db.CreateParameter("@Image", product.Image));
               cmd.Parameters.Add(Db.CreateParameter("@Price", product.Price));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", product.CreatedBy));
               // Obtener el valor de la primary key.
               product.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return product;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="product"></param>
        public void UpdateById(Product product)
        {
            const string sqlStatement = "UPDATE dbo.Product " +
                "SET [Title]=@Title, " +
                    "[Description]=@Description, " +
                    "[DealerId]=@DealerId, " +
                    "[Image]=@Image, " +
                    "[Price]=@Price, " +
                    "[QuantitySold]=@QuantitySold, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Title", product.Title));
               cmd.Parameters.Add(Db.CreateParameter("@Description", product.Description));
               cmd.Parameters.Add(Db.CreateParameter("@DealerId", product.DealerId));
               cmd.Parameters.Add(Db.CreateParameter("@Image", product.Image));
               cmd.Parameters.Add(Db.CreateParameter("@Price", product.Price));
               cmd.Parameters.Add(Db.CreateParameter("@QuantitySold", product.QuantitySold));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", product.ChangedOn));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", product.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", product.Id));
               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Product WHERE [Id]=@Id ";
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
        public Product SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Title], [Description], [DealerId], [Image], [Price], [QuantitySold], [AvgStars], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Product WHERE [Id]=@Id ";

            Product product = null;
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) product = LoadProduct(dr);
               }
            }

            return product;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Product> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Title], [Description], [DealerId], [Image], [Price], [QuantitySold], [AvgStars], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Product ";

            var result = new List<Product>();
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var product = LoadProduct(dr); // Mapper
                       result.Add(product);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo Product desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Product.</returns>
        private static Product LoadProduct(IDataReader dr)
        {
            var product = new Product
            {
                Id = GetDataValue<int>(dr, "Id"),
                Title = GetDataValue<string>(dr, "Title"),
                Description = GetDataValue<string>(dr, "Description"),
                DealerId = GetDataValue<int>(dr, "DealerId"),
                Image = GetDataValue<string>(dr, "Image"),
                Price = GetDataValue<double>(dr, "Price"),
                QuantitySold = GetDataValue<int>(dr, "QuantitySold"),
                AvgStars = GetDataValue<double>(dr, "AvgStars"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return product;
        }

    }
}
