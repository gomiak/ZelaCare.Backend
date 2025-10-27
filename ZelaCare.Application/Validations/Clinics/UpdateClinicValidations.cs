using ZelaCare.Application.Models.Clinics;
using ZelaCare.Application.Models;

namespace ZelaCare.Application.Validations.Clinics
{
    internal class UpdateClinicValidations
    {
        internal static ResultViewModel Validate(UpdateClinicInputModel model)
        {
            var result = ResultViewModel.Success();

            if (string.IsNullOrWhiteSpace(model.Name))
                result.AddError("Name cannot be empty");

            return result;
        }
    }
}
