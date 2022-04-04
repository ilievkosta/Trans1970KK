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
         

        }
        public Show(double x,double y)
        {
            x = Math.Round(x, 2);
            y = Math.Round(y, 2);
            InitializeComponent();
            MapViewM.ShowMap(mapView, x, y);
        }
    }
}