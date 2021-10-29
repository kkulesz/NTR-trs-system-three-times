using System;

namespace lab1.Models.Repositories
{
    public class UserNotFound : Exception
    {
        public UserNotFound()
        {
        }
        public UserNotFound(string msg) : base(msg)
        {
        }
        public UserNotFound(string msg, Exception inner) : base(msg, inner)
        {
        }
    }

    public class UserAlreadyExists : Exception
    {
        public UserAlreadyExists()
        {
        }
        public UserAlreadyExists(string msg) : base(msg)
        {
        }
        public UserAlreadyExists(string msg, Exception inner) : base(msg, inner)
        {
        }
    }
}