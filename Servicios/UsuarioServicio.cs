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
                    Aux.NombreCompleto = Aux.Nombre + " " + Aux.Apellido;
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

        public void ModificarDB(Usuario modify)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("update USUARIOS set NombreUsuario=@NombreUsuario, Clave=@Clave, Nombre=@Nombre, Apellido=@Apellido, Mail=@Mail, Telefono=@Telefono, IDTipo=@IDTipo where ID=@Id");
                datos.setearParametros("@ID", modify.ID);
                datos.setearParametros("@Nombre", modify.Nombre);
                datos.setearParametros("@Apellido", modify.Apellido);
                datos.setearParametros("@Mail", modify.Email);
                datos.setearParametros("@Telefono", modify.Telefono);
                datos.setearParametros("@IDTipo", modify.Tipo.ID);
                datos.setearParametros("@NombreUsuario", modify.NombreUsuario);
                datos.setearParametros("@Clave", modify.Clave);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Login(Usuario User)
        {
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT U.ID AS USERID, U.NOMBREUSUARIO AS UUSER, U.CLAVE AS UCLAVE FROM Usuarios U WHERE U.NombreUsuario = @USER AND U.Clave = @PASS AND U.ESTADO=1");
                Datos.setearParametros("@USER", User.NombreUsuario);
                Datos.setearParametros("@PASS", User.Clave);
                Datos.LecturaDB();

                while (Datos.Lector.Read())
                {
                    User.ID = Convert.ToInt32(Datos.Lector["USERID"]);
                    return User.ID;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

    }
}
