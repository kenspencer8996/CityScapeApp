using CityScapeApp.Objects.Entities;
using Dapper;
using Microsoft.Maui.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Xml.Linq;

namespace CityScapeApp.Objects.database
{
    public class PersonImageImageRepository
    {
        AdoNetHelper adoNetHelper = new AdoNetHelper();

        public async Task<List<PersonImageEntity>> GetPersonImagesAsync()
        {
            List<PersonImageEntity> PersonImages = new List<PersonImageEntity>();
            try
            {
                var connection = adoNetHelper.GetConnection();
                var sql = "SELECT * FROM PersonImage";
                var results = await connection.QueryAsync<PersonImageEntity>(sql);
                if (results != null && results.Any())
                {
                    PersonImages = results.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return PersonImages;
        }
        public async Task<PersonImageEntity> GetPersonImagebyNameAsync(string name)
        {
            List<PersonImageEntity> PersonImages = new List<PersonImageEntity>();
            PersonImageEntity results = new PersonImageEntity();
            try
            {
                var connection = adoNetHelper.GetConnection();
                var sql = "SELECT Name,FilePath,PersonImageType,ImageType,FKPersonId FROM PersonImage where name  = " + "'" + name + "' ";
                //var results = await connection.QueryAsync<PersonImageEntity>(sql);
                var con = adoNetHelper.GetConnection();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Name = reader.GetString("name");
                            results.FilePath = reader.GetString("name");
                            PersonImageTypeEnum imagetype = PersonImageTypeEnum.Normal;
                            switch (reader.GetString("PersonImageType"))
                            {
                                case "Normal":
                                    imagetype = PersonImageTypeEnum.Normal;
                                    break;
                                case "Working":
                                    imagetype = PersonImageTypeEnum.Working;
                                    break;
                                case "BadGuy":
                                    imagetype = PersonImageTypeEnum.BadGuy;
                                    break;
                                default:
                                    break;
                            }
                            results.PersonImageType = imagetype;
                            results.ImageType = reader.GetString(3);
                            results.FKPersonId = reader.GetInt32("FKPersonId");

                            Console.WriteLine($"Hello, {name}!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    cmd = null;
                    con.Close();
                }
                //if (results != null && results.Any())
                //{
                //    PersonImages = results.ToList();
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
            //PersonImageEntity PersonImageout = new PersonImageEntity();
            //if (PersonImages.Any())
            //    PersonImageout = PersonImages.FirstOrDefault();
            //return PersonImageout;
            return results;
        }
   
        public async void UpsertPersonImage(PersonImageEntity PersonImage)
        {
            bool result = false;
            PersonImageEntity PersonImagefound = await GetPersonImagebyNameAsync(PersonImage.Name);
            var connection = adoNetHelper.GetConnection();
            if (PersonImagefound != null && PersonImagefound.Name != null && PersonImagefound.Name != "")
            {
                try
                {   
                    string sqlraw = "Update PersonImage ";
                    sqlraw += "Set Name = " + "'" + PersonImage.Name + "', ";
                    sqlraw += "FilePath = '" + PersonImage.FilePath + "', ";
                    sqlraw += "PersonImageType = '" + PersonImage.PersonImageType + "', ";
                    sqlraw += "PersonImageStatus = '" + PersonImage.PersonImageStatus + "', ";                   
                    sqlraw += "ImageType = " + "'" + PersonImage.ImageType + "', ";
                    sqlraw += "FKPersonId = " + "" + PersonImage.FKPersonId + " ";
                    sqlraw += "where PersonImageID = " + PersonImage.PersonImageID;

                    var command = new SQLiteCommand();
                    command.Connection = connection;
                    command.CommandText = sqlraw;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }
            } 
            else
            {
                try
                {                  
                    string sqlraw = "INSERT INTO PersonImage ( Name,FilePath,PersonImageType,ImageType,FKPersonId,PersonImageStatus) ";
                    sqlraw += "VALUES('" + PersonImage.Name + "','" + PersonImage.FilePath + "',";
                    sqlraw+= "'" + PersonImage.PersonImageType + "','" + PersonImage.ImageType + "'," + PersonImage.FKPersonId + ",'" + PersonImage.PersonImageStatus +  "')"; 
                    var command = new SQLiteCommand();
                    command.Connection = connection;
                    command.CommandText = sqlraw;
                    command.ExecuteNonQuery();
     
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
