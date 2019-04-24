using System;
using System.Collections.Generic;
using System.Text;
using PhoneBook.Domain.Core.Phones;

namespace PhoneBook.Domain.Contracts.Phones
{
    public interface IPhoneService
    {
        bool IsPhoneNumberIsDuplicate(string number);
    }
}
