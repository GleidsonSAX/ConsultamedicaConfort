namespace ConsultamedicaConfort.Models
{
    public class Pacientemedico
    {
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}
namespace ConsultamedicaConfort.Models
{
    public class PacienteMedico
    {
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int MedicoId { get; set; }
        public Medico medico { get; set; }
    }
}

