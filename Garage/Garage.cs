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
        private readonly int _capacity;

        public int Count => _vehicles.Count();
        public bool IsFull => Count >= _capacity;
        public bool IsEmpty => Count <= 0;

        public Garage(int capacity)
        {
            _capacity = capacity;
            _vehicles = new T[_capacity];
        }

        public bool Add(T vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, "vehicle");

            if (IsFull) return false;

            _vehicles[Count - 1] = vehicle; 
            
            return true;
        }

        public bool Remove(T vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, "vehicle");

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
