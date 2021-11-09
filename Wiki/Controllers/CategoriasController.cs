using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Entity_Framework.Data;
using MVC_Entity_Framework.Models;
using MVC_Entity_Framework.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly MVC_Entity_FrameworkContext _context;
        public CategoriasController(MVC_Entity_FrameworkContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString)
        {
            var categorias = await _context.Categorias.ToListAsync();
            return View("Categorias",categorias);
        }
        public async Task<IActionResult> Create()
        {
            return View("Crear");
        }
        [HttpPost]
        public async Task<IActionResult> NeuvaCategoria()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var bodypost = JsonConvert.DeserializeObject<CategoriaViewModel>(body);
                var user = await _context.Usuarios.Include(r=>r.Roles).Where(i => i.Id == bodypost.userid).FirstOrDefaultAsync();
                if (user != null)
                {
                    var isadmin = user.Roles.Count > 0;
                    if (isadmin)
                    {
                        var newcat = new Categoria()
                        {
                            Nombre = bodypost.Nombre,
                            Descripcion=bodypost.Descripcion,
                            Activa = true,
                        };
                        await _context.AddAsync(newcat);
                        await _context.SaveChangesAsync();
                        var categorias = await _context.Categorias.ToListAsync();
                        //return View("Categorias", categorias);
                        return RedirectToAction(nameof(Index));
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            
        }
        public async Task<IActionResult> ArticulosByCategoria(int categoriaid)
        {
            var query = await _context.Articulos.Where(c => c.CategoriaPrincipal.Id == categoriaid).FirstOrDefaultAsync();
            if (query != null)
            {

                return View("Index", query);
            }
            return BadRequest();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
        //POST: Categorias/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Categoria Categoria)
        {
            if (id != Categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Categoria);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Categoria == null)
            {
                return NotFound();
            }
             _context.Remove(Categoria);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
