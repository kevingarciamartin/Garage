using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Vehicles;
using Garage.Vehicles.Properties;

namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] _vehicles;

        public string Name { get; }
        public int Capacity { get; }
        public int Count => _vehicles.Where(v => v != null).Count();
        public bool IsFull => Count >= Capacity;
        public bool IsEmpty => Count <= 0;

        public Garage(string name, int capacity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            if (capacity <= 0)
                throw new ArgumentException($"'{nameof(capacity)}' cannot be 0 or negative.", nameof(capacity));

            Name = name;
            Capacity = capacity;
            _vehicles = new T[capacity];
        }

        public void PrintParkedVehicles()
        {
            if (IsEmpty) 
                ConsoleUI.WriteLine("The garage is empty.");
            else
            {
                Console.WriteLine("List of parked vehicles:");
                foreach (var vehicle in _vehicles)
                {
                    vehicle?.Print();
                }
                Console.WriteLine();
            }
        }

        public void PrintVehicleTypes()
        {
            if (IsEmpty)
                ConsoleUI.WriteLine("The garage is empty.");
            else
            {
                Dictionary<string, int> vehicleTypesInGarage = new()
                {
                    { VehicleTypes.Airplane, 0 },
                    { VehicleTypes.Boat, 0 },
                    { VehicleTypes.Bus, 0 },
                    { VehicleTypes.Car, 0 },
                    { VehicleTypes.Motorcycle, 0 }
                };

                foreach (var vehicle in _vehicles)
                {
                    if (vehicle != null)
                        vehicleTypesInGarage[vehicle.VehicleType]++;
                }

                Console.WriteLine("List of vehicle types:");

                foreach (var keyValuePair in vehicleTypesInGarage)
                {
                    if (keyValuePair.Value > 0)
                    {
                        Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
                    }
                }

                Console.WriteLine();
            }
        }

        public bool Add(T vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));

            if (IsFull) return false;

            vehicle.ID = Count;
            _vehicles[Count] = vehicle;
            
            return true;
        }

        public bool Remove()
        {
            if (IsEmpty) return false;

            _vehicles[Count - 1] = null!;

            return true;
        }

        public bool Remove(string registrationNumber)
        {
            if (IsEmpty) return false;

            if (String.IsNullOrWhiteSpace(registrationNumber)) return false;

            var vehicleToRemove = _vehicles.FirstOrDefault(v => v.RegistrationNumber.Equals(registrationNumber, StringComparison.CurrentCultureIgnoreCase));

            if (vehicleToRemove == null)
            {
                ConsoleUI.ErrorMessage($"Could not find a vehicle with registration number '{registrationNumber.ToUpper()}'.");
                return false;
            }

            var index = vehicleToRemove.ID;
            _vehicles[index] = null!;

            for (int i = index; i < Count; i++)
            {
                if (!(i == Count - 1))
                {
                    _vehicles[i] = _vehicles[i + 1];
                    _vehicles[i].ID = i;
                }
            }

            if (Count != 0)
                _vehicles[Count - 1] = null!;

            ConsoleUI.SuccessMessage($"{vehicleToRemove.VehicleType} ({vehicleToRemove.RegistrationNumber}) has been removed.");

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in _vehicles)
            {
                if (vehicle != null)
                    yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
