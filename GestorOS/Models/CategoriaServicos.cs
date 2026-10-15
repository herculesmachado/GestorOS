using System.ComponentModel.DataAnnotations;

namespace GestorOS.Models
{
    public class CategoriaServicos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        [Display(Name = "Categoria")]
        public string Nome { get; set; }
        [StringLength(255, ErrorMessage = "O campo Descrição deve ter no máximo 255 caracteres.")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        public ICollection<OrdemServico> Ordens { get; set; } = new List<OrdemServico>();
    }
}
