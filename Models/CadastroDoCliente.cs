using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntercambioFinal.Models
{
    [Table("CadastroDoCliente")]
    public class CadastroDoCliente
    {
        [Column("Id_Cliente")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("NomeCompleto")]
        [Display(Name = "Nome Completo")]
        public string NomeCompletoCliente { get; set; } = string.Empty;

        [Column("Idade")]
        [Display(Name = "idade")]
        public int IdadeCliente { get; set; }

        [Column("DataDeNascimento")]
        [Display(Name = "Data de nascimento")]
        public DateTime DataDeNascimentoCliente { get; set; }

        [Column("Email")]
        [Display(Name = "E-mail")]
        public string EmailCliente { get; set; } = string.Empty;

        [Column("Cpf")]
        [Display(Name = "CPF")]
        public string CpfCliente { get; set; } = string.Empty;

        [Column("Rg")]
        [Display(Name = "RG")]
        public string RgCliente { get; set; } = string.Empty;

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public int TelefoneCliente { get; set; }

        [Column("Sexo")]
        [Display(Name = "Sexo")]
        public string SexoCliente { get; set; } = string.Empty;
    }
}
