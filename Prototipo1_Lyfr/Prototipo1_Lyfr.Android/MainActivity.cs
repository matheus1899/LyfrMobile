
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Util;
using Android.Widget;
using System;

namespace Prototipo1_Lyfr.Droid
{
    [Activity(Label = "Lyfr", Icon = "@mipmap/icon", RoundIcon ="@mipmap/icon",  Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const BuildVersionCodes m = BuildVersionCodes.M;
        public string TAG { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public bool IsStoragePermissionGranted()
        {
            if (Build.VERSION.SdkInt >= m)
            {
                if (CheckSelfPermission(Manifest.Permission.ReadExternalStorage) == (int)Android.Content.PM.Permission.Granted)
                {
                    Log.Verbose(TAG, "Permission is granted");
                    return true;
                }
                else
                {
                    Log.Verbose(TAG, "Permission is revoked");
                    ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadExternalStorage }, 1);
                    return false;
                }
            }
            else
            {
                Log.Verbose(TAG, "Permission is granted");
                return true;
            }
        }
    }
}