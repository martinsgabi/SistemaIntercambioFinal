using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntercambioFinal.Models
{
    [Table("TipoIntercambio")]
    public class TipoIntercambio
    {
        [Column("TipoIntercambioId")]
        [Display(Name = "Código do Tipo")]
        public int Id { get; set; }

        [Column("TipoIntercambioDescricao")]
        [Display(Name = "Tipo")]
        public string TipoIntercambioDescricao { get; set; } = string.Empty;
    }
}
