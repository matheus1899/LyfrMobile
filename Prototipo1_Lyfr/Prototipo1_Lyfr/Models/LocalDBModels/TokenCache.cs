using SQLite;

namespace Prototipo1_Lyfr.Models.LocalDBModels
{
    [Table("Token")]
    public class TokenCache
    {
        public string TokenString { get; set; }
        public string HoraExpiracao { get; set; }
    }
}
