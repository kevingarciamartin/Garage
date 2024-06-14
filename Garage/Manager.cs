namespace Garage
{
    internal class Manager
    {
        private GarageHandler _garageHandler = new();

        internal void Run()
        {
            do
            {
                PrintMainMenu();
            } while (true);
        }

        private void PrintMainMenu()
        {
            ConsoleUI.PrintMainMenu();

            var keyPressed = ConsoleUI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.D1:
                    var garageCapacity = ConsoleUI.AskForInt("What is the capacity of your garage?");

                    //Todo: Validate integer > 0

                    //_garageHandler = new GarageHandler(garageCapacity);
                    _garageHandler.Add(garageCapacity);

                    PrintGarageMenu();
                    break;
                case ConsoleKey.D0:
                    ConfirmExitCommand();
                    break;
                default:
                    ConsoleUI.ErrorMessage("Please enter a valid input.");
                    break;
            }
        }

        private void PrintGarageMenu()
        {
            bool inGarage = true;
            do
            {
                ConsoleUI.PrintGarageMenu();

                var keyPressed = ConsoleUI.GetKey();

                switch (keyPressed)
                {
                    case ConsoleKey.D1:
                        //Todo: List all parked vehicles
                        break;
                    case ConsoleKey.D2:
                        //Todo: List the amount of each vehicle type currently in the garage
                        break;
                    case ConsoleKey.D3:
                        //Todo: Add a vehicle to the garage
                        break;
                    case ConsoleKey.D4:
                        //Todo: Remove a vehicle from the garage
                        break;
                    case ConsoleKey.D5:
                        //Todo: Search a specific vehicle by registration number
                        break;
                    case ConsoleKey.D6:
                        //Todo: Search vehicles by one or more characteristics
                        break;
                    case ConsoleKey.D0:
                        inGarage = false;
                        break;
                    default:
                        ConsoleUI.ErrorMessage("Please enter a valid input.");
                        break;
                }
            } while (inGarage);
        }

        private static void ConfirmExitCommand()
        {
            ConsoleUI.ConfirmExit();

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
                    ConsoleUI.ErrorMessage("Please enter a valid input.");
                    break;
            }
        }
    }
}