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
        Project GetProject(string projectName);
        List<Project> GetAllProjects();
        Project CreateProject(Project project);
        Project UpdateProject(Project project);
        // Activity GetActivity()
        // List<Activity> GetActivitiesForUser(string userLogin);
        Activity CreateActivity(Activity activity);
        List<Activity> GetActivitiesForUserForMonth(string executor, int year, int month);
    }
}