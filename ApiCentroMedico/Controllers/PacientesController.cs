using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        /// Obtiene la informacion extra de PACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para devolver datos extras de un paciente
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idpaciente}")]
        public async Task<ActionResult<DatosExtrasPacientes>> GetDatosExtrasPaciente(int idpaciente)
        {
            return this.repo.FindDatosExtrasPacientes(idpaciente);
        }

        /// <summary>
        /// Obtiene la informacion sobre el MEDICO y PACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para devolver los datos del MEDICO y su PACIENTE
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idpaciente}")]
        public async Task<ActionResult<MedicosPacientes>> GetMedicoPaciente(int idpaciente)
        {
            return this.repo.GetMedicoPaciente(idpaciente);
        }

        /// <summary>
        /// Obtiene la informacion sobre el MEDICO.
        /// </summary>
        /// <remarks>
        /// Método para devolver los datos del MEDICO asigando al PACIENTE
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idpaciente}")]
        public async Task<ActionResult<MedicoDetallado>> GetMiMedico(int idpaciente)
        {
            return this.repo.GetMiMedico(idpaciente);
        }

        /// <summary>
        /// Obtiene la informacion de PACIENTE, tabla USUARIOS(ROL PACIENTE).
        /// </summary>
        /// <remarks>
        /// Método para devolver la inforamcion un PACIENTE de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idpaciente}")]
        public async Task<ActionResult<Paciente>> FindPaciente(int idpaciente)
        {
            return this.repo.FindPaciente(idpaciente);
        }

        /// <summary>
        /// Obtiene la toda la informacion detallada de PACIENTE. *****Comparte con Medico
        /// </summary>
        /// <remarks>
        /// Método para devolver la toda la informacion de un paciente detallado
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idpaciente}")]
        public async Task<ActionResult<PacienteDetallado>> FindPacienteDetallado(int idpaciente)
        {
            return this.repo.FindPacienteDetallado(idpaciente);
        }

        /// <summary>
        /// Obtiene el conjunto de CITAS de un PACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para devolver las CITAS de un PACIENTE
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idpaciente}")]
        public async Task<ActionResult<List<CitaDetalladaMedicos>>> FindCitasPaciente(int idpaciente)
        {
            return this.repo.FindCitasPaciente(idpaciente);
        }

        /// <summary>
        /// Obtiene el conjunto de CITAS de un PACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para devolver las CITAS de un PACIENTE mediante un filtro de fechas 
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idpaciente}/{fechadesde}/{fechahasta}")]
        public async Task<ActionResult<List<CitaDetalladaMedicos>>> FindCitaDetalladaPaciente(int idpaciente, DateTime fechadesde, DateTime? fechahasta)
        {
            return this.repo.FindCitasDetalladasPAciente(idpaciente, fechadesde,  fechahasta);
        }

        /// <summary>
        /// Obtiene el conjunto de MEDICAMENTOS de un PACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para devolver los medicamentos asignados a un PACIENTE
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idpaciente}")]
        public async Task<ActionResult<List<MedicamentoYPaciente>>> GetMedicamentosPaciente(int idpaciente)
        {
            return this.repo.GetAllMedicamentosPaciente(idpaciente);
        }

        /// <summary>
        /// Devuelve un valor(int).
        /// </summary>
        /// <remarks>
        /// Método para devolver un valor( 0 y 1) , esto sirve para saber si la cita ya esta reservada
        /// Tener en cuenta que si esta en proceso y esta reservada devuelve 1 , si esta completada y reservada devolvera 0 (Finalizo la cita)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idmedico}/{fecha}/{hora}")]
        public async Task<ActionResult<int>> FindCitaReservada(int idmedico, DateTime fecha, TimeSpan hora)
        {
            return this.repo.FindCitaDispo(idmedico,fecha,hora);
        }

        /// <summary>
        /// Devuelve el Id de un MEDICO ALEATORIO.
        /// </summary>
        /// <remarks>
        /// Método para devolver el ID de un MEDICO aleatorio pasando el id de la especialidad
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpGet]
        [Route("[action]/{idespecialidad}")]
        public async Task<ActionResult<int>> GetIdMedicoAleatorio(int idespecialidad)
        {
            return this.repo.GetIdMedico(idespecialidad);
        }

        /// <summary>
        /// Permite crear un PACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para crear un PACIENTE (Recuerda que el Medico se saca del metodo GetIdMedico)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreatePaciente(string nombre, string apellido, string correo, string contra, int telefono, string direccion, int edad, string genero, int medico)
        {
            this.repo.CreatePaciente(nombre, apellido, correo, contra, telefono, direccion, edad, genero, medico);
            return Ok();
        }

        /// <summary>
        /// Permite crear un cita siendo PACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para crear un cita PACIENTE
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [Authorize]
        [HttpPost]
        [Route("[action]/{fecha}/{hora}/{idmedico}/{idpaciente}")]
        public async Task<ActionResult> CreateCitaPaciente(DateTime fecha, TimeSpan hora, int idmedico, int idpaciente)
        {
            this.repo.CreateCitaPaciente(fecha, hora, idmedico, idpaciente);
            return Ok();
        }


        /// <summary>
        /// Permite editar un PACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para editar un PACIENTE
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>  
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdatePaciente(Paciente paciente)
        {
            this.repo.EditPaciente(paciente.Id, paciente.Nombre, paciente.Apellido, paciente.Correo, paciente.Contra, paciente.Telefono, paciente.Direccion, paciente.Edad, paciente.Genero, paciente.EstadoUsuario, paciente.TipoUsuario);
            return Ok();
        }

        /// <summary>
        /// Permite editar una CITA siendo PACIENTE.
        /// </summary>
        /// <remarks>
        /// Método para editar una cita ya creada siendo PACIENTE
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>  
        [Authorize]
        [HttpPut]
        [Route("[action]/{idcita}/{fecha}/{hora}")]
        public async Task<ActionResult> UpdateCitaPaciente(int idcita, DateTime fecha, TimeSpan hora)
        {
            this.repo.UpdateCitaDetalladaPaciente(idcita, fecha, hora);
            return Ok();
        }
    }
}
