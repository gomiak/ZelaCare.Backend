using ZelaCare.Shared.Models;
using ZelaCare.Shared.Models.Users;
using ZelaCare.Application.Validations.Users;
using ZelaCare.Core.Repositories;

namespace ZelaCare.Application.Services
{
    public interface IUserService
    {
        Task<ResultViewModel<Guid>> CreateAsync(CreateUserInputModel model);
        Task<ResultViewModel> UpdateAsync(Guid id, UpdateUserInputModel model);
        Task<ResultViewModel<UserViewModel>> GetByIdAsync(Guid id);
        Task<ResultViewModel<UserViewModel>> GetByClinicIdAsync(Guid clinicId);
        Task<ResultViewModel> DeleteAsync(Guid id);

    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<Guid>> CreateAsync(CreateUserInputModel model)
        {
            var validation = CreateUserValidations.Validate(model);

            if (validation.HasErrors)
                return ResultViewModel<Guid>.Error(validation.Errors);

            var hash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var user = model.ToEntity();
            user.SetPassword(hash);
            var userId = await _repository.AddAsync(user);

            return ResultViewModel<Guid>.Success(userId);
        }

        public async Task<ResultViewModel<UserViewModel>> GetByClinicIdAsync(Guid clinicId)
        {
            var user = await _repository.GetByIdAsync(clinicId);

            if (user is null)
                return ResultViewModel<UserViewModel>.Error("User not found.");

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }

        public async Task<ResultViewModel<UserViewModel>> GetByIdAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return ResultViewModel<UserViewModel>.Error("User not found.");

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }
        public async Task<ResultViewModel> UpdateAsync(Guid id, UpdateUserInputModel model)
        {
            var validation = UpdateUserValidations.Validate(model);
            if (validation.HasErrors)
                return ResultViewModel.Error(validation.Errors);

            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return ResultViewModel.Error("User not found.");

            user.Update(model.Email, model.Role);
            await _repository.UpdateAsync(user);
            return ResultViewModel.Success();

        }

        public async Task<ResultViewModel> DeleteAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return ResultViewModel<UserViewModel>.Error("User not found.");

            user.MarkAsDeleted();
            await _repository.UpdateAsync(user);

            return ResultViewModel.Success();

        }
    }
}
