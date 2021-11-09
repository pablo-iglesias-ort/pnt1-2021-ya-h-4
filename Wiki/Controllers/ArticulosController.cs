using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Entity_Framework.Data;
using MVC_Entity_Framework.Models;
using MVC_Entity_Framework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly MVC_Entity_FrameworkContext _context;
        public ArticulosController(MVC_Entity_FrameworkContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task <List<Articulo>> ArticulosUserId(int id)
        {
            var articulosList = new List<Articulo>();
            var query = await _context.Articulos.Include(a=>a.Autor).Where(i => i.Autor.Id == id).ToListAsync();
            Console.WriteLine(query);
            articulosList = query;
            return query;
        }

        public async Task <IActionResult> ArticulosByCategoria(int categoriaid)
        {
           // categoriaid = 1;
            var query = await _context.Articulos
                .Include(c=>c.CategoriaPrincipal)
                .Include(cat => cat.CategoriasSecundaria)
                .Include(a => a.Encabezado)
                .Include(c => c.Cuerpo.Entradas)
                .Include(a => a.Autor)
                .Where(c => c.CategoriaPrincipal.Id == categoriaid)
                .ToListAsync();
            if (query != null)
            {
                List<ArticuloViewModel> viemodellist = new List<ArticuloViewModel>();
                foreach (var art in query)
                {
                    var model = new ArticuloViewModel()
                    {
                        Articulo = art
                    };
                    viemodellist.Add(model);
                }

                var newlist = viemodellist.OrderByDescending(x => x.Articulo.Fecha).ToList().Take(4);
                return View(query);
            }
            return BadRequest();
        }
        public async Task<IActionResult> Index()
        {
            List<ArticuloViewModel> viemodellist = new List<ArticuloViewModel>();
            var query = await _context.Articulos
                .Include(cat => cat.CategoriaPrincipal)
                .Include(cat => cat.CategoriasSecundaria)
                .Include(a => a.Encabezado)
                .Include(c => c.Cuerpo.Entradas)
                .Include(a => a.Autor)
                .ToListAsync();

            var articulos = from m in _context.Articulos
                         select m;
            

            foreach (var art in articulos)
            {
                var model = new ArticuloViewModel()
                {
                    Articulo = art
                };
                viemodellist.Add(model);
            }

            var newlist = viemodellist.OrderByDescending(x => x.Articulo.Fecha).ToList().Take(4);
            return View(viemodellist);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id ==0)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }
        public IActionResult Create()
        {
            return View("CreateViewModel");
        }
        //POST: Articulos/Create *ruta para crear nuevo  articulo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int secu,
            int prin,
            string palabrasclave,
        ArtListCatViewModel articulovm)
        {
            if (ModelState.IsValid)
            {
                //buscamos las categorias
                var catprinc = await _context.Categorias.Where(i => i.Id == prin).FirstOrDefaultAsync();
                var catsecu = await _context.Categorias.Where(i => i.Id == secu).FirstOrDefaultAsync();
                //creamos el articulo
                var articulo = new Articulo();
                //asignamos categorias
                articulo.CategoriaPrincipal = catprinc;
                articulo.CategoriasSecundaria = catsecu;
                //asignamos palabras claves
                articulo.PalabrasClave = articulovm.ArticuloDTO.PalalabrasCaves;
                articulo.Fecha = DateTime.Now;
                var autor = new Autor()
                {
                    Nombre="Juan",
                    Apellido="test",
                    Telefono="1111",
                    Email="test@ort.com",
                    Password="test",
                    FechaAlta=DateTime.Now,
                };
                var encabezado = new Encabezado()
                {
                    Titulo = articulovm.ArticuloDTO.encabezadotitulo,
                    Descripcion=articulovm.ArticuloDTO.encabezadodescri,
                };
                var entrylist = new List<Entrada>();
                var cuerpo = new Cuerpo()
                {
                    Entradas=entrylist,
                };
                await _context.SaveChangesAsync();
                articulo.Autor = autor;
                articulo.Encabezado = encabezado;
                articulo.Cuerpo = cuerpo;
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                var vmentrad = new EntradaCreateViewModel()
                {
                    ArtId = articulo.Id,

                };
                return View("Entrada", vmentrad);
            }
            return View("Error");
        }
        //controlador para crear o agregar una entrada
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entrada(int ArtId,
            [Bind("Orden,Titulo,Subtitulo,Texto,ArtId")] Entrada entrada)
        {
            //se busca el cuerpo por el id del articulo
            var cuerpo = await _context.Cuerpos.Where(c=>c.Articulo.Id==ArtId).FirstOrDefaultAsync();
            //si existe
            if (cuerpo != null)
            {
                //se agrega la nueva entrada
                var entrylist = new List<Entrada>();
                entrylist.Add(entrada);
                cuerpo.Entradas = entrylist;
                await _context.SaveChangesAsync();
            }
            else
            {
                //no se encuentra el cuerpo
                return NotFound();
            }
            //retornamos al home
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Entrada(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            //buscamos sus entradas
            var vmentrad = new EntradaCreateViewModel()
            {
                ArtId = articulo.Id,

            };
            return View("Entrada", vmentrad);
        }
        //devuelve la vista a editar
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            return View(articulo);
        }

        //POST: Articulos/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!articuloExists(articulo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(articulo);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool articuloExists(int id)
        {
            return _context.Articulos.Any(e => e.Id == id);
        }
    }
}
