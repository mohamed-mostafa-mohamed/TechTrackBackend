using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.Service.SendEmailService
{
    public interface ISendEmailService
    {
        public Task SendEmailAsync(string Email, string Subject, string Message);

    }
}
