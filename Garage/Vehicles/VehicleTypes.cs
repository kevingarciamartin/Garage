using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class VehicleTypes
    {
        public const string Airplane = "Airplane";
        public const string Boat = "Boat";
        public const string Bus = "Bus";
        public const string Car = "Car";
        public const string Motorcycle = "Motorcycle";

        public static string[] AllTypes = [Airplane, Boat, Bus, Car, Motorcycle];
        public static string[] AllTypesStartingWithVowel = [Airplane];
        public static string[] AllTypesStartingWithConsonant = [Boat, Bus, Car, Motorcycle];
    }
}
