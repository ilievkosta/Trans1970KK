using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mapsui;
using Mapsui.Projection;
using Mapsui.Utilities;
using Xamarin.Essentials;
using Mapsui.UI.Forms;

namespace Trans1970KK
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Show : ContentPage
    {
      


        public Show()
        {
            InitializeComponent();

            double lat = 42.28;
            double lng = 25.94;

            var myPosition = new Position(lat, lng);

            var map = new Mapsui.Map
            {
                CRS = "EPSG:3857",
                Transformation = new MinimalTransformation()
            };

            var tileLayer = OpenStreetMap.CreateTileLayer();

            map.Layers.Add(tileLayer);
            map.Widgets.Add(new Mapsui.Widgets.ScaleBar.ScaleBarWidget(map) { TextAlignment = Mapsui.Widgets.Alignment.Center, HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Left, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Bottom });

            mapView.Map = map;
            mapView.MyLocationLayer.UpdateMyLocation(new Position(lat, lng), true);
      

            var myPin = new Pin()
            {
                Position = myPosition,
                Type = PinType.Pin,
                Label = "Zero point",
                Address = "Zero point",
            };
            mapView.Pins.Add(myPin);

            var w = Application.Current.MainPage.Width;
            var h = Application.Current.MainPage.Height;
            // Transfer your coordinates from WGS84 (MapView format) to spherical mercator (Mapsui format)
           
            var southWest = new Position(lat-0.01, lng-0.01).ToMapsui();
            var northEast = new Position(lat+0.01, lng+0.01).ToMapsui();

            //var southWest = new Position(43.617908, -116.210927).ToMapsui();
            // var northEast = new Position(43.623198, -116.195544).ToMapsui();
            // Use the Mapsui functions
            ZoomHelper.ZoomToBoudingbox(southWest.X, southWest.Y, northEast.X, northEast.Y, w, h, out double x, out double y, out double resolution);
            mapView.Navigator.NavigateTo(new Mapsui.Geometries.Point(x, y), resolution);

        }
    }
}