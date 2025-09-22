using DotNetEnv;

namespace Configuration
{
    public static class AppConfiguration
    {
        static AppConfiguration()
        {
            Env.Load();
        }

        public static string ClientId => 
            Environment.GetEnvironmentVariable("CLIENT_ID") 
            ?? throw new InvalidOperationException("CLIENT_ID environment variable is not set");

        public static string TenantId => 
            Environment.GetEnvironmentVariable("TENANT_ID") 
            ?? throw new InvalidOperationException("TENANT_ID environment variable is not set");

        public static string ClientSecret => 
            Environment.GetEnvironmentVariable("CLIENT_SECRET") 
            ?? throw new InvalidOperationException("CLIENT_SECRET environment variable is not set");

        public static string UserId => 
            Environment.GetEnvironmentVariable("USER_ID") 
            ?? throw new InvalidOperationException("USER_ID environment variable is not set");

        public static void ValidateConfiguration()
        {
            try
            {
                _ = ClientId;
                _ = TenantId;
                _ = ClientSecret;
                _ = UserId;
                Console.WriteLine("✓ Configuration validation passed");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"✗ Configuration validation failed: {ex.Message}");
                throw;
            }
        }
    }
}