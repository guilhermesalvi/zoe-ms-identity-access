using Microsoft.AspNetCore.Identity;

namespace Zoe.IdentityAccess.Api.Describers
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new IdentityError { Code = "IDENTITY_DEFAULT_ERROR", Description = "IDENTITY_DEFAULT_ERROR" }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = "IDENTITY_CONCURRENCY_FAILURE", Description = "IDENTITY_CONCURRENCY_FAILURE" }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = "IDENTITY_PASSWORD_MISMATCH", Description = "IDENTITY_PASSWORD_MISMATCH" }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = "IDENTITY_INVALID_TOKEN", Description = "IDENTITY_INVALID_TOKEN" }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = "IDENTITY_LOGIN_ALREADY_ASSOCIATED", Description = "IDENTITY_LOGIN_ALREADY_ASSOCIATED" }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = "IDENTITY_INVALID_USER_NAME", Description = "IDENTITY_INVALID_USER_NAME" }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = "IDENTITY_INVALID_EMAIL", Description = "IDENTITY_INVALID_EMAIL" }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = "IDENTITY_DUPLICATE_USER_NAME", Description = "IDENTITY_DUPLICATE_USER_NAME" }; }
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = "IDENTITY_DUPLICATE_EMAIL", Description = "IDENTITY_DUPLICATE_EMAIL" }; }
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = "IDENTITY_INVALID_ROLE_NAME", Description = "IDENTITY_INVALID_ROLE_NAME" }; }
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = "IDENTITY_DUPLICATE_ROLE_NAME", Description = "IDENTITY_DUPLICATE_ROLE_NAME" }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = "IDENTITY_USER_ALREADY_HAS_PASSWORD", Description = "IDENTITY_USER_ALREADY_HAS_PASSWORD" }; }
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = "IDENTITY_USER_LOCKOUT_NOT_ENABLED", Description = "IDENTITY_USER_LOCKOUT_NOT_ENABLED" }; }
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = "IDENTITY_USER_ALREADY_IN_ROLE", Description = "IDENTITY_USER_ALREADY_IN_ROLE" }; }
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = "IDENTITY_USER_NOT_IN_ROLE", Description = "IDENTITY_USER_NOT_IN_ROLE" }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = "IDENTITY_PASSWORD_TOO_SHORT", Description = "IDENTITY_PASSWORD_TOO_SHORT" }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = "IDENTITY_PASSWORD_REQUIRES_NON_ALPHANUMERIC", Description = "IDENTITY_PASSWORD_REQUIRES_NON_ALPHANUMERIC" }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = "IDENTITY_PASSWORD_REQUIRES_DIGIT", Description = "IDENTITY_PASSWORD_REQUIRES_DIGIT" }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = "IDENTITY_PASSWORD_REQUIRES_LOWER", Description = "IDENTITY_PASSWORD_REQUIRES_LOWER" }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = "IDENTITY_PASSWORD_REQUIRES_UPPER", Description = "IDENTITY_PASSWORD_REQUIRES_UPPER" }; }
    }
}
