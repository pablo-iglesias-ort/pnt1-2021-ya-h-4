﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class Referencia
    {
        public int Id { get; set; }
        public string ArticuloPrincipal { get; set; }
        public string ArticuloReferencial { get; set; }
    }
}
