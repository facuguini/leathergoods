using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class UserData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public User Create(User User)
        {
            const string sqlStatement = "INSERT INTO AspNetUsers (Email, EmailConfirmed, PasswordHash, SecurityStamp, " +
                "PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, " +
                "UserName) VALUES(@Email, @EmailConfirmed, @PasswordHash, @SecurityStamp, @PhoneNumber, @PhoneNumberConfirmed, " +
                "@TwoFactorEnabled, @LockoutEndDateUtc, @LockoutEnabled, @AccessFailedCount, @UserName); SELECT LAST_INSERT_ID();";

            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Email", User.Email));
               cmd.Parameters.Add(Db.CreateParameter("@EmailConfirmed", User.EmailConfirmed));
               cmd.Parameters.Add(Db.CreateParameter("@PasswordHash", User.PasswordHash));
               cmd.Parameters.Add(Db.CreateParameter("@SecurityStamp", User.SecurityStamp));
               cmd.Parameters.Add(Db.CreateParameter("@PhoneNumber", User.PhoneNumber));
               cmd.Parameters.Add(Db.CreateParameter("@PhoneNumberConfirmed", User.PhoneNumberConfirmed));
               cmd.Parameters.Add(Db.CreateParameter("@TwoFactorEnabled", User.TwoFactorEnabled));
               cmd.Parameters.Add(Db.CreateParameter("@LockoutEndDateUtc", User.LockoutEndDateUtc));
               cmd.Parameters.Add(Db.CreateParameter("@LockoutEnabled", User.LockoutEnabled));
               cmd.Parameters.Add(Db.CreateParameter("@AccessFailedCount", User.AccessFailedCount));
               cmd.Parameters.Add(Db.CreateParameter("@UserName", User.UserName));
               // Obtener el valor de la primary key.
               User.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return User;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="product"></param>
        public void UpdateById(User User)
        {
            throw new NotImplementedException();
            // const string sqlStatement = "UPDATE dbo.User " +
            //     "SET [Name]=@Name, " +
            //         "[Value]=@Value, " +
            //         "[Description]=@Description, " +
            //         "[WebSiteName]=@WebSiteName, " +
            //         "[WebSiteUrl]=@WebSiteUrl, " +
            //         "[PageTitle]=@PageTitle, " +
            //         "[AdminEmailAddress]=@AdminEmailAddress, " +
            //         "[SMTP]=@SMTP, " +
            //         "[SMTPUsername]=@SMTPUsername, " +
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
            //    cmd.Parameters.Add(Db.CreateParameter("@Name", User.Name));
            //    cmd.Parameters.Add(Db.CreateParameter("@Value", User.Value));
            //    cmd.Parameters.Add(Db.CreateParameter("@Description", User.Description));
            //    cmd.Parameters.Add(Db.CreateParameter("@WebSiteName", User.WebSiteName));
            //    cmd.Parameters.Add(Db.CreateParameter("@WebSiteUrl", User.WebSiteUrl));
            //    cmd.Parameters.Add(Db.CreateParameter("@PageTitle", User.PageTitle));
            //    cmd.Parameters.Add(Db.CreateParameter("@AdminEmailAddress", User.AdminEmailAddress));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTP", User.SMTP));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTPUsername", User.SMTPUsername));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTPPassword", User.SMTPPassword));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTPPort", User.SMTPPort));
            //    cmd.Parameters.Add(Db.CreateParameter("@SMTPEnableSSL", User.SMTPEnableSSL));
            //    cmd.Parameters.Add(Db.CreateParameter("@Theme", User.Theme));
            //    cmd.Parameters.Add(Db.CreateParameter("@DefaultLanguageId", User.DefaultLanguageId));
            //    cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", User.ChangedOn));
            //    cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", User.ChangedBy));
            //    cmd.Parameters.Add(Db.CreateParameter("@Id", User.Id));

            //    cmd.ExecuteNonQuery();
            // }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE FROM AspNetUsers WHERE Id = @Id ";
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
        public User SelectById(int id)
        {
            const string sqlStatement = "SELECT * FROM AspNetUsers WHERE Id = @Id;";

            User User = null;
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) User = LoadUser(dr);
               }
            }

            return User;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<User> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT * FROM AspNetUsers";

            var result = new List<User>();
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var User = LoadUser(dr); // Mapper
                       result.Add(User);
                   }
               }
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<User> SelectByUserName(string UserName)
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT * FROM AspNetUsers WHERE UserName = @UserName";

            var result = new List<User>();
            var connection = Db.CreateOpenConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@UserName", UserName));
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var User = LoadUser(dr); // Mapper
                       result.Add(User);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo User desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto User.</returns>
        private static User LoadUser(IDataReader dr)
        {
            var User = new User
            {
                Id = GetDataValue<int>(dr, "Id"),
                Email = GetDataValue<string>(dr, "Email"),
                PasswordHash = GetDataValue<string>(dr, "PasswordHash"),
                UserName = GetDataValue<string>(dr, "UserName")
            };
            return User;
        }

    }
}
