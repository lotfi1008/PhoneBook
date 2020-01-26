using Microsoft.AspNetCore.Http;
using PhoneBook.Domain.Core.Tags;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.WebUI.Models.People
{
    public class UpdatePersonViewModel : PersonViewMode
    {
        public int Id { get; set; }

        [Display(Name = "تصویر فعلی")]
        public string CurrentImage { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile Image { get; set; }
    }
    //public class UpdatePersonDisplayViewModel : UpdatePersonViewModel
    //{

    //    [Display(Name = "تگ")]
    //    public List<Tag> TagsForDisplay { get; set; }
    //}

    //public class UpdatePersonGetViewModel : UpdatePersonViewModel
    //{
    //    public List<int> SelectedTag { get; set; }
    //}

}
