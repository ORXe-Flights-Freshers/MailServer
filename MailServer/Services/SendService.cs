using MailServer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailServer.Services
{
  
    public class SendService
    {
        private ISmtpClientWrapper _smtpClient;
        private IEmailClientWrapper _emailClient;

        public SendService(ISmtpClientWrapper smtpClient, IEmailClientWrapper emailClient)
        {
              _smtpClient = smtpClient;
            _emailClient = emailClient;
        }


        public async Task<Response> Send(EmailMessage emailMessage)
        {
            var from = _emailClient.CreateAddress("orxeflights@gmail.com", "Tripster");
            foreach(var address in emailMessage.To)
            {  
                try
                {

                    var to = _emailClient.CreateAddress(address);
                    var message = _emailClient.CreateMessage(from, to);
                    message.Body = emailMessage.Body;
                    message.Subject = emailMessage.Subject;
                    await _smtpClient.SendMailAsync(message);
                  
                }
                catch (Exception e)
                {
                    return new Response(Status.failure);

                }

            }

            return new Response(Status.success);
        }
    }

   
}
