using ZelaCare.Core.Entities;

namespace ZelaCare.Core.Repositories
{
    public interface IFinancialRecordRepository
    {
        Task<FinancialRecord?> GetByIdAsync(Guid id);
        Task AddAsync(FinancialRecord record);
        Task UpdateAsync(FinancialRecord record);
        Task<List<FinancialRecord>> GetByPatientIdAsync(Guid patientId);
        Task<FinancialRecord?> GetByAppointmentIdAsync(Guid appointmentId);
        Task<List<FinancialRecord>> GetByClinicIdAsync(Guid clinicId);
    }
}
