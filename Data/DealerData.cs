using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class DealerData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name = "dealer" ></ param >
        /// < returns ></ returns >
        public Dealer Create(Dealer dealer)
        {
            const string sqlStatement = "INSERT INTO dbo.Dealer ([FirstName], [LastName], [CategoryId], [CountryId], [Description], [CreatedBy]) " +
                "VALUES(@FirstName, @LastName, @CategoryId, @CountryId, @Description, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@FirstName", dealer.FirstName));
               cmd.Parameters.Add(Db.CreateParameter("@LastName", dealer.LastName));
               cmd.Parameters.Add(Db.CreateParameter("@CategoryId", dealer.CategoryId));
               cmd.Parameters.Add(Db.CreateParameter("@CountryId", dealer.CountryId));
               cmd.Parameters.Add(Db.CreateParameter("@Description", dealer.Description));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", dealer.CreatedBy));
               // Obtener el valor de la primary key.
               dealer.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return dealer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dealer"></param>
        public void UpdateById(Dealer dealer)
        {
            const string sqlStatement = "UPDATE dbo.Dealer " +
                "SET [FirstName]=@FirstName, " +
                    "[LastName]=@LastName, " +
                    "[CategoryId]=@CategoryId, " +
                    "[CountryId]=@CountryId, " +
                    "[Description]=@Description, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@FirstName", dealer.FirstName));
               cmd.Parameters.Add(Db.CreateParameter("@LastName", dealer.LastName));
               cmd.Parameters.Add(Db.CreateParameter("@CategoryId", dealer.CategoryId));
               cmd.Parameters.Add(Db.CreateParameter("@CountryId", dealer.CountryId));
               cmd.Parameters.Add(Db.CreateParameter("@Description", dealer.Description));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", dealer.ChangedOn));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", dealer.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", dealer.Id));

               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Dealer WHERE [Id]=@Id ";
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
        public Dealer SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Dealer WHERE [Id]=@Id ";

            Dealer dealer = null;
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) dealer = LoadDealer(dr);
               }
            }

            return dealer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Dealer> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Dealer ";

            var result = new List<Dealer>();
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var dealer = LoadDealer(dr); // Mapper
                       result.Add(dealer);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo Dealer desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Dealer.</returns>
        private static Dealer LoadDealer(IDataReader dr)
        {
            var dealer = new Dealer
            {
                Id = GetDataValue<int>(dr, "Id"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                LastName = GetDataValue<string>(dr, "LastName"),
                CategoryId = GetDataValue<int>(dr, "CategoryId"),
                CountryId = GetDataValue<int>(dr, "CountryId"),
                Description = GetDataValue<string>(dr, "Description"),
                TotalProducts = GetDataValue<int>(dr, "TotalProducts"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return dealer;
        }

    }
}
