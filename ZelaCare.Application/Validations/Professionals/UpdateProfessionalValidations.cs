using ZelaCare.Shared.Models;
using ZelaCare.Shared.Models.Professionals;
using ZelaCare.Application.Utils;

namespace ZelaCare.Application.Validations.Professionals
{
    internal static class UpdateProfessionalValidations
    {
        internal static ResultViewModel Validate(UpdateProfessionalInputModel model)
        {
            var result = ResultViewModel.Success();

            if (string.IsNullOrWhiteSpace(model.FullName))
                result.AddError("Full name cannot be empty.");
            else if (model.FullName.Length > 128)
                result.AddError("Full name cannot exceed 128 characters.");

            if (string.IsNullOrWhiteSpace(model.Phone))
                result.AddError("Phone cannot be empty.");
            else if (!ValidationUtils.IsValidPhone(model.Phone))
                result.AddError("Phone is not valid.");
            else if (model.Phone.Length > 15)

                result.AddError("Phone cannot exceed 15 characters.");
            if (!Enum.IsDefined(typeof(ZelaCare.Core.Enums.RegistryType), model.RegistryType))
                result.AddError("Registry type is not valid.");

            if (string.IsNullOrWhiteSpace(model.ProfessionalRegistry))
                result.AddError("Professional registry cannot be empty.");
            else if (model.ProfessionalRegistry.Length > 30)
                result.AddError("Professional registry cannot exceed 30 characters.");

            if (!Enum.IsDefined(typeof(ZelaCare.Core.Enums.Specialty), model.Specialty))
                result.AddError("Specialty is not valid.");

            return result;
        }
    }
}
