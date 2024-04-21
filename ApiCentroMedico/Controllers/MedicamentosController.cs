using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentroMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosController : ControllerBase
    {
        private RepositoryCentroMedico repo;
        public MedicamentosController(RepositoryCentroMedico repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Obtiene conjunto de MEDICAMENTOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver la informacion de todos los medicamentos de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Medicamentos>>> GetMedicamentos()
        {
            return this.repo.GetAllMedicamentos();
        }

        /// <summary>
        /// Obtiene datos de un MEDICAMENTO.
        /// </summary>
        /// <remarks>
        /// Método para devolver la informacion de un medicamento de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{idmedicamento}")]
        public async Task<ActionResult<Medicamentos>> FindMedicamento(int idmedicamento)
        {
            return this.repo.FindMedicamento(idmedicamento);
        }


        /// <summary>
        /// Obtiene la informacion de Medicamentos y Pacientes.
        /// </summary>
        /// <remarks>
        /// Método para devolver los datos de esa asiganacion de medicamento al paciente (Parametro = IDMEDICAMENTOYPACIENTE)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<MedicamentoYPaciente>> FindMedicamentoYPaciente(int id)
        {
            return this.repo.FindMedicamentoYPaciente(id);
        }

        /// <summary>
        /// Obtiene el conjunto de Medicamentos y Pacientes.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los datos de MedicamentoPaciente
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<MedicamentoYPacienteSInView>>> GetAllMedicamentoPaciente()
        {
            return this.repo.GetAllMedicamentoPaciente();
        }

        /// <summary>
        /// Permite actualidar los datos, Tabla MEDICAMENTOPACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para actualizar la disponibilidad(a BAJA) de un medicamento asigando a un paciente (Parametro = IDMEDICAMENTOPACIENTE)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> UpdateMedicamentoYPaciente(int id)
        {
            this.repo.UpdateMedicamentoYPaciente(id);
            return Ok();
        }
    }
}
