namespace Garage
{
    abstract class Vehicle
    {
        protected Vehicle(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }

        public string RegistrationNumber { get; }
    }
}