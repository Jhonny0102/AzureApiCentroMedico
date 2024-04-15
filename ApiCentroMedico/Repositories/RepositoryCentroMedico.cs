using ApiCentroMedico.Data;
using ApiCentroMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCentroMedico.Repositories
{
    public class RepositoryCentroMedico 
    {
        private CentroMedicoContext context;
        public RepositoryCentroMedico(CentroMedicoContext context)
        {
            this.context = context;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await this.context.Usuarios.ToListAsync();
        }
    }
}
