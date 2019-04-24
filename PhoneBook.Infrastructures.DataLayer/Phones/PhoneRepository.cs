using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Infrastructures.Common;
using PhoneBook.Infrastructures.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Infrastructures.DataLayer.Phones
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        

        public PhoneRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Phone> Where(Func<Phone, bool> func)
        {
            return dbContext.Phones.Where(func).ToList();
        }
    }
}
