using Microsoft.AspNetCore.Http;
using PhoneBook.Domain.Core.Tags;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.WebUI.Models.People
{


    public abstract class AddNewPersonViewModel : PersonViewMode
    {
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        [Display(Name = "تصویر")]
        public IFormFile Image { get; set; }
    }
    public class AddNewPersonDisplayViewModel : AddNewPersonViewModel
    {

        [Display(Name = "تگ")]
        public List<Tag> TagsForDisplay { get; set; }
    }

    public class AddNewPersonGetViewModel : AddNewPersonViewModel
    {
        public List<int> SelectedTag { get; set; }
    }
}
