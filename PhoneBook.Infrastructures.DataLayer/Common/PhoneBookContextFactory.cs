﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PhoneBook.Infrastructures.DataLayer.Common
{
    public class PhoneBookContextFactory : IDesignTimeDbContextFactory<PhoneBookContext>
    {
  
        public PhoneBookContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PhoneBookContext>();
            builder.UseSqlServer("Server=DESKTOP-DPJGB00\\MSSQL2017;Database=PhoneBookDb;Integrated Security=True;MultipleActiveResultSets=true");

            return new PhoneBookContext(builder.Options);
        }    
    }
}
