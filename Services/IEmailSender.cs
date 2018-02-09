using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPSyncCollegeRoom2018.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
