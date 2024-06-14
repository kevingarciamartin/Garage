using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Vehicles;

namespace Garage
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] _vehicles;

        public int Capacity { get; }
        public int Count => _vehicles.Count();
        public bool IsFull => Count >= Capacity;
        public bool IsEmpty => Count <= 0;

        public Garage(int capacity)
        {
            Capacity = capacity;
            _vehicles = new T[capacity];
        }

        public bool Add(T vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));

            if (IsFull) return false;

            _vehicles[Count - 1] = vehicle; 
            
            return true;
        }

        public bool Remove(T vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));

            if (IsEmpty) return false;

            //Todo: Remove vehicle from array

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in _vehicles)
            {
                yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
