using System;
using System.IO;
using Android.OS;
using Prototipo1_Lyfr.Conexao.Interfaces;
using Prototipo1_Lyfr.Droid;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(FileHelper))]
namespace Prototipo1_Lyfr.Droid
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}