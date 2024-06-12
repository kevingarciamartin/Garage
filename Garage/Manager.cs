

namespace Garage
{
    internal class Manager
    {
        internal void Run()
        {
            Initialize();
        }

        private void Initialize()
        {
            ConsoleUI ui = new();
            GarageHandler garageHandler = new();
        }
    }
}