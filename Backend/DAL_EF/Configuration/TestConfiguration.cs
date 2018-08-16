using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using DAL_Common.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF.Configuration
{
    public class TestConfiguration : EntityTypeConfiguration<Test>
    {
        public void GadgetConfiguration()
        {
            this.Property(test => test.Title).IsRequired().HasMaxLength(50);
            this.Property(test => test.Descr).IsRequired().HasMaxLength(1000);
            this.Property(test => test.CreationDate).IsRequired();
            this.Property(test => test.DurationMin).IsRequired();
            this.Property(test => test.CategoryId).IsRequired();
        }
    }
}
