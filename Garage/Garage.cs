﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Vehicles;

namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] _vehicles;

        public string Name { get; }
        public int Capacity { get; }
        public int Count => _vehicles.Where(v => v != null).Count();
        public bool IsFull => Count >= Capacity;
        public bool IsEmpty => Count <= 0;

        public Garage(string name, int capacity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            if (capacity <= 0)
                throw new ArgumentException($"'{nameof(capacity)}' cannot be 0 or negative.", nameof(capacity));

            Name = name;
            Capacity = capacity;
            _vehicles = new T[capacity];
        }

        public void Print(Action<T> action)
        {
            if (IsEmpty) 
                ConsoleUI.WriteLine("The garage is empty.");
            else
                foreach (var vehicle in _vehicles)
                {
                    action?.Invoke(vehicle);
                }
        }

        public bool Add(T vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));

            if (IsFull) return false;

            _vehicles[Count] = vehicle; 
            
            return true;
        }

        public bool Remove(T vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));

            if (IsEmpty) return false;

            //Todo: Remove vehicle from array

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in _vehicles)
            {
                yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
