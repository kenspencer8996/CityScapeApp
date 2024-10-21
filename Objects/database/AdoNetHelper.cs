using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.database
{
    internal class AdoNetHelper
    {
        DatabaseHelper databaseHelper;
        internal AdoNetHelper()
        {
            databaseHelper = new DatabaseHelper();
           // databaseHelper.CheckOrCreateDB();
        }
        internal SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = databaseHelper.GetConnection();
            return connection;
        }
    }
}
