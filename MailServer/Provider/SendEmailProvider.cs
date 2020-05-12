using MailServer.Entity;
using MailServer.Interface;
using MailServer.Models;
using MailServer.Response;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailServer.Provider
{

    public class SendService
    {
        private ISmtpClientBuilder _smtpClient;
        private IMailBuilder _emailClient;
        private SendCredentials _sendCredentials;

        public SendService(ISmtpClientBuilder smtpClient, IMailBuilder emailClient, SendCredentials sendCredentials)
        {
            _smtpClient = smtpClient;
            _emailClient = emailClient;
            _sendCredentials = sendCredentials;
        }

        public  EmailResponse Send(EmailMessage emailMessage)
        {
          try{ 

            var from = _emailClient.CreateAddress(_sendCredentials.Email, _sendCredentials.DisplayName);
            var mailMessage = _emailClient.CreateMessage();
            HashSet<string> to_set = new HashSet<string>(emailMessage.To);
            foreach (var recipient in to_set)
                    mailMessage.To.Add(_emailClient.CreateAddress(recipient));
            mailMessage.From = from;
            mailMessage.Subject = emailMessage.Subject;
            mailMessage.Body = emailMessage.Body;
            _smtpClient.send(mailMessage); 
          }
          catch (Exception)
          {
                return new EmailResponse(Status.failure);

          }

            return new EmailResponse(Status.success);
        }
    }


}
