using Prototipo1_Lyfr.Models;
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
        Livros _livro;
        public CapaLivro(Livros l)
        {
            InitializeComponent();
            this._livro = l;
        }
    }
}