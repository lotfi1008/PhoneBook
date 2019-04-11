using PhoneBook.Domain.Contracts.People;
using PhoneBook.Domain.Core.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Services.ApplicatinServices.People
{
    public class AddNewPerson : IAddNewPerson
    {
        private readonly IPersonRepository personRepository;

        public AddNewPerson(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        public Person Execute(Person person)
        {
            // Add Business if needed
            return personRepository.Add(person);
        }
    }
}
