﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.EndPoints.WebUI.Controllers
{
    public class PhoneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}