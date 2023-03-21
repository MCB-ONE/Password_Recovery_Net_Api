namespace PasswordRecovery.Contracts.Authentication;

public record VerifyRequest(
    string VerificationToken
);