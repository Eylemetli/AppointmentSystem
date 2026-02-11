using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Lütfen alanı boş geçmeyin!")]
		[StringLength(50,ErrorMessage ="En fazla 50 karakter girilebilir!")]
		public string Name { get; set; }

		[EmailAddress(ErrorMessage ="Lütfen doğru formatta giriniz!")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Lütfen alanı boş geçmeyin!")]
		[StringLength(11,ErrorMessage ="Lütfen eksik girmeyiniz!")]
		public string Phone { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public List<Appointment> Appointments { get; set; } = new();
		public string Notes { get; set; }
	}
}
