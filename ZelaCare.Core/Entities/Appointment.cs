using ZelaCare.Core.Shared;

namespace ZelaCare.Core.Entities
{
    public class Appointment : BaseEntity
    {
        public Guid ClinicId { get; private set; }
        public Guid PatientId { get; private set; }
        public Patient Patient { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public Professional Professional { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public int MyProperty { get; private set; }

    }
}
