using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class CategoryData : DataAccessComponent
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Category> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Category ";

            var result = new List<Category>();
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var category = LoadCategory(dr); // Mapper
                        result.Add(category);
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
        public Category SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Category WHERE [Id]=@Id ";

            Category category = null;
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
                cmd.Parameters.Add(Db.CreateParameter("@Id", id));
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read()) category = LoadCategory(dr);
                }
            }

            return category;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Category Create(Category category)
        {
            const string sqlStatement ="INSERT INTO dbo.Category ([Name], [CreatedOn], [CreatedBy]) " +
                "VALUES(@Name, @CreatedOn, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
                cmd.Parameters.Add(Db.CreateParameter("@Name", category.Name));
                cmd.Parameters.Add(Db.CreateParameter("@CreatedOn", DateTime.Now));
                cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", category.CreatedBy));
                category.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return category;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="category"></param>
        public void UpdateById(Category category)
        {
            const string sqlStatement = "UPDATE dbo.Category " +
                "SET [Name]=@Name, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
                cmd.Parameters.Add(Db.CreateParameter("@Name", category.Name));
                cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", DateTime.Now));
                cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", category.ChangedBy));
                cmd.Parameters.Add(Db.CreateParameter("@Id", category.Id));

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Category WHERE [Id]=@Id ";
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
                cmd.Parameters.Add(Db.CreateParameter("@Id", id));
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Crea una nueva Categoría desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Categoria.</returns>
        private static Category LoadCategory(IDataReader dr)
        {
            var category = new Category
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return category;
        }

    }
}
