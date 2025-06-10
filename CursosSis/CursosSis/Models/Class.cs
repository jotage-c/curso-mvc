using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosSis.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Courses { get; set; }

        [Required]
        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
