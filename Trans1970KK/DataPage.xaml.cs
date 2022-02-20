using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
namespace Trans1970KK
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbCord.db3");
        public DataPage()
        {

            InitializeComponent();
            var db = new SQLiteConnection(App.dbPath);
            var table = db.Table<Cord>();
            CordView.ItemsSource = table;
        }
        private void Del_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            //Customer customer = db.GetWithChildren<Customer>("1", recursive: true);
            // db.Delete(customer, recursive: true);
            var db = new SQLiteConnection(App.dbPath);
            var idCordDel = btn.ClassId;
            db.Delete<Cord>(idCordDel);
            var table = db.Table<Cord>();
            CordView.ItemsSource = table;
            DisplayAlert("Съобщение", "Записа е изтрит" , "OK");
        }
    }
}