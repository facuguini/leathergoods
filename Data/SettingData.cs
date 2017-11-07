using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class SettingData : DataAccessComponent
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public Setting Create(Setting setting)
        {
            const string sqlStatement = "INSERT INTO dbo.Setting ([Name], [Value], [Description], [WebSiteName], [WebSiteUrl], [PageTitle], [AdminEmailAddress], [SMTP], [SMTPUsername], [SMTPPassword], [SMTPPort], [SMTPEnableSSL], [Theme], [DefaultLanguageId], [CreatedBy]) " +
                "VALUES(@Name, @Value, @Description, @WebSiteName, @WebSiteUrl, @PageTitle, @AdminEmailAddress, @SMTP, @SMTPUsername, @SMTPPassword, @SMTPPort, @SMTPEnableSSL, @Theme, @DefaultLanguageId, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Name", setting.Name));
               cmd.Parameters.Add(Db.CreateParameter("@Value", setting.Value));
               cmd.Parameters.Add(Db.CreateParameter("@Description", setting.Description));
               cmd.Parameters.Add(Db.CreateParameter("@WebSiteName", setting.WebSiteName));
               cmd.Parameters.Add(Db.CreateParameter("@WebSiteUrl", setting.WebSiteUrl));
               cmd.Parameters.Add(Db.CreateParameter("@PageTitle", setting.PageTitle));
               cmd.Parameters.Add(Db.CreateParameter("@AdminEmailAddress", setting.AdminEmailAddress));
               cmd.Parameters.Add(Db.CreateParameter("@SMTP", setting.SMTP));
               cmd.Parameters.Add(Db.CreateParameter("@SMTPUsername", setting.SMTPUsername));
               cmd.Parameters.Add(Db.CreateParameter("@SMTPPassword", setting.SMTPPassword));
               cmd.Parameters.Add(Db.CreateParameter("@SMTPPort", setting.SMTPPort));
               cmd.Parameters.Add(Db.CreateParameter("@SMTPEnableSSL", setting.SMTPEnableSSL));
               cmd.Parameters.Add(Db.CreateParameter("@Theme", setting.Theme));
               cmd.Parameters.Add(Db.CreateParameter("@DefaultLanguageId", setting.DefaultLanguageId));
               cmd.Parameters.Add(Db.CreateParameter("@CreatedBy", setting.CreatedBy));
               // Obtener el valor de la primary key.
               setting.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return setting;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="product"></param>
        public void UpdateById(Setting setting)
        {
            const string sqlStatement = "UPDATE dbo.Setting " +
                "SET [Name]=@Name, " +
                    "[Value]=@Value, " +
                    "[Description]=@Description, " +
                    "[WebSiteName]=@WebSiteName, " +
                    "[WebSiteUrl]=@WebSiteUrl, " +
                    "[PageTitle]=@PageTitle, " +
                    "[AdminEmailAddress]=@AdminEmailAddress, " +
                    "[SMTP]=@SMTP, " +
                    "[SMTPUsername]=@SMTPUsername, " +
                    "[SMTPPassword]=@SMTPPassword, " +
                    "[SMTPPort]=@SMTPPort, " +
                    "[SMTPEnableSSL]=@SMTPEnableSSL, " +
                    "[Theme]=@Theme, " +
                    "[DefaultLanguageId]=@DefaultLanguageId, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Name", setting.Name));
               cmd.Parameters.Add(Db.CreateParameter("@Value", setting.Value));
               cmd.Parameters.Add(Db.CreateParameter("@Description", setting.Description));
               cmd.Parameters.Add(Db.CreateParameter("@WebSiteName", setting.WebSiteName));
               cmd.Parameters.Add(Db.CreateParameter("@WebSiteUrl", setting.WebSiteUrl));
               cmd.Parameters.Add(Db.CreateParameter("@PageTitle", setting.PageTitle));
               cmd.Parameters.Add(Db.CreateParameter("@AdminEmailAddress", setting.AdminEmailAddress));
               cmd.Parameters.Add(Db.CreateParameter("@SMTP", setting.SMTP));
               cmd.Parameters.Add(Db.CreateParameter("@SMTPUsername", setting.SMTPUsername));
               cmd.Parameters.Add(Db.CreateParameter("@SMTPPassword", setting.SMTPPassword));
               cmd.Parameters.Add(Db.CreateParameter("@SMTPPort", setting.SMTPPort));
               cmd.Parameters.Add(Db.CreateParameter("@SMTPEnableSSL", setting.SMTPEnableSSL));
               cmd.Parameters.Add(Db.CreateParameter("@Theme", setting.Theme));
               cmd.Parameters.Add(Db.CreateParameter("@DefaultLanguageId", setting.DefaultLanguageId));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedOn", setting.ChangedOn));
               cmd.Parameters.Add(Db.CreateParameter("@ChangedBy", setting.ChangedBy));
               cmd.Parameters.Add(Db.CreateParameter("@Id", setting.Id));

               cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Setting WHERE [Id]=@Id ";
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
        public Setting SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Name], [Value], [Description], [LastChangeDate], [WebSiteName], [WebSiteUrl], [PageTitle], [AdminEmailAddress], [SMTP], [SMTPUsername], [SMTPPassword], [SMTPPort], [SMTPEnableSSL], [Theme], [DefaultLanguageId], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Setting WHERE [Id]=@Id ";

            Setting setting = null;
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               cmd.Parameters.Add(Db.CreateParameter("@Id", id));
               using (var dr = cmd.ExecuteReader())
               {
                   if (dr.Read()) setting = LoadSetting(dr);
               }
            }

            return setting;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<Setting> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Name], [Value], [Description], [LastChangeDate], [WebSiteName], [WebSiteUrl], [PageTitle], [AdminEmailAddress], [SMTP], [SMTPUsername], [SMTPPassword], [SMTPPort], [SMTPEnableSSL], [Theme], [DefaultLanguageId], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Setting ";

            var result = new List<Setting>();
            var connection = Db.CreateConnection();
            using (var cmd = Db.CreateCommand(sqlStatement, connection))
            {
               using (var dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var setting = LoadSetting(dr); // Mapper
                       result.Add(setting);
                   }
               }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo Setting desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Setting.</returns>
        private static Setting LoadSetting(IDataReader dr)
        {
            var setting = new Setting
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                Value = GetDataValue<string>(dr, "Value"),
                Description = GetDataValue<string>(dr, "Description"),
                LastChangeDate = GetDataValue<DateTime>(dr, "LastChangeDate"),
                WebSiteName = GetDataValue<string>(dr, "WebSiteName"),
                WebSiteUrl = GetDataValue<string>(dr, "WebSiteUrl"),
                PageTitle = GetDataValue<string>(dr, "PageTitle"),
                AdminEmailAddress = GetDataValue<string>(dr, "AdminEmailAddress"),
                SMTP = GetDataValue<string>(dr, "SMTP"),
                SMTPUsername = GetDataValue<string>(dr, "SMTPUsername"),
                SMTPPassword = GetDataValue<string>(dr, "SMTPPassword"),
                SMTPPort = GetDataValue<string>(dr, "SMTPPort"),
                SMTPEnableSSL = GetDataValue<bool>(dr, "SMTPEnableSSL"),
                Theme = GetDataValue<string>(dr, "Theme"),
                DefaultLanguageId = GetDataValue<int>(dr, "DefaultLanguageId"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return setting;
        }

    }
}
