using System.Data.Entity;
using DAL_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF.EF
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new TestDbInitializer());
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<TestStat> TestStatistics { get; set; }
        public DbSet<Answer> Answers { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // использование Fluent API
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<Test>().
        //}

    }
}
