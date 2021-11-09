using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Servicios
{
    class ClienteServicio
    {
        public List<Cliente> Listar()
        {
            List<Cliente> Lista = new List<Cliente>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT C.ID, C.Tipo, C.RazonSocial, C.Cuit, C.Telefono, C.Mail FROM Clientes C");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Cliente Aux = new Cliente();
                    Aux.ID = (int)Datos.Lector["ID"];
                    Aux.Tipo = (string)Datos.Lector["Tipo"];
                    Aux.RazonSocial = (string)Datos.Lector["RazonSocial"];
                    Aux.Cuit = (string)Datos.Lector["Cuit"];
                    Aux.Telefono = (string)Datos.Lector["Telefono"];
                    Aux.Email = (string)Datos.Lector["Mail"];

                    Lista.Add(Aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}