using Newtonsoft.Json;
using Prototipo1_Lyfr.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.Conexao.Classes
{
    public class ConexaoAPI
    {
        private Uri uri;
        public string mensagem;

        public ConexaoAPI()
        {
            uri = new Uri("https://lyfrapi1.herokuapp.com/api/");
        }

        public async Task<string> Add(Cliente cliente, string Token)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    var json = JsonConvert.SerializeObject(cliente);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.PostAsync("Cliente/Insert/", content);
                    mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return mensagem;
                    }

                    if (mensagem != null)
                    {
                        throw new Exception(mensagem);
                    }

                    throw new Exception(response.StatusCode.ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}

