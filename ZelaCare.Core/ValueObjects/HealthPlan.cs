namespace ZelaCare.Core.ValueObjects
{
    public class HealthPlan
    {
        public HealthPlan(string? name, string? number, string? holderName)
        {
            Name = name;
            Number = number;
            HolderName = holderName;
        }
        private HealthPlan() { }

        public string? Name { get; private set; }
        public string? Number { get; private set; }
        public string? HolderName { get; private set; }
        public bool IsEmpty =>
            string.IsNullOrWhiteSpace(Name) &&
            string.IsNullOrWhiteSpace(Number) &&
            string.IsNullOrWhiteSpace(HolderName);
    }
}
