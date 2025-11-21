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

        public DbSet<Paciente> Pacientes { get; set; } = default!;
        public DbSet<Medico> Medicos { get; set; } = default!;
        public DbSet<Consulta> Consultas { get; set; } = default!;
    }
}
