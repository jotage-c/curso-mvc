using System.ComponentModel.DataAnnotations;

namespace CursosSis.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public int StudentRegNum { get; set; }

        [Required]
        public string StudentTel { get; set; }

        [Required]
        public string StudentEmail { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StudentDateOfBirth { get; set; }
    }
}
