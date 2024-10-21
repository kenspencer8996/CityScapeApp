using CityScapeApp.Objects.Entities;
using Dapper;
using System.Data.SQLite;

namespace CityScapeApp.Objects.database
{
    public class SettingsRepository
    {
        SQLiteConnection _connection;
        public SettingsRepository(SQLiteConnection connection) 
        { 
            _connection = connection;
        }
        public  List<SettingEntity> GetSetting()
        {
            List<SettingEntity> Setting = new List<SettingEntity>();
            try
            {
                
                var sql = "SELECT * FROM Settings";
                var results =  _connection.Query<SettingEntity>(sql);
                if (results != null && results.Any())
                {
                    Setting = results.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Setting;
        }
        public  SettingEntity GetSettingbyName(string name)
        {
            List<SettingEntity> Setting = new List<SettingEntity>();
            try
            {
                
                var sql = "SELECT * FROM Settings where name  = " + "'" + name + "' ";
                var results =  _connection.Query<SettingEntity>(sql);
                if (results != null && results.Any())
                {
                    Setting = results.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            SettingEntity Settingout = new SettingEntity();
            if (Setting.Any())
                Settingout = Setting.FirstOrDefault();
            return Settingout;
        }
   
        public  void UpsertSetting(SettingEntity Setting)
        {
            bool result = false;
            SettingEntity Settingfound =  GetSettingbyName(Setting.Name);
            
            if (Settingfound != null && Settingfound.Name != "")
            {
                try
                {   
                    string sqlraw = "Update Settings ";
                    sqlraw += "Set Name = " + "'" + Setting.Name + "', ";
                    sqlraw += "StringSetting = '" + Setting.StringSetting + "', ";
                    sqlraw += "IntSetting = " + Setting.IntSetting + " where SettingID = " + Setting.SettingID;
                    
                    var command = new SQLiteCommand();
                    command.Connection = _connection;
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
                    string sqlraw = "INSERT INTO Settings ( Name,StringSetting,IntSetting) ";
                    sqlraw += "VALUES('" + Setting.Name + "','" + Setting.StringSetting + "', ";
                    sqlraw+= "" + Setting.IntSetting + ")"; 
                    var command = new SQLiteCommand();
                    command.Connection = _connection;
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
