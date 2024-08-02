using System;

namespace SpaceVc
{
    public class Spaceship
    {
        public string Name { get; set; } // Name of the spaceship
        public string Model { get; set; } // Model of the spaceship
        public int CrewCapacity { get; set; } // Crew capacity of the spaceship
        public double MaxSpeed { get; set; } // Maximum speed of the spaceship
        public Status Status { get; set; } // Current status of the spaceship
        public DateTime LaunchDate { get; set; } // Launch date of the spaceship
        public MissionType MissionType { get; set; } // Mission type of the spaceship
    }

    public enum Status
    {
        Active,      // Spaceship is active
        Inactive,    // Spaceship is inactive
        Maintenance  // Spaceship is under maintenance
    }

    public enum MissionType
    {
        Research,     // Spaceship is used for research
        Transport,    // Spaceship is used for transport
        Military,     // Spaceship is used for military purposes
        Communications // Spaceship is used for communications
    }
}
