using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using System;
using Xamarin.Forms;
using Color = Android.Graphics.Color;

namespace Prototipo1_Lyfr.Droid
{
    [Activity(Label = "Lyfr", Icon = "@mipmap/icon", RoundIcon ="@mipmap/icon",  Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const BuildVersionCodes m = BuildVersionCodes.M;
        public string TAG { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.SetNavigationBarColor(Color.Argb(255,67,100,119));
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //RequestWindowFeature(WindowFeatures.NoTitle);
            //Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            EsperarMensagem();
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

        void EsperarMensagem()
        {
            //Espera uma mensagem
            MessagingCenter.Subscribe<string>(this, "Mensagem", message =>
            {
                //Inicia um broadcast junto com a mensagem
                var intent = new Intent(this, typeof(MensagemReceiver));
                intent.PutExtra("mensagem", message);
                SendBroadcast(intent);
            });
        }
    }
}