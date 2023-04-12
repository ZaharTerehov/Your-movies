
namespace YourMovies.Application.Contracts
{
    public sealed class BaseResponse<T> where T : class
    {
        public string? Description { get; set; }

        //public StatusCode? StatusCode { get; set; }

        public T? Data { get; set; }
    }
}
