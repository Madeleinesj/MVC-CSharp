using Challenge547.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;


namespace Challenge547.Controllers

{
    public class ViewModel
    {
        public DateTime dateTime { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewModel vm = new ViewModel() { dateTime = DateTime.Now };
            return View(vm);
        }

        
      
        
        
        
    }
}
