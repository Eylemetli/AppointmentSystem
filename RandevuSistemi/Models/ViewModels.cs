using System.Collections.Generic;
using RandevuSistemi.Models;

namespace RandevuSistemi.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Appointment> UpcomingAppointments { get; set; } = new();
        public int CustomerCount { get; set; }
    }
}
