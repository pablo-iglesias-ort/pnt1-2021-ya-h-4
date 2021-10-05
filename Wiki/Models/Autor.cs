using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }
        public  string Password { get; set; }
        public List<Articulo> Articulos { get; set; }
    }
}
