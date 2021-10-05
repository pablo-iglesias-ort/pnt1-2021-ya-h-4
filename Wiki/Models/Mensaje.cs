using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class Mensaje
    {
        public int Id { get; set; }
        public DateTime FechaYHora { get; set; }
        
        public Articulo Articulo { get; set; }
        public string Usuario { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
    }
}
