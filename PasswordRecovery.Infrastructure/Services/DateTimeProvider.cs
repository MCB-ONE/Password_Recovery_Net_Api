using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PasswordRecovery.Application.Common.Interfaces.Services;

namespace PasswordRecovery.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}