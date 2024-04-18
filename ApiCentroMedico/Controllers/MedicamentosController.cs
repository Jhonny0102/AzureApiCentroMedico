using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
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
        /// Obtiene la informacion de Medicamentos y Pacientes. //Zona Medicamentos ***
        /// </summary>
        /// <remarks>
        /// Método para devolver los datos de esa asiganacion de medicamento al paciente (Parametro = IDMEDICAMENTOYPACIENTE)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<MedicamentoYPaciente>> FindMedicamentoYPaciente(int id)
        {
            return this.repo.FindMedicamentoYPaciente(id);
        }

        /// <summary>
        /// Permite actualidar los datos, Tabla MEDICAMENTOPACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para actualizar la disponibilidad de un medicamento asigando a un paciente (Parametro = IDMEDICAMENTOPACIENTE)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> UpdateMedicamentoYPaciente(int id)
        {
            this.repo.UpdateMedicamentoYPaciente(id);
            return Ok();
        }
    }
}
