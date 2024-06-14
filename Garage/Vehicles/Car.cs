using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Car : Vehicle
    {
        public Car(string registrationNumber) : base(registrationNumber)
        {
        }

        public string Characteristic { get; } = "Passenger airbags";
    }
}
