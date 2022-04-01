using System;


using Xamarin.Forms;

using Mapsui;
using Mapsui.Projection;
using Mapsui.Utilities;

using Mapsui.UI.Forms;

namespace Trans1970KK
{
    public class MapViewM
    {
        public static void ShowMap(MapView MyMapView, double lat, double lng)
        {


            var myPosition = new Position(lat, lng);

            var map = new Mapsui.Map
            {
                CRS = "EPSG:3857",
                Transformation = new MinimalTransformation()
            };

            var tileLayer = OpenStreetMap.CreateTileLayer();

            map.Layers.Add(tileLayer);
            map.Widgets.Add(new Mapsui.Widgets.ScaleBar.ScaleBarWidget(map) { TextAlignment = Mapsui.Widgets.Alignment.Center, HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Left, VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Bottom });

            MyMapView.Map = map;



            var myPin = new Pin()
            {
                Position = myPosition,
                Type = PinType.Pin,
                Label = "Zero point",
                Address = "Zero point",
            };
            MyMapView.Pins.Add(myPin);

            var w = Application.Current.MainPage.Width;
            var h = Application.Current.MainPage.Height;
            // Transfer your coordinates from WGS84 (MapView format) to spherical mercator (Mapsui format)

            var southWest = new Position(lat - 0.01, lng - 0.01).ToMapsui();
            var northEast = new Position(lat + 0.01, lng + 0.01).ToMapsui();

            // Use the Mapsui functions
            ZoomHelper.ZoomToBoudingbox(southWest.X, southWest.Y, northEast.X, northEast.Y, w, h, out double x, out double y, out double resolution);
            MyMapView.Navigator.NavigateTo(new Mapsui.Geometries.Point(x, y), resolution);

        }
    }
}
