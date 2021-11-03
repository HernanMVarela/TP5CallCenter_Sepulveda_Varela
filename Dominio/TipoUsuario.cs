using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoUsuario
    {
        public int ID { get; set; }
        public string Tipo { get; set; }

        public TipoUsuario()
        {
            Tipo = "Sin tipo";
            ID = 0;
        }
    }
}
