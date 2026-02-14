using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Data;
using RandevuSistemi.Models;

namespace RandevuSistemi.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppDbContext _Db;
        public AppointmentController(AppDbContext db)
        {
            _Db = db;
        }
        public IActionResult Index()
        {
            var appointments = _Db.Appointments.Include(a => a.customer).OrderByDescending(a => a.StartTime).ToList();
            return View(appointments);
        }
        [HttpGet]
        public IActionResult CreateAppointment()
        {
            ViewBag.Customers = _Db.Customers.ToList();
            return View(new Appointment());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            ViewBag.Customers = _Db.Customers.ToList();

            if (!ModelState.IsValid)
                return View(appointment);
            var newStart = appointment.StartTime;
            var newEnd = appointment.StartTime.AddMinutes(appointment.DurationMinutes);

            var hasConflict = _Db.Appointments.Any(a =>
        newStart < a.StartTime.AddMinutes(a.DurationMinutes) &&
        newEnd > a.StartTime
    );

            if (hasConflict)
            {
                ModelState.AddModelError("", "Bu saat aralığında başka bir randevu var.");
                return View(appointment);
            }

            _Db.Appointments.Add(appointment);
            _Db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult DeleteAppointment(int id)
        {
            Appointment appointment = _Db.Appointments.Include(a => a.customer).FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();


            return View(appointment);
        }

        [HttpPost, ActionName("DeleteAppointment")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAppointmentConfirm(int id)
        {
            Appointment appointment = _Db.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();

            _Db.Appointments.Remove(appointment);
            _Db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult EditAppointment(int id)
        {
            ViewBag.Customers = _Db.Customers.ToList();
            Appointment appointment = _Db.Appointments.Include(a => a.customer).FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();
            return View(appointment);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAppointment(Appointment appointment)
        {
            ViewBag.Customers = _Db.Customers.ToList();
            if (!ModelState.IsValid)
                return View(appointment);

            var newStart = appointment.StartTime;
            var newEnd = appointment.StartTime.AddMinutes(appointment.DurationMinutes);

            var hasConflict = _Db.Appointments.Any(a => newStart < a.StartTime.AddMinutes(a.DurationMinutes) && newEnd > a.StartTime && a.Id!=appointment.Id);
            
            if (hasConflict)
            {
                ModelState.AddModelError("","Bu saat aralığında başka randevu bulunmaktadır!");
                return View(appointment);
            }
            Appointment appointment1 = _Db.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            if (appointment1 == null)
                return NotFound();

            appointment1.StartTime = newStart;
            appointment1.DurationMinutes = appointment.DurationMinutes;
            appointment1.CustomerId = appointment.CustomerId;
            appointment1.Status = appointment.Status;

            _Db.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }
    }
}
