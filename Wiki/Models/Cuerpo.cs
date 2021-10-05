using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class Cuerpo
    {
        public int Id { get; set; }
        public List<Entrada> Entradas { get; set; }
        
        public Articulo Articulo { get; set; }
    }
}
