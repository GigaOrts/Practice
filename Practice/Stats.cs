namespace Practice
{
    internal class Stats
    {
        public Stat[] Values { get; private set; }
        public int Length => Values.Length;

        private readonly Stat[] _defaultValues;

        public Stats()
        {
            _defaultValues = [
                new Stat("Сила", 1, "Сила повышает урон героя."),
                new Stat("Живучесть", 1, "Живучесть повышает здоровье героя."),
                new Stat("Скорость", 1, "Скорость повышает шанс уклонения и шанс не промахнуться.")
                ];

            Values = new Stat[_defaultValues.Length];
            Reset();
        }

        public void DisplayStats(int selectedStatIndex, int[] changes)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                if (i == selectedStatIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("> "); 
                }
                else
                {
                    Console.Write("  ");
                }
                    
                Console.Write(Values[i].Name + ": ");
                Console.ResetColor();
                Console.Write(Values[i].Value);

                // Отображение изменений
                Console.ForegroundColor = changes[i] > 0 ? ConsoleColor.Green :
                                          changes[i] < 0 ? ConsoleColor.Red : ConsoleColor.White;

                if (changes[i] > 0)
                {
                    Console.Write($" <+{changes[i]}> ");
                }
                else
                {
                    Console.Write($" <{changes[i]}> ");
                }

                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void DisplayStats()
        {
            for (int i = 0; i < Values.Length; i++)
            {
                Console.WriteLine(Values[i].Name + ": " + Values[i].Value);
            }

            Console.WriteLine();
        }

        public Stat Get(int index)
        {
            return Values[index];
        }

        public void Change(int index, int value)
        {
            Values[index].Value += value;
        }

        public void ShowDescription(int index)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Values[index].Description);
            Console.ResetColor();
        }

        public void Reset()
        {
            _defaultValues.CopyTo(Values, 0);
        }
    }
}
