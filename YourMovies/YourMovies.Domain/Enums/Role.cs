
using System.ComponentModel.DataAnnotations;

namespace YourMovies.Domain.Enums
{
    public enum Role
    {
        [Display(Name = "User")]
        User = 0,
        [Display(Name = "Admin")]
        Admin = 1
    }
}
