using System.Net.Mail;

namespace MailServer.Services
{
    public interface IEmailClientWrapper
    {
        MailAddress CreateAddress(string address, string displayName);
        MailAddress CreateAddress(string address);
        MailMessage CreateMessage(MailAddress from, MailAddress to);
    }

}
