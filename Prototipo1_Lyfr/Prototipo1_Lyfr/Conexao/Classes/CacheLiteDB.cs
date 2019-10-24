﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Prototipo1_Lyfr.Conexao.Interfaces;
using Prototipo1_Lyfr.ConexaoAPI;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Models.SQLiteModels;
using Xamarin.Forms;

namespace Prototipo1_Lyfr.Conexao.Classes
{
    public class CacheLiteDB
    {
        private LiteDatabase _dataBase;
        LiteCollection<Capa> Capas;
        Cache cache = new Cache();
        public ConexaoAPI _conexao = new ConexaoAPI();
        List<Livros> livros;

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

        public async Task<List<Capa>> LoadCapas()
        {
            if (Capas.Count() <= 0)
            {
                livros = await _conexao.GetAllLivros(GerarToken.GetTokenFromCache());
                foreach (var livro in livros)
                {
                    Capa capa = new Capa()
                    {
                        NomeLivro = livro.Titulo,
                        Caminho = livro.Capa
                    };
                    InserirCapa(capa);
                    return ListarCapas();
                }
            }
            else
            {
                return ListarCapas();
            }
            return null;
        }


        public List<Capa> ListarCapas()
        {
            return Capas.FindAll().ToList();
        }

    }
}