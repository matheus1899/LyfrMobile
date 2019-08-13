﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototipo1_Lyfr;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Introducao : ContentPage
    {
        public Introducao()
        {
            try
            {
                InitializeComponent();
                List<Models.Livro> lista = new List<Models.Livro>();
                lista.Add(new Models.Livro { Nome = "bfhadbahbfj" });
                lista.Add(new Models.Livro { Nome = "bfhadbahbfjhadbfjk" });
                lista.Add(new Models.Livro { Nome = "bfhadbahbfjhadbhbfdajk" });
                Carousel.ItemsSource = lista;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro -> " + ex.Message);
            }
        }
        private void ChamarPagCadastrar(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Cadastrar());
        }

        private void ChamarPagLogin(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage( new Login());

        }

        private void Left_Swiped(object sender, SwipedEventArgs e)
        {

        }

        private void Right_Swiped(object sender, SwipedEventArgs e)
        {
            
        }
    }
}