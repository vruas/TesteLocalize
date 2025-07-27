using System.ComponentModel.DataAnnotations;

namespace LocalizaEmpresas.Dtos
{
    public class CadastroEmpresaDto
    {
        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ deve ter 14 caracteres.")]
        public string Cnpj { get; set; }
    }
}
