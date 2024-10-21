using CityScapeApp.Objects.Entities;

namespace CityScapeApp.Objects.database
{
    public class BusinessRepository
    {
        AdoNetHelper adoNetHelper = new AdoNetHelper();

        public async Task<List<BusinessEntity>> GetBusinesssAsync()
        {
            List<BusinessEntity> Businesss = new List<BusinessEntity>();
            try
            {
                var connection = adoNetHelper.GetConnection();
                var sql = "SELECT * FROM Business";
                var results = await connection.QueryAsync<BusinessEntity>(sql);
                if (results != null && results.Any())
                {
                    Businesss = results.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Businesss;
        }
        public async Task<BusinessEntity> GetBusinessbyNameAsync(string name)
        {
            List<BusinessEntity> Businesss = new List<BusinessEntity>();
            try
            {
                var connection = adoNetHelper.GetConnection();
                var sql = "SELECT * FROM Business where name  = " + "'" + name + "' ";
                var results = await connection.QueryAsync<BusinessEntity>(sql);
                if (results != null && results.Any())
                {
                    Businesss = results.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            BusinessEntity Businessout = new BusinessEntity();
            if (Businesss.Any())
                Businessout = Businesss.FirstOrDefault();
            return Businessout;
        }

        public async void UpsertBusiness(BusinessEntity Business)
        {
            bool result = false;
            BusinessEntity Businessfound = await GetBusinessbyNameAsync(Business.Name);
            var connection = adoNetHelper.GetConnection();
            if (Businessfound != null && Businessfound.Name != "")
            {
                try
                {
                    string sqlraw = "Update Business ";
                    sqlraw += "Set Name = " + "'" + Business.Name + "', ";
                    sqlraw += "EmployeePayHour = " + Business.EmployeePayHour + ", ";
                    sqlraw += "BusinessType = '" + Business.BusinessType + "', ";
                    sqlraw += "ImageName = " + "'" + Business.ImageName + "'";
                    sqlraw += "where BusinessID = " + Business.BusinessID;

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
                    string sqlraw = "INSERT INTO Business (Name, EmployeePayHour, BusinessType, ImageName)";
                    sqlraw += "VALUES('" + Business.Name + "'," + Business.EmployeePayHour + ",";
                    sqlraw += "'" + Business.BusinessType + "','" + Business.ImageName + "'" + ")"; 
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
