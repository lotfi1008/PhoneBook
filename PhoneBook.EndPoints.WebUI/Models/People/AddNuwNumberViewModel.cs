using PhoneBook.Domain.Core.Phones;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.WebUI.Models.People
{
    public class AddNuwNumberViewModel
    {
        public int PersonId { get; set; }
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی می باشد")]
        [MaxLength(13)]
        public string Number { get; set; }
        [Display(Name = "نوع")]
        public PhoneType PhoneType { get; set; }
    }
}
