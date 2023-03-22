using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KatsCoffeMachine.Models;

namespace KatsCoffeMachine.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<CoffeeType> CoffeeType { get; set; }
    }
}