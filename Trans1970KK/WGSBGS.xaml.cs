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

namespace Trans1970KK
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WGSBGS : ContentPage
	{
        string url = "http://www.geo-bg.eu";
        string xpos = "1";
        string ypos = "1";
        string xposWGS = "1";
        string yposWGS = "1";

        public WGSBGS ()
		{
			InitializeComponent ();
		}

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
                Cord TransformedCoordinates = new Cord(xpos, ypos, NameCord.Text, "WGS84 в BGS2005Cad");

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
        public void CheckCord_Clicked(object sender, EventArgs e)
        {
            if (xpos.Length > 2)
            {
                ShowMap(xposWGS, yposWGS);
            }

        }

        async void Check_Clicked(object sender, EventArgs e)
        {
            //if (xpos.Length > 2)
            //{
            //    ShowMap(xposWGS, yposWGS);
            //}

            
                await Navigation.PushModalAsync(new Show());
            

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
                
                xposWGS = CordX;
                yposWGS = CordY;

                var result = await httpClient.GetStringAsync("https://bsite.net/ilievkosta/api/values/?i=" + 11 + "&x=" + CordX + "&y=" + CordY);
                var Arr = result.Split(',');
                xpos = Arr[0].Trim('[');
                ypos = Arr[1].Trim(']');
                ResultX.Text = xpos;
                ResultY.Text = ypos;
            }

            catch
            {
                ResultError.Text = "Попълнете всички полета с коректни данни";
            }

        }
        
    }
}