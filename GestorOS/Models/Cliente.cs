using System.ComponentModel.DataAnnotations;

namespace GestorOS.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(120)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
        [StringLength(100)]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "O telefone informado é inválido.")]
        [StringLength(20)]
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Cadastro.")]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public ICollection<OrdemServico> Ordens { get; set; } = new List<OrdemServico>();

    }
}
