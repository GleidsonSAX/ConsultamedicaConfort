using System.ComponentModel.DataAnnotations;

namespace ConsultamedicaConfort.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do médico")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Display(Name = "CRM")]
        public string CRM { get; set; } = string.Empty;

        [Display(Name = "Especialidade")]
        public string Especialidade { get; set; } = string.Empty;


    }


}