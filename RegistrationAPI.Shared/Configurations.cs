namespace RegistrationAPI.Shared
{
    public static class EndpointConfig
    {
        public const string BaseUserUrl = "/api/users";
        public const string UserByIdUrl = BaseUserUrl + "/{id:int}";
        public const string MigrateUserUrl = BaseUserUrl + "/migrate";
        public const string BulkUserUrl = BaseUserUrl + "/bulk";
        public const string UserStatusUrl = BaseUserUrl + "/status";
        public const string SearchUserUrl = BaseUserUrl + "/search";
        public const string OtpExpiredMessage = "OTP has expired. Please request a new one.";

        // Pin Management URLs
        public const string SetupPinUrl = BaseUserUrl + "/pin/setup";
        public const string VerifyPinUrl = BaseUserUrl + "/pin/verify";

        // OTP URLs
        public const string SendOtpUrl = BaseUserUrl + "/otp/send";
        public const string VerifyOtpUrl = BaseUserUrl + "/otp/verify";
        public const string EnableBiometricUrl = BaseUserUrl + "/biometric/enable";

        // OTP Messages
        public const string OtpSendSuccessMessage = "OTP {0} sent to {1}";
        public const string OtpSendFailureMessage = "Failed to send OTP for {0}";
        public const string OtpVerificationSuccessMessage = "OTP verified successfully for {0}";
        public const string OtpVerificationFailureMessage = "Invalid OTP code for {0}";
        public const string OtpSaveErrorMessage = "Failed to save OTP for {0}";
        public const string OtpDeleteErrorMessage = "Failed to delete OTP for {0}";
        public const string OtpDeleteSuccessMessage = "OTP deleted successfully for {0}";
        public const string OtpNotFoundMessage = "No OTP found for {0}";
        public const string OtpErrorMessage = "Error occurred while processing OTP for {0}";
        public const string OtpGenerationMessage = "Generated OTP: {0} for {1} with expiry at {2}";
        public const string OtpExpiryTimeMessage = "OTP Expiry Time: {0}";
        public const string OtpCurrentTimeMessage = "Current UTC Time: {0}";
        public const string OtpSendingMessage = "Attempting to send OTP for {0}";
        public const string OtpSentMessage = "OTP sent successfully to {0}";
        public const string OtpSaveFailureMessage = "Failed to save OTP for {0}";
        public const string OtpVerificationAttemptMessage = "Attempting to verify OTP for {0}";
        public const string OtpExpiredLogMessage = "OTP expired for {0}";

        // Endpoint Names
        public const string GetAllUsersName = "User_GetAllUsers";
        public const string GetUserByIdName = "User_GetUserById";
        public const string CreateUserName = "User_CreateUser";
        public const string UpdateUserName = "User_UpdateUser";
        public const string DeleteUserName = "User_DeleteUser";
        public const string MigrateUserName = "User_MigrateUser";
        public const string BulkCreateUsersName = "User_BulkCreateUsers";
        public const string UpdateUserStatusName = "User_UpdateUserStatus";
        public const string SearchUsersName = "User_SearchUsers";

        // Biometric Endpoint and Name
        public const string EnableBiometricName = "User_EnableBiometric";

        // Biometric Messages
        public const string BiometricEnableSuccessMessage = "Biometric enabled successfully.";
        public const string BiometricEnableFailureMessage = "Failed to enable biometric.";

        // OTP Endpoint Names
        public const string SendOtp = "User_SendOtp";
        public const string VerifyOtp = "User_VerifyOtp";

        // OTP Messages
        public const string SendOtpSuccessMessage = "OTP sent successfully.";
        public const string SendOtpFailureMessage = "Failed to send OTP.";
        public const string VerifyOtpSuccessMessage = "OTP verified successfully.";
        public const string VerifyOtpFailureMessage = "Invalid OTP provided.";

        // Pin Management Names
        public const string SetupPinName = "SetupPin";
        public const string VerifyPinName = "VerifyPin";

        // Messages
        public const string UserNotFoundMessage = "User with id {0} does not exist.";
        public const string UserCreatedMessage = "User created successfully with ID {0}.";
        public const string InvalidInputMessage = "Invalid input. FirstName, LastName, and Email are required.";
        public const string UserStatusNotFoundMessage = "User with id {0} not found.";
        public const string BulkCreateSuccessMessage = "Bulk user creation successful.";
        public const string UserMigrationNotFoundMessage = "User with id {0} not found for migration.";
        public const string UserStatusUpdateMessage = "User status updated successfully.";
        public const string UserSearchSuccessMessage = "Users retrieved successfully based on search criteria.";

        // Pin Management Messages
        public const string InvalidPinMessage = "Invalid PIN provided.";
        public const string SetupPinSuccessMessage = "PIN setup successful.";
        public const string VerifyPinSuccessMessage = "PIN verified successfully.";

        // Swagger and Configuration
        public const string SwaggerUrl = "/swagger/v1/swagger.json";
        public const string SwaggerTitle = "Registration API V1";
        public const string ConnectionStringName = "DefaultConnection";

        // Biometric messages disable
        public const string BiometricDisableSuccessMessage = "Biometric disabled successfully.";
        public const string BiometricDisableFailureMessage = "Failed to disable biometric.";
    }
}