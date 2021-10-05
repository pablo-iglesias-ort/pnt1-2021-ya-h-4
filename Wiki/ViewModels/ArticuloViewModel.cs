using MVC_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Entity_Framework.ViewModels
{
    public class ArticuloViewModel
    {
        
        public Articulo Articulo { get; set; }
        public Autor Autor { get; set; }
        public Encabezado Encabezado { get; set; }
        public Cuerpo Cuerpo { get; set; }
    }
}
