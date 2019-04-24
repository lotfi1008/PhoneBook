using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Core.Phones;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Services.ApplicatinServices.Phone
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            this.phoneRepository = phoneRepository;
        }

        public bool IsPhoneNumberIsDuplicate(string number)
        {
            return phoneRepository.Where(c => c.PhoneNumber == number).ToList().Any();
        }
    }
}
