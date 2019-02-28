using System.Net.Mail;

namespace OnBoardingHumanaAPI.Common
{
    public static class Mail
    {
        public static void SendMail(string from, string to, string subject, string body)
        {
            var mail = new MailMessage(from, to);
            var client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "apacsmtp.cts.com";
            mail.Subject = subject;
            mail.Body = body;
            client.Send(mail);
        }
    }
}