using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tecnico:Persona
    {
        public string EspecialidadTecnico { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", Nombre, Apellido, Email, Telefono, EspecialidadTecnico);
        }

    }
}
