using SQLite;

namespace Prototipo1_Lyfr.Models.SQLiteModels
{
    [Table("Token")]
    public class TokenCache
    {
        public string TokenString { get; set; }
        public string HoraExpiracao { get; set; }
    }
}
