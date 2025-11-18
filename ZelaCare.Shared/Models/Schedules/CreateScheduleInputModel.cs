using ZelaCare.Core.Entities;

namespace ZelaCare.Shared.Models.Schedules
{
    public class CreateScheduleInputModel
    {
        public CreateScheduleInputModel(Guid clinicId, Guid professionalId, DateTime startTime, DateTime endTime)
        {
            ClinicId = clinicId;
            ProfessionalId = professionalId;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Guid ClinicId { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public Schedule ToEntity() => new(ClinicId, ProfessionalId, StartTime, EndTime);
    }
}
