
namespace YourMovies.Domain.Entities
{
    public class Country : Entity
    {
        public string ISOCode { get; set; }

        public string Name { get; set; }


        public void UpdateDetails(CountryDetails details)
        {
            ISOCode = details.ISOCode;
            Name = details.Name;
        }

        public readonly record struct CountryDetails
        {
            public string ISOCode { get; }

            public string Name { get; }

            public CountryDetails(string iSOCode, string name)
            {
                ISOCode = iSOCode;
                Name = name;
            }
        }
    }
}
