using LanguageExt;
using System.Collections.Generic;


namespace lab1.Models
{
    public abstract class Repository
    {
        public abstract Option<User> GetUser(string login);
        public abstract Option<User> CreateUser(User user);
        public abstract Option<Project> GetProject(string name);
        public abstract Option<Project> CreateProject(Project project);
        public abstract List<Activity> GetActivitiesForUser(string userLogin);
        public abstract Option<Activity> CreateActivity(Activity activity);
    }
}