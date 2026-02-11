using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models
{
	public class Appointment
	{
		public int Id { get; set; }
		[Required]
		public int CustomerId { get; set; }
		public List<Customer> Custemers { get; set; }
		[Required]
		public DateTime StartTime { get; set; }
		[Range(5,240,ErrorMessage ="5-240 arası değer giriniz!")]
		public int DurationMinutes { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

		public DateTime EndTime => StartTime.AddMinutes(DurationMinutes);

	}
}
