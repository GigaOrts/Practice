namespace Practice
{
    internal struct Stat
    {
        public string Name;
        public int Value;
        public string Description;

        public Stat(string name = "?", int value = 0, string description = "?")
        {
            Name = name;
            Value = value;
            Description = description;
        }
    }
}
