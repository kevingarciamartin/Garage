using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public Motorcycle(string registrationNumber) : base(registrationNumber)
        {
        }

        public string Characteristic { get; } = "Two wheels";
    }
}
