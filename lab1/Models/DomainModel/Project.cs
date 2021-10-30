using System.Collections.Generic;

namespace lab1.Models.DomainModel
{
    public class Project
    {
        public string Name { get; }
        public string Owner { get; }
        public bool IsActive { get; }
        // public List<string> Categories { get; }
        // public List<string> Participants { get; }

        public Project(string name, string owner, bool isActive)
        {
            Name = name;
            Owner = owner;
            IsActive = isActive;
            // Categories = categories ?? new List<string>();
            // Participants = participants ?? new List<string>();
        }
    }
}