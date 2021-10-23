using System;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;


namespace lab1.Models
{
    public abstract class Repository
    {
        public abstract Optional<User> GetUser(string login);
        public abstract Optional<User> CreateUser(User user);
        public abstract Optional<Project> GetProject(string name);
        public abstract Optional<Project> CreateProject(Project project);
        public abstract List<Activity> GetActivitiesForUser(string userLogin);
        public abstract Optional<Activity> CreateActivity(Activity activity);
    }
}