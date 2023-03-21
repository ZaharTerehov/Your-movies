
namespace YourMovies.Domain.Entities
{
    public class CinemaCrew : Entity
    {
        public Person? Person { get; set; }

        public Guid PersonId { get; set; }

        public Cinema? Cinema { get; set; }

        public Guid CinemaId { get; set; }

        public Department? Department { get; set; }

        public Guid DepartmentId { get; set; }

        public string Job { get; set; }

        public void UpdateDetails(CinemaCrewDetails details)
        {
            Person = details.Person;
            PersonId = details.PersonId;
            Cinema = details.Cinema;
            CinemaId = details.CinemaId;
            Department = details.Department;
            DepartmentId = details.DepartmentId;
            Job = details.Job;
        }

        public readonly record struct CinemaCrewDetails
        {
            public Person Person { get; }

            public Guid PersonId { get; }

            public Cinema? Cinema { get; }

            public Guid CinemaId { get; }

            public Department Department { get; }

            public Guid DepartmentId { get; }

            public string Job { get; }

            public CinemaCrewDetails(Person person, Guid personId, Cinema cinema, Guid cinemaId, Department department, Guid departmentId, string job)
            {
                Person = person;
                PersonId = personId;
                Cinema = cinema;
                CinemaId = cinemaId;
                Department = department;
                DepartmentId = departmentId;
                Job = job;
            }
        }
    }
}
