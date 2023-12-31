﻿using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CapaLivro : ContentPage
    {

        public CapaLivro(Livros l)
        {
            InitializeComponent();
            titleView.Text = l.Titulo;
            image.Source = l.Capa;
        }
        private void ToolbarClose_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<INavigationService>().GoBack();
        }
    }
}