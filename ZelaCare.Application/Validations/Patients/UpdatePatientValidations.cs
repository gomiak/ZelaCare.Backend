using ZelaCare.Shared.Models;
using ZelaCare.Shared.Models.Patients;
using ZelaCare.Application.Utils;

namespace ZelaCare.Application.Validations.Patients
{
    internal static class UpdatePatientValidations
    {
        internal static ResultViewModel Validate(UpdatePatientInputModel model)
        {
            var result = ResultViewModel.Success();

            if (string.IsNullOrWhiteSpace(model.FullName))
                result.AddError("Full name cannot be empty.");

            if (!string.IsNullOrWhiteSpace(model.CPF) && !ValidationUtils.IsValidCpf(model.CPF))
                result.AddError("CPF is not valid.");

            if (!string.IsNullOrWhiteSpace(model.Email) && !ValidationUtils.IsValidEmail(model.Email))
                result.AddError("E-mail is not valid.");

            if (string.IsNullOrWhiteSpace(model.Phone))
                result.AddError("Phone cannot be empty.");
            else if (!ValidationUtils.IsValidPhone(model.Phone))
                result.AddError("Phone is not valid.");

            if (model.BirthDate > DateTime.UtcNow)
                result.AddError("Birth date cannot be in the future.");

            return result;
        }
    }
}
