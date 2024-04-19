using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentroMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private RepositoryCentroMedico repo;
        public UsuariosController(RepositoryCentroMedico repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Obtiene el información del USUARIO(Login), tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver toda la informacion del USUARIOS de la BBDD mediante CORREO y CONTRA
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpGet]
        [Route("[action]/{correo}/{contra}")]
        public async Task<ActionResult<Usuario>> GetLogin(string correo, string contra)
        {
            return this.repo.GetLogin(correo,contra);
        }

        /// <summary>
        /// Obtiene el información de un conjunto USUARIOS, Tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver los usuarios de la bbdd
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            return this.repo.GetUsuarios();
        }

        /// <summary>
        /// Obtiene el información del USUARIO, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver toda la informacion del USUARIOS de la BBDD mediante IdUsuario
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Usuario>> FindUsuario(int id)
        {
            return this.repo.FindUsuario(id);
        }

        /// <summary>
        /// Obtiene el información del USUARIO DETALLADO.
        /// </summary>
        /// <remarks>
        /// Método para devolver toda la informacion del USUARIOS DETALLADO de la BBDD mediante IdUsuario
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<UsuarioDetallado>> GetUsuarioDetallado(int id)
        {
            return this.repo.FindUsuarioDetallado(id);
        }

        /// <summary>
        /// Obtiene el información de Tipos(Roles), Tabla TIPOUSUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los tipos de roles de los usuarios
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<UsuariosTipo>>> GetTipoUsuarios()
        {
            return this.repo.GetTipoUsuarios();
        }

        /// <summary>
        /// Obtiene el información de un conjunto USUARIOS, Tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver los usuarios de un tipo especifico(Rol)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpGet]
        [Route("[action]/{tipo}")]
        public async Task<ActionResult<List<Usuario>>> GetUsuariosTipo(int tipo)
        {
            return this.repo.GetUsuariosTipo(tipo);
        }

        /// <summary>
        /// Permite crear un USUARIO, Tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para crear un usuario en la bbdd (Recepcionista o Admin)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpPost]
        public async Task<ActionResult> CreateUsuario(string nombre, string apellido, string correo, string contra, int tipo)
        {
            this.repo.CreateUsuario( nombre, apellido, correo, contra, tipo);
            return Ok();
        }

        /// <summary>
        /// Actualiza la información de un USUARIOS, Tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para actualizar el usuarios de la bbdd (Admin y Recepcionista)
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpPut]
        public async Task<ActionResult> UpdateUsuario(Usuario usuario)
        {
            this.repo.EditUsuario(usuario.Id,usuario.Nombre,usuario.Apellido,usuario.Correo,usuario.Contra,usuario.Id_EstadoUsuario,usuario.Id_TipoUsuario);
            return Ok();
        }

        /// <summary>
        /// Elimina un USUARIOS, Tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para eliminar un usuario de la bbdd .Pasamos el parametro tipo porque dependiendo del rol que sea tiene que eliminar datos de
        /// diferentes tablas
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpDelete]
        [Route("[action]/{id}/{tipo}")]
        public async Task<ActionResult> DeleteUsuario(int id, int tipo)
        {
            this.repo.DeleteUsuario(id,tipo);
            return Ok();
        }
    }
}
