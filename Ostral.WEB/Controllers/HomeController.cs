using System;
using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using Ostral.Core.ViewModel;

namespace Ostral.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        
        public async Task<IActionResult> Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PopularCourses = await _homeService.GetPopularCourses(),
                // RandomCourse = await _homeService.GetRandomCourses(),
                Tutors = await _homeService.GetPopularTutors(),
                Categories = await _homeService.GetCategories(),
            };
            
            return View(homeViewModel);
        }
    }
}
