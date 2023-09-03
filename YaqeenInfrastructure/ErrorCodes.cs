namespace YaqeenInfrastructure
{
    public static class ErrorCodes
    {
        public static class UserErrorCodes
        {
            public const string FirstNameMissing = "1";

            public static string FailedToStoreUserToDb = "2";
            public static string FailedToStoreUserLogicError = "2";
        }
    }
}
