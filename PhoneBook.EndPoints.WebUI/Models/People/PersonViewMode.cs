using PhoneBook.Domain.Core.Tags;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.WebUI.Models.People
{
    public abstract class PersonViewMode
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage ="وارد کردن {0} الزامی است")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "آدرس")]
        [StringLength(500)]
        public string Address { get; set; }
    }
}
