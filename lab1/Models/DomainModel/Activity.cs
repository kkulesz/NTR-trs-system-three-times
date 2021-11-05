using System;
using System.Collections.Generic;

namespace lab1.Models.DomainModel
{
    public class Activity
    {
        public string Code { get; }
        public string ProjectName { get; }
        public string ExecutorName { get; }
        public int Budget { get; }
        public Nullable<int> AcceptedBudget { get; }
        public DateTime Date { get; }
        public List<string> Subactivities { get; }
        public string Description { get; }

        public Activity(string code, string projectName, string executorName, int budget, Nullable<int> acceptedBudget,  DateTime date, List<string> subactivities, string description)
        {
            Code = code;
            ProjectName = projectName;
            ExecutorName = executorName;
            Budget = budget;
            AcceptedBudget = acceptedBudget;
            Date = date;
            Subactivities = subactivities ?? new List<string>();
            Description = description;
        }

        private Activity(Activity acc, int acceptedBudget)
        {
            Code = acc.Code;
            ProjectName = acc.ProjectName;
            ExecutorName = acc.ExecutorName;
            Budget = acc.Budget;
            AcceptedBudget = acceptedBudget;
            Date = acc.Date;
            Subactivities = acc.Subactivities;
            Description = acc.Description;
        }

        public Activity SetAcceptedBudget(int acceptedBudget)
        {
            return new Activity(this, acceptedBudget);
        }
    }
}