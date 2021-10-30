using System.Collections.Generic;
using LanguageExt;

using lab1.Models.DomainModel;


namespace lab1.Models.Repositories
{
    interface IRepository
    {
        Option<User> GetUser(string login);
        List<User> GetAllUsers();
        Option<User> CreateUser(string login);
        Option<Project> GetProject(string projectName);
        List<Project> GetAllProjects();
        Option<Project> CreateProject(Project project);
        Option<Project> UpdateProject(Project project);
        // List<Activity> GetActivitiesForUser(string userLogin);
        // Option<Activity> CreateActivity(Activity activity);
    }
}