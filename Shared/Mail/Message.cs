using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    public class Message
    {
        //public List<MailboxAddress> To { get; set; }

        //public string Subject { get; set; }

        //public string Content { get; set; }

        //public Message(IEnumerable<string> to, string subject, string content)
        //{
        //    To = new List<MailboxAddress>();
        //    To.AddRange(to.Select(x => new MailboxAddress("email",x)));
        //    Subject = subject;
        //    Content = content;
        //}

        public string To { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

        public Message(string to,string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
