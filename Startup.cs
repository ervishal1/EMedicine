using EMedicine.Data;
using EMedicine.Repositories;
using EMedicine.Repositories.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMedicine
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
			services.AddDbContext<DAL>(Options => Options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));
			services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
			services.AddTransient<IUsersRepo, UsersRepo>();
			services.AddTransient<ICartRepo, CartRepo>();
			services.AddTransient<IOrdersRepo, OrdersRepo>();
			services.AddTransient<IUnitOfWork,UnitOfWork>();
			services.AddControllers();

			services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });
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
			app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
