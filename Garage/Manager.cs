



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
                    ConfirmApplicationExitCommand();
                    break;
                default:
                    ConsoleUI.WriteLine("Please enter a valid input.");
                    break;
            }
        }

        private void ConfirmApplicationExitCommand()
        {
            ConsoleUI.ConfirmApplicationExit();

            var confirmationKeyPressed = ConsoleUI.GetKey();

            switch (confirmationKeyPressed)
            {
                case ConsoleKey.D1:
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