using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentroMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtrosController : ControllerBase
    {
        private RepositoryCentroMedico repo;
        public OtrosController(RepositoryCentroMedico repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Obtiene conjunto de datos ESTADOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver los datos de ESTADOS
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Estados>>> GetEstados()
        {
            return this.repo.GetEstados();
        }

        /// <summary>
        /// Obtiene string(Nombre) de ESTADO.
        /// </summary>
        /// <remarks>
        /// Método para devolver el nombre del estado que buscamos por id
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{idestado}")]
        public async Task<ActionResult<string>> FinNombreEstado(int idestado)
        {
            return this.repo.FindNombreEstado(idestado); ;
        }

        /// <summary>
        /// Obtiene conjunto de ESPECIALIDADES de los medicos.
        /// </summary>
        /// <remarks>
        /// Método para devolver los datos de las especialidades de los medicos
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Especialidades>>> GetEspecialidadesMedico()
        {
            return this.repo.GetEspecialidades();
        }

        /// <summary>
        /// Permite obtener un conjunto de estados de CITAS.
        /// </summary>
        /// <remarks>
        /// Método para obtener informacion de los estados de citas
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<SeguimientoCita>>> GetEstadosSeguimiento()
        {
            return this.repo.GetAllSeguimientoCita();
        }

        /// <summary>
        /// Permite convertir una lista de ints medicamentos en un mensaje.
        /// </summary>
        /// <remarks>
        /// Método para convertir a string una serie de ids
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<string>> GetMensaje([FromQuery] List<int> medicamentos)
        {
            return this.repo.ConvertToStringmedicamento(medicamentos);
        }
    }
}
