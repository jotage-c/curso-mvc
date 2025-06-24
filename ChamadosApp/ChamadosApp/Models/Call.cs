using System.ComponentModel.DataAnnotations;

namespace ChamadosApp.Models
{
    public class Call
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? CallTitle { get; set; }

        [Required]
        public string? CallDescription { get; set; }

        public DateTime CallDate { get; set; } = DateTime.Now;

        public string CallStatus { get; set; } = "Opened";

        //-----------------------------------------------------

        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
