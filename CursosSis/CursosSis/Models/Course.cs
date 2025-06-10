using System.ComponentModel.DataAnnotations;

namespace CursosSis.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string CourseCode { get; set; }

        [Required]
        public decimal CoursePrice { get; set; }

        [Required]
        public string CourseType { get; set; }
    }
}
