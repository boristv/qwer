﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using AncMvca.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AncMvca.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public MailController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            TempData["UserName"] = user.UserName;
            return View();
        }
    }
}
