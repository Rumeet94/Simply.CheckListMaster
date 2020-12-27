using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Simply.CheckListMaster.PL.AspNet.Helpers.Startups;

namespace Simply.CheckListMaster.PL.AspNet {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			StartupConfigureServicesHelper.AddDLLConfigure(services, Configuration);
			StartupConfigureServicesHelper.AddPLConfigure(services);
			StartupConfigureServicesHelper.AddBLLConfigure(services);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
			StartupConfigureHelper.AddConfigure(app, env);
	}
}
