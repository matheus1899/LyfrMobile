using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using Prototipo1_Lyfr.Conexao.Interfaces;
using Prototipo1_Lyfr.Models.SQLiteModels;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.Conexao.Classes
{

    public class CacheLiteDB
    {
        private LiteDatabase _dataBase;
        LiteCollection<Capa> Capas;
        public CacheLiteDB()
        {
            _dataBase = new LiteDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("MeuBanco.db"));
            Capas = _dataBase.GetCollection<Capa>();
        }

        public void InserirCapa(Capa capa)
        {
            Capas.Upsert(capa);
        }

        public Capa GetCapa(string nomeLivro)
        {
            if (Capas.Count() > 0)
            {
                return Capas.FindOne(x => x.NomeLivro == nomeLivro);
            }
            else
            {
                return null;
            }
        }

        //public List<Capa> ListarCapas()
        //{
        //    return Capas.FindAll().t
        //}

    }
}
