using MVC_Entity_Framework.Models;
using MVC_Entity_Framework.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.ViewModels
{
    public class ArtListCatViewModel
    {
        public ArticuloDTO  ArticuloDTO { get; set; }
        public int secu { get; set; }
        public int prin { get; set; }
    }
}
