using System;

namespace lab1.Models
{
    public class Project
    {
        public string Name { get; }
        public string Owner { get; }

        public Project(string name, string owner)
        {
            Name = name;
            Owner = owner;
        }
    }
}