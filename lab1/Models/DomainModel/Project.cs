namespace lab1.Models.DomainModel
{
    public class Project
    {
        public string Name { get; }
        public string Owner { get; }

        public bool IsActive { get; }

        public Project(string name, string owner, bool isActive = true)
        {
            Name = name;
            Owner = owner;
            IsActive = isActive;
        }
    }
}