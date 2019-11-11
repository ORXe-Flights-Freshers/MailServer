using MailServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailServer.Services
{
    public class SendService
    {
        private SmtpClient _smtpClient;

        public SendService(SmtpClient smtpClient)
        {
            this._smtpClient = smtpClient;
        }
        public async Task Send(EMailMessage emailMessage)
        {
            MailAddress from = new MailAddress("orxeflights@gmail.com", "Tripster");
            MailAddress to = new MailAddress(emailMessage.To[0]);
            MailMessage message = new MailMessage(from, to);
            message.Body = emailMessage.Body;
            message.Subject = emailMessage.Subject;

            await this._smtpClient.SendMailAsync(message);
        }
    }
}
