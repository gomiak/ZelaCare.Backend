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

        public string ClinicId { get; private set; }
        public string UserId { get; private set; }
        public string Action { get; private set; }
        public string ResourceType { get; private set; }
        public string ResourceId { get; private set; }
        public string OldValues { get; private set; }
        public string NewValues { get; private set; }
        public string IpAddress { get; private set; }
        public string UserAgent { get; private set; }
    }
}
