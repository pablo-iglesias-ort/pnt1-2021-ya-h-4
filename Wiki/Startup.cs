using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MVC_Entity_Framework.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using MVC_Entity_Framework.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;

namespace MVC_Entity_Framework
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
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
				opciones =>
				{
					opciones.LoginPath = "/Users/Ingresar";
					opciones.AccessDeniedPath = "/Users/AccesoDenegado";
					opciones.LogoutPath = "/Users/Salir";
				}
			);
			services.AddControllersWithViews().AddNewtonsoftJson();
			services.AddMvc()
				 .AddNewtonsoftJson(
					  options => {
						  options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
					  });
			services.AddDbContext<MVC_Entity_FrameworkContext>(opciones => opciones.UseSqlite("filename=BaseDeDatos.db"));
			//services.AddDbContext<MVC_Entity_FrameworkContext>(opciones => opciones.UseSqlite(Configuration.GetConnectionString("MVC_Entity_FrameworkContext")));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
