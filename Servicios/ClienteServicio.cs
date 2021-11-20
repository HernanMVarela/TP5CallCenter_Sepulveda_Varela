using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Servicios
{
    public class ClienteServicio
    {
        public List<Cliente> Listar()
        {
            List<Cliente> Lista = new List<Cliente>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT C.ID, T.Nombre as Tipo, C.IDTipo, C.NOMBRE, C.Cuit, C.Telefono, C.EMAIL FROM Clientes C INNER JOIN TIPOCLIENTES T ON T.ID=C.IDTIPO");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Cliente Aux = new Cliente();
                    Aux.ID = (int)Datos.Lector["ID"];
                    Aux.Tipo = new TipoCliente();
                    Aux.Tipo.ID = Convert.ToInt32(Datos.Lector["IDTipo"]);
                    Aux.Tipo.Nombre = (string)Datos.Lector["Tipo"];
                    Aux.RazonSocial = (string)Datos.Lector["Nombre"];
                    Aux.Cuit = (string)Datos.Lector["Cuit"];
                    Aux.Telefono = (string)Datos.Lector["Telefono"];
                    Aux.Email = (string)Datos.Lector["EMAIL"];

                    Lista.Add(Aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Cliente Buscar(int ID)
        {
            AccesoDB Datos = new AccesoDB();
            Cliente Aux = new Cliente();
            try
            {
                Datos.SetearComando("SELECT C.ID, T.Nombre as Tipo, C.IDTipo, C.NOMBRE, C.Cuit, C.Telefono, C.EMAIL FROM Clientes C INNER JOIN TIPOCLIENTES T ON T.ID=C.IDTIPO WHERE C.ID=@ID");
                Datos.setearParametros("@ID", ID);
                Datos.LecturaDB();
                Datos.Lector.Read();
                
                Aux.ID = (int)Datos.Lector["ID"];
                Aux.Tipo = new TipoCliente();
                Aux.Tipo.ID = Convert.ToInt32(Datos.Lector["IDTipo"]);
                Aux.Tipo.Nombre = (string)Datos.Lector["Tipo"];
                Aux.RazonSocial = (string)Datos.Lector["Nombre"];
                Aux.Cuit = (string)Datos.Lector["Cuit"];
                Aux.Telefono = (string)Datos.Lector["Telefono"];
                Aux.Email = (string)Datos.Lector["EMAIL"];
                
                return Aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AgregarDB(Cliente nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("insert into CLIENTES (NOMBRE, CUIT, EMAIL, Telefono, IDTipo) values (@Nombre, @CUIT, @Email, @Telefono, @IDTipo)");
                datos.setearParametros("@Nombre", nuevo.RazonSocial);
                datos.setearParametros("@CUIT", nuevo.Cuit);
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

        public void ModificarDB(Cliente modify)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("update CLIENTES set Nombre=@Nombre, CUIT=@Cuit, Email=@Email, Telefono=@Telefono, IDTipo=@IDTipo where ID=@Id");
                datos.setearParametros("@ID", modify.ID);
                datos.setearParametros("@Nombre", modify.RazonSocial);
                datos.setearParametros("@Cuit", modify.Cuit);
                datos.setearParametros("@Email", modify.Email);
                datos.setearParametros("@Telefono", modify.Telefono);
                datos.setearParametros("@IDTipo", modify.Tipo.ID);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BorrarDB(Tecnico borrarArt)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("delete from TECNICOS where ID = @ID");
                datos.setearParametros("@ID", borrarArt.ID);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}