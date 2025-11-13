using ZelaCare.Core.Shared;

namespace ZelaCare.Core.Entities
{
    public class FinancialRecord : BaseEntity
    {
        public Guid ClinicId { get; private set; }
        public Guid PatientId { get; private set; }
        public Patient Patient { get; private set; } = default!;
        public Guid AppointmentId { get; private set; }
        public Appointment Appointment { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public decimal Amount { get; private set; } = default!;

    }
}
