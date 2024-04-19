﻿using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentroMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private RepositoryCentroMedico repo;
        public AdministradorController(RepositoryCentroMedico repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Obtiene el conjunto de CITAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los datos de las citas
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Cita>>> GetAllCitas()
        {
            return this.repo.GetCitasAll();
        }

        /// <summary>
        /// Obtiene la informacion sobre una CITA.
        /// </summary>
        /// <remarks>
        /// Método para devolver datos de una cita
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]/{idcita}")]
        public async Task<ActionResult<Cita>> FindCita(int idcita)
        {
            return this.repo.FindCita(idcita); ;
        }

        /// <summary>
        /// Obtiene el conjunto de PETICIONES de USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para los datos de las peticiones de usuarios
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<PeticionesDetallado>>> GetPeticionesDetalladasUsuarios()
        {
            return this.repo.GetPeticionesDetallado();
        }

        /// <summary>
        /// Obtiene el conjunto de PETICIONES de MEDICAMENTOS.
        /// </summary>
        /// <remarks>
        /// Método para los datos de las peticiones de medicamentos de forma detallada
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<PeticionesMedicamentoDetallado>>> GetPeticionesDetalladasMedicamentos()
        {
            return this.repo.GetPeticionesMedicametentosDetallado();
        }

        /// <summary>
        /// Permite aceptar una peticion de un USUARIO.
        /// </summary>
        /// <remarks>
        /// Método para aceptar la peticion solicitada por un recepcionista de un usuario. Una vez realizada la peticion , esta se elimina
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPut]
        [Route("[action]/{idpeticion}/{idusuario}/{idestadonuevo}")]
        public async Task<ActionResult> AceptarPeticionUsuario(int idpeticion, int idusuario , int idestadonuevo)
        {
            this.repo.OkPetcion(idpeticion,idusuario,idestadonuevo);
            return Ok();
        }

        /// <summary>
        /// Permite denagar una peticion de un USUARIO.
        /// </summary>
        /// <remarks>
        /// Método para denegar la peticion solicitada por un recepcionista de un usuario. Una vez realizada la peticion , esta se elimina
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPut]
        [Route("[action]/{idpeticion}")]
        public async Task<ActionResult> DenegarPeticionUsuario(int idpeticion)
        {
            this.repo.OkNoPeticion(idpeticion);
            return Ok();
        }

        /// <summary>
        /// Permite aceptar una peticion de un MEDICAMENTO **** Necesario crear todas las situaciones que pede tener este metodo
        /// </summary>
        /// <remarks>
        /// Método para aceptar la peticion de un medicameto solicitado por un MEDICO
        /// Recuerda, este metodo puede recibir idmedicamento y descripcion:
        /// 1. Si recibe el idmedicamento , solicitara la actualizacion del estado del medicamento.
        /// 2. Si recibe descripcion , solicitara el alta de un medicamento.
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPut]
        [Route("[action]/{idpeticion}/{idmedicamento}/{nombre}/{descripcion}/{estado}")]
        public async Task<ActionResult> AceptarPeticionMedicamento(int idpeticion, int? idmedicamento, string nombre, string? descripcion, int estado)
        {
            this.repo.OkPeticionMedicamento(idpeticion,idmedicamento,nombre,descripcion,estado);
            return Ok();
        }

        /// <summary>
        /// Permite denagar una peticion de un MEDICAMENTO.
        /// </summary>
        /// <remarks>
        /// Método para denegar la peticion solicitada por un medico de un medicamento. Una vez realizada la peticion , esta se elimina
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpPut]
        [Route("[action]/{idpeticion}")]
        public async Task<ActionResult> DenegarPeticionMedicamento(int idpeticion)
        {
            this.repo.OkNoPeticionMedicamento(idpeticion);
            return Ok();
        }

        /// <summary>
        /// Permite eliminar una CITA.
        /// </summary>
        /// <remarks>
        /// Método para eliminar una cita
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>   
        [HttpDelete]
        [Route("[action]/{idcita}")]
        public async Task<ActionResult> DeleteCita(int idcita)
        {
            this.repo.DeleteCita(idcita);
            return Ok();
        }
    }
}
