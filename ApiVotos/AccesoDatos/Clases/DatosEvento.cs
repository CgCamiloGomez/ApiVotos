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

        public long CrearEvento(RequestEvento evento) 
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarEvento", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdTipoEvento", evento.evento.IdTipoEvento);
                command.Parameters.AddWithValue("@DescripcionEvento", evento.evento.DescripcionEvento);
                command.Parameters.AddWithValue("@FechaInicio", evento.evento.FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", evento.evento.FechaFin);

                conn.Open();
                var IdEvento = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt64(IdEvento);
            }
        }

        public long InsertarCandidatoEvento(long idCandidato, long idEvento)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarCandidatoEvento", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdCandidato", idCandidato);
                command.Parameters.AddWithValue("@IdEvento", idEvento);

                conn.Open();
                var IdCandidatoEven = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt64(IdCandidatoEven);
            }
        }

        public long InsertarUsuarioEvento(long idUsuario, long idEvento, bool esVotante)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarUsuarioEvento", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                command.Parameters.AddWithValue("@IdEvento", idEvento);
                command.Parameters.AddWithValue("@EsVotante", esVotante);
                

                conn.Open();
                var IdUsuarioEvento = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt64(IdUsuarioEvento);
            }
        }

        public List<Evento> ObtenerEventosUsuario(long idUsuario, bool esVotante) 
        {
            List<Evento> ltsEventos = new List<Evento>();
            Evento evento = null;
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_ObtenerEventosUsuario", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                command.Parameters.AddWithValue("@EsVotante", esVotante);

                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        evento = new Evento()
                        {
                            IdEvento = Convert.ToInt64(reader["IdEvento_EVT"]),
                            IdTipoEvento = Convert.ToInt32(reader["IdTipoEvento_EVT"]),
                            DescripcionEvento = reader["DescripcionEvento_EVT"].ToString(),
                            FechaInicio = Convert.ToDateTime( reader["FechaInicio_EVT"]),
                            FechaFin = Convert.ToDateTime(reader["FechaFin_EVT"]),
                        };
                        ltsEventos.Add(evento);
                    }                
                }
                conn.Close();
            }
            return ltsEventos;
        }
    }
}
