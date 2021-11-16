using MVC_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Data
{
	public static class InicializacionDeDatos
	{
		public static void Inicializar(MVC_Entity_FrameworkContext context)
		{
			//nos aseguramos de que por lo menos existan categorias por defecto
			context.Database.EnsureCreated();
			if (context.Categorias.Any())
			{
				return;
			}
			var nuebaCategoria = new Categoria();
			nuebaCategoria.Name = "Por defecto";
			nuebaCategoria.Activa = true;
			nuebaCategoria.Descripcion = "La categoria por defecto";
			context.Add(nuebaCategoria);
			context.SaveChanges();
			var nuebaCategoriaSecu = new Categoria();
			nuebaCategoriaSecu.Name = "Por defecto secundaria";
			nuebaCategoriaSecu.Activa = true;
			nuebaCategoriaSecu.Descripcion = "La categoria por defecto secundaria";
			context.Add(nuebaCategoriaSecu);
			context.SaveChanges();
		}
	}
}
