using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Entity_Framework.Data;
using MVC_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Controllers
{
    public class UsersController : Controller
    {
        private readonly MVC_Entity_FrameworkContext _context;
        public Seguridad seguridad = new Seguridad();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User usuario, string Contraseña)
        {
            if (ModelState.IsValid)
            {
                usuario.Id = Guid.NewGuid();
                usuario.Contraseña = seguridad.EncriptarPass(Contraseña);
                //usuario.FechaAlta = DateTime.Now;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        
        [HttpGet]
        public async Task <List<Usuario>> UsersList()
        {
            
            var users = await _context.Usuarios.ToListAsync();

            return users;
        }
        [HttpPost]
        public async Task<IActionResult> Ingresar(string usuario, string pass)
        {
            // Guardamos la URL a la que debemos redirigir al usuario
            var urlIngreso = TempData["UrlIngreso"] as string;

            // Verificamos que ambos esten informados
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(pass))
            {

                // Verificamos que exista el usuario
                var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario);

                if (user != null)
                {

                    // Verificamos que coincida la contraseña
                    var contraseña = seguridad.EncriptarPass(pass);
                    if (contraseña.SequenceEqual(user.Contraseña))
                    {

                        // Creamos los Claims (credencial de acceso con informacion del usuario)
                        ClaimsIdentity identidad = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                        // Agregamos a la credencial el nombre de usuario
                        identidad.AddClaim(new Claim(ClaimTypes.Name, usuario));
                        // Agregamos a la credencial el nombre del estudiante/administrador
                        identidad.AddClaim(new Claim(ClaimTypes.GivenName, user.Nombre));
                        //// Agregamos a la credencial el Rol
                        identidad.AddClaim(new Claim(ClaimTypes.Role, user.Rol.ToString()));
                        // Agregar ID Usuario
                        identidad.AddClaim(new Claim("IdUsuario", user.Id.ToString()));
                        
                        
                        ClaimsPrincipal principal = new ClaimsPrincipal(identidad);

                        // Ejecutamos el Login
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        if (!string.IsNullOrEmpty(urlIngreso))
                        {
                            return Redirect(urlIngreso);
                        }
                        else
                        {
                            // Redirigimos a la pagina principal
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }

            ViewBag.ErrorEnLogin = "Verifique el usuario y contraseña";
            TempData["UrlIngreso"] = urlIngreso; // Volvemos a enviarla en el TempData para no perderla
            return View();

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
        /*
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

        */
    }
}
