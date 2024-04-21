using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentroMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionistasController : ControllerBase
    {
        private RepositoryCentroMedico repo;
        public RecepcionistasController(RepositoryCentroMedico repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Obtiene la informacion de PACIENTE, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver los datos de un PACIENTE desde RECEPCION (Parametros = todo del PACIENTE) 
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{nombre}/{apellido}/{correo}")]
        public async Task<ActionResult<Paciente>> GetPacienteRecepcion(string nombre, string apellido, string correo)
        {
            return this.repo.FindPacienteDistintoDetallado(nombre, apellido, correo);
        }

        /// <summary>
        /// Permite crear una peticion de un USUARIO.
        /// </summary>
        /// <remarks>
        /// Método para crear una peticion de alta/baja de un USUAURIO 
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpPost]
        [Route("[action]/{idrecepcionista}/{idpaciente}/{nuevoestado}")]
        public async Task<ActionResult> CreatePeticionUsuario(int idrecepcionista, int idpaciente, int nuevoestado)
        {
            this.repo.CreatePeticionUsuarios(idrecepcionista, idpaciente, nuevoestado);
            return Ok();
        }
    }
}
