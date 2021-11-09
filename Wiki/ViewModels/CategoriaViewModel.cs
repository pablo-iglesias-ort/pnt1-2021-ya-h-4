using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.ViewModels
{
    public class CategoriaViewModel
    {
        public int userid { get; set; }

        public string Nombre { get; set; }
        public bool Activa { get; set; }
        public string Descripcion { get; set; }
    }
}
