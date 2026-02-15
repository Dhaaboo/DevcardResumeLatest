using DevcardResume.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DevcardResume.Data
{
    public class APPDBC : IdentityDbContext<DevResumeUser>
    {
        public APPDBC(DbContextOptions<APPDBC> options) : base(options)
        {
        }

        [AllowNull]
        public DbSet<People> _Peoples { get; set; }
        protected override void OnModelCreating(ModelBuilder _builder)
        {
            base.OnModelCreating(_builder);

            // Seed Person Table
            _builder.Entity<People>().HasData(new People
            {
                PID = 1,
                FirstName = "Abdinoor",
                LastName = "Suleman",
                City = "Burao"

            });

            _builder.Entity<People>().HasData(new People
            {
                PID = 2,
                FirstName = "Abdirahman",
                LastName = "Suleman",
                City = "Boorama"

            });

            _builder.Entity<People>().HasData(new People
            {
                PID = 3,
                FirstName = "Abdiqani",
                LastName = "Suleman",
                City = "BerBera"

            });

        }

    }
}
