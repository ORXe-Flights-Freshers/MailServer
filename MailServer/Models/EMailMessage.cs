using System.Collections.Generic;

namespace MailServer.Models
{
    public class EmailMessage
    {

       
       public List<string> To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}