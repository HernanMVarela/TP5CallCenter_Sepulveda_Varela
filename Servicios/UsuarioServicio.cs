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
                Datos.SetearComando("SELECT U.ID, U.NombreUsuario, U.Clave, T.ID, T.Tipo, U.Nombre, U.Apellido, U.Telefono, U.Mail FROM Usuarios U inner join TipoCuenta T on T.ID = U.IDTipo");
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
                    Aux.NombreCompleto = Aux.Nombre + " " + Aux.Apellido;
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

        public Usuario Buscar(int ID)
        {
            Usuario Aux = new Usuario();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT U.ID, U.NombreUsuario, U.Clave, T.ID, T.Tipo, U.Nombre, U.Apellido, U.Telefono, U.Mail FROM Usuarios U inner join TipoCuenta T on T.ID = U.IDTipo WHERE U.ID=@ID");
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
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AgregarDB(Usuario nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("insert into USUARIOS (NombreUsuario, Clave, Nombre, Apellido, Mail, Telefono, IDTipo) values (@NombreUsuario, @Clave, @Nombre, @Apellido, @Email, @Telefono, @IDTipo)");
                datos.setearParametros("@NombreUsuario", nuevo.NombreUsuario);
                datos.setearParametros("@Clave", nuevo.Clave);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Apellido", nuevo.Apellido);
                datos.setearParametros("@Email", nuevo.Email);
                datos.setearParametros("@Telefono", nuevo.Telefono);
                datos.setearParametros("@IDTipo", nuevo.Tipo.ID);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
