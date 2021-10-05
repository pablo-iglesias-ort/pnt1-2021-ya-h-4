using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public class Articulo
    {
        
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public bool Actvo { get; set; }
        [ForeignKey("CategoriaPrincipalForeignKey")]
        public Categoria CategoriaPrincipal { get; set; }
        [ForeignKey("CategoriasSecundariaForeignKey")]
        public Categoria CategoriasSecundaria { get; set; }
        
        [ForeignKey("AutorForeignKey")]
        public Autor Autor { get; set; }
        
        [ForeignKey("EncabezadoForeignKey")]
        public Encabezado Encabezado { get; set; }
        [ForeignKey("CuerpoForeignKey")]
        public Cuerpo Cuerpo { get; set; }

        public List<Referencia> Referencias { get; set; }
        
        public List<Mensaje> Mensajes { get; set; }
        public string PalabrasClave { get; set; }
        
    }
}
