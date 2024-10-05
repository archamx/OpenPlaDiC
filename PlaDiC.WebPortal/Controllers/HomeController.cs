using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaDiC.Data;
using PlaDiC.WebPortal.Data;
using PlaDiC.WebPortal.Models;
using System.Diagnostics;

namespace PlaDiC.WebPortal.Controllers
{
    //[Authorize]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PlaDiCDBContext _context;


        public HomeController(ILogger<HomeController> logger, PlaDiCDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            PlaDiC.Biz.Core biz = new Biz.Core();

            var resp = biz.GetSql(_context.Database.GetDbConnection(), "select current_timestamp from rdb$database");

            if (resp.IsSuccess)
            {
                TempData["FechaHora"] = resp.Data.Rows[0][0].ToString();
            }
            else
            {
                TempData["FechaHora"] = "No disponible";
            }
            return View();
        }

        public IActionResult Options()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
