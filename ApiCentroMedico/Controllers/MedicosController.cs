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
        /// Obtiene informacion MEDICO.
        /// </summary>
        /// <remarks>
        /// Método para los datos de un medico
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{idmedico}")]
        public async Task<ActionResult<Medico>> FindMedico(int idmedico)
        {
            return this.repo.FindMedico(idmedico);
        }

        /// <summary>
        /// Obtiene informacion DETALLADA de MEDICO.
        /// </summary>
        /// <remarks>
        /// Método para devolver datos de forma detallada de un medico
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{idmedico}")]
        public async Task<ActionResult<MedicoDetallado>> FindMedicoDetallado(int idmedico)
        {
            return this.repo.FindMedicoDetallado(idmedico);
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
        /// Obtiene informacion filtrada de CITAS DETALLADA.
        /// </summary>
        /// <remarks>
        /// Método para devolver la informacion detallada de las citas de la BBDD mediante un filtro (Muestra las citas que hay ese fecha solicitada)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{idmedico}/{fecha}")]
        public async Task<ActionResult<List<CitaDetalladaMedicos>>> FindCitaDetalladaMedicoList(int idmedico, DateTime fecha)
        {
            return this.repo.FindCitasDetalladasMedicos(idmedico,fecha);
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
        /// Permite crear un MEDICO.
        /// </summary>
        /// <remarks>
        /// Método para crear un MEDICO nuevo
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPost]
        [Route("[action]/{nombre}/{apellido}/{correo}/{contra}/{especialidad}")]
        public async Task<ActionResult> CreateMedico(string nombre, string apellido, string correo, string contra, int especialidad)
        {
            this.repo.CreateMedico(nombre,apellido,correo,contra,especialidad);
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

        /// <summary>
        /// Permite Actualizar los datos MEDICO
        /// </summary>
        /// <remarks>
        /// Método para actualizar una los datos de un MEDICO.
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdateMedico(Medico medico)
        {
            this.repo.EditMedico(medico.Id, medico.Nombre, medico.Apellido, medico.Correo, medico.Contra, medico.EstadoUsuario, medico.TipoUsuario, medico.Especialidad);
            return Ok();
        }
    }
}
