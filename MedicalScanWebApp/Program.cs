using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MedicalScanWebApp;

namespace NombreDeTuProyecto {
	public class Program {
		public static void Main(string[] args) {
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => {
					webBuilder.UseStartup<Startup>(); // Customized startup class for App configuration
					webBuilder.UseUrls("https://localhost:7202"); //To avoid http as default.
				});
	}
}
