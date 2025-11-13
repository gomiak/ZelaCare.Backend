using ZelaCare.Shared.Models;
using ZelaCare.Shared.Models.Professionals;
using ZelaCare.Application.Validations.Professionals;
using ZelaCare.Core.Enums;
using ZelaCare.Core.Repositories;

namespace ZelaCare.Application.Services
{
    public interface IProfessionalService
    {
        Task<ResultViewModel<Guid>> CreateAsync(CreateProfessionalInputModel model);
        Task<ResultViewModel> UpdateAsync(Guid id, UpdateProfessionalInputModel model);
        Task<ResultViewModel> DeleteAsync(Guid id);
        Task<ResultViewModel<ProfessionalViewModel>> GetByIdAsync(Guid id);
        Task<ResultViewModel<ProfessionalViewModel>> GetByUserIdAsync(Guid userId);
        Task<ResultViewModel<List<ProfessionalViewModel>>> GetByClinicIdAsync(Guid clinicId);
        Task<ResultViewModel<List<ProfessionalViewModel>>> GetBySpecialtyAsync(Specialty specialty);
    }

    internal class ProfessionalService : IProfessionalService
    {
        private readonly IProfessionalRepository _repository;

        public ProfessionalService(IProfessionalRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<Guid>> CreateAsync(CreateProfessionalInputModel model)
        {
            var validations = CreateProfessionalValidations.Validate(model);

            if (validations.HasErrors)
                return ResultViewModel<Guid>.Error(validations.Errors);

            var professional = model.ToEntity();
            await _repository.AddAsync(professional);

            return ResultViewModel<Guid>.Success(professional.Id);
        }

        public async Task<ResultViewModel> UpdateAsync(Guid id, UpdateProfessionalInputModel model)
        {
            var professional = await _repository.GetByIdAsync(id);
            if (professional is null)
                return ResultViewModel.Error("Professional not found.");

            var validations = UpdateProfessionalValidations.Validate(model);
            if (validations.HasErrors)
                return ResultViewModel.Error(validations.Errors);


            await _repository.UpdateAsync(professional);
            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(Guid id)
        {
            var professional = await _repository.GetByIdAsync(id);
            if (professional is null)
                return ResultViewModel.Error("Professional not found.");

            professional.MarkAsDeleted();
            await _repository.UpdateAsync(professional);

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel<ProfessionalViewModel>> GetByIdAsync(Guid id)
        {
            var professional = await _repository.GetByIdAsync(id);
            if (professional is null)
                return ResultViewModel<ProfessionalViewModel>.Error("Professional not found.");

            var model = ProfessionalViewModel.FromEntity(professional);
            return ResultViewModel<ProfessionalViewModel>.Success(model);
        }

        public async Task<ResultViewModel<ProfessionalViewModel>> GetByUserIdAsync(Guid userId)
        {
            var professional = await _repository.GetByUserIdAsync(userId);
            if (professional is null)
                return ResultViewModel<ProfessionalViewModel>.Error("Professional not found.");

            var model = ProfessionalViewModel.FromEntity(professional);
            return ResultViewModel<ProfessionalViewModel>.Success(model);
        }

        public async Task<ResultViewModel<List<ProfessionalViewModel>>> GetByClinicIdAsync(Guid clinicId)
        {
            var professionals = await _repository.GetByClinicIdAsync(clinicId);
            var model = professionals.Select(ProfessionalViewModel.FromEntity).ToList();

            return ResultViewModel<List<ProfessionalViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<List<ProfessionalViewModel>>> GetBySpecialtyAsync(Specialty specialty)
        {
            var professionals = await _repository.GetBySpecialtyAsync(specialty);
            var model = professionals.Select(ProfessionalViewModel.FromEntity).ToList();

            return ResultViewModel<List<ProfessionalViewModel>>.Success(model);
        }
    }
}
