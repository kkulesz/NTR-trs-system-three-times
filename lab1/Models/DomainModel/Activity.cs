using System;
using System.Collections.Generic;

namespace lab1.Models.DomainModel
{
    public class Activity
    {
        public string Code { get; }
        public string ProjectName { get; }
        public string ExecutorName { get; }
        public int Budget { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime Date { get; set; }
        public List<string> Subactivities { get; set; } //todo: maybe remove setter and add 'addSubactivity()' 


        public Activity(string code, string projectName, string executorName, int budget, bool isActive, DateTime date, List<string> subactivities = null)
        {
            Code = code;
            ProjectName = projectName;
            ExecutorName = executorName;
            Budget = budget;
            IsActive = isActive;
            Date = date;
            Subactivities = subactivities ?? new List<string>();
        }
    }
}