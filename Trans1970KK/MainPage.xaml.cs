using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Trans1970KK
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

       
        string url = "http://www.geo-bg.eu";
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
                    case "BGSCADKK към 1970 3-та зона":
                        ZoneList = 33;
                        break;

                    case "BGSCADKK към 1970 5-та зона":
                        ZoneList = 55;
                        break;
                    
                    case "BGSCADKK към 1970 7-ма зона":
                        ZoneList = 77;
                        break;

                    case "BGSCADKK към 1970 9-та зона":
                        ZoneList = 99;
                        break;

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



                ResultX.Text = Arr[0].Trim('[');
                ResultY.Text = Arr[1].Trim(']');
            }
         
            catch 
            {
                ResultError.Text = "Попълнете всички полета с коректни данни";
            }

        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
           
        await Navigation.PushModalAsync(new NavigationPage(new SecondPage()));

        }
    }
}