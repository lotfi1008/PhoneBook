using Microsoft.EntityFrameworkCore;
using PhoneBook.Infrastructures.DataLayer.People;
using PhoneBook.Infrastructures.DataLayer.Phones;
using PhoneBook.Infrastructures.DataLayer.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastructures.DataLayer.Common
{
    public class PhoneBookContext:DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> option) :base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PersonTagConfig());
            modelBuilder.ApplyConfiguration(new PhoneConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
