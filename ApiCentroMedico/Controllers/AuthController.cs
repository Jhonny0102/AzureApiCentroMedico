using ApiCentroMedico.Helpers;
using ApiCentroMedico.Models;
using ApiCentroMedico.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiCentroMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryCentroMedico repo;
        private HelperActionServicesOAuth helper;
        public AuthController(RepositoryCentroMedico repo, HelperActionServicesOAuth helper)
        {
            this.repo = repo;
            this.helper = helper;
        }

        /// <summary>
        /// Obtiene el información del USUARIO(Login), tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver el token.
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(Login login)
        {
            Usuario usuario = this.repo.GetLogin(login.Correo,login.Contra);
            if (usuario == null)
            {
                return Unauthorized();
            }
            else
            {
                SigningCredentials credentials = new SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256);

                string jsonusuario = JsonConvert.SerializeObject(usuario);

                Claim[] informacion = new[]
                {
                    new Claim("Userdata",jsonusuario)
                };

                JwtSecurityToken token = new JwtSecurityToken
                    (
                        claims:informacion,
                        issuer: this.helper.Issuer,
                        audience: this.helper.Audience,
                        signingCredentials: credentials,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        notBefore:DateTime.UtcNow
                    );
                return Ok(
                    new
                    {
                        response = new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
        }
    }
}
