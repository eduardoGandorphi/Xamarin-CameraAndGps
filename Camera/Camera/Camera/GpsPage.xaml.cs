using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Camera
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GpsPage : ContentPage
	{
		public GpsPage ()
		{
			InitializeComponent ();
            GetInfo();
        }

        private async void GetInfo()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);
                var SENAC = new Location(-20.814622, -49.377225);
                var mc = new Location(-20.822608, -49.384599);

                StringBuilder str = new StringBuilder();
                str.AppendLine($"lat:{location.Latitude}, long:{location.Longitude}");
                str.AppendLine($"Distancia do senac:{SENAC.CalculateDistance(location, DistanceUnits.Kilometers)}");
                str.AppendLine($"Distancia do mc:{mc.CalculateDistance(location, DistanceUnits.Kilometers)}");

                lblLoc.Text = str.ToString();
            }
            catch (Exception e)
            {
            }

        }
    }
}