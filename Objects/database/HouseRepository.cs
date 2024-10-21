using CityScapeApp.Objects.Entities;
using Dapper;
using System.Data.SQLite;

namespace CityScapeApp.Objects.database
{
    public class HouseRepository
    {
        AdoNetHelper adoNetHelper = new AdoNetHelper();

        public async Task<List<HouseEntity>> GetHousesAsync()
        {
            List<HouseEntity> Houses = new List<HouseEntity>();
            try
            {
                var connection = adoNetHelper.GetConnection();
                var sql = "SELECT * FROM House";
                var results = await connection.QueryAsync<HouseEntity>(sql);
                if (results != null && results.Any())
                {
                    Houses = results.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Houses;
        }
        public async Task<HouseEntity> GetHousebyNameAsync(string name)
        {
            List<HouseEntity> Houses = new List<HouseEntity>();
            try
            {
                var connection = adoNetHelper.GetConnection();
                var sql = "SELECT * FROM House where name  = " + "'" + name + "' ";
                var results = await connection.QueryAsync<HouseEntity>(sql);
                if (results != null && results.Any())
                {
                    Houses = results.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            HouseEntity Houseout = new HouseEntity("", "", "", "", "","",false);
            if (Houses.Any())
                Houseout = Houses.FirstOrDefault();
            return Houseout;
        }

        public async Task<HouseEntity> UpsertHouse(HouseEntity House)
        {
            bool result = false;
            HouseEntity Housefound = await GetHousebyNameAsync(House.Name);
            var connection = adoNetHelper.GetConnection();
            int isuser = 0;
            if (House.IsUserHouse)
            {
                isuser = 1;
            }
            HouseEntity newHousefound = House;
            if (Housefound != null && Housefound.Name != "")
            {
                try
                {
                    string sqlraw = "Update House ";
                    sqlraw += "Set Name = " + "'" + House.Name + "', ";
                    sqlraw += "IsUserHouse = " + isuser + ", ";
                    sqlraw += "OwnerName = '" + House.OwnerName + "', ";
                    sqlraw += "ImageFileName = '" + House.ImageFileName + "', ";
                    sqlraw += "ImageLivingRoomFileName = '" + House.ImageLivingRoomFileName + "', ";
                    sqlraw += "ImageKitchenFileName = '" + House.ImageKitchenFileName + "', ";
                    sqlraw += "ImageGarageFileName = '" + House.ImageGarageFileName + "' ";
                    sqlraw += "where HouseID = " + House.HouseID;

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
                    string sqlraw = "INSERT INTO House (Name, imageFileName, ImageLivingRoomFileName, ImageKitchenFileName, ImageGarageFileName,OwnerName,IsUserHouse) ";
                    sqlraw += "VALUES('" + House.Name + "','" + House.ImageFileName + "',";
                    sqlraw += "'" + House.ImageLivingRoomFileName + "','" + House.ImageKitchenFileName + "','" + House.ImageGarageFileName + "','" + House.OwnerName + "',"  + House.IsUserHouse + ")"; 
                    var command = new SQLiteCommand();
                    command.Connection = connection;
                    command.CommandText = sqlraw;
                    command.ExecuteNonQuery();
                    //get House and return
                    newHousefound = await GetHousebyNameAsync(House.Name);

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return newHousefound;
        }
    }
}
