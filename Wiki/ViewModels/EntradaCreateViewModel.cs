using MVC_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.ViewModels
{
    public class EntradaCreateViewModel
    {
        public int ArtId { get; set; }
        public Entrada Entrada { get; set; }
    }
}
