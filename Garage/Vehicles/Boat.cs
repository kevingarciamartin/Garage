﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public class Boat : Vehicle
    {
        public Boat(string registrationNumber, string color, int numberOfWheels) : base(registrationNumber, color, numberOfWheels)
        {
        }

        public string Characteristic { get; } = "Watercraft";
    }
}
