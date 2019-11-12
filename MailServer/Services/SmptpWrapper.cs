using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailServer.Services
{
    public class SmptpWrapper : ISmtpClientWrapper
    {
        private SmtpClient _smtpClient;

        public SmptpWrapper(IConfiguration config)
        {
            _smtpClient = new SmtpClient() {
                Host = config.GetValue<String>("Email:Smtp:Host"),
                Port = config.GetValue<int>("Email:Smtp:Port"),
                Credentials = new NetworkCredential(
                            config.GetValue<String>("Email:Smtp:Username"),
                            config.GetValue<String>("Email:Smtp:Password")
                        ),
                EnableSsl = config.GetValue<bool>("Email:Smtp:EnableSsl")
            }; 
        }


        public async Task SendMailAsync(MailMessage mailMessage)
        {
           await _smtpClient.SendMailAsync(mailMessage);
        }
    }
    
   
}
