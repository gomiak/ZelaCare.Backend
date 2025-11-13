using ZelaCare.Core.Enums;
using ZelaCare.Core.Shared;

namespace ZelaCare.Core.Entities
{
    public class User : BaseEntity
    {
        private User() { }
        public User(string email, Role role, Guid clinicId)
        {
            Email = email;
            Role = role;
            ClinicId = clinicId;
            IsActive = true;
        }

        public string Email { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public Role Role { get; private set; } = default!;
        public Guid ClinicId { get; private set; }
        public Clinic Clinic { get; private set; } = default!;
        public bool IsActive { get; private set; } = true;

        public void Update(string email, Role role)
        {
            Email = email;
            Role = role;
            UpdateTimestamp();
        }
        public void SetPassword(string passwordHash)
        {
            PasswordHash = passwordHash;
            UpdateTimestamp();
        }
    }
}
