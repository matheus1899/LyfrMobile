using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;

namespace Prototipo1_Lyfr.Droid
{
    [Activity(Theme= "@style/MyTheme.Splash", MainLauncher=true,NoHistory =true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, UiOptions =Android.Content.PM.UiOptions.SplitActionBarWhenNarrow)]
    public class SplashScreen : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashScreen).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        void SimulateStartup()
        {
            Log.WriteLine(LogPriority.Debug,TAG,"Performing some startup work that takes a bit of time.");
            Log.WriteLine(LogPriority.Debug,TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}