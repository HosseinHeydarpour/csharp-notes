using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace Csharp_Clean_Code
{

    

    internal class Program
    {

        // Dependency inversion principle (DIP)

        static void Main(string[] args)
        {
            IEmailService emailService = new EmailService();
            Notification notification = new Notification(emailService);
            notification.Send("Hello, this is a test notification. ")
        }



    }


    public interface IEmailService
    {
        public void SendEmail(string to, string subject, string body);
    }


    public class EmailService: IEmailService 
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to} with subject {subject}");
        }
    }


    public class Notification: IEmailService
    {
        private readonly IEmailService _emailService;

        public Notification(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Send(string message)
        {
            _emailService.SendEmail("user@example.com", "Notification", message);
        }
    }

    public class  MockEmailService : IEmailService 
    {

        public void SendEmail(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }

    }

}
