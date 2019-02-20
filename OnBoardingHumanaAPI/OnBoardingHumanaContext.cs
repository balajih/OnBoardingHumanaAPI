using OnBoardingHumanaAPI.Models;
using System.Data.Entity;

namespace OnBoardingHumanaAPI
{
    public class OnBoardingHumanaContext : DbContext
    {
        public OnBoardingHumanaContext() : base("OnBoardingHumanaAPIConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder ModelBuilder)
        {
            //Configure Domain classes using fluent API here.
            base.OnModelCreating(ModelBuilder);
        }
    }
}