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
            GetMainMenuCommand();
        }

        private void GetMainMenuCommand()
        {
            var keyPressed = ConsoleUI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.D1:
                    var garageName = ConsoleUI.AskForString("What is the name of your garage?");
                    var garageCapacity = GetGarageCapacity();

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

        private static int GetGarageCapacity()
        {
            int garageCapacity;
            do
            {
                garageCapacity = ConsoleUI.AskForInt("What is the capacity of your garage?");

                if (garageCapacity <= 0) ConsoleUI.ErrorMessage("Please enter a positive integer.");
            } while (garageCapacity <= 0);

            return garageCapacity;
        }

        private void PrintGarageMenu(Garage<Vehicles.Vehicle> currentGarage)
        {
            bool inGarage = true;

            do
            {
                ConsoleUI.PrintGarageMenu(currentGarage.Name);
                inGarage = GetGarageMenuCommand(currentGarage);

            } while (inGarage);
        }

        private bool GetGarageMenuCommand(Garage<Vehicles.Vehicle> currentGarage)
        {
                var keyPressed = ConsoleUI.GetKey();

                switch (keyPressed)
                {
                    case ConsoleKey.D1:
                        currentGarage.Print(vehicle => Console.WriteLine($"{vehicle.VehicleType}: {vehicle.RegistrationNumber}"));
                        return true;
                    case ConsoleKey.D2:
                        //Todo: List the amount of each vehicle type currently in the garage
                        return true;
                    case ConsoleKey.D3:
                        //Todo: Add a vehicle to the garage
                        return true;
                    case ConsoleKey.D4:
                        //Todo: Remove a vehicle from the garage
                        return true;
                    case ConsoleKey.D5:
                        //Todo: Search a specific vehicle by registration number
                        return true;
                    case ConsoleKey.D6:
                        //Todo: Search vehicles by one or more characteristics
                        return true;
                    case ConsoleKey.D0:
                        return false;
                    default:
                        ConsoleUI.ErrorMessage("Please enter a valid input.");
                        return true;
                }
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