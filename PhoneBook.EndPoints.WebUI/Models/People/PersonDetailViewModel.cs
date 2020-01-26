using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.WebUI.Models.People
{
    public class PersonDetailViewModel:PersonViewMode
    {
        public int PersonId{ get; set; }
        public string Image { get; set; }
        [Display(Name = "شماره تلفن ها")]
        public List<Phone> Phones { get; set; }

        [Display(Name = "تگ ها")]
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
