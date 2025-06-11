using System.ComponentModel.DataAnnotations;

namespace Blogs.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PostAuthor { get; set; }

        [Required]
        public string PostContent { get; set; }

        public string PostImageUrl { get; set; }

        public DateTime PostCreationDate { get; set; } = DateTime.Now;
    }
}
