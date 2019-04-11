using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infrastructures.Common;
using PhoneBook.Infrastructures.DataLayer.Common;

namespace PhoneBook.Infrastructures.DataLayer.Tags
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
