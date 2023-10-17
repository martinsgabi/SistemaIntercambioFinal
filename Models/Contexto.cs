using Microsoft.EntityFrameworkCore;

namespace SistemaIntercambioFinal.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<CadastroDoCliente>? CadastroDoCliente { get; set; }
        public DbSet<CadastroIntercambio>? CadastroIntercambio { get; set; }
        public DbSet<AgendamentoProfissional>? AgendamentoProfissional { get; set; }
        public DbSet<AgendamentoViagem>? AgendamentoViagem { get; set; }
        public DbSet<CompanhiaAerea>? CompanhiaAerea { get; set; }
        public DbSet<DestinoIntercambio>? DestinoIntercambio { get; set; }
        public DbSet<DuracaoIntercambio>? DuracaoIntercambio { get; set; }
        public DbSet<TipoIntercambio>? TipoIntercambio { get; set; }


    }
}