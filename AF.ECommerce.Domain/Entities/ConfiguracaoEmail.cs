using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AF.ECommerce.Domain.Entities
{
    public class ConfiguracaoEmail
    {
        public void EnvioEmail(string emailDestinatario, Produto produto)
        {

            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailRemetente = "testearimelo@gmail.com";            
            string senha = "zdopxbfqxiuveqji";
            string assunto = $"COMUNICADO - Time de Compra";
            string corpoEmail = $"<h2 style=color:red>Estoque Baixo!<h2/> <br/>" +
                             $"Informamos que o produto: " +
                             $"<b>{produto.Descricao}</b>" +
                             $" encontra-se com a quantidade de {produto.Estoque} unidade(s) em estoque. " +
                             $"<br/><br/><b> E-mail enviado automaticamente, favor nao responda.";


            using (MailMessage mail = new MailMessage())
            {
               
                mail.From = new MailAddress(emailRemetente);
                mail.To.Add(emailDestinatario);
                mail.Subject = assunto;
                mail.Body = corpoEmail;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailRemetente, senha);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}
