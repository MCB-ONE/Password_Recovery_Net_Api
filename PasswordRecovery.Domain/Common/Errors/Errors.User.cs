using ErrorOr;

namespace PasswordRecovery.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Este email ya existe."
            );

        public static Error EmailNotValidated => Error.Conflict(
                code: "User.EmailNotValidated",
                description: "Dirección de correo no validada."            );
    }
}
