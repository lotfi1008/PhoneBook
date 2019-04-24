using PhoneBook.Domain.Contracts.People;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Services.ApplicatinServices.People
{
    public class PeopleService : IPeopleService
    {
        private readonly IPersonRepository personRepository;

        public PeopleService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public bool AddNewNumberForPerson(Domain.Core.Phones.Phone phone, int personId)
        {
            return personRepository.AddPhoneToPerson(phone, personId);
        }

        public Person AddNewPerson(Person person)
        {
            var result = personRepository.Add(person);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<Person> GetAllPerson()
        {
            return personRepository.GetAll().ToList();
        }

        public Person GetPersonWithChilds(int personId)
        {
            Person person = personRepository.GetWithPhones(personId);
            
            return person;
        }
    }
}
