using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using AlphaCorp.BLO;
using System.Net;
using System.IO;
using System.Web;
using System.Reflection;

namespace AlphaCorp.BLL
{
    public class clsEmailBLL
    {
        static public string CurrentAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
        public void Enviar(string _emailAlpha, clsEmpresaBLO _contratante, string _nomeAlpha, string mensagem)
        {
            MailMessage mail = new MailMessage();
            //email da alphacorp
            mail.From = new MailAddress(_emailAlpha);
            //Endereço para qual o email será enviado.
            mail.To.Add(_contratante.Email);
            mail.Subject = "Senha : ";

            mail.Body = CurrentAssemblyDirectory();

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_emailAlpha, "reinado1");
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                mail = null;
                client = null;
            }
        }
        public void Enviar(string _emailAlpha, clsPessoaFisicaBLO _contratante, string _nomeAlpha, string mensagem)
        {
            MailMessage mail = new MailMessage();
            //email da alphacorp
            mail.From = new MailAddress(_emailAlpha);
            //Endereço para qual o email será enviado.
            mail.To.Add(_contratante.Email);
            mail.Subject = "Senha : ";

            mail.Body = CurrentAssemblyDirectory();

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_emailAlpha, "reinado1");
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                mail = null;
                client = null;
            }
        }
    }
}

