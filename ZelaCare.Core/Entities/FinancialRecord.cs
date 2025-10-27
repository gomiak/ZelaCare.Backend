using ZelaCare.Core.Shared;

namespace ZelaCare.Core.Entities
{
    public class FinancialRecord : BaseEntity
    {
        public Guid ClinicId { get; private set; }
        public Guid PatientId { get; private set; }
        public Patient Patient { get; private set; }
        public Guid AppointmentId { get; private set; }
        public Appointment Appointment { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }

    }
}
