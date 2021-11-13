﻿using System;
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
                Datos.SetearComando("SELECT T.ID, T.EspecialidadTecnico, T.Nombre, T.Apellido, T.Telefono, T.Mail FROM Tecnicos T");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Tecnico Aux = new Tecnico();
                    Aux.ID = (int)Datos.Lector["ID"];
                    Aux.EspecialidadTecnico.Nombre = (string)Datos.Lector["EspecialidadTecnico"];
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

        public void AgregarDB(Tecnico nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearComando("insert into TECNICOS (Nombre, Apellido, Mail, Telefono, IDESP) values (@Nombre, @Apellido, @Email, @Telefono, @IDEspecialidad)");
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Apellido", nuevo.Apellido);
                datos.setearParametros("@Email", nuevo.Email);
                datos.setearParametros("@Telefono", nuevo.Telefono);
                datos.setearParametros("@IDEspecialidad", nuevo.EspecialidadTecnico.ID);
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
                datos.SetearComando("update TECNICOS set Nombre=@Nombre, Apellido=@Apellido, Email=@Email, Telefono=@Telefono, IDEspecialidad=@IDEspecialidad where ID=@Id");
                datos.setearParametros("@ID", modify.ID);
                datos.setearParametros("@Nombre", modify.Nombre);
                datos.setearParametros("@Apellido", modify.Apellido);
                datos.setearParametros("@Email", modify.Email);
                datos.setearParametros("@Telefono", modify.Telefono);
                datos.setearParametros("@IDEspecialidad", modify.EspecialidadTecnico.ID);
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
