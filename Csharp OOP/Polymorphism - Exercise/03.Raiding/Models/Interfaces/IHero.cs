﻿namespace Raiding.Models.Interfaces
{
    public interface IHero
    {
        string Name { get; }
        int Power { get; }

        public string CastAbility();
    }
}
