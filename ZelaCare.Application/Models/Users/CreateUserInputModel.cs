using ZelaCare.Core.Entities;
using ZelaCare.Core.Enums;

namespace ZelaCare.Application.Models.Users
{
    public class CreateUserInputModel
    {
        public CreateUserInputModel(string email, string password, Role role, Guid clinicId)
        {
            Email = email;
            Password = password;
            Role = role;
            ClinicId = clinicId;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }
        public Guid ClinicId { get; private set; }

        public User ToEntity() => new User(Email, Role, ClinicId);
    }
}
