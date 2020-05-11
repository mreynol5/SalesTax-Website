using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesTax.Models;
using SalesTax.Repositories;


namespace SalesTax
{

	public class Startup
	{
		private IConfiguration Configuration;

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}		

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContextPool<AppDBContext>(
				options => options.UseSqlServer(Configuration.GetConnectionString("ProductDbConnection"))) ;
			services.AddMvc();
			services.AddScoped<ILineItemRepo, SQLLineItemRepo>();
			services.AddControllersWithViews();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "item",
					pattern: "Home/GetItem/{id?}",
					defaults: new { controller = "Home", action = "GetItem" });

				endpoints.MapControllerRoute(
					name: "add",
					pattern: "Home/Create/{GetLineItemsList}",
					defaults: new { controller = "Home", action = "AddProduct" });


				endpoints.MapControllerRoute(
					name: "itemlist",
					pattern: "Home/{GetLineItemsList}",
					defaults: new { controller = "Home", action = "GetLineItemsList " });

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{Id?}");

				//endpoints.MapControllers();		  //uncomment for Attribute Routing
			});

		}
	}
}
