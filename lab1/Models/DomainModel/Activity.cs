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
        public DateTime Date { get; }
        public List<string> Subactivities { get; }
        public string Description {get;}

        public Activity(string code, string projectName, string executorName, int budget, DateTime date, List<string> subactivities, string description)
        {
            Code = code;
            ProjectName = projectName;
            ExecutorName = executorName;
            Budget = budget;
            Date = date;
            Subactivities = subactivities ?? new List<string>();
            Description = description;
        }
    }
}