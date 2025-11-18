namespace ZelaCare.Shared.Models.Schedules
{
    public class UpdateScheduleInputModel
    {
        public UpdateScheduleInputModel(Guid professionalId, DateTime startTime, DateTime endTime, bool isComplete)
        {
            ProfessionalId = professionalId;
            StartTime = startTime;
            EndTime = endTime;
            IsComplete = isComplete;
        }

        public Guid ProfessionalId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public bool IsComplete { get; private set; }
    }
}
