using System.Collections.Generic;
using LanguageExt;

using lab1.Models.DomainModel;


namespace lab1.Models.Repositories
{
    interface IRepository
    {
        Option<User> GetUser(string login);
        Option<User> CreateUser(User user);
        Option<Project> GetProject(string name);
        Option<Project> CreateProject(Project project);
        List<Activity> GetActivitiesForUser(string userLogin);
        Option<Activity> CreateActivity(Activity activity);
    }
}