using System;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;
using uts_helps_system.api.Data;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace uts_helps_system.api.ResourceManagement
{
    public class EmailTemplateManager
    {
        public EmailTemplateManager() {

        }

        public bool SendConfirmRegistrationEmail(string sendTo, string emailHeading, string emailMessage, string address, string subject, string bcc = "", string cc = "") {
            try {
                string body = File.ReadAllText($@"{Directory.GetCurrentDirectory()}/ResourceManagement/EmailTemplates/RegistrationTemplate.cshtml");
                body = body.Replace("{Heading}", emailHeading);
                body = body.Replace("{EmailMessage}", emailMessage);
                body = body.Replace("{address}", address);
                return CreateAndSendConfirmRegistrationEmail(body, sendTo, subject, bcc, cc);
            } catch(Exception) {
                return false;
            }
        }

        private bool CreateAndSendConfirmRegistrationEmail(string bodyText, string sendTo, string subject, string bcc, string cc) {
            string to, from, body;
            to = sendTo.Trim();
            from = CentralResourceManagement.FromEmailAddress;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            if(!string.IsNullOrEmpty(bcc)) {
                message.Bcc.Add(new MailAddress(bcc));
            }
            if(!string.IsNullOrEmpty(cc)) {
                message.Bcc.Add(new MailAddress(cc));
            }
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            return SendEmailMessage(message);
        }

        private bool SendEmailMessage(MailMessage message) {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(CentralResourceManagement.FromEmailAddress, CentralResourceManagement.FromEmailAddressPassword);
            try {
                smtpClient.Send(message);
                return true;
            } catch(Exception e) {
                e.ToString();
                return false;
            }
        }

    }
}