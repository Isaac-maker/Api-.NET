using System.ComponentModel.DataAnnotations;

namespace ApiUsers.Data
{
    internal sealed class Post
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100000)]
        public string Content { get; set; }= string.Empty;
       
    }
}
