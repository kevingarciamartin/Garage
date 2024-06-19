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
            var message = $"{VehicleType, Properties.Print.VehicleTypeSpace}"
                        + $"{RegistrationNumber, Properties.Print.RegistrationNumberSpace}"
                        + $"{Color, Properties.Print.ColorSpace}"
                        + $"{NumberOfWheels, Properties.Print.NumberOfWheelsSpace}";

            Console.WriteLine(message);

            return message;
        }

        public static bool IsValidRegistrationNumber(string registrationNumber)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                throw new ArgumentException($"'{nameof(registrationNumber)}' cannot be null or whitespace.", nameof(registrationNumber));
            }

            if (registrationNumber.Length != 6)
            {
                ConsoleUI.ErrorMessage(() =>
                {
                    Console.Write($"The registration number '{registrationNumber.ToUpper()}' is ");
                    if (registrationNumber.Length < 6)
                        Console.Write("too short.");
                    else if (registrationNumber.Length > 6)
                        Console.Write("too long.");
                    Console.WriteLine();
                    Console.WriteLine();
                });

                return false;
            }

            var registrationNumberArray = registrationNumber.ToCharArray();
            int letters = 0;
            int integers = 0;

            for (int i = 0; i < registrationNumber.Length; i++)
            {
                if (i < registrationNumber.Length / 2)
                {
                    if (Char.IsLetter(registrationNumberArray[i]))
                        letters++;
                }
                else
                {
                    if (Char.IsDigit(registrationNumberArray[i]))
                        integers++;
                }
            }

            if (letters == 3 && integers == 3) return true;
            else
            {
                ConsoleUI.ErrorMessage($"The registration number '{registrationNumber.ToUpper()}' is not of valid format (ABC123).");
                return false;
            }
        }
    }
}