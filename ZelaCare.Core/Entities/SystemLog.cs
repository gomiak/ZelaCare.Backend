using ZelaCare.Core.Shared;

namespace ZelaCare.Core.Entities
{
    public class SystemLog : BaseEntity
    {
        public SystemLog(string clinicId, string userId, string action, string resourceType, string resourceId, string oldValues, string newValues, string ipAddress, string userAgent)
        {
            ClinicId = clinicId;
            UserId = userId;
            Action = action;
            ResourceType = resourceType;
            ResourceId = resourceId;
            OldValues = oldValues;
            NewValues = newValues;
            IpAddress = ipAddress;
            UserAgent = userAgent;
        }

        public string ClinicId { get; private set; } = default!;
        public string UserId { get; private set; } = default!;
        public string Action { get; private set; } = default!;
        public string ResourceType { get; private set; } = default!;
        public string ResourceId { get; private set; } = default!;
        public string OldValues { get; private set; } = default!;
        public string NewValues { get; private set; } = default!;
        public string IpAddress { get; private set; } = default!;
        public string UserAgent { get; private set; } = default!;
    }
}
