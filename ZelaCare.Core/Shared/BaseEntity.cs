namespace ZelaCare.Core.Shared
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
        public bool IsDeleted { get; private set; } = false;

        public void UpdateTimestamp()
        {
            UpdatedAt = DateTime.Now;
        }
        public void MarkAsDeleted()
        {
            IsDeleted = true;
            UpdateTimestamp();
        }
    }
}
