using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntercambioFinal.Models
{
    [Table("CadastroIntercambio")]
    public class CadastroIntercambio
    {
        [Column("Id_CadastoIntercambio")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [ForeignKey("DestinoIntercambioId")]
        public int DestinoIntercambioId { get; set; }
        public DestinoIntercambio? DestinoIntercambio { get; set; }

        [ForeignKey("TipoIntercambioId")]
        public int TipoIntercambioId { get; set; }
        public TipoIntercambio? TipoIntercambio { get; set; }


        [ForeignKey("DuracaoIntercambioId")]
        public int DuracaoIntercambioId { get; set; }
        public DuracaoIntercambio? DuracaoIntercambio { get; set; }
    }
}
