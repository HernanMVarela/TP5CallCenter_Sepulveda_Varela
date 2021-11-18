using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicios
{
    public class CategoriaServicio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> Lista = new List<Categoria>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearComando("SELECT ID, NOMBRE FROM CATEGORIASINCIDENCIAS");
                Datos.LecturaDB();
                while (Datos.Lector.Read())
                {
                    Categoria Aux = new Categoria();
                    Aux.ID = (int)Datos.Lector["ID"];
                    Aux.Nombre = (string)Datos.Lector["NOMBRE"];
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
