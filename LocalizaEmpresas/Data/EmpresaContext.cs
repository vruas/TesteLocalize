using LocalizaEmpresas.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalizaEmpresas.Data
{
    public class EmpresaContext : DbContext
    {
        public EmpresaContext(DbContextOptions<EmpresaContext> options) : base(options)
        {

        }

        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                 .OwnsOne(empresa => empresa.AtividadePrincipal, atv =>
                 {
                     atv.Property(a => a.Codigo).HasColumnName("CodigoAtividadePrincipal");
                     atv.Property(a => a.Descricao).HasColumnName("DescricaoAtividadePrincipal");
                 });

            modelBuilder.Entity<Empresa>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Empresas)
                .HasForeignKey(e => e.UsuarioId);


        }

        

    }
    
}
