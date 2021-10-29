using System.Collections.Generic;

namespace lab1.Models.DomainModel
{
    public class UsersMonth
    {
        public int Year { get; }
        public int Month { get; }
        public string UsersLogin { get; }
        public bool Frozen { get; }
        public List<Activity> Activitoes { get; }

        public UsersMonth(int year, int month, string usersLogin, bool frozen, List<Activity> activities)
        {
            Year = year;
            Month = month;
            UsersLogin = usersLogin;
            Frozen = frozen;
            Activitoes = activities ?? new List<Activity>();
        }
    }
}