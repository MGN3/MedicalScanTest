using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MedicalScanWebApp.Models;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;

using System.Configuration;
using MedicalScanWebApp.DatabaseContext;

namespace MedicalScanWebApp {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {

			services.AddDbContext<MedicalScanDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("cnMoveIT")));

			services.AddCors(options => {
				options.AddDefaultPolicy(builder => {
					builder.AllowAnyOrigin()
						   .AllowAnyMethod() // Any HTTP Method, change to make it only availeable for HTTPS
						   .AllowAnyHeader();
				});
			});

			// Add other needed services
			services.AddControllers();

			// More configutarions
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MedicalScanDbContext dbContext) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseCors();
			app.UseHttpsRedirection();

			//Make sure DataBase exists before routing config
			dbContext.Database.EnsureCreated();

			app.UseRouting();

			//KEY code. The authentication applies only WHEN:
			//app.UseWhen(context =>
			//	context.Request.Path.StartsWithSegments("/api/Auth"), // MODIFICAR RUTAS A COMPROBAR, añadir un identificador a las que requieran comprobación de JWT?
			//	builder => {
			//		builder.UseAuthentication();
			//	});

			//app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
				// More endpoins
			});

		}

	}
}