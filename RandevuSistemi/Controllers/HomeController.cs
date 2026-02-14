using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using RandevuSistemi.Data;
using RandevuSistemi.ViewModels;


namespace RandevuSistemi.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _Db;

        public HomeController(AppDbContext db)
        {
            _Db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var now = DateTime.Now;

            var vm = new HomeIndexViewModel
            {
                CustomerCount = _Db.Customers.Count(),
                UpcomingAppointments = _Db.Appointments
                    .Include(a => a.customer)
                    .Where(a => a.StartTime >= now)
                    .OrderBy(a => a.StartTime)
                    .Take(5)
                    .ToList()
            };

            return View(vm);
        }

    }
}
