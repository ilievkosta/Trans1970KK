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
            MapViewM.ShowMap(mapView, 41, 22);

        }
        public Show(double x,double y)
        {
            InitializeComponent();
            MapViewM.ShowMap(mapView, x, y);

        }
    }
}