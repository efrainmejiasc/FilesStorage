using FilesStorageShared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.Threading.Tasks;
using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Extensions.Options;

namespace FilesStorageApi.Controllers.v1
{
    /// <summary>
    /// Controlador para la autenticación.
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AzureActiveDirectorySettings _azureActiveDirectorySettings;

        /// <summary>
        /// Constructor de AuthController.
        /// </summary>
        /// <param name="azureActiveDirectorySettings">La configuración de la aplicación.</param>
        public AuthController(IOptions<AzureActiveDirectorySettings> azureActiveDirectorySettings)
        {
            _azureActiveDirectorySettings = azureActiveDirectorySettings.Value;
        }

        /// <summary>
        /// Inicia sesión y obtiene un token de acceso.
        /// </summary>
        /// <param name="userCredentials">Credenciales del usuario.</param>
        /// <returns>El token de acceso.</returns>
        [HttpPost("login")]
        [Obsolete]
        public async Task<IActionResult> Login([FromBody] UserCredentials userCredentials)
        {
            try
            {
                string clientId = _azureActiveDirectorySettings.ClientId;
                string clientSecret = _azureActiveDirectorySettings.ClientSecret;
                string tenantId = _azureActiveDirectorySettings.TenantId;

                string authority = $"https://login.microsoftonline.com/{tenantId}";

                var authContext = new AuthenticationContext(authority);

                var clientCredential = new Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential(clientId, clientSecret);

                var userAssertion = new Microsoft.IdentityModel.Clients.ActiveDirectory.UserAssertion(userCredentials.Password, "password", userCredentials.Email);

                var result = await authContext.AcquireTokenAsync("https://outlook.office365.com", clientCredential, userAssertion);

                return Ok(new { AccessToken = result.AccessToken });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
