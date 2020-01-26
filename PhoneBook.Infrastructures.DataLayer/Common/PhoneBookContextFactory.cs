using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PhoneBook.Infrastructures.DataLayer.Common
{
    public class PhoneBookContextFactory : IDesignTimeDbContextFactory<PhoneBookContext>
    {
  
        public PhoneBookContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PhoneBookContext>();
            builder.UseSqlServer("Server=.\\MSSQL2017;Initial catalog=PhoneBookDB;Integrated security=true;");

            return new PhoneBookContext(builder.Options);
        }    
    }
}
