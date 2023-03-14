using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordRecovery.Application.Common.Interfaces.Authentication;

public interface IVerificationTokenGenerator
{
     string GenerateVerificationToken();
}