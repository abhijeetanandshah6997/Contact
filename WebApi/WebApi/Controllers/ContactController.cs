using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ContactController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("api/Contact")]
        public string ContactUs(Contact contact)
        {
            System.Diagnostics.Debug.WriteLine(contact.bname);
            System.Diagnostics.Debug.WriteLine(contact.bemail);
            System.Diagnostics.Debug.WriteLine(contact.bsubject);
            System.Diagnostics.Debug.WriteLine(contact.bmobile);
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("abhijeet.anand99@gmail.com");
                mailMessage.To.Add(contact.bemail);
                mailMessage.Subject = contact.bname + " - "+ contact.bsubject;
                mailMessage.Body = "Hi " + contact.bname + ",\n\n" + contact.bmessage + "\n\nRegards,\nAbhijeet Anand Shah";
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                NetworkCredential credentials = new NetworkCredential("abhijeet.anand99@gmail.com", "upmsfuviwsogdsyb");
                smtpClient.Credentials = credentials;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                return "OTP Sent Successfully...!!!";
            }
            catch (Exception)
            {
                return "Sending OTP Failed";
            }
        }
    }
}
