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
                var result = await httpClient.GetStringAsync("https://bsite.net/ilievkosta/api/values/?i=" + zone.SelectedItem + "&x=" + CordX + "&y=" + CordY);
                var Arr = result.Split(',');



                ResultX.Text = Arr[0].Trim('[');
                ResultY.Text = Arr[1].Trim(']');
            }
         
            catch (Exception i)
            {
                ResultError.Text = "Попълнете всички полета с коректни данни";
            }

        }
    }
}