using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Vehicles;

namespace Garage.Tests.Tests
{
    public class GarageTests
    {
        private const string validString = "Valid";
        private const string emptyString = "";
        private const string whiteSpaceString = " ";
        private const string airplaneRegistrationNumber = "ABC123";
        private const string boatRegistrationNumber = "DEF123";
        private const string busRegistrationNumber = "GHI123";
        private const string carRegistrationNumber = "JKL123";
        private const string motorcycleRegistrationNumber = "MNO123";
        private const int validCapacity = 1;
        private const int invalidCapacity = -1;
        private const int initialCount = 0;

        private readonly Garage<Vehicle> _garage;
        private readonly Airplane _airplane;
        private readonly Boat _boat;
        private readonly Bus _bus;
        private readonly Car _car;
        private readonly Motorcycle _motorcycle;

        public GarageTests()
        {
            _garage = new Garage<Vehicle>(validString, validCapacity);
            _airplane = new Airplane(registrationNumber: airplaneRegistrationNumber, color: "Red", numberOfWheels: 4);
            _boat = new Boat(registrationNumber: boatRegistrationNumber, color: "Red", numberOfWheels: 4);
            _bus = new Bus(registrationNumber: busRegistrationNumber, color: "Red", numberOfWheels: 4);
            _car = new Car(registrationNumber: carRegistrationNumber, color: "Red", numberOfWheels: 4);
            _motorcycle = new Motorcycle(registrationNumber: motorcycleRegistrationNumber, color: "Red", numberOfWheels: 4);
        }

        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            Assert.Equal(validString, _garage.Name);
            Assert.Equal(validCapacity, _garage.Capacity);
            Assert.Equal(initialCount, _garage.Count);
            Assert.False(_garage.IsFull);
            Assert.True(_garage.IsEmpty);
        }

        [Fact]
        public void Constructor_ShouldThrowException_OnInvalidName()
        {
            Assert.Throws<ArgumentException>(() => new Garage<Vehicle>(emptyString, validCapacity));
            Assert.Throws<ArgumentException>(() => new Garage<Vehicle>(whiteSpaceString, validCapacity));
            Assert.Throws<ArgumentException>(() => new Garage<Vehicle>(null!, validCapacity));
        }

