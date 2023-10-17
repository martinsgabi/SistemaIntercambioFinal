using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntercambioFinal.Models
{
    [Table("DuracaoIntercambio")]
    public class DuracaoIntercambio
    {
        [Column("DuracaoIntercambioId")]
        [Display(Name = "Código da duração")]
        public int Id { get; set; }

        [Column("DuracaoIntercambioDescricao")]
        [Display(Name = "Duração")]
        public string DuracaoIntercambioDescricao { get; set; } = string.Empty;
    }
}
