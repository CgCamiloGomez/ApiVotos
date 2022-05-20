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

        public List<VotosEvento> ObtenerVotosXEvento(long idEvento)
        {
            VotosEvento votos = null;
            List<VotosEvento> ltsVotosEvento = new List<VotosEvento>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_ObtenerVotosXEvento", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdEvento", idEvento);

                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        votos = new VotosEvento
                        {
                            IdCandidato = Convert.ToInt64(reader["IdCandidato_VTO"]),
                            Nombre = reader["Nombre_PER"].ToString(),
                            Apellidos = reader["Apellidos_PER"].ToString(),
                            FotoCandidato = (byte[])reader["FotoCandidato_CAN"],
                            IdPartido = Convert.ToInt32(reader["IdPartido_CAN"]),
                            NombrePardito = reader["NombrePardito_PAR"].ToString(),
                            TotalVotos = Convert.ToInt32(reader["TotalVotos"])
                        };
                        ltsVotosEvento.Add(votos);
                    }
                }
                conn.Close();
            }
            return ltsVotosEvento;
        }
    }
}
