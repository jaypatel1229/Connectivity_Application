using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace Connectivity_AppEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme" ,MainLauncher =true)]
    class MainActivity : Activity
    {
        TextView myconnectivity;
        TextView myconnectivityprofile;
        Button myconnectbutton;
        Button myconnectivityprofilebutton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            UIReference();
            UIClick();
        }

        private void UIClick()
        {
            myconnectbutton.Click += Myconnectbutton_Click;
            myconnectivityprofilebutton.Click += Myconnectivityprofilebutton_Click;
        }

        private void Myconnectivityprofilebutton_Click(object sender, EventArgs e)
        {
            var profiles = Connectivity.ConnectionProfiles;
            if (profiles.Contains(ConnectionProfile.WiFi))
            {

                myconnectivityprofile.Text = "Connected to Wifi";
            }
            else if (profiles.Contains(ConnectionProfile.Cellular))
            {

                myconnectivityprofile.Text = "Connected to Cellular";
            }
            else if (profiles.Contains(ConnectionProfile.Ethernet))
            {

                myconnectivityprofile.Text = "Connected to Ethernet";
            }
            else
            {

                myconnectivityprofile.Text = "Connected to Unknown";
            }
        }

        private void Myconnectbutton_Click(object sender, EventArgs e)
        {
            var curr = Connectivity.NetworkAccess;
            if (curr == NetworkAccess.Internet)
            {
                myconnectivity.Text = "Connected to Internet";
            }
            else
            {
                myconnectivity.Text = "No Internet";
            }

        }

        private void UIReference()
        {
            myconnectivity = FindViewById<TextView>(Resource.Id.textViewCC);
            myconnectivityprofile = FindViewById<TextView>(Resource.Id.textViewCCP);
            myconnectbutton = FindViewById<Button>(Resource.Id.buttonCC);
            myconnectivityprofilebutton = FindViewById<Button>(Resource.Id.buttonCCP);
        }
    }
}