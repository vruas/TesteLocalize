using Microsoft.AspNetCore.Identity;

namespace LocalizaEmpresas.Models
{
    public class Usuario : IdentityUser
    {
        public ICollection<Empresa> Empresas { get; set; }
        Usuario() : base() { }
    }
}
