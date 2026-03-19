namespace ConsoleMenu.Entities
{
    public abstract class CustomEnumeration
    {
        protected CustomEnumeration(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public Type
        public int Id { get; set; }
        public string Value { get; set; }
    }
}