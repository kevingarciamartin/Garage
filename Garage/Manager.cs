



namespace Garage
{
    internal class Manager
    {
        private GarageHandler _garageHandler = null!;

        internal void Run()
        {
            do
            {
                PrintMainMenu();
                GetCommand();
            } while (true);
        }

        private void GetCommand()
        {
            var keyPressed = ConsoleUI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.D1:
                    var garageCapacity = ConsoleUI.AskForInt("What is the capacity of your garage?");

                    _garageHandler = new GarageHandler(garageCapacity);
                    break;
                case ConsoleKey.D0:
                    ConfirmExitCommand();
                    break;
                default:
                    ConsoleUI.WriteLine("Please enter a valid input.");
                    break;
            }
        }

        private void ConfirmExitCommand()
        {
            ConsoleUI.ConfirmExit("application");

            var confirmationKeyPressed = ConsoleUI.GetKey();

            switch (confirmationKeyPressed)
            {
                case ConsoleKey.D1:
                    ConsoleUI.WriteLine("Application closed.");
                    Environment.Exit(0);
                    break;
                case ConsoleKey.D0:
                    break;
                default:
                    ConsoleUI.WriteLine("Please enter a valid input.");
                    break;
            }
        }

        private void PrintMainMenu()
        {
            ConsoleUI.PrintMainMenu();
        }
    }
}