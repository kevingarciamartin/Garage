using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Airplane : Vehicle
    {
        public Airplane(string registrationNumber, string color, int numberOfWheels) : base(registrationNumber, color, numberOfWheels)
        {
        }
    }
}
