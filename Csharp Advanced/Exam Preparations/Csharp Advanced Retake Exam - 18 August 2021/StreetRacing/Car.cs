﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"Make: {Make}{Environment.NewLine}" +
                   $"Model: {Model}{Environment.NewLine}" +
                   $"License Plate: {LicensePlate}{Environment.NewLine}" +
                   $"Horse Power: {HorsePower}{Environment.NewLine}" +
                   $"Weight: {Weight}";

        }
    }
}
