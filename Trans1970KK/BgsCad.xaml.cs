using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace Trans1970KK
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        string url = "http://www.geo-bg.eu";
        string xpos = "1";
        string ypos = "1";
        string type = "1970";
        string xposWGS = "1";
        string yposWGS = "1";

        async void AddToDatabase(object sender, EventArgs e)
        {
            if (xpos == "1")
            {
                await DisplayAlert("Съобщение", "Не сте конвертирали координатите", "OK");
            }
            else
            {

                var db = new SQLiteConnection(App.dbPath);
  
                db.CreateTable<Cord>();
                Cord TransformedCoordinates = new Cord(xpos, ypos, NameCord.Text,type);
             
                db.Insert(TransformedCoordinates);


                await DisplayAlert("Съобщение", "Координатите са записани", "OK");

            }
        }
        public async Task OpenBrowser(Uri uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
        async void CheckCord_Clicked(object sender, EventArgs e)
        {
            if (xpos.Length > 2)
            {
                double wgsDx = Math.Round(Convert.ToDouble(xposWGS.Replace('.', ',')), 5);
                double wgsDy = Math.Round(Convert.ToDouble(yposWGS.Replace('.', ',')), 5);
               


                await Navigation.PushModalAsync(new Show(wgsDx, wgsDy));
            }

        }


        public void ShowMap(string x, string y)
        {
            string mapposition = "https://www.bing.com/maps/directions?cp=" + x + "~" + y + "&amp;sty=r&amp;lvl=11.25097951270283&amp;rtp=~pos.42.478308717866554_24.110854669100945____&amp;FORM=MBEDLD ";
            Uri mapurl = new Uri(mapposition);
            OpenBrowser(mapurl);
        }
        public async void Handle_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
        }
        async void Calculate_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            try
            {

                String CordX = x.Text.Replace(',', '.');
                String CordY = y.Text.Replace(',', '.');
                //    String item = zone.SelectedItem.ToString();


                int ZoneList = 0;

                switch (zone.SelectedItem.ToString())
                {
                  

                    case "1970 3-та зона към BGSCADKK":
                        ZoneList = 3;
                        break;

                    case "1970 5-та зона към BGSCADKK":
                        ZoneList = 5;
                        break;

                    case "1970 7-ма зона към BGSCADKK":
                        ZoneList = 7;
                        break;

                    case "1970 9-та зона към BGSCADKK":
                        ZoneList = 9;
                        break;

                }




                var result = await httpClient.GetStringAsync("https://bsite.net/ilievkosta/api/values/?i=" + ZoneList + "&x=" + CordX + "&y=" + CordY);
                var Arr = result.Split(',');
                type = "BGS1970, зона " +ZoneList+" в BGS2005Cad";

                ResultX.Text = Arr[0].Trim('[');
                ResultY.Text = Arr[1].Trim(']');

                String CadX= ResultX.Text;
                String CadY= ResultY.Text;
                xpos = CadX;
                ypos = CadY;

                var resultWGS = await httpClient.GetStringAsync("https://bsite.net/ilievkosta/api/values/?i=" + 22 + "&x=" + CadX + "&y=" + CadY);
               
                var ArrWGS = resultWGS.Split(',');

                xposWGS= ArrWGS[0].Trim('[');
                yposWGS = ArrWGS[1].Trim(']');

            }

            catch
            {
                ResultError.Text = "Попълнете всички полета с коректни данни";
            }

        }
    }
}