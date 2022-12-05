﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get { return this.raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return this.numberOfLaps; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value; 
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot) => this.pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"The {this.RaceName} race has:")
                  .AppendLine($"Participants: {this.Pilots.Count}")
                  .AppendLine($"Number of laps: {this.NumberOfLaps}")
                  .AppendLine($"{(this.TookPlace ? "Yes" : "No")}");

            return output.ToString().TrimEnd();
        }
    }
}
