using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario:Persona
    {
        public TipoUsuario Tipo { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}",Nombre,Apellido,NombreUsuario);
            // return Nombre;
        }

    }
}
