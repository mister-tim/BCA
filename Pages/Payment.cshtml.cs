using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohnsonChessAcademy.Pages
{
    public class PaymentModel : PageModel
    {
        public void OnPost()
        {
            string pn = Request.Cookies["parentname"];
            string sn = Request.Cookies["studentname"];
            string nm = Request.Cookies["phonenumber"];
            string eml = Request.Cookies["email"];
            string cc = Request.Cookies["class"];
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("Chess.Reply.Automatic@gmail.com", "sc0rpi0n");
            MailMessage matey = new MailMessage();
            matey.To.Add(eml);
            matey.From = new MailAddress("Chess.Reply.Automatic@gmail.com");
            matey.Subject = sn;
            matey.Body = pn + ' ' + nm + ' ' + cc;
            client.Send(matey);
        }
    }
}