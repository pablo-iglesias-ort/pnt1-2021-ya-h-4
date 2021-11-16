using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
    public abstract class Usuario 
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(20, ErrorMessage = "La longitud máxima es {1}")]
        [MinLength(8, ErrorMessage = "La longitud mínima es {1}")]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [ScaffoldColumn(false)]
        public byte[] Contraseña { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [MaxLength(40, ErrorMessage = "El maximo permitido para el {0} es {1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [MaxLength(80, ErrorMessage = "El maximo permitido para el {0} es {1}")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [MaxLength(80, ErrorMessage = "El maximo permitido para el {0} es {1}")]
        public string Email { get; set; }


        public abstract Rol Rol { get;  }
    }
}
