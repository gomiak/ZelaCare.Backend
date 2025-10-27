using ZelaCare.Shared.Models;
using ZelaCare.Shared.Models.Clinics;
using ZelaCare.Application.Validations.Clinics;
using ZelaCare.Core.Repositories;

namespace ZelaCare.Application.Services
{
    public interface IClinicService
    {
        Task<ResultViewModel<Guid>> CreateAsync(CreateClinincInputModel model);
        Task<ResultViewModel> UpdateAsync(Guid id, UpdateClinicInputModel model);
        Task<ResultViewModel> DeleteAsync(Guid id);
        Task<ResultViewModel<List<ClinicViewModel>>> GetAllAsync();
        Task<ResultViewModel<ClinicViewModel>> GetByIdAsync(Guid id);
        Task<ResultViewModel<ClinicViewModel>> GetByCnpjAsync(string cnpj);
    }

    internal class ClinicService : IClinicService
    {
        private readonly IClinicRepository _repository;
        public ClinicService(IClinicRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<Guid>> CreateAsync(CreateClinincInputModel model)
        {
            var validations = CreateClinicValidations.Validate(model);

            if (validations.HasErrors)
                return ResultViewModel<Guid>.Error(validations.Errors);

            var clinic = model.ToEntity();
            var clinicId = await _repository.AddAsync(clinic);

            return ResultViewModel<Guid>.Success(clinicId);
        }
        public async Task<ResultViewModel<List<ClinicViewModel>>> GetAllAsync()
        {
            var clinics = await _repository.GetAllAsync();

            var model = clinics.Select(ClinicViewModel.FromEntity).ToList();

            return ResultViewModel<List<ClinicViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<ClinicViewModel>> GetByCnpjAsync(string cnpj)
        {
            var clinic = await _repository.GetByCnpjAsync(cnpj);

            if (clinic is null)
                return ResultViewModel<ClinicViewModel>.Error("Clinic not found.");

            var model = ClinicViewModel.FromEntity(clinic);

            return ResultViewModel<ClinicViewModel>.Success(model);
        }

        public async Task<ResultViewModel<ClinicViewModel>> GetByIdAsync(Guid id)
        {
            var clinic = await _repository.GetByIdAsync(id);

            if (clinic is null)
                return ResultViewModel<ClinicViewModel>.Error("Clinic not found.");

            var model = ClinicViewModel.FromEntity(clinic);

            return ResultViewModel<ClinicViewModel>.Success(model);
        }

        public async Task<ResultViewModel> UpdateAsync(Guid id, UpdateClinicInputModel model)
        {
            var clinic = await _repository.GetByIdAsync(id);

            if (clinic is null)
                return ResultViewModel.Error("Clinic not found.");

            var validations = UpdateClinicValidations.Validate(model);

            if (validations.HasErrors)
                return ResultViewModel.Error(validations.Errors);

            await _repository.UpdateAsync(clinic);

            return ResultViewModel.Success();

        }

        public async Task<ResultViewModel> DeleteAsync(Guid id)
        {
            var clinic = await _repository.GetByIdAsync(id);

            if (clinic is null)
                return ResultViewModel.Error("Clinic not found.");

            clinic.MarkAsDeleted();
            await _repository.UpdateAsync(clinic);

            return ResultViewModel.Success();
        }
    }
}
