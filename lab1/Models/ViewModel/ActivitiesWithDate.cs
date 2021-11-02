using System.Collections.Generic;
using System;

using lab1.Models.DomainModel;

namespace lab1.Models.ViewModel
{
    public class ActivitiesWithDate
    {
        public List<Activity> Activities { get; }
        public DateTime Date {get;}

        public ActivitiesWithDate(List<Activity> activities, DateTime date)
        {
            Activities = activities;
            Date = date;
        }
    }
}