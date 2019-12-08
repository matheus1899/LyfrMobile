using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.ViewModels;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoLivro : ContentPage
    {
        private InfoLivroViewModel bind;
        public InfoLivro()
        {
            InitializeComponent();
            SetLayout(this.Width, this.Height);
        }
        public InfoLivro(Livros livro, Cliente c)
        {
            InitializeComponent();
            bind=this.BindingContext as InfoLivroViewModel;
            bind.Livro = livro;
            bind.Cliente = c;
            bind.SetMinhaLista();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            SetLayout(this.Width, this.Height);
        }

        private void SetIsVisible(VisualElement v, bool boolean)
        {
            v.IsVisible = boolean;
        }

        private void SetLayout(double w, double h)
        {
            if (w > h)
            {
                SetIsVisible(bxv_HeaderPage, true);
                SetIsVisible(bxv_HeaderPage2, true);
                //stc_BtnActionLivro.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                SetIsVisible(bxv_HeaderPage, false);
                SetIsVisible(bxv_HeaderPage2, false);
                //stc_BtnActionLivro.Orientation = StackOrientation.Vertical;
            }
        }
    }
}