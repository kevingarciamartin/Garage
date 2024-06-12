

namespace Garage
{
    internal class GarageHandler
    {
        public int GarageCapacity { get; }

        public GarageHandler(int garageCapacity)
        {
            GarageCapacity = garageCapacity;

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
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        break;
                    case ConsoleKey.D6:
                        break;
                    case ConsoleKey.D0:
                        inGarage = false;
                        break;
                    default:
                        ConsoleUI.WriteLine("Please enter a valid input.");
                        break;
                }
            } while (inGarage);
        }
    }
}