using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Data;


namespace RandevuSistemi

{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();
			app.UseAuthentication();

			app.MapControllerRoute(
				name:"default",
				pattern:"{controller=Home}/{action=Index}/{id?}"
				);

			app.Run();
		}
	}
}
