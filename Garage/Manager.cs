using Garage.Vehicles;

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
                    CreateGarage(_garageHandler);
                    break;
                case ConsoleKey.D0:
                    ConfirmExitCommand();
                    break;
                default:
                    ConsoleUI.ErrorMessage("Please enter a valid input.");
                    break;
            }
        }

        private void CreateGarage(GarageHandler garageHandler)
        {
            var garageName = ConsoleUI.AskForString("Enter a name for the garage:");
            var garageCapacity = ConsoleUI.AskForPositiveNonZeroInt("Enter a maximum capacity:");

            _garageHandler.Add(garageName, garageCapacity);

            var currentGarage = _garageHandler.Garages.LastOrDefault(garage => garage != null);

            PrintGarageMenu(currentGarage!);
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
                        currentGarage.PrintParkedVehicles();
                        return true;
                    case ConsoleKey.D2:
                        //Todo: List the amount of each vehicle type currently in the garage
                        currentGarage.PrintVehicleTypes();
                        return true;
                    case ConsoleKey.D3:
                        AddVehicle(currentGarage);
                        return true;
                    case ConsoleKey.D4:
                        //Todo: Remove a vehicle from the garage
                        //RemoveVehicle(currentGarage);
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

        private static bool AddVehicle(Garage<Vehicle> currentGarage)
        {
            bool isSuccessful = false;

            if (currentGarage.IsFull)
            {
                ConsoleUI.ErrorMessage("The garage is full.");
                return isSuccessful;
            }
            else
            {
                //Todo: Validate inputs
                var vehicleType = GetVehicleType(currentGarage) ?? "car";
                var registrationNumber = ConsoleUI.AskForString("Enter a unique registration number (e.g. 'ABC123'):");
                var color = ConsoleUI.AskForString("Enter a vehicle color:");
                var numberOfWheels = ConsoleUI.AskForPositiveInt("Enter the amount of wheels of the vehicle:");

                switch (vehicleType)
                {
                    case VehicleTypes.Airplane:
                        isSuccessful = currentGarage.Add(new Airplane(registrationNumber, color, numberOfWheels));
                        break;
                    case VehicleTypes.Boat:
                        isSuccessful = currentGarage.Add(new Boat(registrationNumber, color, numberOfWheels));
                        break;
                    case VehicleTypes.Bus:
                        isSuccessful = currentGarage.Add(new Bus(registrationNumber, color, numberOfWheels));
                        break;
                    case VehicleTypes.Car:
                        isSuccessful = currentGarage.Add(new Car(registrationNumber, color, numberOfWheels));
                        break;
                    case VehicleTypes.Motorcycle:
                        isSuccessful = currentGarage.Add(new Motorcycle(registrationNumber, color, numberOfWheels));
                        break;
                    default:
                        ConsoleUI.ErrorMessage($"Vehicle type {vehicleType} does not exist.");
                        break;
                }

                if (isSuccessful && VehicleTypes.AllTypesStartingWithVowel.Contains(vehicleType))
                    ConsoleUI.SuccessMessage($"An {vehicleType} has been added to your garage.");
                else if (isSuccessful)
                    ConsoleUI.SuccessMessage($"A {vehicleType} has been added to your garage.");

                return isSuccessful;
            }
        }
        
        //private bool RemoveVehicle(Garage<Vehicle> currentGarage)
        //{
        //    bool isSuccessful = false;

        //    if (currentGarage == null)
        //    {
        //        ConsoleUI.ErrorMessage("The garage is empty.");
        //        return isSuccessful;
        //    }
        //    else
        //    {
        //        isSuccessful = currentGarage.Remove
        //    }
        //}

        private static string GetVehicleType(Garage<Vehicles.Vehicle> currentGarage)
        {
            string? vehicleType = null;

            do
            {
                ConsoleUI.PrintGetVehicleTypeMenu(currentGarage.Name);

                var keyPressed = ConsoleUI.GetKey();

                switch (keyPressed)
                {
                    case ConsoleKey.D1:
                        vehicleType = VehicleTypes.Airplane;
                        break;
                    case ConsoleKey.D2:
                        vehicleType = VehicleTypes.Boat;
                        break;
                    case ConsoleKey.D3:
                        vehicleType = VehicleTypes.Bus;
                        break;
                    case ConsoleKey.D4:
                        vehicleType = VehicleTypes.Car;
                        break;
                    case ConsoleKey.D5:
                        vehicleType = VehicleTypes.Motorcycle;
                        break;
                    default:
                        ConsoleUI.ErrorMessage("Invalid input.");
                        break;
                }
            } while (vehicleType == null);

            return vehicleType;
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