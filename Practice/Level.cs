namespace Practice
{
    internal class Level
    {
        public int ExperiencePoints { get; private set; }

        public Level()
        {
            Reset();
        }

        public void SetExpirience(int value)
        {
            ExperiencePoints = value;
        }

        public void AddExpiriencePoint(int value)
        {
            ExperiencePoints += value;
        }

        public void ShowExpiriencePoints()
        {
            Console.Write("\nОчки опыта: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ExperiencePoints);
            Console.ResetColor();
        }

        public void Reset()
        {
            ExperiencePoints = 3;
        }
    }
}
