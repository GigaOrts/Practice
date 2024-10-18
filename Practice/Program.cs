
namespace Practice
{
    class Program
    {
        private static Stats _stats;
        private static Level _level;
        private static StatsModification _statsModification;
        private static MainMenu _mainMenu;

        private static bool _isMainWindowOpen;

        static void Main()
        {
            _stats = new Stats();
            _level = new Level();
            _statsModification = new StatsModification(_level, _stats);
            
            _mainMenu = new MainMenu();

            Console.CursorVisible = false;
            _isMainWindowOpen = true;
            
            while (_isMainWindowOpen)
            {
                _mainMenu.DisplayMenu();
                MenuCommand menuCommand = _mainMenu.Process();

                if(menuCommand == MenuCommand.Confirm)
                {
                    // TODO: Нужен класс, который хранил бы статус команды, и какую конкретно команду нажали, типа Order или OperationInfo
                    if (_mainMenu.SelectedOptionIndex == 0)
                    {
                        HandleStatsWindow(_level, _statsModification);
                    }
                    else if(_mainMenu.SelectedOptionIndex == 1)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void HandleStatsWindow(Level level, StatsModification statsModification)
        {
            MenuCommand menuCommand;

            do
            {
                Console.Clear();
                level.ShowExpiriencePoints();
                statsModification.DisplayMenu();
                menuCommand = statsModification.Process();
            } while (menuCommand != MenuCommand.Exit);
        }
    }
}