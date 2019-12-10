using System;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using Prototipo1_Lyfr.Models;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Plugin.Connectivity;

namespace Prototipo1_Lyfr.Conexao
{
    public class ConexaoAPI
    {
        private Uri uri;
        public string mensagem;

        public ConexaoAPI()
        {
            uri = new Uri("http://www.lyfrapi.com.br/api/");
        }
        private bool HasInternet()
        {
            return CrossConnectivity.Current.IsConnected;
        }
        public async Task<string> Add(Cliente cliente, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
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

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<Cliente> SelectOne(Cliente cliente, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    var json = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.PostAsync("Cliente/GetClienteByEmail/", content);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode==true)
                    {
                        
                        Cliente user = JsonConvert.DeserializeObject<Cliente>(mensagem);
                        return user;
                    }

                    if (string.IsNullOrWhiteSpace(mensagem))
                    {
                        throw new Exception(mensagem);
                    }

                    throw new Exception(response.StatusCode.ToString());
                }
                catch (TimeoutException ex)
                {
                    throw new TimeoutException(ex.Message);
                }
                catch (Exception ex)
                {
                    if(ex.Message == "BadRequest")
                    {
                        throw new Exception("Email ou senha inválidos. \nTente novamente...");
                    }
                    else
                    {
                        throw new Exception(ex.Message);
                    }
                }
                
            }
        }
        public async Task<Cliente> SelectOneWithoutPassword(Cliente cliente, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    var json = JsonConvert.SerializeObject(cliente.Email);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.PostAsync("Cliente/GetClienteToUpdateByEmail/", content);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {

                        Cliente user = JsonConvert.DeserializeObject<Cliente>(mensagem);
                        return user;
                    }

                    if (string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<string> EnviarEmail(RecoveryPassword recovery, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var json = JsonConvert.SerializeObject(recovery);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("Cliente/ForgotPassword", content);
                    mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return mensagem;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<string> Update(Cliente cliente, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    var json = JsonConvert.SerializeObject(cliente);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.PutAsync("Cliente/Update/", content);
                    mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return mensagem;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<string> SendSugestao(Sugestao sugestao, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    var json = JsonConvert.SerializeObject(sugestao);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.PostAsync("Sugestao/Insert/", content);
                    mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return mensagem;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<List<Livros>> GetSixLivros(string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.GetAsync("/Livros/GetAllLivros/?numeroDeLivros=6");
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {
                        List<Livros> livros = JsonConvert.DeserializeObject<List<Livros>>(mensagem);
                        return livros;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<List<Livros>> GetAllLivros(string Token,short n_livros)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.GetAsync("Livros/GetAllLivros/"+n_livros.ToString());
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {
                        List<Livros> livros = JsonConvert.DeserializeObject<List<Livros>>(mensagem);
                        return livros;
                    }

                    if (string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<Livros> GetLivroByTitulo(string Titulo, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    var json = JsonConvert.SerializeObject(Titulo);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("Livros/GetLivroByTitulo/", content);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {
                        Livros livro = JsonConvert.DeserializeObject<Livros>(mensagem);
                        Debug.WriteLine("LIVRO =>" + livro.Sinopse);
                        return livro;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<Livros> GetLivroByTituloWithoutFile(string Titulo, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    var json = JsonConvert.SerializeObject(Titulo);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("Livros/GetLivroByTituloWithoutFile/", content);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {
                        Livros livro = JsonConvert.DeserializeObject<Livros>(mensagem);
                        Debug.WriteLine("LIVRO =>" + livro.Sinopse);
                        return livro;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<List<Livros>> GetLivrosByGenero(string Genero, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    var content = new StringContent("\"" + Genero + "\"", Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.PostAsync("Livros/GetLivrosByGenero/", content);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {
                        List<Livros> livros = JsonConvert.DeserializeObject<List<Livros>>(mensagem);
                        return livros;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<Autores> GetAutorByNome(string Nome, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(Nome);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);


                    HttpResponseMessage response = await client.PostAsync("Autores/GetAutorByNome/", content);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {
                        Autores autores = JsonConvert.DeserializeObject<Autores>(mensagem);
                        return autores;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<List<Livros>> SearchLivros(string Titulo, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.GetAsync("Livros/Search/" + Titulo);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {
                        List<Livros> livros = JsonConvert.DeserializeObject<List<Livros>>(mensagem);
                        return livros;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task RemoveFromMyList(Favoritos objeto, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.DeleteAsync("Favoritos/DeleteById/" + objeto.FkIdCliente + "/" + objeto.FkIdLivro);
                    await response.Content.ReadAsStringAsync();
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode && mensagem == "O livro de id " + objeto.FkIdLivro + " foi deletado com sucesso da sua lista")
                    {
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task AddToMyList(Favoritos favorito, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    var json = JsonConvert.SerializeObject(favorito);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.PostAsync("Favoritos/Insert/", content);
                    await response.Content.ReadAsStringAsync();
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode && mensagem == "Favoritos cadastrado com sucesso!")
                    {
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<List<Livros>> GetLivrosByCliente(int idCliente, string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.GetAsync("Favoritos/GetFavoritosByUsuario/" + idCliente);
                    await response.Content.ReadAsStringAsync();
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<List<Livros>>(mensagem);
                    }

                    if (!string.IsNullOrWhiteSpace(mensagem))
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
        public async Task<List<Genero>> GetAllGeneros(string Token)
        {
            if (!HasInternet())
            {
                throw new Exception("Verifique sua conexão e \ntente novamente mais tarde");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.GetAsync("Genero/GetAllGeneros");
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {
                        List<Genero> generos = JsonConvert.DeserializeObject<List<Genero>>(mensagem);
                        return generos;
                    }

                    if (string.IsNullOrWhiteSpace(mensagem))
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

