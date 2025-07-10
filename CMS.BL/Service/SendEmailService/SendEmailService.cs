using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net; 
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CMS.BL.Service.SendEmailService
{
    public class SendEmailService: ISendEmailService
    {
        private readonly IConfiguration _configuration;
        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string Email, string Subject, string Message)
        {
         //  var emailSettings  = _configuration.GetSection("EmailSettings");
            var Mail = _configuration["EmailSettings:Email"];
            var Password = _configuration["EmailSettings:Password"];

            try
            {
                var Client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(Mail, Password)
                };

                await Client.SendMailAsync(new MailMessage(from: Mail, to: Email, Subject, Message));
            }
            catch (SmtpException ex)
            {
                
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
