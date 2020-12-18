using AutoMapper;
using eVenda.Estoque.Map;
using eVenda.Estoque.ServiceBusProcess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eVenda.Estoque
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
			var mapConfiguration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<EstoqueMapProfile>();
			}).CreateMapper();

			services.AddSingleton(mapConfiguration);

			services.AddHostedService<ProdutoVendidoServiceReader>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
