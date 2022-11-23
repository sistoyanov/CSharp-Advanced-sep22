﻿namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        private const double POWERSUPPLY_UNIT_OVERALL_PERFORMANCE_MULTIPLIER = 1.05;

        public PowerSupply(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * POWERSUPPLY_UNIT_OVERALL_PERFORMANCE_MULTIPLIER;
    }
}