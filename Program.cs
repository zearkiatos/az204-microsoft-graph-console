using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Configuration;

namespace MicrosoftGraphConsole
{
    static class Program
    {
        private static readonly string clientId = AppConfiguration.ClientId;
        private static readonly string clientSecret = AppConfiguration.ClientSecret;
        private static readonly string tenantId = AppConfiguration.TenantId;
        private static readonly string userId = AppConfiguration.UserId;

        public static async Task Main(string[] args)
        {
            var app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
                .Build();

            var scopes = new string[] { "https://graph.microsoft.com/.default" };
            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

            var response = await httpClient.GetAsync($"https://graph.microsoft.com/v1.0/users/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
}