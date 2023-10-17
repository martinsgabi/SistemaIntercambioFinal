using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntercambioFinal.Models
{
    [Table("AgendamentoProfissional")]
    public class AgendamentoProfissional
    {
        [Column("Id_AgendamentoProfissional")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("DataAgendamento")]
        [Display(Name = "Data do agendamento")]
        public DateTime DataAgendamento { get; set; }

        [Column("HoraAgendamento")]
        [Display(Name = "Horário")]
        public int HoraAgendamento { get; set; }

    }
}
