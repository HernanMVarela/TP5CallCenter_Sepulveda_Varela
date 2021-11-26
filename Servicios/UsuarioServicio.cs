using Dominio;
using System;
using System.Collections.Generic;

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
                Datos.SetearComando("SELECT U.ID, U.NombreUsuario, U.Clave, T.ID, T.Tipo, U.Nombre, U.Apellido, U.Telefono, U.Mail, U.ESTADO FROM Usuarios U inner join TipoCuenta T on T.ID = U.IDTipo");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Usuario Aux = new Usuario();
                    Aux.ID = (int) Datos.Lector["ID"];
                    Aux.NombreUsuario = (string)Datos.Lector["NombreUsuario"];
                    Aux.Clave = (string)Datos.Lector["Clave"];
                    if (!(Datos.Lector["Tipo"] is DBNull))
                    {
                        Aux.Tipo = new TipoUsuario();
                        Aux.Tipo.ID = (int)Datos.Lector["ID"];
                        Aux.Tipo.Tipo = (string)Datos.Lector["Tipo"];
                    }
                    Aux.Nombre = (string)Datos.Lector["Nombre"];
                    Aux.Apellido = (string)Datos.Lector["Apellido"];
                    Aux.Telefono = (string)Datos.Lector["Telefono"];
                    Aux.Email = (string)Datos.Lector["Mail"];
                    Aux.Estado = (bool)Datos.Lector["ESTADO"];

                    Lista.Add(Aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public Usuario Buscar(int ID)
        {
            Usuario Aux = new Usuario();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT U.ID, U.NombreUsuario, U.Clave, T.ID, T.Tipo, U.Nombre, U.Apellido, U.Telefono, U.Mail, U.ESTADO FROM Usuarios U inner join TipoCuenta T on T.ID = U.IDTipo WHERE U.ID=@ID");
                Datos.setearParametros("@ID", ID);
                Datos.LecturaDB();
                if (Datos.Lector.Read()) {
                    Aux.ID = Convert.ToInt32(Datos.Lector["ID"]);
                    Aux.NombreUsuario = (string)Datos.Lector["NombreUsuario"];
                    Aux.Clave = (string)Datos.Lector["Clave"];
                    if (!(Datos.Lector["Tipo"] is DBNull))
                    {
                        Aux.Tipo = new TipoUsuario();
                        Aux.Tipo.ID = (int)Datos.Lector["ID"];
                        Aux.Tipo.Tipo = (string)Datos.Lector["Tipo"];
                    }
                    Aux.Nombre = (string)Datos.Lector["Nombre"];
                    Aux.Apellido = (string)Datos.Lector["Apellido"];
                    Aux.Telefono = (string)Datos.Lector["Telefono"];
                    Aux.Email = (string)Datos.Lector["Mail"];
                    Aux.Estado = (bool)Datos.Lector["ESTADO"];
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
