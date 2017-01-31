using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Project1ToDo.Models;
using Project1ToDo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1ToDo.Controllers
{
    public class AppController : Controller
    {
        private IConfigurationRoot _config;
        private ILogger<AppController> _logger;
        private ListContext _context;

        public AppController(IConfigurationRoot config,
            ILogger<AppController> logger,
            ListContext context)
        {
            _config = config;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Lists.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            return View();
        }

        public IActionResult SplashPage()
        {
            return View();
        }

        public IActionResult Select()
        {
            return View();
        }
    }
}
