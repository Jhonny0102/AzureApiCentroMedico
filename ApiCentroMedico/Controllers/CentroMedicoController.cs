using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentroMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroMedicoController : ControllerBase
    {
        private RepositoryCentroMedico repo;
        public CentroMedicoController(RepositoryCentroMedico repo)
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
        [Route("[action]")]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            return await this.repo.GetUsuariosAsync();
        }
    }
}
