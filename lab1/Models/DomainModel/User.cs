namespace lab1.Models
{
    public class User
    {
        //TODO: password and id maybe?
        public string Login { get; }

        public User(string login)
        {
            Login = login;
        }
    }
}