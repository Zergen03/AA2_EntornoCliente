using System.ComponentModel.DataAnnotations;

namespace RefuApi.Models
{
    public class Zone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }

    }
}
