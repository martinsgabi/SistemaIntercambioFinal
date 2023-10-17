using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntercambioFinal.Models
{
    [Table("CompanhiaAerea")]
    public class CompanhiaAerea
    {
        [Column("CompanhiaAereaId")]
        [Display(Name = "Código da Companhia")]
        public int Id { get; set; }

        [Column("CompanhiaAereaDescricao")]
        [Display(Name = "Companhia")]
        public string CompanhiaAereaDescricao { get; set; } = string.Empty;
    }
}
