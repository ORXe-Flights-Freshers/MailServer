using MailServer.Interface;
using System.Net.Mail;

namespace MailServer.Provider

{
    public class MailBuilder : IMailBuilder
    {
        public MailAddress CreateAddress(string address, string displayName)
        {
            return new MailAddress(address, displayName);
        }

        public MailAddress CreateAddress(string address)
        {
            return new MailAddress(address);
        }

        public MailMessage CreateMessage()
        {
            return new MailMessage();
        }

    }

}
