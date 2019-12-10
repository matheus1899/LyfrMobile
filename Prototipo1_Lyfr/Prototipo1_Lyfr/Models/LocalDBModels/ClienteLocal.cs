using SQLite;

namespace Prototipo1_Lyfr.Models.LocalDBModels
{
    [Table("User")]
    public class ClienteLocal
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Data_Cadastro { get; set; }
    }
}
