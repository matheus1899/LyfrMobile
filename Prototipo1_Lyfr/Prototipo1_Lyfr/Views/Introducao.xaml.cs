﻿using Prototipo1_Lyfr.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Introducao : ContentPage
    {
        List<Texto> lista = new List<Texto>();
        Lazy<Stopwatch> sw = new Lazy<Stopwatch>();
        public Introducao(){
            sw.Value.Start();
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            lista.Add(new Texto { TextoIntro = "Bem vindo ao seu aplicativo de leitura" });
            lista.Add(new Texto { TextoIntro = "Lyfr tem um acervo de contendo cerca de \n500 livros e aumentando..." });
            lista.Add(new Texto { TextoIntro = "Aproveite o seu livro, onde e \nquando quiser, gratuitamente" });
            Carousel.ItemsSource = lista;
            sw.Value.Stop();
            Debug.WriteLine("Introducao -> " + sw.Value.ElapsedMilliseconds.ToString());
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            btn_Cadastrar.IsEnabled = true;
            btn_Entrar.IsEnabled = true;
        }


        private void ChamarPagCadastrar(object sender, EventArgs e){
            btn_Cadastrar.IsEnabled = false;
            btn_Entrar.IsEnabled = false;
            Navigation.PushAsync(new Cadastrar());
        }
        private void ChamarPagLogin(object sender, EventArgs e){
            btn_Cadastrar.IsEnabled = false;
            btn_Entrar.IsEnabled = false;
            Navigation.PushAsync(new Login());
        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            if(this.Width>this.Height) {
                VisualStateManager.GoToState(stc_Buttons, "Landscape");
            }
            else{
                VisualStateManager.GoToState(stc_Buttons, "Portrait");
            }
        }
    }
}