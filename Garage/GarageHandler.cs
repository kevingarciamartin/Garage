using Garage.Vehicles;

namespace Garage
{
    internal class GarageHandler
    {
        private Garage<Vehicle> _garage;
        private int _garageCapacity;

        public GarageHandler(int garageCapacity)
        {
            _garageCapacity = garageCapacity;
            _garage = new(_garageCapacity);
        }
    }
}