using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Data;
using TheGlobeServer.Extensions;
using AutoMapper;
using Implementations.Repositories;
using Contracts;

namespace TheGlobeServer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DatabaseContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:TheGlobeTest"]));
			// This line is for testing with no database.
			//services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("TheGlobeTest"));


			services.AddScoped<IRepository, Repository>();



			services.RegisterServices();
			services.AddControllers();
			services.AddAutoMapper(typeof(Startup));

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
