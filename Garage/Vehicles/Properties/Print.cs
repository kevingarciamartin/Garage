using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles.Properties
{
    internal class Print
    {
        public const int VehicleTypeSpace = -15;
        public const int RegistrationNumberSpace = -15;
        public const int ColorSpace = -12;
        public const int NumberOfWheelsSpace = 6;

        public const string VehicleTypeTitle = "Type";
        public const string RegistrationNumberTitle = "Reg. Nr.";
        public const string ColorTitle = "Color";
        public const string NumberOfWheelsTitle = "Wheels";

        public static string VehiclePropertyTitles = $"{VehicleTypeTitle, VehicleTypeSpace}"
                          + $"{RegistrationNumberTitle, RegistrationNumberSpace}"
                          + $"{ColorTitle, ColorSpace}"
                          + $"{NumberOfWheelsTitle}"
                          +  "\n------------------------------------------------";
    }
}
