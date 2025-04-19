using System.ComponentModel.DataAnnotations;

namespace RefuApi.DTOs.Schedule
{
    public class UpdateScheduleDTO : IValidatableObject
    {
        public DateOnly? Day { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Day < DateOnly.FromDateTime(DateTime.Today))
            {
                yield return new ValidationResult("Day cannot be in the past.", new[] { nameof(Day) });
            }

            if (EndTime < StartTime)
            {
                yield return new ValidationResult("End time must be greater than start time.", new[] { nameof(EndTime) });
            }
        }
    }
}
