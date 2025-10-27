using ZelaCare.Application.Models.Users;
using ZelaCare.Application.Models;
using ZelaCare.Application.Utils;

namespace ZelaCare.Application.Validations.Users
{
    internal class UpdateUserValidations
    {
        internal static ResultViewModel Validate(UpdateUserInputModel model)
        {
            var result = ResultViewModel.Success();
            
            if (!ValidationUtils.IsValidEmail(model.Email))
                result.AddError("E-mail is not valid.");


            return result;
        }
    }
}
