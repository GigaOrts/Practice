namespace Practice
{
    internal class StatsModification
    {
        private const ConsoleKey CommandBack = ConsoleKey.Escape;
        private const ConsoleKey CommandConfirm = ConsoleKey.Enter;
        private const ConsoleKey CommandInfo = ConsoleKey.E;
        private const ConsoleKey CommandReset = ConsoleKey.R;
        private const ConsoleKey CommandResetStats = ConsoleKey.T;

        private bool _showDescription;
        private int selectedStatIndex = 0;
        
        private readonly int _valuePerClick = 1;
        private readonly int[] changes;
        private readonly Stats _stats;
        private readonly Level _level;

        public StatsModification(Level level, Stats stats)
        {
            _level = level;
            _stats = stats;

            changes = new int[_stats.Values.Length];
        }

        public void DisplayMenu()
        {
            Console.WriteLine($"Выберите стат (нажмите {ConsoleKey.UpArrow}/{ConsoleKey.DownArrow}):\n");

            _stats.DisplayStats(selectedStatIndex, changes);

            Console.WriteLine($"Нажмите '{CommandConfirm}' для подтверждения, '{CommandReset}' для сброса очков опыта," +
                $" '{CommandResetStats}' для сброса характеристик, '{CommandBack}' для выхода.\n");
            Console.WriteLine($"Нажмите '{CommandInfo}' для подробностей");

            if (_showDescription)
            {
                _stats.ShowDescription(selectedStatIndex);
            }
        }

        public MenuCommand Process()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case CommandConfirm:
                    Confirm();
                    Clear();
                    return MenuCommand.Confirm;

                case ConsoleKey.Escape:
                    return MenuCommand.Exit;

                case ConsoleKey.UpArrow:
                    selectedStatIndex = (selectedStatIndex - 1 + _stats.Length) % _stats.Length; // Циклический выбор
                    return MenuCommand.Move;

                case ConsoleKey.DownArrow:
                    selectedStatIndex = (selectedStatIndex + 1) % _stats.Length; // Циклический выбор
                    return MenuCommand.Move;

                case ConsoleKey.LeftArrow:
                    if (changes[selectedStatIndex] > -_stats.Get(selectedStatIndex).Value)
                    {
                        changes[selectedStatIndex] -= _valuePerClick;
                        _level.AddExpiriencePoint(_valuePerClick);
                    }
                    return MenuCommand.None;

                case ConsoleKey.RightArrow:
                    if (_level.ExperiencePoints > 0)
                    {
                        changes[selectedStatIndex] += _valuePerClick;
                        _level.AddExpiriencePoint(-_valuePerClick);
                    }
                    return MenuCommand.None;

                case CommandReset:
                    Reset();
                    return MenuCommand.None;

                case CommandResetStats:
                    ResetStats();
                    return MenuCommand.None;

                case CommandInfo:
                    _showDescription = !_showDescription;
                    return MenuCommand.None;
            }

            return MenuCommand.None;
        }

        private void Confirm()
        {
            for (int i = 0; i < _stats.Length; i++)
            {
                _stats.Change(i, changes[i]);
            }
        }

        private void Reset()
        {
            Clear();
            _level.Reset();

            Console.WriteLine("Очки опыта сброшены! Можно распределять очки");
            Console.ReadLine();
        }

        private void ResetStats()
        {
            Clear();
            _stats.Reset();
        }

        private void Clear()
        {
            Array.Clear(changes, 0, changes.Length);
        }
    }
}
