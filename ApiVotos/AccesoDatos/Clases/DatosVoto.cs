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
    public class DatosVoto : IDatosVoto
    {
        private readonly string CadenaConexion;
        public DatosVoto(IConfiguration config)
        {
            CadenaConexion = config.GetConnectionString("BdVotos");
        }

        public long RegistrarVoto(Voto voto)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarVoto", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdCandidato", voto.IdCandidato);
                command.Parameters.AddWithValue("@IdEvento", voto.IdEvento);
                
                conn.Open();
                var IdVoto  = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(IdVoto);
            }
        }

        public void ActualizarUsuarioEvento(long idUsuario, long idEvento)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_ActualizarUsuarioEvento", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                command.Parameters.AddWithValue("@IdEvento", idEvento);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
