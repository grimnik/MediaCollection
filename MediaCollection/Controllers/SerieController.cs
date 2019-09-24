using MediaCollection.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCollection.Controllers
{
    public class SerieController : Controller
    {
        private readonly ApplicationDbContext _appContext;
        public SerieController(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
        }
        public IActionResult Serie()
        {
            return View();
        }
        public IActionResult SerieCreate()
        {
            return View();
        }
        
    }
}
