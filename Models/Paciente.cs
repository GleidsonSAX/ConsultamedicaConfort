using System;
using System.ComponentModel.DataAnnotations;

namespace ConsultamedicaConfort.Models
{
    public class Paciente
    {
        // Id existe só para o banco – não vamos mostrar nas telas
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do paciente")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Display(Name = "CPF")]
        public string CPF { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; } = string.Empty;

        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
