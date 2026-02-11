using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Data;
using RandevuSistemi.Models;

namespace RandevuSistemi.Controllers
{
	public class CustomerController : Controller
	{
		private readonly AppDbContext _Db;
		public CustomerController(AppDbContext db)
		{
			_Db = db;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var customers = _Db.Customers.ToList();
			return View(customers);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateCustomer(Customer customer)
		{
			if (!ModelState.IsValid)
				return View(customer);

			_Db.Customers.Add(customer);
			_Db.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult CreateCustomer()
		{
			return View();
		}

		[HttpGet]
		public IActionResult DeleteCustomer(int id)
		{
			Customer customer = _Db.Customers.FirstOrDefault(c => c.Id == id);
			if (customer == null) return NotFound();

			return View(customer);
			
		}

		[HttpPost,ActionName("DeleteCustomer")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteCustomerConfirmed(int id)
		{
			Customer customer = _Db.Customers.FirstOrDefault(c => c.Id == id);
			if (customer == null) return NotFound();

			_Db.Customers.Remove(customer);
			_Db.SaveChanges();

			return RedirectToAction(nameof(Index));

		}

		[HttpGet]
		public IActionResult EditCustomer(int id)
		{
			Customer customer = _Db.Customers.FirstOrDefault(c=> c.Id==id);

			if (customer == null) return NotFound();

			return View(customer);
		}

		[HttpPost]
		public IActionResult EditCustomer(Customer customer)
		{
			if (!ModelState.IsValid) return View(customer);

			Customer c1 = _Db.Customers.FirstOrDefault(c => c.Id == customer.Id);
			if (c1 == null) return NotFound();
			c1.Name = customer.Name;
			c1.Email = customer.Email;
			c1.Phone = customer.Phone;
			c1.Notes = customer.Notes;
			_Db.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
