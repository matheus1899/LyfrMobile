using System;
using System.Collections.Generic;
using System.Text;

namespace Prototipo1_Lyfr.Models
{
    public class Favoritos
    {
        public int Id_Favoritos { get; set; }
        public int? FkIdLivro { get; set; }
        public int? FkIdCliente { get; set; }
    }
}
