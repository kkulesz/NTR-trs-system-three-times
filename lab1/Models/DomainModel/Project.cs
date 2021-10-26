namespace lab1.Models.DomainModel
{
    public class Project
    {
        public string Name { get; }
        public string Owner { get; }

        public Project(string name, string owner)
        {
            Name = name;
            Owner = owner;
        }
    }
}