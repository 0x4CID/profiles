using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace ProfilesAPI.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string? Name { get; set; }


    }

    public class ProfileDb : DbContext
    {
        public ProfileDb(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
    }
}