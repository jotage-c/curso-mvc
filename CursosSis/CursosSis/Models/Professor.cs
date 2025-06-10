using System.ComponentModel.DataAnnotations;

namespace CursosSis.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }

        [Required]
        public string ProfessorName { get; set; }

        [Required]
        public string ProfessorTel { get; set; }

        [Required]
        public string ProfessorEmail { get; set; }

        [Required]
        public string ProfessorWorkPeriod { get; set; }
    }
}
