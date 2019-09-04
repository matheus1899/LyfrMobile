using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototipo1_Lyfr.Models.SQLiteModels
{
    [Table("Pequisa")]
    public class PesquisaCache
    {
        public string ItemPesquisado { get; set; }
        public string DataPesquisa { get; set; }
    }
}
