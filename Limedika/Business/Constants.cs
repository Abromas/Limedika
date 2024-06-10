namespace Limedika.Business;

public class Constants
{
    public static class KeyVaultKeys
    {
        public const string DatabaseConnectionString = "DatabaseConnectionString";
        public const string StorageAccountKey = "StorageAccountKey";
        public const string PostItApiBaseUrl = "PostItApiBaseUrl";
        public const string PostItApiKey = "PostItApiKey";

    }
    public static class AppSettings
    {
        public const string AzureKeyVaultEndpoint = "KeyVault:Endpoint";
        public const string DbConnectionStringDevelopment = "DefaultConnection";
        public const string ApiBaseUrl = "PostItApi:BaseUrl";
        public const string ApiKey = "PostItApi:ApiKey";
    }

    public const int PostItRateLimit = 6;
    public const int PostItRequestTimeFrameInSeconds = 1;

}
