using LiteDB;

namespace Prototipo1_Lyfr.Models.LocalDBModels
{
    public class Capa
    {
        [BsonId]
        public string NomeLivro { get; set; }
        public string Caminho { get; set; }
    }
}
