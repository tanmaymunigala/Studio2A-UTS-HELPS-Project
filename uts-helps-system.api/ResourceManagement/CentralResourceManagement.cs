namespace uts_helps_system.api.ResourceManagement
{
    /**
    * This class stores key constants useful in the operation of the application.
    * It is a rule that all values in this class should be constant (const) and should have a comment describing its nature,
    * purpose and where it is primarily used. The variable name should also be clear and meaningful.
    */
    public static class CentralResourceManagement
    {
        // This string is the connection string which is used in Startup.cs to establish a connection to the database.
        public const string DatabaseConnectionString = @"Server=localhost;Database=Uts_Helps_Core;Trusted_Connection=True;";

        // This integer is meant to indicate how many tokens are allowed to be managed by the system at the same time for each user. This value is used by the TokenManager.
        public const int UserTokenLimitPerUser = 3;

        // This string is meant to store the address of the Confirm Email method within the Registration Controller so that the User Manager can implant this url where needed, for example in replacing the address of an email template. 
        public const string ConfirmRegistrationUrl = "http://localhost:5000/api/UserRegistrationController/ConfirmEmail/";

        // This string is meant to store the email address that will be used by the Email Template Manager to send emails.
        public const string FromEmailAddress = "usermanagement1147@gmail.com";

        // This string is meant to store the password for the from email address. This is the password used for the crednetials to send to Google Mail via the Email Template Manager.
        public const string FromEmailAddressPassword = "Eishun2013!";
    }
}