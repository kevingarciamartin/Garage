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
        }
    }
}