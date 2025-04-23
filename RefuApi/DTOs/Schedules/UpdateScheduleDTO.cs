using System.ComponentModel.DataAnnotations;

namespace RefuApi.DTOs.Schedule
{
    public class UpdateScheduleDTO : IValidatableObject
    {
        public DateOnly? Day { get; set; }

        public TimeOnly? StartTime { get; set; }

        public TimeOnly? EndTime { get; set; }

        public string? Report { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Day.HasValue && Day.Value < DateOnly.FromDateTime(DateTime.Today))
            {
                yield return new ValidationResult("Day cannot be in the past.", new[] { nameof(Day) });
            }

            if (StartTime.HasValue && EndTime.HasValue && EndTime.Value < StartTime.Value)
            {
                yield return new ValidationResult("End time must be greater than start time.", new[] { nameof(EndTime) });
            }
        }
    }
}
