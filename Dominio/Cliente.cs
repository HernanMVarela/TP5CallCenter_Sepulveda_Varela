using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int ID { get; set; }
        public TipoCliente Tipo { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", RazonSocial,Cuit,Email,Telefono,Tipo.Nombre);
        }
        public Cliente()
        {
            ID = 0;
            RazonSocial = "No definida";
            Cuit = "0";
            Email = "Sin Email";
            Telefono = "Sin Telefono";
            
        }
    }
}
