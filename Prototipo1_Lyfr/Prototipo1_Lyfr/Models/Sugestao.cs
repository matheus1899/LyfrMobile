using System;
using System.Collections.Generic;
using System.Text;

namespace Prototipo1_Lyfr.Models
{
    public class Sugestao
    {
        public int idSugestao { get; set; }
        public int? FkIdCliente { get; set; }
        public string Mensagem { get; set; }
        public char Atendido { get; set; }
    }
}
