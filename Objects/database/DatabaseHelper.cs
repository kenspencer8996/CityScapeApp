using Microsoft.Maui.Controls;

using Dapper;
using System.Linq;
using CityScapeApp.Objects.Entities;

namespace CityScapeApp.Objects.database
{
    internal class DatabaseHelper
    {
        internal string dbname = "cityscapedb.db";
        List<string> databasesTables = new List<string>();
        string currentPath;
        internal DatabaseHelper()
        {
            currentPath = AppDomain.CurrentDomain.BaseDirectory;
            dbname = Path.Combine(currentPath, dbname);
        }
        internal void CheckOrCreateDB()
        {
            try
            {
                SettingEntity droptablesetting = Global.GettingSetting("dbname");
                droptablesetting.IntSetting = 1;
                if (DBExists() == false)
                {
                    CreateDB();
                }
                CreateTableListAsync();
                if (droptablesetting.IntSetting == 1)
                {
                    DropAllTables();
                }
                CreateTables();
                SettingsRepository settingsRepository = new SettingsRepository(GetConnection());
                Global.Settings = settingsRepository.GetSetting();
                if (Global.Settings.Count == 0)
                {
                    Global.InsertSetting("droptables", "true", 1);
                    Global.InsertSetting("emaillog", "true", 1);
                    Global.InsertSetting("aninationTime", "15000", 1);
                }
                SettingEntity thisSetting = Global.GetSettingByName("travelspeed");
                if (thisSetting == null || thisSetting.Name == "")
                    Global.InsertSetting("travelspeed", "", 10);
                 thisSetting = Global.GetSettingByName("campfire");
                if (thisSetting == null || thisSetting.Name == "")
                    Global.InsertSetting("campfire", "", 5);
                thisSetting = Global.GetSettingByName("badguycount");
                if (thisSetting == null || thisSetting.Name == "")
                    Global.InsertSetting("badguycount", "", 1);
                thisSetting = Global.GetSettingByName("policecarspeed");
                if (thisSetting == null || thisSetting.Name == "")
                    Global.InsertSetting("policecarspeed", "", 15);
                thisSetting = Global.GetSettingByName("policecarspeed");
                if (thisSetting == null || thisSetting.Name == "")
                    Global.InsertSetting("campfiresleeptime", "", 10);

                
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        private void DropAllTables()
        {
            var connection = GetConnection();
            var command = new SQLiteCommand();
            command.Connection = connection;

  
                try
                {
                      command.CommandText = @"drop TABLE Person";
                      if (DoesTableExist("Person"))
                        command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }
            try
            {
                    command.CommandText = @"drop TABLE PersonImage";

                if (DoesTableExist("PersonImage"))
                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {
                     command.CommandText = @"drop TABLE House";

                if (DoesTableExist("House"))
                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {
                    command.CommandText = @"drop TABLE Business";

                if (DoesTableExist("Business"))
                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task CreateTableListAsync()
        {
            var connection = GetConnection();
            string checksql = "SELECT name FROM sqlite_master WHERE type='table';";
            List<string> tables = new List<string>();
            var tablese =await connection.QueryAsync<string>(checksql);
            foreach (var row in tablese) 
            {
                databasesTables.Add(row);
            }
    
        }
        private bool DoesTableExist(string tableName)
        {
            bool result = false;
            try
            {
               var found = from t in databasesTables where t == tableName select t;
               if (found != null && found.Count() > 0) 
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        internal SQLiteConnection GetConnection()
        {
            string connectionString = $"Data Source={dbname};Version=3";
            SQLiteConnection connection;
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {

                throw;
            }
           return connection;
        }
        private bool DBExists()
        {
            bool exists = false;
            if (File.Exists(dbname))
                exists = true;
            return exists;
        }
        private void CreateDB()
        {
            try
            {
                SQLiteConnection.CreateFile(dbname);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void CreateTables()
        {
            var connection =GetConnection();
            var command = new SQLiteCommand();
            command.Connection = connection;

            try
            {

                try
                {
                    command.CommandText = @"
                CREATE TABLE if not exists  Person (
                    PersonID INTEGER PRIMARY KEY,
                    Name TEXT, 
                    CurrentImageKey integer,
                    PersonRole TEXT, 
                    IsUser INTEGER,
                    Funds REAL,
                    CurrentImage TEXT
                )";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }

                command.CommandText = @"
                CREATE TABLE if not exists   PersonImage (
                    PersonImageID INTEGER PRIMARY KEY,
                    Name TEXT, 
                    PersonImageType TEXT, 
                    FilePath TEXT, 
                    ImageType TEXT, 
                    FKPersonID INTEGER,
                    PersonImageStatus TEXT
                )";
                command.ExecuteNonQuery();
                command.CommandText = @"
                CREATE TABLE  if not exists House (
                    HouseID INTEGER PRIMARY KEY,
                    Name TEXT, 
                    OwnerName TEXT, 
                    imageFileName TEXT, 
                    ImageLivingRoomFileName TEXT, 
                    ImageKitchenFileName TEXT, 
                    ImageGarageFileName TEXT, 
                    IsUserHouse INTEGER
                )";
                command.ExecuteNonQuery();
               
                command.CommandText = @"
                CREATE TABLE  if not exists Business (
                   BusinessID INTEGER PRIMARY KEY,
                   Name TEXT, 
                   BusinessType TEXT, 
                   ImageName TEXT,
                   EmployeePayHour NUMERIC 
                )";
                command.ExecuteNonQuery();

                if (DoesTableExist("Settings") == false)
                {
                    command.CommandText = @"
                        CREATE TABLE  if not exists Settings (
                           SettingID INTEGER PRIMARY KEY,
                           Name TEXT, 
                           StringSetting TEXT, 
                           IntSetting INT
                        )";
                    command.ExecuteNonQuery();

                }
                command.CommandText = @"
                        CREATE TABLE  if not exists Logging (
                           LoggingID INTEGER PRIMARY KEY,
                           ClassName TEXT, 
                           MethodName TEXT, 
                           Message TEXT,
                           RunTime NUMERIC
                        )";
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
