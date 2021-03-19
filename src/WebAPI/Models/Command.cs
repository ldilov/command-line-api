using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Command
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Platform { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string CommandLine { get; set; }
    }
}