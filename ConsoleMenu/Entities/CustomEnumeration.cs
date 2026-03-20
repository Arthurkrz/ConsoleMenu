namespace ConsoleMenu.Entities
{
    public abstract class CustomEnumeration
    {
        protected CustomEnumeration(int id, string value)
        {
            Id = id;
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Id { get; }
        public string Value { get; }
    }
}