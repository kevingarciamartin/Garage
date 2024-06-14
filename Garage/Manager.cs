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

            //Todo: Make GetMainMenuCommand()
            var keyPressed = ConsoleUI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.D1:
                    var garageName = ConsoleUI.AskForString("What us the name of your garage?");
                    var garageCapacity = ConsoleUI.AskForInt("What is the capacity of your garage?");

                    //Todo: Validate integer > 0

                    _garageHandler.Add(garageName, garageCapacity);
                    var currentGarage = _garageHandler.Garages.LastOrDefault(garage => garage != null);

                    PrintGarageMenu(currentGarage!);
                    break;
                case ConsoleKey.D0:
                    ConfirmExitCommand();
                    break;
                default:
                    ConsoleUI.ErrorMessage("Please enter a valid input.");
                    break;
            }
        }

        private void PrintGarageMenu(Garage<Vehicles.Vehicle> currentGarage)
        {
            bool inGarage = true;

            do
            {
                ConsoleUI.PrintGarageMenu(currentGarage.Name);

                //Todo: Make GetGarageMenuCommand()
                var keyPressed = ConsoleUI.GetKey();

                switch (keyPressed)
                {
                    case ConsoleKey.D1:
                        currentGarage.Print(vehicle => Console.WriteLine($"{vehicle.VehicleType}: {vehicle.RegistrationNumber}"));
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