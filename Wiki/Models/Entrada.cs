using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class Entrada
    {
        public int Id { get; set; }
        public string Orden { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Texto { get; set; }
        [ForeignKey("CuerpoForeignKey")]
        public Cuerpo Cuerpo { get; set; }

    }
}
