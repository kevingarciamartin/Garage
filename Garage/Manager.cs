

namespace Garage
{
    internal class Manager
    {
        internal void Run()
        {
            bool applicationInProgress = true;

            do
            {
                //PrintMenu

                //GetCommand()
            } while (applicationInProgress);
        }

        internal void Initialize()
        {
            ConsoleUI ui = new();
            GarageHandler garageHandler = new();
        }
    }
}