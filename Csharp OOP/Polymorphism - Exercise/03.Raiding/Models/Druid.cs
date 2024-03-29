﻿
namespace Raiding.Models
{
    using Interfaces;
    using System;
    using System.Linq;

    public class Druid : BaseHero
    {
        private const int DRUID_POWER = 80;
        public Druid(string name) : base(name, DRUID_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
