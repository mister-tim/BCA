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
    public class RegistrationModel : PageModel
    {
        public Customer Custodes { get; set; }
        public void OnPost()
        {
            
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("Chess.Reply.Automatic@gmail.com", "sc0rpi0n");
            MailMessage matey = new MailMessage();
            matey.To.Add(Custodes.Parentemail);
            matey.From = new MailAddress("Chess.Reply.Automatic@gmail.com");
            matey.Subject = "Fack";
            matey.Body = "Oh my,this appears to be the body of the Email. You've selected " + Custodes.Classchoice;
            client.Send(matey);
            
        }
    }
}
public class Customer
{
    public string Studentname { get; set; }
    public string Parentname { get; set; }
    public string Parentnumber { get; set; }
    public string Parentemail { get; set; }
    public int Classchoice { get; set; }
}