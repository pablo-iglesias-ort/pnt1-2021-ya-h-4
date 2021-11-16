using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public bool Activa { get; set; }
        public string Descripcion { get; set; }

    }
}
