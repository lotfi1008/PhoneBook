using System;
using System.Collections.Generic;
using System.Linq;
using PhoneBook.Domain.Contracts.Common;
using PhoneBook.Domain.Core.Phones;

namespace PhoneBook.Domain.Contracts.Phones
{
    public interface IPhoneRepository : IBaseRepository<Phone>
    {
        ICollection<Phone> Where(Func<Phone, bool> func);
    }
}
