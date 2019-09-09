using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;

namespace Controlador
{
    public class ArticuloMetodos
    {
        public List<Articulo> MostrarArticulos()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulo> listado = new List<Articulo>();
            Articulo art;
            try
            {
                conexion.ConnectionString = "data source=(local); initial catalog = COMERCIO; Integrated Security=True;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT ID, COD_ARTICU, DESCRIPCION, FECHA_ALTA FROM ARTICULOS";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    art = new Articulo();
                    art.Id = lector.GetInt16(0);
                    art.Codigo = lector.GetString(1);
                    art.Nombre = lector.GetString(2);
                    art.FechaAlta = lector.GetDateTime(3);

                    listado.Add(art);
                }
                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
