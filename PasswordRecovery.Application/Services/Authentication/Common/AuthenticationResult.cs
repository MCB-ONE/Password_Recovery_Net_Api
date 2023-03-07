
using PasswordRecovery.Domain.Entities;

namespace PasswordRecovery.Application.Services.Authentication.Common;

public record AuthenticationResult
(
    User User,
    string Token);
