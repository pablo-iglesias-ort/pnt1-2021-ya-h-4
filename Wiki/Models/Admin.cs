using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class Admin:Usuario
    {
        public override Rol Rol => Rol.Admin;

        
    }
}
