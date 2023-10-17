using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntercambioFinal.Models
{
    [Table("DestinoIntercambio")]
    public class DestinoIntercambio
    {

        [Column("DestinoIntercambioId")]
        [Display(Name = "Código do Destino")]
        public int Id { get; set; }

        [Column("DestinoIntercambioDescricao")]
        [Display(Name = "Destino")]
        public string DestinoIntercambioDescricao { get; set; } = string.Empty;
    }
}
