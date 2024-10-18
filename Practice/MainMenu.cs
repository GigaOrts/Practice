namespace Practice
{
    public enum MenuCommand
    {
        None = 0,
        Exit,
        Confirm,
        Move
    }

    internal class MainMenu
    {
        public string[] Options = ["Stats", "Exit"];
        public int SelectedOptionIndex = 0;

        public MenuCommand Process()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.Enter:
                    return MenuCommand.Confirm;

                case ConsoleKey.UpArrow:
                    SelectedOptionIndex = (SelectedOptionIndex - 1 + Options.Length) % Options.Length; // Циклический выбор
                    return MenuCommand.Move;

                case ConsoleKey.DownArrow:
                    SelectedOptionIndex = (SelectedOptionIndex + 1) % Options.Length; // Циклический выбор
                    return MenuCommand.Move;
            }

            return MenuCommand.None;
        }

        public void DisplayMenu()
        {
            Console.Clear();

            for (int i = 0; i < Options.Length; i++)
            {
                if (i == SelectedOptionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("> ");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("  ");
                }

                Console.Write(Options[i]);

                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
