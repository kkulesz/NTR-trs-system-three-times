using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using LanguageExt;

using lab1.Models.DomainModel;

namespace lab1.Models.Repositories
{
    public class RepositoryJson : Repository
    {
        public RepositoryJson()
        {
            _initializeRepo();
        }

        override public Option<User> GetUser(string login)
        {
            List<User> users = _getAllUsers();
            User user = users.Find(u => u.Login == login);
            if (user == null)// c# does not have pretty Option initializer i think :(
            {
                return Option<User>.None;
            }
            else
            {
                return Option<User>.Some(user);
            }
        }

        override public Option<User> CreateUser(User user)
        {
            List<User> users = _getAllUsers();
            if (users.Exists(u => u.Login == user.Login))
            {
                return Option<User>.None;
            }
            else
            {
                users.Add(user);
                string usersJson = JsonSerializer.Serialize(users);
                File.WriteAllText(_usersDataFile, usersJson);

                return Option<User>.Some(user);
            }
        }

        override public Option<Project> GetProject(string name)
        {
            //todo
            return Option<Project>.Some(new Project("", ""));
        }
        override public Option<Project> CreateProject(Project project)
        {
            //todo
            return Option<Project>.Some(new Project("", ""));
        }

        override public List<Activity> GetActivitiesForUser(string userLogin)
        {
            //todo
            return new List<Activity>();
        }

        override public Option<Activity> CreateActivity(Activity activity)
        {
            //todo
            return Option<Activity>.Some(new Activity("", "", "", 0, true, DateTime.Now));
        }

        private List<User> _getAllUsers()
        {

            string usersJsonString = File.ReadAllText(_usersDataFile);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersJsonString);

            return users;
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
                string emptyUsersListJson = JsonSerializer.Serialize(emptyUsersList);
                File.WriteAllText(_usersDataFile, emptyUsersListJson);
            }
        }


        private static string _dataDirectory = Path.Combine(Environment.CurrentDirectory, "Models", "data");
        private static string _usersDataFile = Path.Combine(_dataDirectory, "users.json");
    }
}