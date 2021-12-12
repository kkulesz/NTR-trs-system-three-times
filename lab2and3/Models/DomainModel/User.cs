namespace lab2and3.Models.DomainModel
{
    public record User
    {
        public string UserId { get; init;}

        public User(string login)
        {
            UserId = login;
        }
    }
}