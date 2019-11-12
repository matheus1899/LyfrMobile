using SQLite;

namespace Prototipo1_Lyfr.Models.LocalDBModels
{
    [Table("Pequisa")]
    public class PesquisaCache
    {
        public string ItemPesquisado { get; set; }
        public string DataPesquisa { get; set; }
    }
}
