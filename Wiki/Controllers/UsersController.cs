using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Entity_Framework.Data;
using MVC_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Controllers
{
    public class UsersController : Controller
    {
        private readonly MVC_Entity_FrameworkContext _context;
        public UsersController(MVC_Entity_FrameworkContext context)
        {
            _context = context;
        }
        public IActionResult CrearArt()
        {
            return RedirectToAction("Create", "Articulos");
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginResult()
        {
            return View();
        }
        [HttpGet]
        public async Task <List<Usuario>> UsersList()
        {
            var users = await _context.Usuarios.Include(r=>r.Roles).ToListAsync();

            return users;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,PassWord")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var checifexist = await _context.Usuarios.Include(r=>r.Roles).FirstOrDefaultAsync(e => e.Email == usuario.Email);
                //se cheque que el usuario exista o se devuelve error
                if (checifexist == null)
                {
                    return View("Error");
                }
                //se chequea que la contrasenia sea correcta
                if (checifexist.PassWord != usuario.PassWord)
                {
                    return View("Error");
                }
                else
                {
                    //todo ok se devuelve la vista resultado ok
                    return View("LoginResult",checifexist);
                }
            }
            //error de modelo invalido sin mail o password
            return View("Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("Nombre,Apellido,Email,PassWord")] Usuario newuser)
        {
            if (ModelState.IsValid)
            {
                var checifexist = await _context.Usuarios.Include(r => r.Roles).FirstOrDefaultAsync(e=>e.Email==newuser.Email);
                //se chequea que no exista otro usuario con ese correo
                if (checifexist != null)
                {
                    return View("Error");
                }
                try
                {
                    //se agrega si no existe
                    _context.Add(newuser);
                    var success = await _context.SaveChangesAsync() > 0;

                    if (!success)
                    {
                        return View("Error");
                    }
                    else
                    {
                        //se crea rol de autor
                        var rol = new Rol()
                        {
                            NombreRol = "Autor"
                        };
                        _context.Add(rol);
                        await _context.SaveChangesAsync();
                        var roleslist = new List<Rol>();
                        roleslist.Add(rol);
                        newuser.Roles=roleslist;
                        _context.Update(newuser);
                        await _context.SaveChangesAsync();
                        var localuser = new LocalStorageUser()
                        {
                            Token = "kjshjkdhksjhdkshdh",
                            Rol = newuser.Roles.Last().NombreRol,
                            UserId=newuser.Id,
                        };
                        return View("Result", localuser);
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                
                
                
            }
            return View(newuser);
        }

        public async Task <List<Usuario>> TopTresAutores()
        {
            //buscar los articulos
            //ordenarlos por id de autor
            //tomar los primero 3 articulos para usar el usuario id
            //buscar los 3 autores por id
            var users = await _context.Usuarios
                .Include(r => r.Roles)
                .ToListAsync();
            return users;
        }

    }
}
