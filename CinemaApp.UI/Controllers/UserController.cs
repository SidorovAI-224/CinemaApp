﻿using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
