﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Microsoft.AppCenter;
//using Microsoft.AppCenter.Analytics;
//using Microsoft.AppCenter.Crashes;
using System.Diagnostics;
using Prototipo1_Lyfr.ViewModels.Services;
using Prototipo1_Lyfr.Views.Services;
using Prototipo1_Lyfr.Views;
using Prototipo1_Lyfr.Conexao;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Prototipo1_Lyfr
{
    public partial class App : Application
    {
        public App()
        {

            try
            {
                InitializeComponent();
                DependencyService.Register<INavigationService, NavigationService>();
                DependencyService.Register<IMessageService, MessageService>();

                Cache cache = new Cache();
                if (!cache.IsTableClienteNull())
                {
                    MainPage = new NavigationPage(new MainPage(cache.GetClienteLocal()));
                }
                else
                {
                    bool t = Application.Current.Properties.ContainsKey("IsFirst");
                    if (t)
                    {
                        var isfirst = (bool)Application.Current.Properties["IsFirst"];
                        if (!isfirst)
                        {
                            MainPage = new NavigationPage(new Login());
                        }
                        else
                        {
                            MainPage = new NavigationPage(new Views.Introducao());
                        }
                    }
                    else
                    {
                        MainPage = new NavigationPage(new Views.Introducao());
                    }
                }
                //MainPage = new NavigationPage(new Views.MainPage());
                //MainPage = new Views.MainPage();
                //MainPage = new Views.InfoLivro();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("AVISO -> " + ex.Message);
            }
        }
        protected override void OnStart()
        {
            App.Current.Resources.Add("IsFirst", false);
            //AppCenter.Start("android=5af831f0-b735-4a30-a1ff-a33d62146c66;", typeof(Analytics), typeof(Crashes));
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {

        }
    }
}
