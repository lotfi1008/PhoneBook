using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Contracts.People;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Infrastructures.Common;
using PhoneBook.Infrastructures.DataLayer.Common;
using System.Linq;

namespace PhoneBook.Infrastructures.DataLayer.People
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }

        public bool AddPhoneToPerson(Phone phone, int personId)
        {
            var person = dbContext.People.Include(c => c.Phones).First(c => c.Id == personId);
            person.Phones.Add(phone);
            dbContext.SaveChanges();
            return true;
        }

        public Person GetWithPhones(int id)
        {
            return dbContext.People.Where(c => c.Id == id).Include(c => c.Phones).FirstOrDefault();
        }

        public Person Update(Person person)
        {
            var p = dbContext.People.Find(person.Id);
            if (p == null)
            {
                return null;
            }
            p.Address = person.Address;
            p.Email = person.Email;
            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            if (!string.IsNullOrWhiteSpace(person.Image))
            {
                p.Image = person.Image;
            }
            dbContext.SaveChanges();
            return p;
        }
    }
}
