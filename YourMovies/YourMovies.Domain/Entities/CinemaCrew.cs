
namespace YourMovies.Domain.Entities
{
    public class CinemaCrew : Entity
    {
        public Person Person { get; set; }

        public Department Department { get; set; }

        public string Job { get; set; }

        public void UpdateDetails(CinemaCrewDetails details)
        {
            Person = details.Person;
            Department = details.Department;
            Job = details.Job;
        }

        public readonly record struct CinemaCrewDetails
        {
            public Person Person { get; }
            public Department Department { get; }
            public string Job { get; }

            public CinemaCrewDetails(Person person, Department department, string job)
            {
                Person = person;
                Department = department;
                Job = job;
            }
        }
    }
}
