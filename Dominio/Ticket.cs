using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ticket
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Comentario { get; set; }
        public Estado PEstado { get; set; }
        public Cliente PCliente { get; set; }
        public Usuario PResponsable { get; set; }
        public List<Incidencia> PIncidencia { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Cierre { get; set; }
    }
}
