﻿using System.Collections.Generic;

namespace MailServer.Models
{
    public class EMailMessage
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}