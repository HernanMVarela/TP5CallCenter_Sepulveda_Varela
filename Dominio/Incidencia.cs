using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Incidencia
    {
        public string Descripcion { get; set; }
        public int ID { get; set; }
        public string Categoria { get; set; }


        public override string ToString()
        {
            return string.Format("{0},{1},{2}", ID, Descripcion, Categoria);
        }
    }


}
