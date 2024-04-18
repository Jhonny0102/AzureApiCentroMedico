using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentroMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private RepositoryCentroMedico repo;
        public MedicosController(RepositoryCentroMedico repo)
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
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<MedicoDetallado>> FindMedicoDetallado(int id)
        {
            return this.repo.FindMedicoDetallado(id);
        }

        /// <summary>
        /// Obtiene el conjunto de pacientes de un MEDICO.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las paciente de un MEDICO de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{idmedico}")]
        public async Task<ActionResult<List<MedicosPacientes>>> GetMisPaciente(int idmedico)
        {
            return this.repo.MisPacientes(idmedico);
        }

        /// <summary>
        /// Obtiene el conjunto de CITAS de un MEDICO.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las citas de un MEDICO que tiene con sus paciente de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{idmedico}")]
        public async Task<ActionResult<List<CitaDetalladaMedicos>>> GetCitasDetalladasMedico(int idmedico)
        {
            return this.repo.GetCitasDetalladasMedico(idmedico);
        }

        /// <summary>
        /// Obtiene informacion sobre una CITA DETALLADA.
        /// </summary>
        /// <remarks>
        /// Método para devolver la informacion detallada de una cita de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{idcita}")]
        public async Task<ActionResult<CitaDetalladaMedicos>> FindCitaDetalladaMedico(int idcita)
        {
            return this.repo.FindCitasDetalladasMedicosSinFiltro(idcita);
        }

        /// <summary>
        /// Solicitud de creacion de un MEDICAMENTO.
        /// </summary>
        /// <remarks>
        /// Método para crear una solicitud de un medicamento nuevo, se pasa 3 parametros
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPost]
        [Route("[action]/{idmedico}/{nombremedicamento}/{descripcionmedicamento}")]
        public async Task<ActionResult> CreateSolicitudAltaMedicamento(int idmedico, string nombremedicamento, string descripcionmedicamento)
        {
            this.repo.CreatePeticionMedicamentoSinId(idmedico,nombremedicamento,descripcionmedicamento);
            return Ok();
        }

        /// <summary>
        /// Solicitud de actualizacion de un MEDICAMENTO.
        /// </summary>
        /// <remarks>
        /// Método para crear una solicitud de actualizaciín de un medicamento , se pasa 3 parametros
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPut]
        [Route("[action]/{idmedico}/{idmedicamento}/{estadomedicamento}")]
        public async Task<ActionResult> CreateSolicitudActualizacionEstadoMedicamento(int idmedico, int idmedicamento, int estadomedicamento)
        {
            this.repo.CreatePeticionMedicamentoConId(idmedico,idmedicamento,estadomedicamento);
            return Ok();
        }

        /// <summary>
        /// Permite Actualizar(finalizar) una Cita Medica. ***Error Raro
        /// </summary>
        /// <remarks>
        /// Método para actualizar una cita. Esto seria la finalización de una cita medica donde pasamos ciertos parametros.
        /// Si pasamos los id de medicamentos por el campo medicamentos no lo coge, pero si lo pasamos por el body si **
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPut]
        [Route("[action]/{idmedico}/{idpaciente}/{idcita}/{comentario}/{seguimiento}/{medicamentos}")]
        public async Task<ActionResult> UpdateCitaMedica(int idmedico, int idpaciente, int idcita, string comentario, int seguimiento, List<int> medicamentos)
        {
            this.repo.UpdateCitaMedica(idmedico, idpaciente, idcita,comentario,seguimiento,medicamentos);
            return Ok();
        }
    }
}
