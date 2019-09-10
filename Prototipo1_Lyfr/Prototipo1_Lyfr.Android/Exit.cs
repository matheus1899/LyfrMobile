using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Prototipo1_Lyfr.Interfaces;
using Xamarin.Forms;
using Prototipo1_Lyfr.Droid;

[assembly: Dependency(typeof(Exit))]
namespace Prototipo1_Lyfr.Droid
{
    public class Exit : IExit
    {
        public void ExitApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}