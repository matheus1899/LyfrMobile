using Prototipo1_Lyfr.Conexao.Interfaces;
using Prototipo1_Lyfr.Droid;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(CaminhoCache))]
namespace Prototipo1_Lyfr.Droid
{
    public class CaminhoCache : ICaminhoCache
    {
        public string ObterCaminho(string NomeCache)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(caminhoDaPasta, NomeCache);
        }
    }
}