using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;


namespace lab1.Models
{
    public class RepositoryJson : Repository
    {
        override public Optional<User> GetUser(string login)
        {
            //todo
            if(login == "error")
                return new Optional<User>();
            else
                return new Optional<User>(new User(login));
        }

        override public Optional<User> CreateUser(User user)
        {
            string json = JsonSerializer.Serialize(user);
            string filePath = _prepareFilePath(user.Login);

            File.WriteAllText(filePath, json);

            return new Optional<User>(user);
        }

        override public Optional<Project> GetProject(string name)
        {
            //todo
            return new Optional<Project>(new Project("", ""));
        }
        override public Optional<Project> CreateProject(Project project)
        {
            //todo
            return new Optional<Project>(new Project("", ""));
        }

        override public List<Activity> GetActivitiesForUser(string userLogin)
        {
            //todo
            return new List<Activity>();
        }

        override public Optional<Activity> CreateActivity(Activity activity)
        {
            //todo
            return new Optional<Activity>(new Activity("", "", "", 0, true, DateTime.Now));
        }


        private string _prepareFilePath(string fileName)
        {
            return Path.Combine(_storeDirectory, fileName + ".json");
        }
        private string _storeDirectory = Path.Combine(Environment.CurrentDirectory, "Models", "data");
    }
}