using FluentResults;
using MailKit.Net.Smtp;
using MimeKit;
using UsuariosWebAPI.Models;

namespace UsuariosWebAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatarios, string assunto, int idUsuario, string codigoDeConfirmacao)
        {
            Mensagem mensagem = new Mensagem(destinatarios, assunto, idUsuario, codigoDeConfirmacao);
            MimeMessage mensagemDeEmail = CriarCorpoDoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                    _configuration.GetValue<int>("EmailSettings:Port"), true);
                client.AuthenticationMechanisms.Remove("XOUATH2");
                client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                    _configuration.GetValue<string>("EmailSettings:Password"));
                client.Send(mensagemDeEmail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private MimeMessage CriarCorpoDoEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From"),
                _configuration.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatarios);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemDeEmail;
        }
    }
}
