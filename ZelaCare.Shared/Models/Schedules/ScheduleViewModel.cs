using ZelaCare.Core.Entities;

namespace ZelaCare.Shared.Models.Schedules
{
    public class ScheduleViewModel
    {
        public ScheduleViewModel(Guid clinicId, Guid professionalId, DateTime startTime, DateTime endTime, bool isComplete)
        {
            ClinicId = clinicId;
            ProfessionalId = professionalId;
            StartTime = startTime;
            EndTime = endTime;
            IsComplete = isComplete;
        }

        public Guid ClinicId { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public bool IsComplete { get; private set; }
        
        public static ScheduleViewModel FromEntity(Schedule schedule) => new(schedule.ClinicId, schedule.ProfessionalId, schedule.StartTime, schedule.EndTime, schedule.IsComplete);
    }
}
