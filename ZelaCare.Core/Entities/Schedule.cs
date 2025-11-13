using ZelaCare.Core.Shared;

namespace ZelaCare.Core.Entities
{
    public class Schedule : BaseEntity
    {
        public Schedule(Guid clinicId, Guid professionalId, DateTime startTime, DateTime endTime)
        {
            ClinicId = clinicId;
            ProfessionalId = professionalId;
            StartTime = startTime;
            EndTime = endTime;
            IsComplete = false;
        }

        public Guid ClinicId { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public Professional Professional { get; private set; } = default!;
        public DateTime StartTime { get; private set; } = default!;
        public DateTime EndTime { get; private set; } = default!;
        public bool IsComplete { get; private set; } = default!;

        public void Complete() => IsComplete = true;
    }
}
