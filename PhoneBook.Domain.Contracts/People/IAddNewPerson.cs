using PhoneBook.Domain.Contracts.Common;
using PhoneBook.Domain.Core.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domain.Contracts.People
{
    public interface IAddNewPerson: IApplicationService
    {
        Person Execute(Person person);
    }
}
