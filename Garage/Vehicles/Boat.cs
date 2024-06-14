using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Boat : Vehicle
    {
        public Boat(string registrationNumber) : base(registrationNumber)
        {
        }

        public string Characteristic { get; } = "Hull";
    }
}
