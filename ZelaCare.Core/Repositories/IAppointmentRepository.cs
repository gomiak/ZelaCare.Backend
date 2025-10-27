using ZelaCare.Core.Entities;

namespace ZelaCare.Core.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment?> GetByIdAsync(Guid id);
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Guid id);
        Task<List<Appointment>> GetByPatientIdAsync(Guid patientId);
        Task<List<Appointment>> GetByProfessionalIdAsync(Guid professionalId);
        Task<List<Appointment>> GetByClinicIdAsync(Guid clinicId);
    }
}
