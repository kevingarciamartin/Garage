using Garage.Vehicles;

namespace Garage
{
    internal interface IHandler
    {
        List<Garage<Vehicle>> Garages { get; }
        int Capacity { get; }
        int Count { get; }
        bool IsFull { get; }
        bool IsEmpty { get; }

        void Print();
        void Add(string garageName, int garageCapacity);
    }
}