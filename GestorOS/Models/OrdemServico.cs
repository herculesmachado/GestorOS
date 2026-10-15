using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorOS.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Observações")]
        [StringLength(255)]
        public string? Observacoes { get; set; }

        [Required]
        [Display(Name = "Data de Abertura.")]
        [DataType(DataType.Date)]
        public DateTime DataAbertura { get; set; } = DateTime.UtcNow;

        [Display(Name = "Data de Conclusão.")]
        [DataType(DataType.Date)]
        public DateTime? DataConclusao { get; set; }

        [Display(Name = "Status")]
        public  StatusOrdem Status { get; set; } = StatusOrdem.Aberta;

        [Required(ErrorMessage = "Informe o valor do serviço.")]
        [Display(Name = "Valor (R$)")]
        [Range(0, 999999.99, ErrorMessage = "O valor deve ser entre 0 e 999.999,99.")]
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal Valor { get; set; }

        public int ClienteModelId { get; set; }
        public Cliente? Cliente { get; set; }

        public int? CategoriaServicosModelId { get; set; }

        public CategoriaServicos? CategoriaServicos { get; set; }
    }
}
