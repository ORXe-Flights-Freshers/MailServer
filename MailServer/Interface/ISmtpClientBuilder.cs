using System.Net.Mail;
using System.Threading.Tasks;

  namespace MailServer.Interface
{
    public interface ISmtpClientBuilder
    {
        void send(MailMessage message);
       
    }

}
