﻿using Newtonsoft.Json;
using Prototipo1_Lyfr.ConexaoAPI;
using Prototipo1_Lyfr.Models;
using Prototipo1_Lyfr.Models.SQLiteModels;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.Conexao
{
    public class GerarToken
    {
        Cache cache = new Cache();
        public string mensagem;
        public string dataExpiracao;

        public async Task<Token> GenerateToken()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://lyfrapi1.herokuapp.com/api/");

                try
                {
                    UserToken user = new UserToken();

                    user.Usuario = "Lyfr_User123";
                    user.Senha = "LyfrAPI123";
                    user.TipoUsuario = "M";

                    var json = JsonConvert.SerializeObject(user);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("Seguranca/Login", content);
                    var response_json = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<Token>(response_json);
                    }

                    if (response_json != null)
                    {
                        throw new Exception(response_json);
                    }

                    throw new Exception(response.StatusCode.ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async void GuardarCache()
        {
            var token = await GenerateToken();

            TokenCache tokenCache = new TokenCache()
            {
                TokenString = token.TokenString,
                HoraExpiracao = token.HoraExpiracao
            };

            cache.InserirTokenCache(tokenCache);
        }


        public bool Expirou()
        {
            DateTime now = DateTime.Now;
            DateTime expiration = DateTime.ParseExact(cache.GetTokenCache().HoraExpiracao, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            if (now.CompareTo(expiration) >= 0)
            {
                return true;
            }

            return false;
        }

        public void ChecharCache()
        {
            if (cache.IsTableNull() == true || Expirou() == true)
            {
                GuardarCache();
            }
        }

        public static string GetTokenFromCache()
        {
            Cache cache = new Cache();
            return cache.GetTokenCache().TokenString;
        }
    }
}
