
namespace YourMovies.Domain.Entities
{
    public class Country : Entity
    {
        string ISOCode { get; set; }

        string Name { get; set; }


        public Country(Guid id, string iSOCode, string name) : base(id)
        {
            ISOCode = iSOCode;
            Name = name;
        }
    }
}
