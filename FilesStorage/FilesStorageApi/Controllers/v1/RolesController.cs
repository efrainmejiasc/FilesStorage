using FilesStorageShared.Application;
using FilesStorageShared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FilesStorageApi.Controllers.v1
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        /// <summary>
        /// Crea un nuevo rol de usuario
        /// </summary>
        /// <param name="usuarioDTO">Crear rol  de usuarios</param>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostRolUsuario")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostRolUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Id = 0;


            var genericResponse = new GenericResponse();

            if (genericResponse.Ok)
                return Ok(EngineService.SetGenericResponse(true, "Usuario agregado correctamente"));

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));

        }
    }
}
