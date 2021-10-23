using System;
using Microsoft.CodeAnalysis.Options;
using System.Collections.Generic;


namespace lab1.Models
{
    public abstract class Repository
    {
        public abstract Option<User> GetUser();
        public abstract List<Activity> GetActivitiesForUser();
    }
}