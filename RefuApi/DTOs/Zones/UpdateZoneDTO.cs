using System.ComponentModel.DataAnnotations;

namespace RefuApi.DTOs.Zone
{
    public class UpdateZoneDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "The Zone Name should be less than 100 chars")]
        public string Name { get; set; } = default!;
    }
}
