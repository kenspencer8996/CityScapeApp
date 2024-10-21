using CityScapeApp.Objects.Entities;
using Dapper;
using System.Data.SQLite;

namespace CityScapeApp.Objects.database
{
    public class PersonRepository
    {
        AdoNetHelper adoNetHelper = new AdoNetHelper();

        public async Task<List<PersonEntity>> GetPersonsAsync()
        {
            List<PersonEntity> Persons = new List<PersonEntity>();
            try
            {
                var connection = adoNetHelper.GetConnection();
                var sql = "SELECT * FROM Person";
                var results = await connection.QueryAsync<PersonEntity>(sql);
                if (results != null && results.Any())
                {
                    Persons = results.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Persons;
        }
        public async Task<PersonEntity> GetPersonbyNameAsync(string name)
        {
            List<PersonEntity> Persons = new List<PersonEntity>();
            try
            {
                var connection = adoNetHelper.GetConnection();
                var sql = "SELECT * FROM Person where name  = " + "'" + name + "' ";
                var results = await connection.QueryAsync<PersonEntity>(sql);
                if (results != null && results.Any())
                {
                    Persons = results.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            PersonEntity personout = new PersonEntity();
            if (Persons.Any())
                personout = Persons.FirstOrDefault();
            return personout;
        }
   
        public async Task<PersonEntity> UpsertPerson(PersonEntity person)
        {
            bool result = false;
            PersonEntity personfound = await GetPersonbyNameAsync(person.Name);
            var connection = adoNetHelper.GetConnection();
            int isuser = 0;
            if (person.IsUser)
            {
                isuser = 1;
            }
            PersonEntity newpersonfound = person;
            if (personfound != null && personfound.Name != "")
            {
                try
                {
                    string role = person.PersonRole.ToString();
                    string sqlraw = "Update Person ";
                    sqlraw += "Set Name = " + "'" + person.Name + "', ";
                    sqlraw += "IsUser = " + isuser + ", ";
                    sqlraw += "Funds = " + person.Funds + ", ";
                    sqlraw += "PersonRole = " + "'" + role + "', ";
                    sqlraw += "CurrentImage = " + "'" + person.CurrentImage + "', ";
                    sqlraw += "CurrentImageKey = " + "" + person.CurrentImageKey + " ";
                    sqlraw += "where PersonId = " + person.PersonId;
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
                    string role = person.PersonRole.ToString();
                    string sqlraw = "INSERT INTO person ( Name,IsUser,Funds,PersonRole,CurrentImageKey,CurrentImage) ";
                    sqlraw+= "VALUES('" + person.Name + "'," + isuser + ",0,'" + role + "'," + person.CurrentImageKey + ",'" + person.CurrentImage + "')"; 
                    var command = new SQLiteCommand();
                    command.Connection = connection;
                    command.CommandText = sqlraw;
                    command.ExecuteNonQuery();
                    //get person and return
                    newpersonfound = await GetPersonbyNameAsync(person.Name);

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return newpersonfound;
        }
    }
}
