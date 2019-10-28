﻿using Newtonsoft.Json;
using Prototipo1_Lyfr.Models;
using System;
using System.Collections.Generic;
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
            uri = new Uri("http://www.lyfrapi.com.br/api/");
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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<string> EnviarEmail(string email, string Token)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var json = JsonConvert.SerializeObject(email);
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
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = uri;
                    var json = JsonConvert.SerializeObject(Titulo);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                    HttpResponseMessage response = await client.PostAsync("/Livros/GetLivroByTitulo/", content);
                    string mensagem = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode == true)
                    {
                        Livros livro = JsonConvert.DeserializeObject<Livros>(mensagem);
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
    }
}

