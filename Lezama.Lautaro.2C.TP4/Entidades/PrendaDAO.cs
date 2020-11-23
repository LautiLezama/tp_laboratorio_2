using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class PrendaDAO
    {
        private SqlConnection sqlConexion;
        /// <summary>
        /// Constructor donde inicio la conexión a la base de datos.
        /// </summary>
        public PrendaDAO()
        {
            string conexionString = "Server=.;Database=LezamaLautaroDB;Trusted_Connection=True;";
            this.sqlConexion = new SqlConnection(conexionString);
        }

        /// <summary>
        /// (Aqui se aplica SQL)Inserta una prenda a la base de datos.
        /// </summary>
        /// <param name="prenda">Prenda a insertar</param>
        /// <param name="tipoPrenda">Tipo de prenda</param>
        public void InsertarPrenda(Prenda prenda, Prenda.ETipoPrenda tipoPrenda)
        {
            try
            {
                string comandoString = "INSERT INTO Prendas(codigo, precio, color, tipo, tipoPrenda) VALUES(@codigo, @precio, @color, @tipo, @tipoPrenda)";
                SqlCommand sqlComando = new SqlCommand(comandoString, this.sqlConexion);
                sqlComando.Parameters.AddWithValue("codigo", prenda.Codigo);
                sqlComando.Parameters.AddWithValue("precio", prenda.Precio);
                sqlComando.Parameters.AddWithValue("color", prenda.Color.ToString());
                switch (tipoPrenda)
                {
                    case Prenda.ETipoPrenda.Pantalon:
                        sqlComando.Parameters.AddWithValue("tipo", ((Pantalon)prenda).TipoPantalon.ToString());
                        sqlComando.Parameters.AddWithValue("tipoPrenda", Prenda.ETipoPrenda.Pantalon.ToString());
                        break;
                    case Prenda.ETipoPrenda.Remera:
                        sqlComando.Parameters.AddWithValue("tipo", ((Remera)prenda).TipoManga.ToString());
                        sqlComando.Parameters.AddWithValue("tipoPrenda", Prenda.ETipoPrenda.Remera.ToString());
                        break;
                }

                this.sqlConexion.Open();

                sqlComando.ExecuteNonQuery();
            }
            finally
            {
                if (this.sqlConexion.State == System.Data.ConnectionState.Open && this.sqlConexion != null)
                {
                    sqlConexion.Close();
                }
            }
        }

        /// <summary>
        /// (Aqui se aplica SQL)Elimina una prenda de la base de datos.
        /// </summary>
        /// <param name="codigo">Primary key para identificar la prenda a eliminar</param>
        public void EliminarPrenda(int codigo)
        {

            try
            {
                string comandoString = "DELETE FROM Prendas WHERE codigo = @codigo";
                SqlCommand sqlComando = new SqlCommand(comandoString, this.sqlConexion);
                sqlComando.Parameters.AddWithValue("codigo", codigo);

                this.sqlConexion.Open();

                sqlComando.ExecuteNonQuery();
            }
            finally
            {
                if (this.sqlConexion.State == System.Data.ConnectionState.Open && this.sqlConexion != null)
                {
                    sqlConexion.Close();
                }
            }
        }

        /// <summary>
        /// (Aqui se aplica SQL)Consulta todas las prendas que hayan en la base de datos.
        /// </summary>
        /// <returns>Lista con las prendas en la base de datos</returns>
        public List<Prenda> ListarPrendas()
        {
            try
            {
                string comandoString = "SELECT * FROM Prendas";
                SqlCommand sqlComando = new SqlCommand(comandoString, this.sqlConexion);
                this.sqlConexion.Open();
                sqlComando.ExecuteNonQuery();
                SqlDataReader lector = sqlComando.ExecuteReader();
                List<Prenda> prendas = new List<Prenda>();

                while (lector.Read())
                {
                    int codigo = (int)lector["codigo"];
                    string colorString = (string)lector["color"];
                    Prenda.EColor color = (Prenda.EColor)Enum.Parse(typeof(Prenda.EColor), colorString);
                    float precio = (float)Convert.ToDouble(lector["precio"]);
                    string tipoPrendaString = (string)lector["tipoPrenda"];
                    Prenda.ETipoPrenda tipoPrenda = (Prenda.ETipoPrenda)Enum.Parse(typeof(Prenda.ETipoPrenda), tipoPrendaString);
                    
                    switch (tipoPrenda)
                    {
                        case Prenda.ETipoPrenda.Pantalon:
                            string tipoPantalonString = (string)lector["tipo"];
                            Pantalon.EPantalon tipoPantalon = (Pantalon.EPantalon)Enum.Parse(typeof(Pantalon.EPantalon), tipoPantalonString);
                            prendas.Add(new Pantalon(codigo, precio, color, tipoPantalon));
                            break;
                        case Prenda.ETipoPrenda.Remera:
                            string tipoMangaString = (string)lector["tipo"];
                            Remera.EManga tipoManga = (Remera.EManga)Enum.Parse(typeof(Remera.EManga), tipoMangaString);
                            prendas.Add(new Remera(codigo, precio, color, tipoManga));
                            break;
                    }
                }
                return prendas;
            }
            finally
            {
                if (this.sqlConexion.State == System.Data.ConnectionState.Open && this.sqlConexion != null)
                {
                    sqlConexion.Close();
                }
            }
        }
    }
}
