namespace Garage.Vehicles
{
    abstract class Vehicle
    {
        protected Vehicle(string registrationNumber, string color, int numberOfWheels)
        {
            //Todo: Validate registration number
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public string RegistrationNumber { get; }
        public string Color { get; }
        public int NumberOfWheels { get; }
    }
}