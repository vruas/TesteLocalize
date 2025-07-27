using LocalizaEmpresas.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalizaEmpresas.Data
{
    public class EmpresaContext : DbContext
    {
        public EmpresaContext(DbContextOptions<EmpresaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        public DbSet<Empresa> Empresas { get; set; }

    }
    
}
