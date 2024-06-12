



namespace Garage
{
    internal class Manager
    {
        internal void Initialize()
        {
            GarageHandler garageHandler = new();
        }

        internal void Run()
        {
            bool applicationInProgress = true;

            do
            {
                PrintMenu();
                GetCommand();
            } while (applicationInProgress);
        }

        private void GetCommand()
        {
            var keyPressed = ConsoleUI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.D0:
                    ConsoleUI.ConfirmExit();

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
                    break;
                default:
                    ConsoleUI.WriteLine("Please enter a valid input.");
                    break;
            }
        }

        private void PrintMenu()
        {
            ConsoleUI.PrintMenu();
        }
    }
}