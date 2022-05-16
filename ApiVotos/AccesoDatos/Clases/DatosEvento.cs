using AccesoDatos.Interfaces;
using Microsoft.Extensions.Configuration;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class DatosEvento : IDatosEvento
    {
        private readonly string CadenaConexion;
        public DatosEvento(IConfiguration config)
        {
            CadenaConexion = config.GetConnectionString("BdVotos");
        }

        public int CrearPartido(Partido partido) 
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion)) 
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarPartido", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NombrePartido",partido.NombrePartido);

                conn.Open();
                var IdPersona = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(IdPersona);
            }
        }

        public List<Partido> ConsultarPartidos() 
        {
            List<Partido> ltsPartido = new List<Partido>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_ObtenerPartidos", conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        Partido partido = new Partido
                        {
                            IdPartido = Convert.ToInt16(reader["IdPartido_PAR"]),
                            NombrePartido =  reader["NombrePardito_PAR"].ToString()
                        };
                        ltsPartido.Add(partido);
                    }
                }
                conn.Close();
                return ltsPartido;
            }
        }
    }
}
