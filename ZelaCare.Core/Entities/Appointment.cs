using ZelaCare.Core.Shared;

namespace ZelaCare.Core.Entities
{
    public class Appointment : BaseEntity
    {
        public Appointment(Guid clinicId, Guid patientId, Guid professionalId, DateTime appointmentDate)
        {
            ClinicId = clinicId;
            PatientId = patientId;
            ProfessionalId = professionalId;
            AppointmentDate = appointmentDate;
        }

        public Guid ClinicId { get; private set; } 
        public Guid PatientId { get; private set; }
        public Patient Patient { get; private set; } = default!;
        public Guid ProfessionalId { get; private set; }
        public Professional Professional { get; private set; } = default!;
        public DateTime AppointmentDate { get; private set; }

    }
}
