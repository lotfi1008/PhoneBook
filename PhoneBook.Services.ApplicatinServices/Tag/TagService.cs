using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Services.ApplicatinServices.Tag
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;
        private readonly IPersonTagRepository personTagRepository;

        public TagService(ITagRepository tagRepository,IPersonTagRepository personTagRepository)
        {
            this.tagRepository = tagRepository;
            this.personTagRepository = personTagRepository;
        }
        public List<Domain.Core.Tags.Tag> GetAllTags()
        {
            return tagRepository.GetAll().ToList();
        }

        public List<Domain.Core.Tags.Tag> GetAllTags(List<PersonTag> personTags)
        {
            List<Domain.Core.Tags.Tag> resultTags = new List<Domain.Core.Tags.Tag>();
            for (int i = 0; i < personTags.Count; i++)
            {
                resultTags.Add(tagRepository.Get(personTags[i].TagId));
            }
            return resultTags;
        }

        public List<Domain.Core.Tags.Tag> GetTagsByPersonId(int personId)
        {
            return GetAllTags(personTagRepository.Where(c=>c.PersonId==personId));
        }
    }
}
