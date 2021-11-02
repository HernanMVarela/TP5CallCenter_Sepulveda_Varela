using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Servicios
{
    public class UsuarioServicio
    {
        public List<Usuario> Listar()
        {
            List<Usuario> Lista = new List<Usuario>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT U.ID, U.NombreUsuario, U.Clave, U.Nombre, U.Apellido, U.Telefono, U.Mail FROM Usuarios U inner join TipoCuenta T on T.ID = U.IDTipo");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Usuario Aux = new Usuario();
                    Aux.ID = (int) Datos.Lector["ID"];
                    Aux.NombreUsuario = (string)Datos.Lector["NombreUsuario"];
                    Aux.Clave = (string)Datos.Lector["Clave"];
                    Aux.Tipo.ID = (int)Datos.Lector["ID"];
                    Aux.Tipo.Tipo = (string)Datos.Lector["Tipo"];
                    Aux.Nombre = (string)Datos.Lector["Nombre"];
                    Aux.Apellido = (string)Datos.Lector["Apellido"];
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
