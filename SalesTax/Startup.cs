using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
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
			services.AddAuthentication(IISDefaults.AuthenticationScheme);
			services.AddSingleton<ICartContentsRepo, MockCartContentsRepo>();
			services.AddControllersWithViews();
			services.Configure<IISServerOptions>(options =>
			{
				options.AutomaticAuthentication = false;
			});

			services.AddDbContextPool<AppDbContext>(
				options => options.UseSqlServer(Configuration.GetConnectionString("ProductDbConnection")));
			services.AddMvc();		
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
					name: "productDetails",
					pattern: "Home/ProductDetails/{id}",
					defaults: new { controller = "Home", action = "ProductDetails" });

				endpoints.MapControllerRoute(
					name: "add",
					pattern: "Home/Create/{AddProduct}",
					defaults: new { controller = "Home", action = "AddProduct" });


				endpoints.MapControllerRoute(
					name: "cartContents",
					pattern: "Home/{CartContents}",
					defaults: new { controller = "Home", action = "GetCartContents " });

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{Id?}");

				//endpoints.MapControllers();		  //uncomment for Attribute Routing
			});

		}
	}
}
