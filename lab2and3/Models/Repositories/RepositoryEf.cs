using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using lab2and3.Models.DomainModel;

namespace lab2and3.Models.Repositories
{
    public class RepositoryEf : IRepository
    {
        public User GetUser(string login)
        { return null; }

        public List<User> GetAllUsers()
        { return null; }
        public User CreateUser(string login)
        { return null; }

        public Project GetProject(string projectName)
        { return null; }

        public List<Project> GetAllProjects()
        { return null; }

        public List<Project> GetAllProjectsForOwner(string owner)
        { return null; }

        public Project CreateProject(Project project)
        { return null; }

        public Project UpdateProject(Project project)
        { return null; }

        public Activity GetActivity(string code)
        { return null; }

        public Activity CreateActivity(Activity activity)
        { return null; }

        public Activity UpdateActivity(Activity activity)
        { return null; }

        public List<Activity> GetAllActivities()
        { return null; }

        public List<Activity> GetActivitiesForUserForMonth(string executor, int year, int month)
        { return null; }

        public void DeleteActivity(string code, string executor)
        { }

        public UsersMonth GetUsersMonth(string executor, int year, int month)
        { return null; }

        public UsersMonth AcceptMonthForUser(UsersMonth month)
        { return null; }
    }
}