using FluentValidation;
using Zoe.IdentityAccess.Api.Describers;

namespace Zoe.IdentityAccess.Api.UseCases.CreateUserAccount
{
    public class CreateUserAccountCommandValidator : AbstractValidator<CreateUserAccountCommand>
    {
        private const string _allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";

        public CreateUserAccountCommandValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(AccountMessageDescriber.ACCOUNT_EMPTY_USER_EMAIL.Code).WithMessage(AccountMessageDescriber.ACCOUNT_EMPTY_USER_EMAIL.Description)
                .Length(5, 100).WithErrorCode(AccountMessageDescriber.ACCOUNT_INVALID_EMAIL_LENGTH.Code).WithMessage(AccountMessageDescriber.ACCOUNT_INVALID_EMAIL_LENGTH.Description)
                .EmailAddress().WithErrorCode(AccountMessageDescriber.ACCOUNT_INVALID_EMAIL_FORMAT.Code).WithMessage(AccountMessageDescriber.ACCOUNT_INVALID_EMAIL_FORMAT.Description);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(AccountMessageDescriber.ACCOUNT_EMPTY_PASSWORD.Code).WithMessage(AccountMessageDescriber.ACCOUNT_EMPTY_PASSWORD.Description)
                .Length(5, 100).WithErrorCode(AccountMessageDescriber.ACCOUNT_INVALID_PASSWORD_LENGTH.Code).WithMessage(AccountMessageDescriber.ACCOUNT_INVALID_PASSWORD_LENGTH.Description);

            RuleFor(x => x.ConfirmPassword)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(AccountMessageDescriber.ACCOUNT_EMPTY_CONFIRM_PASSWORD.Code).WithMessage(AccountMessageDescriber.ACCOUNT_EMPTY_CONFIRM_PASSWORD.Description)
                .Must((obj, prop) => obj.Password == prop).WithErrorCode(AccountMessageDescriber.ACCOUNT_INVALID_CONFIRM_PASSWORD.Code).WithMessage(AccountMessageDescriber.ACCOUNT_INVALID_CONFIRM_PASSWORD.Description);

            RuleFor(x => x.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(AccountMessageDescriber.ACCOUNT_EMPTY_FULL_NAME.Code).WithMessage(AccountMessageDescriber.ACCOUNT_EMPTY_FULL_NAME.Description)
                .Length(5, 100).WithErrorCode(AccountMessageDescriber.ACCOUNT_INVALID_FULL_NAME_LENGTH.Code).WithMessage(AccountMessageDescriber.ACCOUNT_INVALID_FULL_NAME_LENGTH.Description)
                .Must(HasOnlyAllowedChars).WithErrorCode(AccountMessageDescriber.ACCOUNT_INVALID_FULL_NAME_FORMAT.Code).WithMessage(AccountMessageDescriber.ACCOUNT_INVALID_FULL_NAME_FORMAT.Description);

            RuleFor(x => x.PreferredName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(AccountMessageDescriber.ACCOUNT_EMPTY_PREFERRED_NAME.Code).WithMessage(AccountMessageDescriber.ACCOUNT_EMPTY_PREFERRED_NAME.Description)
                .Length(2, 30).WithErrorCode(AccountMessageDescriber.ACCOUNT_INVALID_PREFERRED_NAME_LENGTH.Code).WithMessage(AccountMessageDescriber.ACCOUNT_INVALID_PREFERRED_NAME_LENGTH.Description)
                .Must(HasOnlyAllowedChars).WithErrorCode(AccountMessageDescriber.ACCOUNT_INVALID_FULL_NAME_FORMAT.Code).WithMessage(AccountMessageDescriber.ACCOUNT_INVALID_FULL_NAME_FORMAT.Description);
        }

        private bool HasOnlyAllowedChars(string value)
        {
            if (value is null) return false;

            foreach (var c in value)
            {
                var isIn = false;

                for (var i = 0; i < _allowedChars.Length; i++)
                {
                    if (_allowedChars[i] == c)
                    {
                        isIn = true;
                        break;
                    }
                }

                if (!isIn) return false;
            }

            return true;
        }
    }
}
