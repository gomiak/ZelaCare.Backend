using ZelaCare.Core.Entities;
using ZelaCare.Core.Enums;

namespace ZelaCare.Shared.Models.Users
{
    public class UserViewModel
    {
        public UserViewModel(string email, Role role, Guid clinicId)
        {
            Email = email;
            Role = role;
            ClinicId = clinicId;
        }

        public string Email { get; private set; }
        public Role Role { get; private set; }
        public Guid ClinicId { get; private set; }

        public static UserViewModel FromEntity(User user) => new UserViewModel(user.Email, user.Role, user.ClinicId);
    }
}
