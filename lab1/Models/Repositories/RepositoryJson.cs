using System;
using Microsoft.CodeAnalysis.Options;
using System.Collections.Generic;

namespace lab1.Models
{
    public class RepositoryJson : Repository
    {
        override public Option<User> GetUser()
        {
            //todo
            return new Option<User>("", "", new User());
        }

        override public List<Activity> GetActivitiesForUser()
        {
            //todo
            return new List<Activity>();
        }
    }
}