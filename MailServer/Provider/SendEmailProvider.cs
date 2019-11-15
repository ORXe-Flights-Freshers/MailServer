using MailServer.Entity;
using MailServer.Interface;
using MailServer.Models;
using MailServer.Response;
using System;
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
            emailMessage.To.ForEach(recipient => mailMessage.To.Add(new MailAddress(recipient)));
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
