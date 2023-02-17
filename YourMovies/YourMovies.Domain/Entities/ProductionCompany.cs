
namespace YourMovies.Domain.Entities
{
    public class ProductionCompany : Entity
    {
        public string Name { get; set; }

        public void UpdateDetails(ProductionCompanyDetails details)
        {
            Name = details.Name;
        }

        public readonly record struct ProductionCompanyDetails
        {
            public string Name { get; }

            public ProductionCompanyDetails(string name)
            {
                Name = name;
            }
        }
    }
}
