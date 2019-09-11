using Microsoft.EntityFrameworkCore;
using System.Linq;
using UnimedAgendamentos.BLL.Models;

namespace UnimedAgendamentos.DAL.Context
{
    public class UnimedAgendamentosDbContext : DbContext
    {
        public UnimedAgendamentosDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Agendamento> Agendas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnimedAgendamentosDbContext).Assembly);

            // Desabilita o método de exclusão "Cascade" que por sua vez, ao ser deletado um registro pai, todos os filhos são removidos.
            // Sendo assim, esses casos são administrados pela aplicação.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
