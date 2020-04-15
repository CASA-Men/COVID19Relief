using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19Relief.Middleware.Extensions
{
    public static class Email
    {
        public static string Send(string Receiver, string ReceiverEmail, string Subject, string Body)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Relief Register", "noreply@reliefRegister.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(Receiver, ReceiverEmail);
            message.To.Add(to);

            message.Subject = Subject;

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                HtmlBody = Body,
                TextBody = Body
            };

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.ionos.com", 587, false);//, false);
            client.Authenticate("Info@theiconflux.com", "Oyebanji@123");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return "";
        }

        public static string SendToAdmins(string Body)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Relief Register", "noreply@reliefRegister.com");

            message.From.Add(from);

            MailboxAddress to1 = new MailboxAddress("ololade", "loladeking@gmail.com");
            MailboxAddress to2 = new MailboxAddress("olaniyi", "olaniyiolatunji@gmail.com");
            message.To.Add(to1);
            message.To.Add(to2);

            message.Subject = "KMN exception";

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                HtmlBody = Body,
                TextBody = Body
            };

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.ionos.com", 587, false);//, false);
            client.Authenticate("Info@theiconflux.com", "Oyebanji@123");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return "";
        }
    }
}
