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

namespace Prototipo1_Lyfr.Droid
{
    [BroadcastReceiver(Enabled = true)]
    class MensagemReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var mensagem = intent.GetStringExtra("mensagem"); //Recebe a mensagem 
            Toast.MakeText(context, mensagem, ToastLength.Long).Show(); //Exibe a mensagem no toast
        }
    }
}