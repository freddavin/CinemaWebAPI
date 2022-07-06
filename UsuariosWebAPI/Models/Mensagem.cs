using MimeKit;

namespace UsuariosWebAPI.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatarios { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatarios, string assunto, int idUsuario, string chaveDeAtivacao)
        {
            Destinatarios = new List<MailboxAddress>();
            Destinatarios.AddRange(destinatarios.Select(d => new MailboxAddress(d, d)));
            Assunto = assunto;
            Conteudo = $"https://localhost:7154/ativar?IdUsuario={idUsuario}&ChaveDeAtivacao={chaveDeAtivacao}";
        }
    }
}
