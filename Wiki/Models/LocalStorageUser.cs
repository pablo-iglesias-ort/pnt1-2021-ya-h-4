using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class LocalStorageUser
    {
        public string Token { get; set; }
        public string Rol { get; set; }
        public int UserId { get; set; }
    }
}
