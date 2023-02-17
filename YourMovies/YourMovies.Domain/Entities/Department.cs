
namespace YourMovies.Domain.Entities
{
    public class Department : Entity
    {
        public string Name { get; set; }

        public void UpdateDetails(DepartmentDetails details)
        {
            Name = details.Name;
        }

        public readonly record struct DepartmentDetails
        {
            public string Name { get; }

            public DepartmentDetails(string name)
            {
                Name = name;
            }
        }
    }
}
