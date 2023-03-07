
using PasswordRecovery.Domain.Entities;

namespace PasswordRecovery.Application.Services.Authentication;

public record AuthenticationResult
(
    User user,
    string Token);
