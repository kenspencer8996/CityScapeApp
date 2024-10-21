using CityScapeApp.Objects;
using CityScapeApp.Objects.database;
using CityScapeApp.Views;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace CityScapeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

           // MainPage = new CityscapeStreets();

             MainPage = new AppShell();

            //MainPage = new AppShell();

            //CityscapeStreets cityscapeStreets = new CityscapeStreets();
            //CityscapeStreetsViewModel model = new CityscapeStreetsViewModel();
            //cityscapeStreets.BindingContext = model;
            DatabaseHelper databaseHelper;
            Global.Log = new Logger();
            Global.SettingsRepository = new SettingsRepository(new DatabaseHelper().GetConnection());

            databaseHelper = new DatabaseHelper();
            databaseHelper.CheckOrCreateDB();

            //FlyoutMenu menu = new FlyoutMenu();
        }
    
        private void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            Global.WriteDebugOutput("unhandled " + e.Exception.Message);
            Debug.WriteLine($"***** Handling Unhandled Exception *****: {e.Exception.Message}");
            // YourLogger.LogError($"***** Handling Unhandled Exception *****: {e.Exception.Message}");
        }
    }
}
