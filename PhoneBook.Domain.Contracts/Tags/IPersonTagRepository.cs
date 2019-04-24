using PhoneBook.Domain.Contracts.Common;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domain.Contracts.Tags
{
    public interface IPersonTagRepository : IBaseRepository<PersonTag>
    {
        List<Tag> GetByPersonIdWithTags(int id);
        List<PersonTag> Where(Func<PersonTag, bool> func);
        
    }
}
