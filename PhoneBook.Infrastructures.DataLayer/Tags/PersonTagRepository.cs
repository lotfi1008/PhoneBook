using System;
using System.Collections.Generic;
using System.Linq;
using PhoneBook.Domain.Contracts.Common;
using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infrastructures.Common;
using PhoneBook.Infrastructures.DataLayer.Common;

namespace PhoneBook.Infrastructures.DataLayer.Tags
{
    public class PersonTagRepository : BaseRepository<Tag>, IPersonTagRepository
    {
        public PersonTagRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }

        public PersonTag Add(PersonTag entity)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetByPersonIdWithTags(int id)
        {
            return dbContext.PersonTags.Where(c => c.PersonId == id).Select(c => c.Tag).ToList();
        }

        public List<PersonTag> Where(Func<PersonTag, bool> func)
        {
            return dbContext.PersonTags.Where(func).ToList();
        }

        PersonTag IBaseRepository<PersonTag>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IQueryable<PersonTag> IBaseRepository<PersonTag>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
