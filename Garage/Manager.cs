﻿using Garage.Vehicles;
using Garage.Vehicles.Properties;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Garage
{
    internal class Manager
    {
        private IConsoleUI _ui;
        private IHandler _garageHandler;

        public Manager(IConsoleUI ui, IHandler garageHandler)
        {
            _ui = ui;
            _garageHandler = garageHandler;
        }

        internal void Run()
        {
            do
            {
                PrintMainMenu();
            } while (true);
        }

        private void PrintMainMenu()
        {
            _ui.PrintMainMenu();
            GetMainMenuCommand();
        }

        private void GetMainMenuCommand()
        {
            var keyPressed = _ui.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.D1:
                    CreateGarage();
                    break;
                case ConsoleKey.D2:
                    DeleteGarage();
                    break;
                case ConsoleKey.D3:
                    SelectGarage();
                    break;
                case ConsoleKey.D0:
                    ConfirmExitCommand();
                    break;
                default:
                    _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input."));
                    break;
            }
        }

        private void DeleteGarage()
        {
            if (_garageHandler.IsEmpty)
            {
                _ui.WriteLine("No garage exists.");
            }
            else
            {
                Console.WriteLine("Select a garage to delete:");
                _garageHandler.Print();

                var keyPressed = _ui.GetKey();

                switch (keyPressed)
                {
                    case ConsoleKey.D1:
                        _garageHandler.Garages.Remove(_garageHandler.Garages[0]);
                        break;
                    case ConsoleKey.D2:
                        if (_garageHandler.Count < 2)
                        {
                            _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input"));
                            break;
                        }
                        else
                        {
                            _garageHandler.Garages.Remove(_garageHandler.Garages[1]);
                            break;
                        }
                    case ConsoleKey.D3:
                        if (_garageHandler.Count < 3)
                        {
                            _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input"));
                            break;
                        }
                        else
                        {
                            _garageHandler.Garages.Remove(_garageHandler.Garages[2]);
                            break;
                        } 
                    case ConsoleKey.D4:
                        if (_garageHandler.Count < 4)
                        {
                            _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input"));
                            break;
                        }
                        else
                        {
                            _garageHandler.Garages.Remove(_garageHandler.Garages[3]);
                            break;
                        }
                    case ConsoleKey.D5:
                        if (_garageHandler.Count < 5)
                        {
                            _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input"));
                            break;
                        }
                        else
                        {
                            _garageHandler.Garages.Remove(_garageHandler.Garages[4]);
                            break;
                        }
                    default:
                        _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input."));
                        break;
                }
            }
        }

        private void SelectGarage()
        {
            if (_garageHandler.IsEmpty)
            {
                _ui.WriteLine("No garage exists.");
            }
            else
            {
                Console.WriteLine("Select a garage:");
                _garageHandler.Print();

                var keyPressed = _ui.GetKey();
                Garage<Vehicle> currentGarage;

                switch (keyPressed)
                {
                    case ConsoleKey.D1:
                        currentGarage = _garageHandler.Garages[0];
                        PrintGarageMenu(currentGarage);
                        break;
                    case ConsoleKey.D2:
                        if (_garageHandler.Count < 2)
                        {
                            _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input"));
                            break;
                        }
                        else
                        {
                            currentGarage = _garageHandler.Garages[1];
                            PrintGarageMenu(currentGarage); 
                            break;
                        }
                    case ConsoleKey.D3:
                        if (_garageHandler.Count < 3)
                        {
                            _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input"));
                            break;
                        }
                        else
                        {
                            currentGarage = _garageHandler.Garages[2];
                            PrintGarageMenu(currentGarage);
                            break;
                        } 
                    case ConsoleKey.D4:
                        if (_garageHandler.Count < 4)
                        {
                            _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input"));
                            break;
                        }
                        else
                        {
                            currentGarage = _garageHandler.Garages[3];
                            PrintGarageMenu(currentGarage);
                            break;
                        }
                    case ConsoleKey.D5:
                        if (_garageHandler.Count < 5)
                        {
                            _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input"));
                            break;
                        }
                        else
                        {
                            currentGarage = _garageHandler.Garages[4];
                            PrintGarageMenu(currentGarage);
                            break;
                        }
                    default:
                        _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input."));
                        break;
                }
            }
        }

        private void CreateGarage()
        {
            if (_garageHandler.IsFull)
            {
                _ui.WriteLine("You have reached the maximum capacity of garages.");
            }
            else
            {
                var garageName = _ui.AskForString("Enter a name for the garage:");
                var garageCapacity = _ui.AskForPositiveNonZeroInt("Enter a maximum capacity:");

                _garageHandler.Add(garageName, garageCapacity);

                var currentGarage = _garageHandler.Garages.LastOrDefault(g => g != null);

                OptionToPopulateGarage(currentGarage!);

                PrintGarageMenu(currentGarage!);
            }
        }

        private void OptionToPopulateGarage(Garage<Vehicle> currentGarage)
        {
            _ui.WriteLine("If you would like to pre-populate the garage, enter the amount of vehicles you want." 
                              + "\nIf not, enter 0.");

            var input = _ui.AskForPositiveInt("Enter the number of vehicles to pre-populate the garage:");

            if (input > 0)
            {
                Random rnd = new();

                for (int i = 0; i < input; i++)
                {
                    var vehicleType = GetRandomVehicleType(rnd);
                    var registrationNumber = GenerateRegistrationNumber(rnd, currentGarage);
                    var color = GetRandomColor(rnd);
                    var numberOfWheels = GetRandomNumberOfWheels(rnd, vehicleType);

                    AddVehicle(currentGarage, vehicleType, registrationNumber, color, numberOfWheels);
                }
            }
        }

        private static int GetRandomNumberOfWheels(Random rnd, string vehicleType)
        {
            int numberOfWheels;

            switch (vehicleType)
            {
                case VehicleTypes.Airplane: return 3;
                case VehicleTypes.Boat: return 0;
                case VehicleTypes.Bus: 
                    numberOfWheels = rnd.Next(4, 9);

                    if (Int32.IsOddInteger(numberOfWheels))
                        return numberOfWheels - 1;

                    return numberOfWheels;
                case VehicleTypes.Car: return 4;
                case VehicleTypes.Motorcycle: return rnd.Next(2, 4);
                default: return 0;
            }
        }

        private static string GenerateRegistrationNumber(Random rnd, Garage<Vehicle> currentGarage)
        {
            const int registrationNumberLength = 6;
            string[] registrationNumberArray = new string[registrationNumberLength];
            string letter;
            string integer;
            string registrationNumber;

            do
            {
                for (int i = 0; i < registrationNumberLength / 2; i++)
                {
                    // Generates random uppercase letter (A-Z)
                    int num = rnd.Next(26);
                    letter = ((char)('A' + num)).ToString();

                    registrationNumberArray[i] = letter;
                }

                for (int i = registrationNumberLength / 2; i < registrationNumberLength; i++)
                {
                    // Generates random integer (0-9)
                    integer = (rnd.Next(10)).ToString();

                    registrationNumberArray[i] = integer;
                }

                registrationNumber = String.Join("", registrationNumberArray);
            } while (!currentGarage.IsUniqueRegistrationNumber(registrationNumber));

            return registrationNumber;
        }

        private static string GetRandomColor(Random rnd)
        {
            var index = rnd.Next(Colors.AllColors.Length);
            var color = Colors.AllColors[index];

            return color;
        }

        private static string GetRandomVehicleType(Random rnd)
        {
            var index = rnd.Next(VehicleTypes.AllTypes.Length);
            var vehicleType = VehicleTypes.AllTypes[index];

            return vehicleType;
        }

        private void PrintGarageMenu(Garage<Vehicle> currentGarage)
        {
            bool inGarage = true;

            do
            {
                _ui.PrintGarageMenu(currentGarage.Name);
                inGarage = GetGarageMenuCommand(currentGarage);

            } while (inGarage);
        }

        private bool GetGarageMenuCommand(Garage<Vehicle> currentGarage)
        {
                bool inGarage = true;
                var keyPressed = _ui.GetKey();

                switch (keyPressed)
                {
                    case ConsoleKey.D1:
                        currentGarage.PrintParkedVehicles();
                        return inGarage;
                    case ConsoleKey.D2:
                        currentGarage.PrintVehicleTypes();
                        return inGarage;
                    case ConsoleKey.D3:
                        Add(currentGarage);  
                        return inGarage;
                    case ConsoleKey.D4:
                        Remove(currentGarage);
                        return inGarage;
                    case ConsoleKey.D5:
                        SearchVehicleByRegistrationNumber(currentGarage);
                        return inGarage;
                    case ConsoleKey.D6:
                        SearchVehiclesByCharacteristics(currentGarage);
                        return inGarage;
                    case ConsoleKey.D0:
                        return inGarage = false;
                    default:
                        _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input."));
                        return inGarage;
                }
        }

        private bool Add(Garage<Vehicle> currentGarage)
        {
            bool isSuccessful = false;

            if (!CheckIfFull(currentGarage))
            {
                var (vehicleType, registrationNumber, color, numberOfWheels) = GetVehicleInput(currentGarage);
                if (AddVehicle(currentGarage, vehicleType, registrationNumber, color, numberOfWheels))
                {
                    _ui.SuccessMessage(() =>
                    {
                        Console.Write("A");
                        if (VehicleTypes.AllTypesStartingWithVowel.Contains(vehicleType))
                            Console.Write("n");
                        Console.WriteLine($" {vehicleType.ToLower()} has been added to the garage.");
                        Console.WriteLine();
                    });

                    return isSuccessful = true;
                }
            }

            return isSuccessful;
        }

        private bool CheckIfFull(Garage<Vehicle> currentGarage)
        {
            if (currentGarage.IsFull)
                _ui.WriteLine("The garage is full.");

            return currentGarage.IsFull;
        }

        private bool AddVehicle(Garage<Vehicle> currentGarage, string vehicleType, string registrationNumber, string color, int numberOfWheels)
        {
            bool isSuccessful = false;

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
                    _ui.ErrorMessage(() => _ui.WriteLine($"Vehicle type {vehicleType} does not exist."));
                    break;
            }

            return isSuccessful;
        }

        private bool SearchVehiclesByCharacteristics(Garage<Vehicle> currentGarage)
        {
            bool isSuccessful = false;

            if (currentGarage.IsEmpty)
            {
                _ui.WriteLine("The garage is empty.");
                return isSuccessful;
            }

            _ui.WriteLine("Enter the characteristics you would like to search for. "
                              + "\nLeave empty if you don't want to search for that specific characteristic.");
            
            Console.Write("Vehicle type: ");
            var searchedVehicleType = Console.ReadLine();
            searchedVehicleType = searchedVehicleType?.Trim();
            
            Console.Write("Vehicle color: ");
            var searchedVehicleColor = Console.ReadLine();
            searchedVehicleColor = searchedVehicleColor?.Trim();

            Console.Write("Number of wheels: ");
            var numberOfWheelsInput = Console.ReadLine();
            numberOfWheelsInput = numberOfWheelsInput?.Trim();
            Console.WriteLine();

            IEnumerable<Vehicle> searchedVehicles = null!;

            if (!string.IsNullOrWhiteSpace(searchedVehicleType))
                searchedVehicles = currentGarage.Where(v => string.Equals(v.VehicleType.ToLower(), searchedVehicleType.ToLower()));

            if (!string.IsNullOrWhiteSpace(searchedVehicleColor))
                searchedVehicles = currentGarage.Where(v => Colors.GetLevenshteinDistance(v.Color, searchedVehicleColor) <= 2);

            if (Int32.TryParse(numberOfWheelsInput, out int searchedNumberOfWheels))
                searchedVehicles = currentGarage.Where(v => Int32.Equals(v.NumberOfWheels, searchedNumberOfWheels));
            
            if (searchedVehicles == null)
            {
                _ui.ErrorMessage(() => _ui.WriteLine("No search keywords have been entered."));

                return isSuccessful;
            }
            else if (!searchedVehicles.Any())
            {
                _ui.ErrorMessage(() =>
                {
                    _ui.WriteLine("There exist no vehicles with the following characteristics;");
                    
                    if (!string.IsNullOrWhiteSpace(searchedVehicleType))
                        Console.WriteLine($"Vehicle type: {searchedVehicleType}");

                    if (!string.IsNullOrWhiteSpace(searchedVehicleColor))
                        Console.WriteLine($"Vehicle color: {searchedVehicleColor}");

                    if (!string.IsNullOrWhiteSpace(numberOfWheelsInput))
                        Console.WriteLine($"Number of wheels: {numberOfWheelsInput}");
                    
                    Console.WriteLine();
                });
                
                return isSuccessful;
            }
            else
            {
                Console.WriteLine(Print.VehiclePropertyTitles);
                foreach (var vehicle in searchedVehicles)
                {
                    vehicle?.Print();
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
                _ui.WriteLine("The garage is empty.");
                return isSuccessful;
            }

            var registrationNumber = _ui.AskForString("Enter the registration number you would like to search for:");
            registrationNumber = registrationNumber.Trim();

            var searchedVehicle = currentGarage.Where(v => string.Equals(v.RegistrationNumber.ToLower(), registrationNumber.ToLower()));

            if (!searchedVehicle.Any())
            {
                _ui.ErrorMessage(() => _ui.WriteLine($"A vehicle with registration number '{registrationNumber}' could not be found."));
                return isSuccessful;
            }
            else
            {
                Console.WriteLine(Print.VehiclePropertyTitles);
                foreach (var vehicle in searchedVehicle)
                {
                    vehicle.Print();
                    Console.WriteLine();
                }
            }

            return isSuccessful = true;
        }

        private (string, string, string, int) GetVehicleInput(Garage<Vehicle> currentGarage)
        {
            string registrationNumber;
            string color;
            int[] levenshteinDistance = new int[Colors.AllColors.Length];

            var vehicleType = GetVehicleType(currentGarage);

            do
            {
                registrationNumber = _ui.AskForString("Enter a unique registration number (e.g. 'ABC123'):");
            } while (!currentGarage.IsUniqueRegistrationNumber(registrationNumber));

            do
            {
                color = _ui.AskForString("Enter a vehicle color:");

                for (int i = 0; i < Colors.AllColors.Length; i++)
                {
                    levenshteinDistance[i] = Colors.GetLevenshteinDistance(color, Colors.AllColors[i]);

                    if (levenshteinDistance[i] <= 2)
                        color = Colors.AllColors[i];
                }

                if (levenshteinDistance.Min() > 2)
                    _ui.ErrorMessage(() => _ui.WriteLine("Enter a valid color."));
            } while (levenshteinDistance.Min() > 2);

            var numberOfWheels = _ui.AskForPositiveInt("Enter the amount of wheels of the vehicle:");

            return (vehicleType, registrationNumber.ToUpper(), color, numberOfWheels);
        }

        private bool Remove(Garage<Vehicle> currentGarage)
        {
            bool isSuccessful = false;

            if (currentGarage.IsEmpty)
            {
                _ui.WriteLine("The garage is empty.");
                return isSuccessful;
            }
            else
            {
                _ui.PrintRemoveVehicleMenu(currentGarage.Name);

                var keyPressed = _ui.GetKey();

                switch (keyPressed)
                {
                    case ConsoleKey.D1:
                        return isSuccessful = currentGarage.Remove();
                    case ConsoleKey.D2:
                        var registrationNumber = _ui.AskForString("Enter the registration number of the vehicle you want removed:");
                        return isSuccessful = currentGarage.Remove(registrationNumber);
                    default:
                        _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input."));
                        return isSuccessful;
                }
            }
        }

        private string GetVehicleType(Garage<Vehicles.Vehicle> currentGarage)
        {
            string? vehicleType = null;

            do
            {
                _ui.PrintGetVehicleTypeMenu(currentGarage.Name);

                var keyPressed = _ui.GetKey();

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
                        _ui.ErrorMessage(() => _ui.WriteLine("Invalid input."));
                        break;
                }
            } while (vehicleType == null);

            return vehicleType;
        }

        private void ConfirmExitCommand()
        {
            _ui.ConfirmExit("application");

            var confirmationKeyPressed = _ui.GetKey();

            switch (confirmationKeyPressed)
            {
                case ConsoleKey.D1:
                    _ui.WriteLine("Application closed.");
                    Environment.Exit(0);
                    break;
                case ConsoleKey.D0:
                    break;
                default:
                    _ui.ErrorMessage(() => _ui.WriteLine("Please enter a valid input."));
                    break;
            }
        }
    }
}