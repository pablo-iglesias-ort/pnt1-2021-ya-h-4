using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Entity_Framework.Data;
using MVC_Entity_Framework.Models;
using MVC_Entity_Framework.ViewModels;

namespace MVC_Entity_Framework.Controllers
{
	public class HomeController : Controller
	{
		private readonly MVC_Entity_FrameworkContext _context;
		public HomeController(MVC_Entity_FrameworkContext context)
		{
			_context = context;
		}

		//buscador en el home si hay query string filtra segun el string asignado a la url
		[AllowAnonymous]
		public async Task<IActionResult> Index(string searchString)
		{
			List<ArticuloViewModel> viemodellist = new List<ArticuloViewModel>();
			var query = await _context.Articulos
				.Include(cat=>cat.CategoriaPrincipal)
				.Include(cat => cat.CategoriasSecundaria)
				.Include(a => a.Encabezado)
				.Include(c=>c.Cuerpo.Entradas)
				.Include(a => a.Autor)
				.ToListAsync();

			var articulos = from m in _context.Articulos
						 select m;
			if (!String.IsNullOrEmpty(searchString))
			{
				articulos = articulos.Where(s => s.Encabezado.Titulo.Contains(searchString)).Take(4);
			}

			foreach (var art in articulos)
			{
				var model = new ArticuloViewModel()
				{
					Articulo = art
				};
				viemodellist.Add(model);
			}

			var newlist= viemodellist.OrderByDescending(x => x.Articulo.Fecha).ToList().Take(4);
			return View(newlist);
			
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
