using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var emailTask = new EmailTask()
            {
                Message = "Hello test email task",
                Recipient = "example@example.com"
            };

            var reportTask = new ReportTask() 
            {
                ReportName = "Annual Report",

            };


            var emailProcessor = new TaskProcessor<EmailTask, string>(emailTask);
            var reportProcessor = new TaskProcessor<ReportTask,string>(reportTask);

            Console.WriteLine(emailProcessor.Execute());
            Console.WriteLine(reportProcessor.Execute());
            





        }


    }

}



