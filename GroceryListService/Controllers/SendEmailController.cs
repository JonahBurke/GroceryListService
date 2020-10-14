using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace GroceryListService.Controllers
{
    public class SendEmail : Controller
    {
        public string Index()
        {
            return "Use /send instead of /Index to send an email.";
        }

        public string Send(string email, string name, string subject, string text)
        {
            string getEmail = HttpUtility.HtmlEncode(email);
            string getName = HttpUtility.HtmlEncode(name);
            string getSubject = HttpUtility.HtmlEncode(subject);
            string getBodyText = HttpUtility.HtmlEncode(text);

            var fromAddress = new MailAddress("grocerylistservice@gmail.com", "grocerylistservice");
            var toAddress = new MailAddress(getEmail, getName);
            string fromPassword = "GroceryListServiceFall2020";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = getSubject,
                Body = getBodyText
            })
            {
                smtp.Send(message);
            }

            return "Email Sent!!!";
        }
    }
}
