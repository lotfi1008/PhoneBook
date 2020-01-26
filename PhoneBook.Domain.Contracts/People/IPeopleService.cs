using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domain.Contracts.People
{
    public interface IPeopleService
    {
        List<Person> GetAllPerson();
        Person AddNewPerson(Person person);
        Person UpdatePerson(Person person);
        Person GetPersonWithChilds(int personId);
        bool AddNewNumberForPerson(Phone phone, int personId);
        bool Delete(int id);
    }
}
