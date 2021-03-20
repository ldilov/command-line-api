using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        
        [ Required]
        [MaxLength(50)]
        public string Platform { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string CommandLine { get; set; }
    }
}