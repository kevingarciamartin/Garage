namespace Garage.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(string registrationNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public int ID { get; set; }
        public string RegistrationNumber { get; }
        public string Color { get; }
        public int NumberOfWheels { get; }
        public string VehicleType => GetType().Name;

        public string Print()
        {
            var message = $"{VehicleType}, "
                        + $"regNr: {RegistrationNumber}, "
                        + $"color: {Color}, "
                        + $"nrOfWheels: {NumberOfWheels}";

            Console.WriteLine(message);

            return message;
        }
    }
}