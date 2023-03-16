using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordRecovery.Application.Common.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(string emailAddress, string confirmationLink);
    }
}