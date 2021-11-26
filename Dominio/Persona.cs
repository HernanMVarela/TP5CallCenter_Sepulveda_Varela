using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string NombreCompleto { get; set; }
        public bool Estado { get; set; }

        public Persona()
        {
            Nombre = "";
            Apellido = "";
            NombreCompleto = "";
            Email = "";
            Telefono = "";
        }
    }
}
