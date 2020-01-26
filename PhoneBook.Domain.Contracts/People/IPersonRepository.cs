using PhoneBook.Domain.Contracts.Common;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Phones;

namespace PhoneBook.Domain.Contracts.People
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Person GetWithPhones(int id);
        bool AddPhoneToPerson(Phone phone, int personId);
        Person Update(Person person);
    }
}
