using Garage.Vehicles;

namespace Garage
{
    internal class GarageHandler
    {
        private List<Garage<Vehicle>> _garages;

        public GarageHandler()
        {
            _garages = new();
        }

        public void Add(int garageCapacity)
        {
            ArgumentNullException.ThrowIfNull(garageCapacity, "garageCapacity");

            _garages.Add(new Garage<Vehicle>(garageCapacity));
        }
    }
}