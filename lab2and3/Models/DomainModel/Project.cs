using System.Collections.Generic;

namespace lab2and3.Models.DomainModel
{
    public record Project
    {
        public string ProjectId { get; init; }
        public virtual User User { get; init; }
        public int Budget { get; init; }
        public bool IsActive { get; init; }
        public List<string> Categories { get; init; }
        public virtual ICollection<User> Users { get; init; }

        public Project Inactive()
        {
            return new Project
            {
                ProjectId = this.ProjectId,
                User = this.User,
                Budget = this.Budget,
                IsActive = false,
                Categories = this.Categories,
                Users = this.Users
            };
        }
    }
}