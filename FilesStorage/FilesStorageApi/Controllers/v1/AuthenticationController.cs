using FilesStorageShared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.Threading.Tasks;
using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Extensions.Options;
using System.Net;
using FilesStorageApi.SecurityToken;
using FilesStorageShared.DTOs;
using AutoMapper;
using SharedProject.DTOs;
using FilesStorageShared.Application;
using Microsoft.AspNetCore.Authorization;

namespace FilesStorageApi.Controllers.v1
{
    /// <summary>
    /// Controlador para la autenticación.
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AzureActiveDirectorySettings _azureActiveDirectorySettings;
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;

        /// <summary>
        /// Constructor de AuthController.
        /// </summary>
        /// <param name="azureActiveDirectorySettings">La configuración de la aplicación.</param>
        ///  /// <param name="jwtBearerTokenSettings">La configuración de la aplicación.</param>
        ///   /// <param name="mapper">La configuración de la aplicación.</param>
        public AuthenticationController(IOptions<AzureActiveDirectorySettings> azureActiveDirectorySettings,
                             IOptions<JwtBearerTokenSettings> jwtBearerTokenSettings,
                             IMapper mapper)
        {
            _azureActiveDirectorySettings = azureActiveDirectorySettings.Value;
            _jwtBearerTokenSettings = jwtBearerTokenSettings.Value;
            _mapper = mapper;
        }

        /// <summary>
        /// Inicia sesión y obtiene un token de acceso.
        /// </summary>
        /// <param name="userCredentials">Credenciales del usuario.</param>
        /// <returns>El token de acceso.</returns>
        [HttpPost(Name = "Login")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(AccessToken))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
       // [Obsolete]
        public IActionResult Login([FromBody] UserCredentialsDTO userCredentials)
        {
            try
            {

                if (userCredentials == null)
                {
                    return BadRequest(EngineService.SetGenericResponse(false, "No se enviaron las credenciales"));
                }

                string clientId = _azureActiveDirectorySettings.ClientId;
                string clientSecret = _azureActiveDirectorySettings.ClientSecret;
                string tenantId = _azureActiveDirectorySettings.TenantId;
                string urlInstanceLogin = _azureActiveDirectorySettings.UrlInstanceLogin;

                string authority = $"{urlInstanceLogin}{tenantId}";

                //var authContext = new AuthenticationContext(authority);

                //var clientCredential = new Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential(clientId, clientSecret);

                //var userAssertion = new Microsoft.IdentityModel.Clients.ActiveDirectory.UserAssertion(userCredentials.Password, "password", userCredentials.Username);

                //var result = await authContext.AcquireTokenAsync("https://outlook.office365.com", clientCredential, userAssertion);
                //string tokeAAD = result.AccessToken;
                var tokenObject = BuilderToken(userCredentials);
                return Ok(tokenObject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private AccessToken BuilderToken(UserCredentialsDTO userCredentials)
        {
            var usuarioDTO = _mapper.Map<UsuarioDTO>(userCredentials);
            if (usuarioDTO == null)
                return null;

            TokenProvider tokenProvider = new TokenProvider(_jwtBearerTokenSettings);

            var tokenObject = tokenProvider.GenerarToken(usuarioDTO);

            return tokenObject;
        }
    }
}
