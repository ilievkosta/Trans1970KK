using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;

namespace Trans1970KK
{
    public partial class App : Application
    {
        public static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbCord.db3");
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            var db = new SQLiteConnection(App.dbPath);

            db.CreateTable<Cord>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
