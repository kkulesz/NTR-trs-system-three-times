namespace lab2and3.Models.DomainModel
{
    public class User
    {
        public string Login { get; }

        public User(string login)
        {
            Login = login;
        }
    }
}