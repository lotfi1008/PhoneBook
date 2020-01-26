using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Contracts.People;
using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.EndPoints.WebUI.Models.People;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.EndPoints.WebUI.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService peopleService;
        private readonly ITagService tagService;
        private readonly IPhoneService phoneService;

        public PeopleController(IPeopleService peopleService, ITagService tagService, IPhoneService phoneService)
        {

            this.peopleService = peopleService;
            this.tagService = tagService;
            this.phoneService = phoneService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var people = peopleService.GetAllPerson();
            return View(people);
        }

        public IActionResult Add()
        {
            AddNewPersonDisplayViewModel model = new AddNewPersonDisplayViewModel();
            model.TagsForDisplay = tagService.GetAllTags();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddNewPersonGetViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    Tags = new List<PersonTag>(model.SelectedTag.Select(c => new PersonTag
                    {
                        TagId = c
                    }).ToList())
                };
                if (model?.Image?.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        model.Image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        person.Image = Convert.ToBase64String(fileBytes);
                    }
                }
                Person result = peopleService.AddNewPerson(person);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.SelectedItem = model.SelectedTag;
            AddNewPersonDisplayViewModel modelforDisplay = new AddNewPersonDisplayViewModel
            {
                Address = model.Address,
                Email = model.Email,
                LastName = model.LastName,
                FirstName = model.FirstName
            };
            modelforDisplay.TagsForDisplay = tagService.GetAllTags();
            return View(modelforDisplay);
        }

        public IActionResult Update(int id)
        {
            var person = peopleService.GetPersonWithChilds(id);
            if (person != null)
            {
                UpdatePersonViewModel model = new UpdatePersonViewModel() {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Address = person.Address,
                    CurrentImage = person.Image
                };
                return View(model);
            }
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult Update(UpdatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person
                {
                    Id=model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address
                };

                if (model?.Image?.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        model.Image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        person.Image = Convert.ToBase64String(fileBytes);
                    }
                }
                Person result = peopleService.UpdatePerson(person);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var person = peopleService.GetPersonWithChilds(id);
            if (person != null)
            {
                PersonDetailViewModel model = new PersonDetailViewModel()
                {
                    PersonId = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Phones = person.Phones,
                    Address = person.Address,
                    Image = person.Image,
                };
                model.Tags = tagService.GetTagsByPersonId(id);
                return View(model);
            }

            return View();
        }

        public IActionResult AddNumber(int id)
        {
            return View(new AddNuwNumberViewModel { PersonId = id });
        }
        [HttpPost]
        public IActionResult AddNumber(AddNuwNumberViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool IsDuplicate = phoneService.IsPhoneNumberIsDuplicate(model.Number);
                if (IsDuplicate)
                {
                    ModelState.AddModelError("Number", "شماره تلفن برای مخاطب دیگری ثبت شده است");
                }
                else
                {
                    Phone phone = new Phone()
                    {
                        PhoneNumber = model.Number,
                        PhoneType = model.PhoneType
                    };
                    bool IsAddSecces = peopleService.AddNewNumberForPerson(phone, model.PersonId);
                    if (IsAddSecces)
                    {
                        return RedirectToAction("Detail", new { id = model.PersonId });
                    }
                    else
                    {
                        ModelState.AddModelError("All", "We Cant Do this Operation ...");
                    }
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var person = peopleService.GetPersonWithChilds(id);
            if (person != null)
            {
                PersonDetailViewModel model = new PersonDetailViewModel()
                {
                    PersonId = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Address = person.Address,
                    Image = person.Image
                };
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int PersonId)
        {
            if (ModelState.IsValid)
            {
                
                var result = peopleService.Delete(PersonId);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Detail", new { id = PersonId });
        }
    }
}
