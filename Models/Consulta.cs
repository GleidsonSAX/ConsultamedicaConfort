using System;
using System.ComponentModel.DataAnnotations;

namespace ConsultamedicaConfort.Models
{
    // ESTA CLASSE FAZ O MUITOS-PARA-MUITOS:
    // Paciente 1 ..* Consulta *.. 1 Médico
    public class Consulta
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data e hora da consulta")]
        [DataType(DataType.DateTime)]
        public DateTime DataConsulta { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public int PacienteId { get; set; }

        [Required]
        [Display(Name = "Médico")]
        public int MedicoId { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; } = string.Empty;

        // Navegação (não aparecem como campos no formulário)
        public Paciente? Paciente { get; set; }
        public Medico? Medico { get; set; }
    }
}
