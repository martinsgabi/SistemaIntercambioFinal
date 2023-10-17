using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntercambioFinal.Models
{
    [Table("AgendamentoViagem")]
    public class AgendamentoViagem
    {
        [Column("AgendamentoViagemId")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("DataAgendamentoViagem")]
        [Display(Name = "Data do agendamento")]
        public DateTime DataAgendamentoViagem { get; set; }

        [Column("HoraAgendamentoViagem")]
        [Display(Name = "Horário")]
        public int HoraAgendamentoViagem { get; set; }


        [ForeignKey("CompanhiaAereaId")]
        public int CompanhiaAereaId { get; set; }
        public CompanhiaAerea? CompanhiaAerea { get; set; }



    }
}
