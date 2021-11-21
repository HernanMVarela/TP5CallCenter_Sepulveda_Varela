using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Estado
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1}", ID, Nombre);
        }
    }
}
