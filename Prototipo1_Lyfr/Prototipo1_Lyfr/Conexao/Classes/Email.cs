using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.Conexao.Classes
{
    public class Email
    {
        //Metódo para gerar códifo aleátorio
        public static string RandomString(int size) //Recebe como parâmetro o tamanho de digítos código
        {
            //Cria uma variável da classe 'StringBuilder' permitindo que se crie uma string de caracteres
            StringBuilder builder = new StringBuilder();
            //Cria uma variável para pegar os números aleátorios
            Random random = new Random();
            //Cria um char para pegar os caracteres
            char ch;

            //Loop para gerar o tamanho do código 
            for (int i = 0; i < size; i++)
            {
                //Atribuí ao char uma letra aleátoria entre A e Z
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(10 * random.NextDouble() + 48)));
                //Acrescenta na string o caracter aleátorio
                builder.Append(ch);
            }
            //Retorna o código aleátorio
            return builder.ToString();
        }

        //Metódo para mandar o e-mail de maneira assíncrona
        public static Task EnviarEmail(string email, string nome, string texto)
        {
            return Task.Run(() =>
            {
                try
                {
                    //Cria uma váriavel que manda a mensagem de e-mail
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    //Manda do email do aplicativo para o e-mail fornecido na entry
                    mail.From = new MailAddress("contato.Lyfr@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = nome;
                    //Manda o código aleatório para o e-mail do usuário
                    mail.Body = texto;

                    SmtpServer.Port = 587;
                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.EnableSsl = true;
                    SmtpServer.UseDefaultCredentials = false;
                    //Autenticando o e-mail do aplicativo
                    SmtpServer.Credentials = new System.Net.NetworkCredential("contato.Lyfr@gmail.com", "l1fr_endeavour");

                    //Manda o e-mail
                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    //MostrarMensagem.Mostrar("Falha");
                }
            });

        }
    }
}
