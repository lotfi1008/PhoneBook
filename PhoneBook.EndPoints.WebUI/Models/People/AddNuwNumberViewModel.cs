using PhoneBook.Domain.Core.Phones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.WebUI.Models.People
{
    public class AddNuwNumberViewModel
    {
        public int PersonId { get; set; }
        [Required]
        [MaxLength(13)]
        public string Number { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}
