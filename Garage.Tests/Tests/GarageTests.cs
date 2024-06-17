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
            _airplane = new Airplane(registrationNumber: "ABC123", color: "Red", numberOfWheels: 4);
            _boat = new Boat(registrationNumber: "ABC123", color: "Red", numberOfWheels: 4);
            _bus = new Bus(registrationNumber: "ABC123", color: "Red", numberOfWheels: 4);
            _car = new Car(registrationNumber: "ABC123", color: "Red", numberOfWheels: 4);
            _motorcycle = new Motorcycle(registrationNumber: "ABC123", color: "Red", numberOfWheels: 4);
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
            Assert.Throws<ArgumentException>(() => new Garage<Vehicle>(null, validCapacity));
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
        public void Remove_ShouldReturnFalse_WhenIsEmpty()
        {
            Assert.False(_garage.Remove());
        }

        [Fact]
        public void Remove_ShouldReturnTrue_WhenNotIsEmpty()
        {
            _garage.Add(_car);

            Assert.True(_garage.Remove());
        }

        [Fact]
        public void Remove_ShouldDecreaseCount_By_1()
        {
            _garage.Add(_car);
            _garage.Remove();

            Assert.Equal(initialCount, _garage.Count);
        }
    }
}