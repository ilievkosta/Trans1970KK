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

     async void OnButtonClicked1970toBGS(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Page1());
        }

     async void OnButtonClickedBGSto1970(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Cad1970());
        }

        async void OnButtonClicked1970toWGS(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new WGS());
        }

        async void OnButtonClickedBGSCadtoWGS84(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BGSWGS());
        }

        async void OnButtonClickedWGS84toBGSCad(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new WGSBGS());
        }
       
        async void OnButtonClickedShowData(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new DataPage());
        }
    }
}