using Garage.Vehicles;
using System.Collections;

namespace Garage
{
    internal class GarageHandler
    {
        public List<Garage<Vehicle>> Garages;

        public GarageHandler()
        {
            Garages = new();
        }

        public void Add(string garageName, int garageCapacity)
        {
            ArgumentNullException.ThrowIfNull(garageName, nameof(garageName));
            ArgumentNullException.ThrowIfNull(garageCapacity, nameof(garageCapacity));

            Garages.Add(new Garage<Vehicle>(garageName, garageCapacity));
        }
    }
}