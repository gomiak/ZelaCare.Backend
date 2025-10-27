using ZelaCare.Core.Enums;

namespace ZelaCare.Shared.Models.Users
{
    public class UpdateUserInputModel
    {
        public UpdateUserInputModel(string email, Role role)
        {
            Email = email;
            Role = role;
        }

        public string Email { get; private set; }
        public Role Role { get; private set; }
    }
}
