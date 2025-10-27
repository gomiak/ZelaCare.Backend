using ZelaCare.Shared.Models;
using ZelaCare.Shared.Models.Users;
using ZelaCare.Application.Utils;

namespace ZelaCare.Application.Validations.Users
{
    internal static class CreateUserValidations
    {
        internal static ResultViewModel Validate(CreateUserInputModel model)
        {
            var result = ResultViewModel.Success();

            if (!ValidationUtils.IsValidEmail(model.Email))
                result.AddError("E-mail is not valid.");

            if (string.IsNullOrWhiteSpace(model.Password))
                result.AddError("Password cannot be empty.");
            else if (model.Password.Length < 8)
                result.AddError("Password must be at least 8 characters.");

            return result;
        }
    }
}
