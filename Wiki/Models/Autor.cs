using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class Autor:Usuario
    {
        

        public DateTime FechaAlta { get; set; }
        public List<Articulo> Articulos { get; set; }

        public override Rol Rol => Rol.Autor;
    }
}
