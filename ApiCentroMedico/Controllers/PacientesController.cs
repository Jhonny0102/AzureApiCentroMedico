using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentroMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private RepositoryCentroMedico repo;
        public PacientesController(RepositoryCentroMedico repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Obtiene el conjunto de USUARIOS, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las usuarios de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        //[HttpGet]
        //[Route("[action]")]
        //public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        //{
        //    return await this.repo.GetUsuariosAsync();
        //}

        /// <summary>
        /// Obtiene la informacion de PACIENTE, tabla USUARIOS(ROL PACIENTE).
        /// </summary>
        /// <remarks>
        /// Método para devolver la inforamcion un PACIENTE de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Paciente>> FindPaciente(int id)
        {
            return this.repo.FindPaciente(id);
        }

        /// <summary>
        /// Obtiene la toda la informacion detallada de PACIENTE, View .
        /// </summary>
        /// <remarks>
        /// Método para devolver la toda la informacion de un paciente detallado
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<PacienteDetallado>> FindPacienteDetallado(int id)
        {
            return this.repo.FindPacienteDetallado(id);
        }

        /// <summary>
        /// Obtiene la informacion extra de PACIENTE, View .
        /// </summary>
        /// <remarks>
        /// Método para devolver datos extras de un paciente
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<DatosExtrasPacientes>> GetDatosExtrasPaciente(int id)
        {
            return this.repo.FindDatosExtrasPacientes(id);
        }

        /// <summary>
        /// Obtiene la informacion de PACIENTE, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver los datos de un PACIENTE desde RECEPCION
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{nombre}/{apellido}/{correo}")]
        public async Task<ActionResult<Paciente>> GetPacienteRecepcion(string nombre, string apellido , string correo)
        {
            return this.repo.FindPacienteDistintoDetallado(nombre,apellido,correo);
        }

    }
}
