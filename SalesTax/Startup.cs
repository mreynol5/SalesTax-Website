using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesTax.Repositories;

namespace SalesTax
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddSingleton<ILineItemRepo, MockLineItemRepo>();			
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
