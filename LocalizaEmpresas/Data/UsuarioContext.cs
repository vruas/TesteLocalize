using LocalizaEmpresas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalizaEmpresas.Data
{
    public class UsuarioContext : IdentityDbContext<Usuario>
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }
        
    }
}
