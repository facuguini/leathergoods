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
    public class CountryData : DataAccessComponent
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="Country"></param>
        /// <returns></returns>
        public Country Create(Country Country)
        {
            const string sqlStatement = "INSERT INTO dbo.Country ([Name], [CreatedOn], [CreatedBy]) " +
                "VALUES(@Name, @CreatedOn, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Name", Country.Name));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedOn", Country.CreatedOn));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", Country.CreatedBy));
               // Obtener el valor de la primary key.
               Country.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return Country;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Country"></param>
        public void UpdateById(Country Country)
        {
            const string sqlStatement = "UPDATE dbo.Country " +
                "SET [Name]=@Name, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Name", Country.Name));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", Country.ChangedOn));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", Country.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", Country.Id));

               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Country WHERE [Id]=@Id ";
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
        public Country SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Country WHERE [Id]=@Id ";

            Country Country = null;
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) Country = LoadCountry(dr);
               }
            }

            return Country;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Country> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Country ";

            var result = new List<Country>();
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var Country = LoadCountry(dr); // Mapper
                       result.Add(Country);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea una nueva Categoría desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Categoria.</returns>
        private static Country LoadCountry(IDataReader dr)
        {
            var Country = new Country
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return Country;
        }
    }
}

