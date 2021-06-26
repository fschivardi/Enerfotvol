using System;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BLL
{
    public class Mailing 
    {
        public bool EnviarMail(string destinatario, string asunto, string cuerpo)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("enerfotvolTFI@gmail.com", "myAdo5sSD7&0i4XjYCGi0O73");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("noreply@enerfotvol.com", "EnerFotVol");
            mail.To.Add(new MailAddress(destinatario));
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            mail.Body = cuerpo;
            try
            {
                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }            
        }        
    }
}
