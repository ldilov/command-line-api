using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPI.Models
{
    public class Command
    {
        [Column("id"), Key]
        [Required]
        public int Id { get; set; }
        
        [Column("description"), Required]
        [MaxLength(255)]
        public string Description { get; set; }
        
        [Column("platform"), Required]
        [MaxLength(50)]
        public string Platform { get; set; }
        
        [Column("command_line"), Required]
        [MaxLength(150)]
        public string CommandLine { get; set; }
    }
}