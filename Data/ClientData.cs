using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class ClientData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public Client Create(Client client)
        {
            const string sqlStatement = "INSERT INTO dbo.Client ([FirstName], [LastName], [Email], [CountryId], " +
                "[AspNetUsers], [City], [CreatedOn], [CreatedBy]) VALUES(@FirstName, @LastName, @Email, @CountryId, " +
                "@AspNetUsers, @City, @CreatedOn, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@FirstName", client.FirstName));
               cmd.Parameters.Add(Db.CreateParameter("@LastName", client.LastName));
               cmd.Parameters.Add(Db.CreateParameter("@Email", client.Email));
               cmd.Parameters.Add(Db.CreateParameter("@CountryId", client.CountryId));
               cmd.Parameters.Add(Db.CreateParameter("@AspNetUsers", client.AspNetUsers));
               cmd.Parameters.Add(Db.CreateParameter("@City", client.City));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedOn", DateTime.Now));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", client.CreatedBy));
               // Obtener el valor de la primary key.
               client.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return client;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="client"></param>
        public void UpdateById(Client client)
        {
            const string sqlStatement = "UPDATE dbo.Client " +
                "SET [FirstName]=@FirstName, " +
                    "[LastName]=@LastName, " +
                    "[Email]=@Email, " +
                    "[CountryId]=@CountryId, " +
                    "[AspNetUsers]=@AspNetUsers, " +
                    "[City]=@City, " +
                    "[OrderCount]=@OrderCount, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@FirstName", client.FirstName));
               cmd.Parameters.Add(Db.CreateParameter("@LastName", client.LastName));
               cmd.Parameters.Add(Db.CreateParameter("@Email", client.Email));
               cmd.Parameters.Add(Db.CreateParameter("@CountryId", client.CountryId));
               cmd.Parameters.Add(Db.CreateParameter("@AspNetUsers", client.AspNetUsers));
               cmd.Parameters.Add(Db.CreateParameter("@City", client.City));
               cmd.Parameters.Add(Db.CreateParameter("@OrderCount", client.OrderCount));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", DateTime.Now));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", client.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", client.Id));

               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Client WHERE [Id]=@Id ";
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
        public Client SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Client WHERE [Id]=@Id ";

            Client client = null;
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) client = LoadClient(dr);
               }
            }

            return client;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Client> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Client ";

            var result = new List<Client>();
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var client = LoadClient(dr); // Mapper
                       result.Add(client);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo Cliente desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Cliente.</returns>
        private static Client LoadClient(IDataReader dr)
        {
            var client = new Client
            {
                Id = GetDataValue<int>(dr, "Id"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                LastName = GetDataValue<string>(dr, "LastName"),
                Email = GetDataValue<string>(dr, "Email"),
                CountryId = GetDataValue<int>(dr, "CountryId"),
                AspNetUsers = GetDataValue<string>(dr, "AspNetUsers"),
                City = GetDataValue<string>(dr, "City"),
                SignupDate = GetDataValue<DateTime>(dr, "SignupDate"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                OrderCount = GetDataValue<int>(dr, "OrderCount"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return client;
        }

    }
}
