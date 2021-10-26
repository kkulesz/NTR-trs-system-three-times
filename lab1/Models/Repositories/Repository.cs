using System.Collections.Generic;
using LanguageExt;

using lab1.Models.DomainModel;


namespace lab1.Models.Repositories
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