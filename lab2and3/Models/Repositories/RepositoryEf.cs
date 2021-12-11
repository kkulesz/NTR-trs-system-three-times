using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using lab2and3.Models.DomainModel;

namespace lab2and3.Models.Repositories
{
    public class RepositoryEf : IRepository
    {
        public User GetUser(string login)
        { return new User(""); }

        public List<User> GetAllUsers()
        { return new List<User>(); }
        public User CreateUser(string login)
        { return new User(""); }

        public Project GetProject(string projectName)
        { return new Project("", "", 0, true, null); }

        public List<Project> GetAllProjects()
        { return new List<Project>(); }

        public List<Project> GetAllProjectsForOwner(string owner)
        { return new List<Project>(); }

        public Project CreateProject(Project project)
        { return new Project("", "", 0, true, null); }

        public Project UpdateProject(Project project)
        { return new Project("", "", 0, true, null); }

        public Activity GetActivity(string code)
        { return new Activity("", "", "", 0, null, DateTime.Now, null, "", true); }

        public Activity CreateActivity(Activity activity)
        { return new Activity("", "", "", 0, null, DateTime.Now, null, "", true); }

        public Activity UpdateActivity(Activity activity)
        { return new Activity("", "", "", 0, null, DateTime.Now, null, "", true); }

        public List<Activity> GetAllActivities()
        { return new List<Activity>(); }

        public List<Activity> GetActivitiesForUserForMonth(string executor, int year, int month)
        { return new List<Activity>(); }

        public void DeleteActivity(string code, string executor)
        { }

        public UsersMonth GetUsersMonth(string executor, int year, int month)
        { return new UsersMonth(0, 0, null, false); }

        public UsersMonth AcceptMonthForUser(UsersMonth month)
        { return new UsersMonth(0, 0, null, false); }
    }
}