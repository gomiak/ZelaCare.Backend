using ZelaCare.Shared.Models;
using ZelaCare.Shared.Models.Clinics;

namespace ZelaCare.Application.Validations.Clinics
{
    internal class CreateClinicValidations
    {
        internal static ResultViewModel Validate(CreateClinincInputModel model)
        {
            var result = ResultViewModel.Success();

            if (string.IsNullOrWhiteSpace(model.Name))
                result.AddError("Name cannot be empty");

            return result;
        }
    }
}
