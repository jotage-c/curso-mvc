using System.ComponentModel.DataAnnotations;

namespace ChamadosApp.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameClient { get; set; }

        [Required]
        public string EmailClient { get; set; }

        [Required]
        public string TelephoneClient { get; set; }

        public ICollection<Call> Calls { get; set; }
    }
}
