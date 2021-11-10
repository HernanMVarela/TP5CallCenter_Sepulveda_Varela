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
        public int IDEstado { get; set; }
        public int IDTecnico { get; set; }
        public int IDCliente { get; set; }
        public int IDIncidencia { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Cierre { get; set; }


    }
}
