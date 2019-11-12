using FluentAssertions;
using MailServer.Services;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace MailServerTest
{
    public class EmailWrapperFixture
    {
        IEmailClientWrapper emailclient = new EmailClientWrapper();

        [Fact]
        public void Should_return_valid_email_address_when_enter_email_address_in_string()
        {
            var actual = emailclient.CreateAddress("abc@gmail.com", "cdf");
            var expected = new MailAddress("abc@gmail.com", "cdf");
            actual.Should().BeEquivalentTo(expected);
        }

    }



}
