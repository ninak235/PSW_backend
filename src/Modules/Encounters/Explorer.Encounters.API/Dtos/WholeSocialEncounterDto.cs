﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos
{
    public class WholeSocialEncounterDto
    {
        public long EncounterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int XpPoints { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long Id { get; set; }

        public int TouristsRequiredForCompletion { get; set; }
        public double DistanceTreshold { get; set; }
        public List<long> TouristIDs { get; set; }
    }
}