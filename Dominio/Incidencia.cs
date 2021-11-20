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
        public int IDTicket { get; set; }
        public Categoria PCategoria { get; set; }
        public Tecnico PTecnico { get; set; }
        public DateTime Modificacion { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", ID, IDTicket, Descripcion, PTecnico.ID, PCategoria.Nombre, Modificacion);
        }
    }


}
