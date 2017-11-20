using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class RoleData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public Role Create(Role Role)
        {
            const string sqlStatement = "INSERT INTO AspNetRoles (Name) VALUES " +
                "(@Name); SELECT LAST_INSERT_ID();";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Name", Role.Name));
               // Obtener el valor de la primary key.
               Role.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return Role;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="product"></param>
        public void UpdateById(Role Role)
        {
            throw new NotImplementedException();
            // const string sqlStatement = "UPDATE dbo.Role " +
            //     "SET [Name]=@Name, " +
            //         "[Value]=@Value, " +
            //         "[Description]=@Description, " +
            //         "[WebSiteName]=@WebSiteName, " +
            //         "[WebSiteUrl]=@WebSiteUrl, " +
            //         "[PageTitle]=@PageTitle, " +
            //         "[AdminEmailAddress]=@AdminEmailAddress, " +
            //         "[SMTP]=@SMTP, " +
            //         "[SMTPRolename]=@SMTPRolename, " +
            //         "[SMTPPassword]=@SMTPPassword, " +
            //         "[SMTPPort]=@SMTPPort, " +
            //         "[SMTPEnableSSL]=@SMTPEnableSSL, " +
            //         "[Theme]=@Theme, " +
            //         "[DefaultLanguageId]=@DefaultLanguageId, " +
            //         "[ChangedOn]=@ChangedOn, " +
            //         "[ChangedBy]=@ChangedBy " +
            //     "WHERE [Id]=@Id ";

            // var connection = Db.CreateOpenConnection();
            // using (var cmd = Db.CreateCommand(sqlStatement, connection))
            // {
            //    cmd.Parameters.Add(Db.CreateParameter("@Name", Role.Name));
            //    cmd.Parameters.Add(Db.CreateParameter("@Value", Role.Value));
            //    cmd.Parameters.Add(Db.CreateParameter("@Description", Role.Description));
            //    cmd.Parameters.Add(Db.CreateParameter("@WebSiteName", Role.WebSiteName));
            //    cmd.Parameters.Add(Db.CreateParameter("@WebSiteUrl", Role.WebSiteUrl));
            //    cmd.Parameters.Add(Db.CreateParameter("@PageTitle", Role.PageTitle));
            //    cmd.Parameters.Add(Db.CreateParameter("@AdminEmailAddress", Role.AdminEmailAddress));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTP", Role.SMTP));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTPRolename", Role.SMTPRolename));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTPPassword", Role.SMTPPassword));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTPPort", Role.SMTPPort));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTPEnableSSL", Role.SMTPEnableSSL));
            //    cmd.Parameters.Add(Db.CreateParameter("@Theme", Role.Theme));
            //    cmd.Parameters.Add(Db.CreateParameter("@DefaultLanguageId", Role.DefaultLanguageId));
            //    cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", Role.ChangedOn));
            //    cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", Role.ChangedBy));
            //    cmd.Parameters.Add(Db.CreateParameter("@Id", Role.Id));

            //    cmd.ExecuteNonQuery();
            // }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE FROM AspNetRoles WHERE Id = @Id ";
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
        public Role SelectById(int id)
        {
            const string sqlStatement = "SELECT * FROM AspNetRoles WHERE Id = @Id;";

            Role Role = null;
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) Role = LoadRole(dr);
               }
            }

            return Role;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Role> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT * FROM AspNetRoles";

            var result = new List<Role>();
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var Role = LoadRole(dr); // Mapper
                       result.Add(Role);
                   }
               }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Role> SelectByUserId(int id)
        {
            const string sqlStatement = "SELECT a.Id, a.Name FROM AspNetRoles a " +
                "JOIN AspNetUserRoles b ON a.Id = b.RoleId WHERE b.UserId = @userId;";

            var result = new List<Role>();
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@userId", id));
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var Role = LoadRole(dr); // Mapper
                       result.Add(Role);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo Role desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Role.</returns>
        private static Role LoadRole(IDataReader dr)
        {
            var Role = new Role
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name")
            };
            return Role;
        }

    }
}
