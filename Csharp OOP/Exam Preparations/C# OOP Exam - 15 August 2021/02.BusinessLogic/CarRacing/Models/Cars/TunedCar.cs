﻿using System;
using System.Text.RegularExpressions;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double TunedCarFuelAvailable = 65;
        private const double TunedCarFuelConsumtpionPerRace = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, TunedCarFuelAvailable, TunedCarFuelConsumtpionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower -= (int)Math.Round(this.HorsePower * 0.03);
        }
    }
}
