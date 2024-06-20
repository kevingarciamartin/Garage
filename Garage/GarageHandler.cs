using Garage.Vehicles;
using System.Collections;

namespace Garage
{
    internal class GarageHandler : IHandler
    {
        public List<Garage<Vehicle>> Garages { get; }
        public int Capacity => 5;
        public int Count => Garages.Count;
        public bool IsFull => Count >= Capacity;
        public bool IsEmpty => Count <= 0;

        public GarageHandler()
        {
            Garages = new();
        }

        public void Print()
        {
            int num = 1;

            foreach (var garage in Garages)
            {
                Console.WriteLine($"{num++}. {garage.Name} ({garage.Count}/{garage.Capacity})");
            }

            Console.WriteLine();
        }

        public void Add(string garageName, int garageCapacity)
        {
            ArgumentNullException.ThrowIfNull(garageName, nameof(garageName));
            ArgumentNullException.ThrowIfNull(garageCapacity, nameof(garageCapacity));

            Garages.Add(new Garage<Vehicle>(garageName, garageCapacity));
        }
    }
}