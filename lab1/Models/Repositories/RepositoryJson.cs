using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using LanguageExt;

namespace lab1.Models
{
    public class RepositoryJson : Repository
    {
        override public Option<User> GetUser(string login)
        {
            //todo
            if (login == "error")
                return Option<User>.None;
            else
                return Option<User>.Some(new User(login));
        }

        override public Option<User> CreateUser(User user)
        {
            if (user.Login == "error")
            {
                return Option<User>.None;
            }
            string json = JsonSerializer.Serialize(user);
            string filePath = _prepareFilePath(user.Login);

            File.WriteAllText(filePath, json);

            return Option<User>.Some(user);
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


        private string _prepareFilePath(string fileName)
        {
            return Path.Combine(_storeDirectory, fileName + ".json");
        }
        private string _storeDirectory = Path.Combine(Environment.CurrentDirectory, "Models", "data");
    }
}