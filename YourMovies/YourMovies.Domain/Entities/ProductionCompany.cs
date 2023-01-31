
namespace YourMovies.Domain.Entities
{
    public class ProductionCompany : Entity
    {
        public string Name { get; set; }

        public ProductionCompany(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
