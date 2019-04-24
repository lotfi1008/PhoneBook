using System;
using System.Collections.Generic;
using System.Text;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Tags;

namespace PhoneBook.Domain.Contracts.Tags
{
    public interface ITagService
    {
        List<Tag> GetAllTags();
        List<Tag> GetAllTags(List<PersonTag> tags);
        List<Tag> GetTagsByPersonId(int personId);
    }
}
