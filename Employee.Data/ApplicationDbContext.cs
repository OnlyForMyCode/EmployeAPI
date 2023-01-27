using Employee.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Employee.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set;}
        public DbSet<Employe> Employees { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employe>().HasData(
                new Employe()
                {
                    Id = 1,
                    FirstName = "Mika",
                    Lastname = "Koeck",
                    Created = DateTime.Now.Date,
               
                },
                new Employe()
                {
                    Id = 2,
                    FirstName = "Gernot",
                    Lastname = "Stimpfl",
                    Created = DateTime.Now.Date
                    
                },
                new Employe()
                {
                    Id = 3,
                    FirstName = "Heinz",
                    Lastname = "Koeck"
                });

        }
    }
}
