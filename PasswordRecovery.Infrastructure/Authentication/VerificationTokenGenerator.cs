using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using PasswordRecovery.Application.Common.Interfaces.Authentication;

namespace PasswordRecovery.Infrastructure.Authentication;
public class VerificationTokenGenerator : IVerificationTokenGenerator
{
    public string GenerateVerificationToken()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
    }
}