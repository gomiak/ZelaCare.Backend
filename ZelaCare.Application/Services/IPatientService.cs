using ZelaCare.Shared.Models;
using ZelaCare.Shared.Models.Patients;
using ZelaCare.Application.Validations.Patients;
using ZelaCare.Core.Repositories;

namespace ZelaCare.Application.Services
{
    public interface IPatientService
    {
        Task<ResultViewModel<Guid>> CreateAsync(CreatePatientInputModel model);
        Task<ResultViewModel> UpdateAsync(Guid id, UpdatePatientInputModel model);
        Task<ResultViewModel> DeleteAsync(Guid id);
        Task<ResultViewModel<List<PatientViewModel>>> GetByClinicIdAsync(Guid clinicId);
        Task<ResultViewModel<PatientViewModel>> GetByIdAsync(Guid id);
        Task<ResultViewModel<PatientViewModel>> GetByCpfAsync(string cpf);
        Task<ResultViewModel<PatientViewModel>> GetByEmailAsync(string email);
        Task<ResultViewModel<List<PatientViewModel>>> SearchByNameAsync(string name, Guid clinicId);
    }

    internal class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<Guid>> CreateAsync(CreatePatientInputModel model)
        {
            var validations = CreatePatientValidations.Validate(model);

            if (validations.HasErrors)
                return ResultViewModel<Guid>.Error(validations.Errors);

            var patient = model.ToEntity();
            await _repository.AddAsync(patient);

            return ResultViewModel<Guid>.Success(patient.Id);
        }

        public async Task<ResultViewModel> UpdateAsync(Guid id, UpdatePatientInputModel model)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient is null)
                return ResultViewModel.Error("Patient not found.");

            var validations = UpdatePatientValidations.Validate(model);
            if (validations.HasErrors)
                return ResultViewModel.Error(validations.Errors);

            await _repository.UpdateAsync(patient);

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(Guid id)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient is null)
                return ResultViewModel.Error("Patient not found.");

            patient.MarkAsDeleted();
            await _repository.UpdateAsync(patient);

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel<List<PatientViewModel>>> GetByClinicIdAsync(Guid clinicId)
        {
            var patients = await _repository.GetByClinicIdAsync(clinicId);
            var model = patients.Select(PatientViewModel.FromEntity).ToList();

            return ResultViewModel<List<PatientViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<PatientViewModel>> GetByIdAsync(Guid id)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient is null)
                return ResultViewModel<PatientViewModel>.Error("Patient not found.");

            var model = PatientViewModel.FromEntity(patient);
            return ResultViewModel<PatientViewModel>.Success(model);
        }

        public async Task<ResultViewModel<PatientViewModel>> GetByCpfAsync(string cpf)
        {
            var patient = await _repository.GetByCpfAsync(cpf);
            if (patient is null)
                return ResultViewModel<PatientViewModel>.Error("Patient not found.");

            var model = PatientViewModel.FromEntity(patient);
            return ResultViewModel<PatientViewModel>.Success(model);
        }

        public async Task<ResultViewModel<PatientViewModel>> GetByEmailAsync(string email)
        {
            var patient = await _repository.GetByEmailAsync(email);
            if (patient is null)
                return ResultViewModel<PatientViewModel>.Error("Patient not found.");

            var model = PatientViewModel.FromEntity(patient);
            return ResultViewModel<PatientViewModel>.Success(model);
        }

        public async Task<ResultViewModel<List<PatientViewModel>>> SearchByNameAsync(string name, Guid clinicId)
        {
            var patients = await _repository.SearchByNameAsync(name, clinicId);
            var model = patients.Select(PatientViewModel.FromEntity).ToList();

            return ResultViewModel<List<PatientViewModel>>.Success(model);
        }
    }
}
