using SQLite;

namespace Prototipo1_Lyfr.Models.LocalDBModels
{
    [Table("PrimeiraVez")]
    public class PrimeiraVez
    {
        public bool IsFirst { get; set; }
    }
}
