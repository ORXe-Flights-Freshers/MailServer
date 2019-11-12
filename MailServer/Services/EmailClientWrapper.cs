using System.Net.Mail;

namespace MailServer.Services
{
    public class EmailClientWrapper : IEmailClientWrapper
    {
        public MailAddress CreateAddress(string address, string displayName)
        {
            return new MailAddress(address, displayName);
        }

        public MailAddress CreateAddress(string address)
        {
            return new MailAddress(address);
        }

        public MailMessage CreateMessage(MailAddress from, MailAddress to)
        {
            return new MailMessage(from, to);
        }

    }

}
