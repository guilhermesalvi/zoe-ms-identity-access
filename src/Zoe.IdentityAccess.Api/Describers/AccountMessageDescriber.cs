namespace Zoe.IdentityAccess.Api.Describers
{
    public static class AccountMessageDescriber
    {
        public static ApplicationMessageDescriber ACCOUNT_USER_CREATED_SUCCESSFULLY => new ApplicationMessageDescriber(nameof(ACCOUNT_USER_CREATED_SUCCESSFULLY), nameof(ACCOUNT_USER_CREATED_SUCCESSFULLY));
        public static ApplicationMessageDescriber ACCOUNT_EMPTY_CONFIRM_PASSWORD => new ApplicationMessageDescriber(nameof(ACCOUNT_EMPTY_CONFIRM_PASSWORD), nameof(ACCOUNT_EMPTY_CONFIRM_PASSWORD));
        public static ApplicationMessageDescriber ACCOUNT_EMPTY_FULL_NAME => new ApplicationMessageDescriber(nameof(ACCOUNT_EMPTY_FULL_NAME), nameof(ACCOUNT_EMPTY_FULL_NAME));
        public static ApplicationMessageDescriber ACCOUNT_EMPTY_PASSWORD => new ApplicationMessageDescriber(nameof(ACCOUNT_EMPTY_PASSWORD), nameof(ACCOUNT_EMPTY_PASSWORD));
        public static ApplicationMessageDescriber ACCOUNT_EMPTY_PREFERRED_NAME => new ApplicationMessageDescriber(nameof(ACCOUNT_EMPTY_PREFERRED_NAME), nameof(ACCOUNT_EMPTY_PREFERRED_NAME));
        public static ApplicationMessageDescriber ACCOUNT_EMPTY_USER_EMAIL => new ApplicationMessageDescriber(nameof(ACCOUNT_EMPTY_USER_EMAIL), nameof(ACCOUNT_EMPTY_USER_EMAIL));
        public static ApplicationMessageDescriber ACCOUNT_INVALID_CONFIRM_PASSWORD => new ApplicationMessageDescriber(nameof(ACCOUNT_INVALID_CONFIRM_PASSWORD), nameof(ACCOUNT_INVALID_CONFIRM_PASSWORD));
        public static ApplicationMessageDescriber ACCOUNT_INVALID_EMAIL_FORMAT => new ApplicationMessageDescriber(nameof(ACCOUNT_INVALID_EMAIL_FORMAT), nameof(ACCOUNT_INVALID_EMAIL_FORMAT));
        public static ApplicationMessageDescriber ACCOUNT_INVALID_EMAIL_LENGTH => new ApplicationMessageDescriber(nameof(ACCOUNT_INVALID_EMAIL_LENGTH), nameof(ACCOUNT_INVALID_EMAIL_LENGTH));
        public static ApplicationMessageDescriber ACCOUNT_INVALID_FULL_NAME_FORMAT => new ApplicationMessageDescriber(nameof(ACCOUNT_INVALID_FULL_NAME_FORMAT), nameof(ACCOUNT_INVALID_FULL_NAME_FORMAT));
        public static ApplicationMessageDescriber ACCOUNT_INVALID_FULL_NAME_LENGTH => new ApplicationMessageDescriber(nameof(ACCOUNT_INVALID_FULL_NAME_LENGTH), nameof(ACCOUNT_INVALID_FULL_NAME_LENGTH));
        public static ApplicationMessageDescriber ACCOUNT_INVALID_PASSWORD_LENGTH => new ApplicationMessageDescriber(nameof(ACCOUNT_INVALID_PASSWORD_LENGTH), nameof(ACCOUNT_INVALID_PASSWORD_LENGTH));
        public static ApplicationMessageDescriber ACCOUNT_INVALID_PREFERRED_NAME_FORMAT => new ApplicationMessageDescriber(nameof(ACCOUNT_INVALID_PREFERRED_NAME_FORMAT), nameof(ACCOUNT_INVALID_PREFERRED_NAME_FORMAT));
        public static ApplicationMessageDescriber ACCOUNT_INVALID_PREFERRED_NAME_LENGTH => new ApplicationMessageDescriber(nameof(ACCOUNT_INVALID_PREFERRED_NAME_LENGTH), nameof(ACCOUNT_INVALID_PREFERRED_NAME_LENGTH));
    }
}
