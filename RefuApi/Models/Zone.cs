using System.ComponentModel.DataAnnotations;

namespace RefuApi.Models
{
    public class Zone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }

        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

        public Zone() { }
        public Zone(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
