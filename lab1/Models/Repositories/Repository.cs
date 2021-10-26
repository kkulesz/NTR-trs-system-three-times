using System.Collections.Generic;
using LanguageExt;

using lab1.Models.DomainModel;


namespace lab1.Models.Repositories
{
    interface IRepository
    {
        Option<User> GetUser(string login);
        Option<User> CreateUser(User user);
        Option<Project> GetProject(string projectName);
        List<Project> GetAllProjects(int offset, int limit);
        Option<Project> CreateProject(Project project);
        Option<Project> UpdateProject(Project project);
        List<Activity> GetActivitiesForUser(string userLogin);
        Option<Activity> CreateActivity(Activity activity);
    }
}