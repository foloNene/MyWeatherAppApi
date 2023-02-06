using Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace WeatherApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;

        }

        public void SendMail(Message request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }


    }
}



//public void SendMail(Message message)
//{
//    var emailMessage = CreateEmailMessage(message);
//    Send(emailMessage);

//}

//private MimeMessage CreateEmailMessage(Message message)
//{
//    var emailMessage = new MimeMessage();
//    emailMessage.From.Add(new MailboxAddress("email", _Config.GetSection("From").Value));
//    emailMessage.To.AddRange(message.To);
//    emailMessage.Subject = message.Subject;
//    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
//    {
//        Text = message.Content
//    };
//    return emailMessage;
//}

//private void Send (MimeMessage mailMessage)
//{
//    using var client = new SmtpClient();
//    try
//    {
//        //var port = Convert.ToInt32(_Config.GetSection("Port").Value);
//       // client.Connect(_Config.GetSection("SmtpServer").Value, 587, true);
//        client.Connect(_Config.GetSection("SmtpServer").Value, 587, SecureSocketOptions.StartTls);

//        //client.Connect(_Config.GetSection("SmtpServer").Value, port, SecureSocketOptions.StartTls);
//        // client.AuthenticationMechanisms.Remove("XOAUTH2");
//        client.Authenticate(_Config.GetSection("UserName").Value, _Config.GetSection("Password").Value);

//        client.Send(mailMessage);
//        client.Disconnect(true);
//        client.Dispose();
//    }
//    catch
//    {
//        throw;
//    }
//    finally
//    {

//    }
//}
