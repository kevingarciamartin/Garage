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

        public Garage(int capacity)
        {
            Capacity = capacity;
            _vehicles = new T[Capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
