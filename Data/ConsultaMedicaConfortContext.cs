using ConsultamedicaConfort.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultamedicaConfort.Data
{
    public class ConsultamedicaConfortContext : DbContext
    {
        public ConsultamedicaConfortContext(DbContextOptions<ConsultamedicaConfortContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        // Novo DbSet (tabela de ligação N↔N)
        public DbSet<PacienteMedico> PacientesMedicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chave composta N↔N
            modelBuilder.Entity<PacienteMedico>()
                .HasKey(pm => new { pm.PacienteId, pm.MedicoId });

            modelBuilder.Entity<PacienteMedico>()
                .HasOne(pm => pm.Paciente)
                .WithMany()
                .HasForeignKey(pm => pm.PacienteId);

            modelBuilder.Entity<PacienteMedico>()
                .HasOne(pm => pm.medico)
                .WithMany()
                .HasForeignKey(pm => pm.MedicoId);
        }
    }
}

