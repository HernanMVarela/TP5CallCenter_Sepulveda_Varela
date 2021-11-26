using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios
{
    public class TecnicoServicio
    {
        public List<Tecnico> Listar()
        {
            List<Tecnico> Lista = new List<Tecnico>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT T.ID, E.ID AS EID, E.NOMBRE AS ESPECIALIDAD, T.Nombre, T.Apellido, T.Telefono, T.Mail, T.ESTADO FROM Tecnicos T INNER JOIN ESPECIALIDADES E ON E.ID=T.IDESP");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Tecnico Aux = new Tecnico();
                    Aux.EspecialidadTecnico = new Especialidad();
                    
                    Aux.ID = (int)Datos.Lector["ID"];
                    Aux.EspecialidadTecnico.ID = (int)Datos.Lector["EID"];
                    Aux.EspecialidadTecnico.Nombre = (string)Datos.Lector["ESPECIALIDAD"];
                    Aux.Nombre = (string)Datos.Lector["Nombre"];
                    Aux.Apellido = (string)Datos.Lector["Apellido"];
                    Aux.NombreCompleto = (string)Datos.Lector["Nombre"] + " " + (string)Datos.Lector["Apellido"];
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

        public void AgregarDB(Tecnico nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("insert into TECNICOS (Nombre, Apellido, Mail, Telefono, IDESP, ESTADO) values (@Nombre, @Apellido, @Email, @Telefono, @IDEspecialidad, @Estado)");
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Apellido", nuevo.Apellido);
                datos.setearParametros("@Email", nuevo.Email);
                datos.setearParametros("@Telefono", nuevo.Telefono);
                datos.setearParametros("@IDEspecialidad", nuevo.EspecialidadTecnico.ID);
                datos.setearParametros("@Estado", nuevo.Estado);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarDB(Tecnico modify)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("update TECNICOS set Nombre=@Nombre, Apellido=@Apellido, Mail=@Mail, Telefono=@Telefono, IDESP=@IDEspecialidad, ESTADO=@Estado where ID=@Id");
                datos.setearParametros("@ID", modify.ID);
                datos.setearParametros("@Nombre", modify.Nombre);
                datos.setearParametros("@Apellido", modify.Apellido);
                datos.setearParametros("@Mail", modify.Email);
                datos.setearParametros("@Telefono", modify.Telefono);
                datos.setearParametros("@IDEspecialidad", modify.EspecialidadTecnico.ID);
                datos.setearParametros("@Estado", modify.Estado);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EstadoDB(Tecnico BorrarTec)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("update TECNICOS set ESTADO=@Estado where ID = @ID");
                datos.setearParametros("@ID", BorrarTec.ID);
                datos.setearParametros("@Estado", BorrarTec.Estado);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
