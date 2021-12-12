using System;
using System.Collections.Generic;

namespace lab2and3.Models.DomainModel
{
    public record Project
    {
        public Guid ProjectId { get; init; }
        public string Name { get; init; }
        public string Owner { get; init; }
        public int Budget { get; init; }
        public bool IsActive { get; init; }
        // public List<string> Categories { get; init; }
        public virtual ICollection<User> Users { get; init; }

        public Project Inactive()
        {
            return new Project
            {
                ProjectId = Guid.NewGuid(),
                Name = this.Name,
                Owner = this.Owner,
                Budget = this.Budget,
                IsActive = false,
                // Categories = this.Categories,
                Users = this.Users
            };
        }
    }
}