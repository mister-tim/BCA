using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JohnsonChessAcademy.Pages
{
    public class TEST_CallendarModel : PageModel
    {
        public void OnPost()
        {
            string pn = Request.Cookies["parentname"];
            string sn = Request.Cookies["studentname"];
            string nm = Request.Cookies["phonenumber"];
            string eml = Request.Cookies["email"];
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("Chess.Reply.Automatic@gmail.com", "sc0rpi0n");
            MailMessage matey = new MailMessage();
            matey.To.Add(eml);
            matey.From = new MailAddress("Chess.Reply.Automatic@gmail.com");
            matey.Subject = sn;
            matey.Body = pn + ' ' + nm;
            client.Send(matey);
        }
    }
}