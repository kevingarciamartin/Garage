using Garage.Vehicles;

namespace Garage
{
    internal class GarageHandler
    {
        private Garage<Vehicle> _garage; 
        public int GarageCapacity { get; }

        public GarageHandler(int garageCapacity)
        {
            GarageCapacity = garageCapacity;
            _garage = new(GarageCapacity);

            PrintMenu();
        }

        private void PrintMenu()
        {
            bool inGarage = true;
            do
            {
                ConsoleUI.PrintMenu();

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
    }
}