using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CarnageApi.Core;
using CarnageApi.Core.DTOs;
using CarnageApi.Core.Interfaces;
using EASendMail;

namespace CarnageApi.Core.Services
{
    public class EmailService : IEmailService
    {
        public string SendEmail(MessageDTO message) 
        {
            try
            {
                //var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                //var config = builder.Build();

                //var smtpClient = new SmtpClient(config["Smtp:Host"])
                //{
                //    Port= 465,
                //    Credentials = new NetworkCredential(config["Smtp:Username"], config["Smtp:Password"]),
                //    EnableSsl = true,

                //};
                ////admin@vanzylboorwerke.com
                //smtpClient.Send(config["Smtp:Username"], "jeandre610@gmail.com", "Vanzylboorwerke.com from "+ message.Email, message.Message);
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                var config = builder.Build();
                SmtpMail oMail = new SmtpMail("TryIt");

                oMail.From = config["Smtp:Username"];
                oMail.To = "admin@vanzylboorwerke.com";

                oMail.Subject = "Email from website from" ;
                oMail.TextBody = message.FirstName + ' ' + message.LastName + ' '+ message.Email +' '+ message.Message;

                // Your SMTP server address
                SmtpServer oServer = new SmtpServer(config["Smtp:Host"]);
                // User and password for ESMTP authentication
                oServer.User = config["Smtp:Username"];
                oServer.Password = config["Smtp:Password"];

                // Set SSL 465 port
                oServer.Port = 465;
                // Set direct SSL connection, you can also use ConnectSSLAuto
                oServer.ConnectType = SmtpConnectType.ConnectDirectSSL;

                Console.WriteLine("start to send email ...");

                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception e) 
            {
                return e.Message;
            }

            return "Sent";
        }
    }
}
