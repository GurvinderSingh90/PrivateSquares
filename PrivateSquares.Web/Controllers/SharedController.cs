﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrivateSquares.Web.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _Header()
        {
            return View();
        }
       
    }
}