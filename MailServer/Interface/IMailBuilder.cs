using System.Net.Mail;

namespace MailServer.Interface
{
    public interface IMailBuilder
    {
        MailAddress CreateAddress(string address, string displayName);
        MailAddress CreateAddress(string address);
        MailMessage CreateMessage();
    }

}
