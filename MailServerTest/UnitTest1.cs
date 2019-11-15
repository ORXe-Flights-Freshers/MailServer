//using MailServer.Services;
//using System;
//using System.Net.Mail;
//using Xunit;
//using Moq;
//using MailServer.Models;
//using FluentAssertions;
//using System.Threading.Tasks;
//using System.Collections.Generic;

//namespace MailServerTest
//{
//    public class UnitTest1
//    {

//        //private readonly Mock<SendService> _sendService;
//        //private readonly Mock<SmtpClient> _smtpoClient;
//        //private EmailMessage emailMessage;
//        private readonly SendService _sendService;
//        private readonly Mock<ISmtpClientBuilder> _smtpClientWrapper;
//        private readonly Mock<IEmailClientWrapper> _emailClientWrapper;

//        public UnitTest1()
//        {
//            _smtpClientWrapper = new Mock<ISmtpClientBuilder>();
//            _emailClientWrapper = new Mock<IEmailClientWrapper>();

//            _sendService = new SendService(_smtpClientWrapper.Object, _emailClientWrapper.Object);
//        }

//        [Fact]
//        public async Task Send_method_should_create_address_with_orxeflights_at_gmail_com_and_display_name_tripster()
//        {
//            var msg = new EmailMessage
//            {

//                Subject = "hi",
//                To = new List<string>{ "vitripathi@tavisca.com", "vikas.t8872@gmail.com" },
//                Body = "gfhgf"
//            };
//            var from = new MailAddress("orxeflights@gmail.com", "Tripster");
//            //var to1 = new MailAddress(msg.To[0]);
//            //var to2 = new MailAddress(msg.To[1]);

//            _emailClientWrapper.Setup(x => x.CreateAddress("orxeflights@gmail.com", "Tripster")).Returns(from);
//            _emailClientWrapper.Setup(x => x.CreateAddress(msg.To[0])).Returns(to1);
//            _emailClientWrapper.Setup(x => x.CreateAddress(msg.To[1])).Returns(to2);
//            //_emailClientWrapper.Setup(x => x.CreateMessage(to1, to2)).Returns(new MailMessage(from, to1));
//            //_emailClientWrapper.Setup(x => x.CreateMessage(to1, to2)).Returns(new MailMessage(from, to2));

//            await _sendService.Send(msg);
//            _emailClientWrapper.Verify(x => x.CreateAddress("orxeflights@gmail.com", "Tripster"), Times.Once);
//        }





//        [Fact]
//        public void Send_method_should_throw_null_exception_when_empty_to_list_is_passed()
//        {

//            var emailMessage = new EmailMessage
//            {
//                Body = "123",
//                To = new List<string> { },
//                Subject = "trip created"
//            };

//            MailAddress from = new MailAddress("orxeflights@gmail.com", "Tripster");
//            MailAddress to = new MailAddress(emailMessage.To[0]);
//            MailMessage message = new MailMessage(from, to);
//            _smtpClientWrapper.Setup(x => x.SendMailAsync(message)).Returns(() => throw new ArgumentNullException());
//            message.Body = emailMessage.Body;
//            message.Subject = emailMessage.Subject;
//            var response = _sendService.Send(emailMessage);
//            response.Status.Should().Equals(Status.failure);
//            //_smtpClientWrapper.Setup(x => x.SendMailAsync(message)).Throws<Exception>();

//        }

//    }
//}
