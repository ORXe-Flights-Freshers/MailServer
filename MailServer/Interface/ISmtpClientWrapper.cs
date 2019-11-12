using System.Net.Mail;
using System.Threading.Tasks;

  namespace MailServer.Services
{
    public interface ISmtpClientWrapper
    {
       Task SendMailAsync(MailMessage mailMessage);
    }

}
