
using CoachingManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Controllers
{
    public class HomeController : Controller
    {
        private ICoachingRepository _CoachingRepository;

        public HomeController(ICoachingRepository coachingRepository)
        {
            _CoachingRepository = coachingRepository;
        }
        public IActionResult Index()
        {
            var model = _CoachingRepository.GetAllStudents();
            return View(model);
        }

        
    }
}
