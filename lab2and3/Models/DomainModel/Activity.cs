using System;
using System.Collections.Generic;

namespace lab2and3.Models.DomainModel
{
    public record Activity
    {
        public string ActivityId { get; init; }
        public virtual Project Project { get; init; }
        public virtual User User { get; init; }
        public int Budget { get; init; }
        public Nullable<int> AcceptedBudget { get; init; }
        public DateTime Date { get; init; }
        public List<string> Subactivities { get; init; }
        public string Description { get; init; }
        public bool IsActive { get; init; }

        public Activity() { }

        private Activity(Activity acc, Nullable<int> acceptedBudget, bool isActive)
        {
            ActivityId = acc.ActivityId;
            Project = acc.Project;
            User = acc.User;
            Budget = acc.Budget;
            AcceptedBudget = acceptedBudget;
            Date = acc.Date;
            Subactivities = acc.Subactivities;
            Description = acc.Description;
            IsActive = isActive;
        }

        public Activity AcceptBudget(int acceptedBudget)
        {
            return new Activity(this, acceptedBudget, this.IsActive);
        }

        public Activity Inactive()
        {
            return new Activity(this, this.AcceptedBudget, false);
        }
    }
}