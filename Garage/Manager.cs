using Garage.Vehicles;
using System.Linq;

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
                    CreateGarage();
                    break;
                case ConsoleKey.D0:
                    ConfirmExitCommand();
                    break;
                default:
                    ConsoleUI.ErrorMessage("Please enter a valid input.");
                    break;
            }
        }

        private void CreateGarage()
        {
            var garageName = ConsoleUI.AskForString("Enter a name for the garage:");
            var garageCapacity = ConsoleUI.AskForPositiveNonZeroInt("Enter a maximum capacity:");

            _garageHandler.Add(garageName, garageCapacity);

            var currentGarage = _garageHandler.Garages.LastOrDefault(g => g != null);

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
                        currentGarage.PrintVehicleTypes();
                        return true;
                    case ConsoleKey.D3:
                        AddVehicle(currentGarage);
                        return true;
                    case ConsoleKey.D4:
                        //Todo: Remove a vehicle from the garage
                        RemoveVehicle(currentGarage);
                        return true;
                    case ConsoleKey.D5:
                        SearchVehicleByRegistrationNumber(currentGarage);
                        return true;
                    case ConsoleKey.D6:
                        SearchVehiclesByCharacteristics(currentGarage);
                        return true;
                    case ConsoleKey.D0:
                        return false;
                    default:
                        ConsoleUI.ErrorMessage("Please enter a valid input.");
                        return true;
                }
        }

        private bool SearchVehiclesByCharacteristics(Garage<Vehicle> currentGarage)
        {
            bool isSuccessful = false;

            if (currentGarage.IsEmpty)
            {
                ConsoleUI.WriteLine("The garage is empty.");
                return isSuccessful;
            }

            ConsoleUI.WriteLine("Enter the characteristics you would like to search for. "
                              + "\nLeave empty if you don't want to search for that specific characteristic.");
            
            Console.Write("Vehicle type: ");
            var searchedVehicleType = Console.ReadLine();
            
            Console.Write("Vehicle color: ");
            var searchedVehicleColor = Console.ReadLine();

            Console.Write("Number of wheels: ");
            var numberOfWheelsInput = Console.ReadLine();
            Console.WriteLine();

            IEnumerable<Vehicle> searchedVehicles = null!;

            if (!string.IsNullOrWhiteSpace(searchedVehicleType))
                searchedVehicles = currentGarage.Where(v => string.Equals(v.VehicleType.ToLower(), searchedVehicleType));

            if (!string.IsNullOrWhiteSpace(searchedVehicleColor))
                searchedVehicles = currentGarage.Where(v => string.Equals(v.Color.ToLower(), searchedVehicleColor));

            if (Int32.TryParse(numberOfWheelsInput, out int searchedNumberOfWheels))
                searchedVehicles = currentGarage.Where(v => v.NumberOfWheels == searchedNumberOfWheels);

            if (searchedVehicles == null)
            {
                ConsoleUI.ErrorMessage($"There exist no vehicles with the following characteristics;");
                
                Console.ForegroundColor = ConsoleColor.Red;
                
                if (!string.IsNullOrWhiteSpace(searchedVehicleType))
                    Console.WriteLine($"Vehicle type: {searchedVehicleType}");

                if (!string.IsNullOrWhiteSpace(searchedVehicleColor))
                    Console.WriteLine($"Vehicle color: {searchedVehicleColor}");

                if (!string.IsNullOrWhiteSpace(numberOfWheelsInput))
                    Console.WriteLine($"Number of wheels: {numberOfWheelsInput}");

                Console.ResetColor();
                Console.WriteLine();

                return isSuccessful;
            }
            else
            {
                foreach (var vehicle in searchedVehicles)
                {
                    vehicle.Print();
                }

                Console.WriteLine();
            }

            return isSuccessful = true;
        }

        private bool SearchVehicleByRegistrationNumber(Garage<Vehicle> currentGarage)
        {
            bool isSuccessful = false;

            if (currentGarage.IsEmpty)
            {
                ConsoleUI.WriteLine("The garage is empty.");
                return isSuccessful;
            }

            var registrationNumber = ConsoleUI.AskForString("Enter the registration number you would like to search for:");

            var searchedVehicle = currentGarage.FirstOrDefault(v => string.Equals(v.RegistrationNumber.ToLower(), registrationNumber.ToLower()));

            if (searchedVehicle == null)
            {
                ConsoleUI.ErrorMessage($"A vehicle with registration number '{registrationNumber}' could not be found.");
                return isSuccessful;
            }
            else
                searchedVehicle.Print();

            return isSuccessful = true;
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

                if (isSuccessful)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write("A");
                    if (VehicleTypes.AllTypesStartingWithVowel.Contains(vehicleType))
                        Console.Write("n");
                    Console.Write($" {vehicleType.ToLower()} has been added to the garage.");
                }

                return isSuccessful;
            }
        }

        private bool RemoveVehicle(Garage<Vehicle> currentGarage)
        {
            bool isSuccessful = false;

            if (currentGarage.IsEmpty)
            {
                ConsoleUI.ErrorMessage("The garage is empty.");
                return isSuccessful;
            }
            else
            {
                isSuccessful = currentGarage.Remove();

                return isSuccessful;
            }
        }

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