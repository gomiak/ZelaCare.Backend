using ZelaCare.Core.Shared;

namespace ZelaCare.Core.Entities
{
    public class Schedule : BaseEntity
    {
        public Guid ClinicId { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public Professional Professional { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public bool IsComplete { get; private set; }
    }
}
