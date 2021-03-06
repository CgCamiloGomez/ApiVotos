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
    public class DatosPersona : IDatosPersona
    {
        private readonly string CadenaConexion;
        public DatosPersona(IConfiguration config)
        {
            CadenaConexion = config.GetConnectionString("BdVotos");
        }

        public long CrearPersona(Persona persona)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarPersona", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@Corrreo", persona.Correo);
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@IdTipoPersona", persona.IdTipoPersona);
                command.Parameters.AddWithValue("@FechaNacimiento",persona.FechaNacimiento);

                conn.Open();
                var IdPersona = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(IdPersona);
            }
        }
        public long CrearUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarUsuario", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPersona", usuario.IdPersona);
                command.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                command.Parameters.AddWithValue("@Password", usuario.PassWord);

                conn.Open();
                var IdUsuario = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(IdUsuario);
            }
        }

        public long CrearCandidato(Candidato candidato)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_InsertarCandidato", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPartido", candidato.IdPartido);
                command.Parameters.AddWithValue("@IdPersona", candidato.IdPersona);
                command.Parameters.AddWithValue("@FotoCandidato", candidato.FotoCandidato);

                conn.Open();
                var IdCandidato = command.ExecuteScalar();
                conn.Close();
                return Convert.ToInt32(IdCandidato);
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> ltsUsuario = new List<Usuario>();
            Usuario usuario = null;
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("pa_ObtenerUsuarios", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        usuario = new Usuario
                        {
                            IdUsuario = Convert.ToInt64(reader["IdUsuario_USU"]),
                            IdRol = Convert.ToInt32(reader["IdRol_USU"]),
                            Nombre = reader["Nombre_PER"].ToString(),
                            Apellidos = reader["Apellidos_PER"].ToString(),
                            Identificacion = reader["Identificacion"].ToString(),
                            FechaNacimiento = Convert.ToDateTime (reader["FechaNacimiento"]),
                            Correo = reader["Correo_PER"].ToString(),
                        };
                        ltsUsuario.Add(usuario);
                    }
                }
                conn.Close();
                return ltsUsuario;
            }
        }
    }
}
