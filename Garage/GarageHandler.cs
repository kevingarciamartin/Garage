using Garage.Vehicles;
using System.Collections;

namespace Garage
{
    internal class GarageHandler : IEnumerable
    {
        private List<Garage<Vehicle>> _garages;

        public GarageHandler()
        {
            _garages = new();
        }

        public void Add(int garageCapacity)
        {
            ArgumentNullException.ThrowIfNull(garageCapacity, nameof(garageCapacity));

            _garages.Add(new Garage<Vehicle>(garageCapacity));
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var garage in _garages)
            {
                yield return garage;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}