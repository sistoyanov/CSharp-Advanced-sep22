﻿namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        private const double SOLID_STATE_DRIVE_UNIT_OVERALL_PERFORMANCE_MULTIPLIER = 1.20;

        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * SOLID_STATE_DRIVE_UNIT_OVERALL_PERFORMANCE_MULTIPLIER;
    }
}
