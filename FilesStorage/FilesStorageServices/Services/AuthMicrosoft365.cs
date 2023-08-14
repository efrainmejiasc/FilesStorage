using System;
using System.Drawing;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace FilesStorageServices.Services
{
    public class AuthMicrosoft365
    {
        private static string clientId = "TU_CLIENT_ID";
        private static string clientSecret = "TU_CLIENT_SECRET";
        private static string tenantId = "TU_TENANT_ID";



        public AuthMicrosoft365()
        {
            
        }


        public async Task<string> GetAuthMS365()
        {
            var result = string.Empty;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "Url");
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("grant_Type", ""));
            formData.Add(new KeyValuePair<string, string>("client_id", ""));
            formData.Add(new KeyValuePair<string, string>("client_secret", ""));
            formData.Add(new KeyValuePair<string, string>("resource",""));
            request.Content = new FormUrlEncodedContent(formData);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        //static async Task Main(string[] args)
        //{
        //    var graphClient = await GetGraphServiceClientAsync();

        //    try
        //    {
        //        var user = await graphClient.Me.GetAsync();
        //        Console.WriteLine($"Usuario autenticado: {user.DisplayName}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al obtener el usuario: {ex.Message}");
        //    }
        //}

        //static async Task<GraphServiceClient> GetGraphServiceClientAsync()
        //{
        //    IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
        //        .Create(clientId)
        //        .WithClientSecret(clientSecret)
        //        .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
        //        .Build();

        //    string[] scopes = new string[] { "https://graph.microsoft.com/.default" };

        //    AuthenticationResult authenticationResult = await confidentialClientApplication
        //        .AcquireTokenForClient(scopes)
        //        .ExecuteAsync();

        //    GraphServiceClient graphClient = new GraphServiceClient(
        //        new DelegateAuthenticationProvider((requestMessage) =>
        //        {
        //            requestMessage.Headers.Authorization =
        //                new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
        //            return Task.FromResult(0);
        //        }));

        //    return graphClient;
        //}
    }
}