        [Fact]
        public void Constructor_ShouldThrowException_OnInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Garage<Vehicle>(validString, invalidCapacity));
            Assert.Throws<ArgumentException>(() => new Garage<Vehicle>(validString, 0));
        }

        [Fact]
        public void IsFull_ShouldReturnTrue_WhenCountIsEqualOrGreaterThanCapacity()
        {
            _garage.Add(_car);

            Assert.True(_garage.IsFull);
        }
        
        [Fact]
        public void IsEmpty_ShouldReturnFalse_WhenCountGreaterThan_0()
        {
            _garage.Add(_car);

            Assert.False(_garage.IsEmpty);
        }

        [Fact]
        public void Add_ShouldReturnFalse_WhenIsFull()
        {
            _garage.Add(_car);

            Assert.False(_garage.Add(_car));
        }
        
        [Fact]
        public void Add_ShouldReturnTrue_WhenNotIsFull()
        {
            Assert.True(_garage.Add(_car));
        }

        [Fact]
        public void Add_ShouldIncreaseCount_By_1()
        {
            _garage.Add(_car);

            Assert.Equal(1, _garage.Count);
        }
        
        [Fact]
        public void Add_ShouldSetVehicleID_To_CountMinus1()
        {
            _garage.Add(_airplane);

            Assert.Equal(_garage.Count - 1, _airplane.ID);
        }

        [Fact]
        public void Remove_ShouldReturnFalse_WhenIsEmpty()
        {
            Assert.False(_garage.Remove());
            Assert.False(_garage.Remove(airplaneRegistrationNumber));
        }

        [Fact]
        public void Remove_ShouldReturnTrue_WhenNotIsEmpty()
        {
            _garage.Add(_car);

            Assert.True(_garage.Remove());
        }
        
        [Fact]
        public void Remove_ByRegistrationNumber_ShouldReturnTrue_WhenNotIsEmpty()
        {
            _garage.Add(_airplane);

            Assert.True(_garage.Remove(airplaneRegistrationNumber));
        }
        
        [Fact]
        public void Remove_ByRegistrationNumber_ShouldReturnFalse_WhenArgumentIsNullOrWhiteSpace()
        {
            Assert.False(_garage.Remove(emptyString));
            Assert.False(_garage.Remove(whiteSpaceString));
            Assert.False(_garage.Remove(null!));
        }
        
        [Fact]
        public void Remove_ByRegistrationNumber_ShouldReturnFalse_WhenVehicleIsNotFound()
        {
            _garage.Add(_car);
            
            Assert.False(_garage.Remove(airplaneRegistrationNumber));
        }

        [Fact]
        public void Remove_ShouldDecreaseCount_By_1()
        {
            _garage.Add(_car);
            _garage.Remove();

            Assert.Equal(initialCount, _garage.Count);
        }
        
        [Fact]
        public void Remove_ByRegistrationNumber_ShouldDecreaseCount_By_1()
        {
            _garage.Add(_airplane);
            _garage.Remove(airplaneRegistrationNumber);

            Assert.Equal(initialCount, _garage.Count);
        }
        
        [Fact]
        public void Remove_ByRegistrationNumber_ShouldDecreaseVehicleID_By_1()
        {
            _garage.Add(_airplane);
            _garage.Add(_boat);
            _garage.Remove(airplaneRegistrationNumber);

            Assert.Equal(initialCount, _boat.ID);
        }

        [Fact]
        public void IsUniqueRegistrationNumber_ShouldThrowException_OnInvalidRegistrationNumber()
        {
            Assert.Throws<ArgumentException>(() => _garage.IsUniqueRegistrationNumber(emptyString));
            Assert.Throws<ArgumentException>(() => _garage.IsUniqueRegistrationNumber(whiteSpaceString));
            Assert.Throws<ArgumentException>(() => _garage.IsUniqueRegistrationNumber(null!));
        }

        [Fact]
        public void IsUniqueRegistrationNumber_ShouldReturnFalse_WhenLengthIsNot_6()
        {
            Assert.False(_garage.IsUniqueRegistrationNumber("ABC"));
            Assert.False(_garage.IsUniqueRegistrationNumber("AABBCC112233"));
        }

        [Fact]
        public void IsUniqueRegistrationNumber_ShouldReturnFalse_WhenFirstThreeCharactersAreNotLetters()
        {
            Assert.False(_garage.IsUniqueRegistrationNumber("0BC123"));
            Assert.False(_garage.IsUniqueRegistrationNumber("A0C123"));
            Assert.False(_garage.IsUniqueRegistrationNumber("AB0123"));
        }

        [Fact]
        public void IsUniqueRegistrationNumber_ShouldReturnFalse_WhenLastThreeCharactersAreNotIntegers()
        {
            Assert.False(_garage.IsUniqueRegistrationNumber("ABCZ23"));
            Assert.False(_garage.IsUniqueRegistrationNumber("ABC1Z3"));
            Assert.False(_garage.IsUniqueRegistrationNumber("ABC12Z"));
        }

        [Fact]
        public void IsUniqueRegistrationNumber_ShouldReturnFalse_WhenRegistrationNumberExists()
        {
            _garage.Add(_airplane);

            Assert.False(_garage.IsUniqueRegistrationNumber(airplaneRegistrationNumber));
        }

        [Fact]
        public void IsUniqueRegistrationNumber_ShouldReturnTrue_WhenRegistrationNumberDoesNotExist()
        {
            _garage.Add(_car);

            Assert.True(_garage.IsUniqueRegistrationNumber(airplaneRegistrationNumber));
        }
    }
}