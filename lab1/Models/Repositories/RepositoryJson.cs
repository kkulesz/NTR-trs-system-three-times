using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using LanguageExt;

using lab1.Models.DomainModel;

namespace lab1.Models.Repositories
{
    /**
    TODO:
    1. Think about C#'s Option methods, if its not that convinient to use then simply define own exceptions and handle them
    2. enclode GetAll* methods' results into pagination, Page class needed
    3. CRU for activities
    */
    public class RepositoryJson : IRepository
    {
        public RepositoryJson()
        {
            _initializeRepo();
        }

        public Option<User> GetUser(string login)
        {
            List<User> users = _getAllUsers();
            User user = users.Find(u => _userLoginPredicate(u, login));

            return user == null ? Option<User>.None : Option<User>.Some(user);
        }

        public Option<User> CreateUser(User user)
        {
            List<User> users = _getAllUsers();
            if (users.Exists(u => _userLoginPredicate(u, user.Login)))
            {
                return Option<User>.None;
            }
            users.Add(user);
            string usersJson = _serializeJson(users);
            File.WriteAllText(_usersDataFile, usersJson);

            return Option<User>.Some(user);
        }

        public Option<Project> GetProject(string projectName)
        {
            List<Project> projects = _getAllProjects();
            Project project = projects.Find(p => _projectNamePredicate(p, projectName));

            return project == null ? Option<Project>.None : Option<Project>.Some(project);
        }

        public List<Project> GetProjectsPage(int offset, int limit)
        {
            List<Project> projects = _getAllProjects();

            int length = projects.Length();
            int realOffset = Math.Min(offset, length);
            int realLimit = Math.Min(length - realOffset, limit);

            return projects.GetRange(realOffset, realLimit);
        }
        public Option<Project> CreateProject(Project project)
        {
            List<Project> projects = _getAllProjects();
            if (projects.Exists(p => _projectNamePredicate(p, project.Name)))
            {
                return Option<Project>.None;
            }


            Option<User> ownerOpt = GetUser(project.Owner);
            if (ownerOpt.IsNone)
            {
                return Option<Project>.None;
            }

            projects.Add(project);
            string projectsJson = _serializeJson(projects);
            File.WriteAllText(_projectsDataFile, projectsJson);

            return Option<Project>.Some(project);
        }

        public Option<Project> UpdateProject(Project project)
        {
            List<Project> projects = _getAllProjects();
            if (!projects.Exists(p => _projectNamePredicate(p, project.Name)))
            {
                return Option<Project>.None;
            }

            Option<User> ownerOpt = GetUser(project.Owner);
            if (ownerOpt.IsNone)
            {
                return Option<Project>.None;
            }

            projects.RemoveAll(p => _projectNamePredicate(p, project.Name));
            projects.Add(project);
            string projectsJson = _serializeJson(projects);
            File.WriteAllText(_projectsDataFile, projectsJson);

            return Option<Project>.Some(project);
        }

        public List<Activity> GetActivitiesForUser(string userLogin)
        {
            //todo
            return new List<Activity>();
        }

        public Option<Activity> CreateActivity(Activity activity)
        {
            //todo
            return Option<Activity>.Some(new Activity("", "", "", 0, true, DateTime.Now));
        }

        private List<User> _getAllUsers()
        {
            string usersJsonString = File.ReadAllText(_usersDataFile);

            return JsonSerializer.Deserialize<List<User>>(usersJsonString);
        }

        private List<Project> _getAllProjects()
        {
            string projectsJsonString = File.ReadAllText(_projectsDataFile);

            return JsonSerializer.Deserialize<List<Project>>(projectsJsonString);
        }

        private static void _initializeRepo()
        {
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }
            if (!File.Exists(_usersDataFile))
            {
                List<User> emptyUsersList = new List<User>();
                string emptyUsersListJson = _serializeJson(emptyUsersList);
                File.WriteAllText(_usersDataFile, emptyUsersListJson);
            }
            if (!File.Exists(_projectsDataFile))
            {
                List<Project> emptyProjectsList = new List<Project>();
                string emptyProjectsListJson = _serializeJson(emptyProjectsList);
                File.WriteAllText(_projectsDataFile, emptyProjectsListJson);
            }
        }

        private bool _userLoginPredicate(User u, string login)
        {
            return u.Login == login;
        }

        private bool _projectNamePredicate(Project p, string projectName)
        {
            return p.Name == projectName;
        }

        private static string _serializeJson<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, _jsonOptions);
        }
        private static JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { WriteIndented = true };


        private static string _dataDirectory = Path.Combine(Environment.CurrentDirectory, "Models", "data");
        private static string _usersDataFile = Path.Combine(_dataDirectory, "users.json");
        private static string _projectsDataFile = Path.Combine(_dataDirectory, "projects.json");
    }
}