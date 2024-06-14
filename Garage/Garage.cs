using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Vehicles;

namespace Garage
{
    internal class Garage
    {
        private Vehicle[] _vehicles;

        public int Capacity { get; }

        public Garage(int capacity)
        {
            Capacity = capacity;
            _vehicles = new Vehicle[Capacity];
        }

    }
}
